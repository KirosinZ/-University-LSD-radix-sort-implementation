using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRIALG_INTERNAL_SORT
{

    public class SwapEventArgs : EventArgs
    {
        public int First { get; private set; }
        public int Last { get; private set; }

        public SwapEventArgs(int first, int last)
        {
            First = first;
            Last = last;
        }
    }

    public class SplitEventArgs : EventArgs
    {
        public int Rank { get; private set; }
        public int Start { get; private set; }
        public int CurrentLeft { get; private set; }
        public int CurrentRight { get; private set; }
        public int Split { get; private set; }
        public int End { get; private set; }

        public SplitEventArgs(int start, int end, int rank)
        {
            Rank = rank;
            CurrentLeft = Start = start;
            Split = -1;
            CurrentRight = End = end;
        }

        public SplitEventArgs(int start, int split, int end, int rank)
        {
            Rank = rank;
            CurrentLeft = Start = start;
            Split = split;
            CurrentRight = End = end;
        }

        public SplitEventArgs(int start, int end, int left, int right, int rank)
        {
            Rank = rank;
            Start = start;
            End = end;
            Split = -1;
            CurrentLeft = left;
            CurrentRight = right;
        }
    }

    public class RadixSort
    {
        public delegate void SwapHandler(object sender, SwapEventArgs args);
        public delegate void SplitHandler(object sender, SplitEventArgs args);

        public event SwapHandler BeginSwap;
        public event SwapHandler DuringSwap;
        public event SwapHandler EndSwap;

        public event SplitHandler LeftValidated;
        public event SplitHandler LeftNotValidated;

        public event SplitHandler RightValidated;
        public event SplitHandler RightNotValidated;

        public event SplitHandler BeginSplit;
        public event SplitHandler EndSplit;

        void Swap(ref int[] input, int l, int r)
        {
            BeginSwap?.Invoke(this, new SwapEventArgs(l, r));
            int tmp = input[l];
            DuringSwap?.Invoke(this, new SwapEventArgs(l, r));
            input[l] = input[r];
            input[r] = tmp;
            EndSwap?.Invoke(this, new SwapEventArgs(l, r));
        }



        int Split(ref int[] input, int start, int end, int rank)
        {
            BeginSplit?.Invoke(this, new SplitEventArgs(start, end, rank));
            int left = start; int right = end;
            while (left < right)
            {
                for (;; left++)
                {
                    if (left < right && input[left].BitAt(rank) == 0)
                    {
                        LeftValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                        continue;
                    }
                    if (left < right)
                    {
                        LeftNotValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                    }
                    break;
                }
                for (;; right--)
                {
                    if (left < right && input[right - 1].BitAt(rank) == 1)
                    {
                        RightValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                        continue;
                    }
                    if (left < right)
                    {
                        RightNotValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                    }
                    break;
                }
                if (left < right) Swap(ref input, left, right - 1);
            }
            EndSplit?.Invoke(this, new SplitEventArgs(start, end, rank));
            return left;
        }

        int ReverseSplit(ref int[] input, int start, int end, int rank)
        {
            BeginSplit?.Invoke(this, new SplitEventArgs(start, end, rank));
            int left = start; int right = end;
            while (left < right)
            {
                for (;; left++)
                {
                    if (left < right && input[left].BitAt(rank) == 1)
                    {
                        LeftValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                        continue;
                    }
                    if (left < right)
                    {
                        LeftNotValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                    }
                    break;
                }
                for (;; right--)
                {
                    if (left < right && input[right - 1].BitAt(rank) == 0)
                    {
                        RightValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                        continue;
                    }
                    if (left < right)
                    {
                        RightNotValidated?.Invoke(this, new SplitEventArgs(start, end, left, right, rank));
                    }
                    break;
                }
                if (left < right) Swap(ref input, left, right - 1);
            }
            EndSplit?.Invoke(this, new SplitEventArgs(start, end, rank));
            return left;
        }

        void InternalSort(ref int[] input, int start, int end, int rank)
        {
            if (rank < 0 || start >= end - 1) return;

            int split = Split(ref input, start, end, rank);

            InternalSort(ref input, start, split, rank - 1);
            InternalSort(ref input, split, end, rank - 1);
        }

        public void Sort(ref int[] input)
        {
            int buf = 0; int r;
            for (int i = 0; i < input.Length; buf |= input[i++]) ;

            if (buf.BitAt(31) == 1)
            {
                int split = ReverseSplit(ref input, 0, input.Length, 31);
                r = 30;
                for (; (buf & (1u << r)) == 0; r -= 1) ;
                InternalSort(ref input, 0, split, r);
                InternalSort(ref input, split, input.Length, r);
                return;
            }

            r = 30;
            for (; (buf & (1u << r)) == 0; r -= 1) ;
            InternalSort(ref input, 0, input.Length, r);
        }
    }

    public static class BitWiseIntExtension
    {
        public static int BitAt(this int @this, int pos)
        {
            if (pos < 0 || pos > 31) throw new Exception("Недопустимый адрес");
            if ((@this & (1 << pos)) == 0) return 0;
            return 1;
        }

        public static string ToBitWise(this int @this)
        {
            string res = "";
            for (int i = 0; i < 32; i++)
            {
                res = @this.BitAt(i).ToString() + res;
            }
            return "0x" + res;
        }
    }
}
