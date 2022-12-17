namespace MidiBinder
{
    partial class MidiBinder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.noteLabel = new System.Windows.Forms.Label();
            this.noteSelect = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.noteLabel);
            this.flowLayoutPanel1.Controls.Add(this.noteSelect);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(3, 6);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(61, 15);
            this.noteLabel.TabIndex = 0;
            this.noteLabel.Text = "MIDI Note";
            // 
            // noteSelect
            // 
            this.noteSelect.Location = new System.Drawing.Point(70, 3);
            this.noteSelect.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.noteSelect.Name = "noteSelect";
            this.noteSelect.Size = new System.Drawing.Size(55, 23);
            this.noteSelect.TabIndex = 1;
            // 
            // MidiBinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MidiBinder";
            this.Size = new System.Drawing.Size(300, 28);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label noteLabel;
        private NumericUpDown noteSelect;
    }
}
