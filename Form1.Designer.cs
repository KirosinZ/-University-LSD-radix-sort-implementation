
namespace STRIALG_INTERNAL_SORT
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ArrayStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateArrayStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SortStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DoSortStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrayBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArrayStrip,
            this.SortStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ArrayStrip
            // 
            this.ArrayStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateArrayStrip});
            this.ArrayStrip.Name = "ArrayStrip";
            this.ArrayStrip.Size = new System.Drawing.Size(61, 20);
            this.ArrayStrip.Text = "Массив";
            // 
            // GenerateArrayStrip
            // 
            this.GenerateArrayStrip.Name = "GenerateArrayStrip";
            this.GenerateArrayStrip.Size = new System.Drawing.Size(157, 22);
            this.GenerateArrayStrip.Text = "Сгенерировать";
            // 
            // SortStrip
            // 
            this.SortStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoSortStrip});
            this.SortStrip.Name = "SortStrip";
            this.SortStrip.Size = new System.Drawing.Size(85, 20);
            this.SortStrip.Text = "Сортировка";
            // 
            // DoSortStrip
            // 
            this.DoSortStrip.Name = "DoSortStrip";
            this.DoSortStrip.Size = new System.Drawing.Size(136, 22);
            this.DoSortStrip.Text = "Выполнить";
            // 
            // ArrayBox
            // 
            this.ArrayBox.Location = new System.Drawing.Point(12, 27);
            this.ArrayBox.Name = "ArrayBox";
            this.ArrayBox.Size = new System.Drawing.Size(776, 741);
            this.ArrayBox.TabIndex = 1;
            this.ArrayBox.TabStop = false;
            this.ArrayBox.Text = "Массив";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 780);
            this.Controls.Add(this.ArrayBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ArrayStrip;
        private System.Windows.Forms.ToolStripMenuItem GenerateArrayStrip;
        private System.Windows.Forms.ToolStripMenuItem SortStrip;
        private System.Windows.Forms.ToolStripMenuItem DoSortStrip;
        private System.Windows.Forms.GroupBox ArrayBox;
    }
}

