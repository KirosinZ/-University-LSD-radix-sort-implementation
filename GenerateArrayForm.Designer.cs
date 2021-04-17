
namespace STRIALG_INTERNAL_SORT
{
    partial class GenerateArrayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.NumericUpDown();
            this.BordersLabel = new System.Windows.Forms.Label();
            this.FromCheck = new System.Windows.Forms.CheckBox();
            this.FromBox = new System.Windows.Forms.NumericUpDown();
            this.ToCheck = new System.Windows.Forms.CheckBox();
            this.ToBox = new System.Windows.Forms.NumericUpDown();
            this.DoneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(12, 9);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(90, 13);
            this.SizeLabel.TabIndex = 1;
            this.SizeLabel.Text = "Введите размер";
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(108, 7);
            this.SizeBox.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(120, 20);
            this.SizeBox.TabIndex = 2;
            this.SizeBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // BordersLabel
            // 
            this.BordersLabel.AutoSize = true;
            this.BordersLabel.Location = new System.Drawing.Point(13, 31);
            this.BordersLabel.Name = "BordersLabel";
            this.BordersLabel.Size = new System.Drawing.Size(208, 13);
            this.BordersLabel.TabIndex = 3;
            this.BordersLabel.Text = "Введите диапазон генерируемых чисел";
            // 
            // FromCheck
            // 
            this.FromCheck.AutoSize = true;
            this.FromCheck.Checked = true;
            this.FromCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FromCheck.Location = new System.Drawing.Point(15, 48);
            this.FromCheck.Name = "FromCheck";
            this.FromCheck.Size = new System.Drawing.Size(39, 17);
            this.FromCheck.TabIndex = 4;
            this.FromCheck.Text = "От";
            this.FromCheck.UseVisualStyleBackColor = true;
            // 
            // FromBox
            // 
            this.FromBox.Location = new System.Drawing.Point(60, 47);
            this.FromBox.Name = "FromBox";
            this.FromBox.Size = new System.Drawing.Size(168, 20);
            this.FromBox.TabIndex = 5;
            // 
            // ToCheck
            // 
            this.ToCheck.AutoSize = true;
            this.ToCheck.Checked = true;
            this.ToCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToCheck.Location = new System.Drawing.Point(15, 74);
            this.ToCheck.Name = "ToCheck";
            this.ToCheck.Size = new System.Drawing.Size(41, 17);
            this.ToCheck.TabIndex = 4;
            this.ToCheck.Text = "До";
            this.ToCheck.UseVisualStyleBackColor = true;
            // 
            // ToBox
            // 
            this.ToBox.Location = new System.Drawing.Point(60, 73);
            this.ToBox.Name = "ToBox";
            this.ToBox.Size = new System.Drawing.Size(168, 20);
            this.ToBox.TabIndex = 5;
            this.ToBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(79, 99);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 6;
            this.DoneButton.Text = "Ввод";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // GenerateArrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 131);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.ToBox);
            this.Controls.Add(this.ToCheck);
            this.Controls.Add(this.FromBox);
            this.Controls.Add(this.FromCheck);
            this.Controls.Add(this.BordersLabel);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.SizeLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(255, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(255, 170);
            this.Name = "GenerateArrayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "GenerateArrayForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.SizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.NumericUpDown SizeBox;
        private System.Windows.Forms.Label BordersLabel;
        private System.Windows.Forms.CheckBox FromCheck;
        private System.Windows.Forms.NumericUpDown FromBox;
        private System.Windows.Forms.CheckBox ToCheck;
        private System.Windows.Forms.NumericUpDown ToBox;
        private System.Windows.Forms.Button DoneButton;
    }
}