using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STRIALG_INTERNAL_SORT
{

    static class Program
    {

        public static void Swap(ref int first, ref int second)
        {
            int tmp = first;
            first = second;
            second = tmp;
        }

        public static int AtBit(this int @this, int r)
        {
            if ((@this & (1 << r)) == 0) return 0;
            else return 1;
        }

        public static void InternalSort(ref int[] input, int start, int end, int rank)
        {
            if (rank < 0 || start >= end) return;
            int left = start; int right = end;

            while (left < right)
            {
                for (; left < right && input[left].AtBit(rank) == 0; left++) ;
                for (; left < right && input[right - 1].AtBit(rank) == 1; right--) ;
                if (left < right) Swap(ref input[left], ref input[right - 1]);
            }

            InternalSort(ref input, start, left, rank - 1);
            InternalSort(ref input, left, end, rank - 1);
        }

        public static void RadixSort(ref int[] input)
        {
            int buf = 0;
            for (int i = 0; i < input.Length; buf |= input[i++]);
            int r = 31;
            for (; (buf & (1u << r)) == 0; r -= 1);
            InternalSort(ref input, 0, input.Length, r);
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        //STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            Random rand = new Random();
            int[] arr = new int[25];

            for (int i = 0; i< arr.Length; i++)
            {
                arr[i] = rand.Next(-(1 << 4), 1 << 4);
            }

            /*            foreach (int item in arr)
                        {
                            Console.Write(item.ToString() + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine();*/

            RadixSort(ref arr);

            foreach(int item in arr)
            {
                Console.Write(item.ToString() + " ");
            }

            bool flag = true;
            for (int i = 1; flag && i<arr.Length; i++)
            {
                if (arr[i-1]>arr[i])
                {
                    flag = false;
                    Console.Write(arr[i - 1].ToString() + " " + arr[i].ToString());
                }
            }

            Console.Write(flag);

            Console.ReadKey(true);
        }
    }
}
