using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STRIALG_INTERNAL_SORT
{
    public partial class GenerateArrayForm : Form
    {
        public int[] Result { get; private set; }

        void Do()
        {
            Random rand = new Random();
            Result = new int[(int)SizeBox.Value];

            int min = FromCheck.Checked ? (int)FromBox.Value : int.MinValue;
            int max = ToCheck.Checked ? (int)ToBox.Value : int.MaxValue;

            if (min <= max)
            {
                for (int i = 0; i < Result.Length; i++)
                {
                    Result[i] = rand.Next(min, max);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show(this, "Верхняя граница должна быть больше нижней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public GenerateArrayForm()
        {
            InitializeComponent();

            FromBox.Minimum = ToBox.Minimum = int.MinValue;
            FromBox.Maximum = ToBox.Maximum = int.MaxValue;

            FromBox.Value = -(ToBox.Value = 20);

            DoneButton.Click += (ob, ev) => Do();
        }
    }
}
