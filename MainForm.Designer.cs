namespace MidiBinder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.midiDevicesCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingsListView = new System.Windows.Forms.ListView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.addBindingButton = new System.Windows.Forms.Button();
            this.deleteBindingButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.bindingNameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.outputFunctionCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.browseSoundTextBox = new System.Windows.Forms.TextBox();
            this.outputKeyCombo = new System.Windows.Forms.ComboBox();
            this.outputCommandTextBox = new System.Windows.Forms.TextBox();
            this.browseSoundButton = new System.Windows.Forms.Button();
            this.detectButton = new System.Windows.Forms.Button();
            this.midiNoteLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.noteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openSoundFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.bindingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteNumericUpDown)).BeginInit();
            this.mainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "MIDI Device Name";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.midiDevicesCombo);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.bindingsListView);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 306);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // midiDevicesCombo
            // 
            this.midiDevicesCombo.FormattingEnabled = true;
            this.midiDevicesCombo.Location = new System.Drawing.Point(0, 25);
            this.midiDevicesCombo.Margin = new System.Windows.Forms.Padding(0);
            this.midiDevicesCombo.Name = "midiDevicesCombo";
            this.midiDevicesCombo.Size = new System.Drawing.Size(200, 23);
            this.midiDevicesCombo.TabIndex = 1;
            this.midiDevicesCombo.SelectedIndexChanged += new System.EventHandler(this.midiDevicesCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(200, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bindings";
            // 
            // bindingsListView
            // 
            this.bindingsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.bindingsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.bindingsListView.Location = new System.Drawing.Point(0, 73);
            this.bindingsListView.Margin = new System.Windows.Forms.Padding(0);
            this.bindingsListView.MultiSelect = false;
            this.bindingsListView.Name = "bindingsListView";
            this.bindingsListView.Size = new System.Drawing.Size(200, 175);
            this.bindingsListView.TabIndex = 0;
            this.bindingsListView.UseCompatibleStateImageBehavior = false;
            this.bindingsListView.View = System.Windows.Forms.View.Details;
            this.bindingsListView.SelectedIndexChanged += new System.EventHandler(this.bindingsListView_SelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addBindingButton);
            this.flowLayoutPanel2.Controls.Add(this.deleteBindingButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 248);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 25);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // addBindingButton
            // 
            this.addBindingButton.Location = new System.Drawing.Point(0, 0);
            this.addBindingButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.addBindingButton.Name = "addBindingButton";
            this.addBindingButton.Size = new System.Drawing.Size(98, 25);
            this.addBindingButton.TabIndex = 0;
            this.addBindingButton.Text = "Add";
            this.addBindingButton.UseVisualStyleBackColor = true;
            this.addBindingButton.Click += new System.EventHandler(this.addBindingButton_Click);
            // 
            // deleteBindingButton
            // 
            this.deleteBindingButton.Location = new System.Drawing.Point(102, 0);
            this.deleteBindingButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.deleteBindingButton.Name = "deleteBindingButton";
            this.deleteBindingButton.Size = new System.Drawing.Size(98, 25);
            this.deleteBindingButton.TabIndex = 1;
            this.deleteBindingButton.Text = "Delete";
            this.deleteBindingButton.UseVisualStyleBackColor = true;
            this.deleteBindingButton.Click += new System.EventHandler(this.deleteBindingButton_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.saveButton);
            this.flowLayoutPanel3.Controls.Add(this.loadButton);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 277);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 25);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(0, 0);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 25);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(102, 0);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(98, 25);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // bindingNameTextBox
            // 
            this.bindingNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bindingNameTextBox.Location = new System.Drawing.Point(5, 1);
            this.bindingNameTextBox.Name = "bindingNameTextBox";
            this.bindingNameTextBox.PlaceholderText = "Binding Name";
            this.bindingNameTextBox.Size = new System.Drawing.Size(363, 23);
            this.bindingNameTextBox.TabIndex = 3;
            this.bindingNameTextBox.WordWrap = false;
            this.bindingNameTextBox.TextChanged += new System.EventHandler(this.bindingNameTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bindingPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(384, 306);
            this.panel1.TabIndex = 1;
            // 
            // bindingPanel
            // 
            this.bindingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bindingPanel.Controls.Add(this.bindingNameTextBox);
            this.bindingPanel.Controls.Add(this.label5);
            this.bindingPanel.Controls.Add(this.outputFunctionCombo);
            this.bindingPanel.Controls.Add(this.label7);
            this.bindingPanel.Controls.Add(this.label6);
            this.bindingPanel.Controls.Add(this.label4);
            this.bindingPanel.Controls.Add(this.browseSoundTextBox);
            this.bindingPanel.Controls.Add(this.outputKeyCombo);
            this.bindingPanel.Controls.Add(this.outputCommandTextBox);
            this.bindingPanel.Controls.Add(this.browseSoundButton);
            this.bindingPanel.Controls.Add(this.detectButton);
            this.bindingPanel.Controls.Add(this.midiNoteLabel);
            this.bindingPanel.Controls.Add(this.label3);
            this.bindingPanel.Controls.Add(this.noteNumericUpDown);
            this.bindingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingPanel.Enabled = false;
            this.bindingPanel.Location = new System.Drawing.Point(2, 2);
            this.bindingPanel.Name = "bindingPanel";
            this.bindingPanel.Size = new System.Drawing.Size(380, 302);
            this.bindingPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Function";
            // 
            // outputFunctionCombo
            // 
            this.outputFunctionCombo.FormattingEnabled = true;
            this.outputFunctionCombo.Location = new System.Drawing.Point(65, 66);
            this.outputFunctionCombo.Name = "outputFunctionCombo";
            this.outputFunctionCombo.Size = new System.Drawing.Size(156, 23);
            this.outputFunctionCombo.TabIndex = 4;
            this.outputFunctionCombo.SelectedIndexChanged += new System.EventHandler(this.outputFunctionCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sound Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Output Key";
            // 
            // browseSoundTextBox
            // 
            this.browseSoundTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSoundTextBox.Location = new System.Drawing.Point(101, 157);
            this.browseSoundTextBox.Name = "browseSoundTextBox";
            this.browseSoundTextBox.PlaceholderText = "Sound Path";
            this.browseSoundTextBox.Size = new System.Drawing.Size(178, 23);
            this.browseSoundTextBox.TabIndex = 3;
            this.browseSoundTextBox.WordWrap = false;
            this.browseSoundTextBox.TextChanged += new System.EventHandler(this.browseSoundTextBox_TextChanged);
            // 
            // outputKeyCombo
            // 
            this.outputKeyCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputKeyCombo.FormattingEnabled = true;
            this.outputKeyCombo.Location = new System.Drawing.Point(101, 98);
            this.outputKeyCombo.Name = "outputKeyCombo";
            this.outputKeyCombo.Size = new System.Drawing.Size(267, 23);
            this.outputKeyCombo.TabIndex = 4;
            this.outputKeyCombo.SelectedIndexChanged += new System.EventHandler(this.outputKeyCombo_SelectedIndexChanged);
            // 
            // outputCommandTextBox
            // 
            this.outputCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputCommandTextBox.Location = new System.Drawing.Point(101, 127);
            this.outputCommandTextBox.Name = "outputCommandTextBox";
            this.outputCommandTextBox.PlaceholderText = "Command";
            this.outputCommandTextBox.Size = new System.Drawing.Size(267, 23);
            this.outputCommandTextBox.TabIndex = 3;
            this.outputCommandTextBox.WordWrap = false;
            this.outputCommandTextBox.TextChanged += new System.EventHandler(this.outputCommandTextBox_TextChanged);
            // 
            // browseSoundButton
            // 
            this.browseSoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSoundButton.Location = new System.Drawing.Point(285, 157);
            this.browseSoundButton.Name = "browseSoundButton";
            this.browseSoundButton.Size = new System.Drawing.Size(83, 23);
            this.browseSoundButton.TabIndex = 2;
            this.browseSoundButton.Text = "Browse...";
            this.browseSoundButton.UseVisualStyleBackColor = true;
            this.browseSoundButton.Click += new System.EventHandler(this.browseSoundButton_Click);
            // 
            // detectButton
            // 
            this.detectButton.Location = new System.Drawing.Point(138, 31);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(83, 23);
            this.detectButton.TabIndex = 2;
            this.detectButton.Text = "Detect";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // midiNoteLabel
            // 
            this.midiNoteLabel.AutoSize = true;
            this.midiNoteLabel.Location = new System.Drawing.Point(227, 35);
            this.midiNoteLabel.Name = "midiNoteLabel";
            this.midiNoteLabel.Size = new System.Drawing.Size(32, 15);
            this.midiNoteLabel.TabIndex = 1;
            this.midiNoteLabel.Text = "[C 0]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "MIDI Note";
            // 
            // noteNumericUpDown
            // 
            this.noteNumericUpDown.Location = new System.Drawing.Point(78, 31);
            this.noteNumericUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.noteNumericUpDown.Name = "noteNumericUpDown";
            this.noteNumericUpDown.Size = new System.Drawing.Size(54, 23);
            this.noteNumericUpDown.TabIndex = 0;
            this.noteNumericUpDown.ValueChanged += new System.EventHandler(this.noteNumericUpDown_ValueChanged);
            // 
            // openSoundFileDialog
            // 
            this.openSoundFileDialog.AddToRecent = false;
            this.openSoundFileDialog.DefaultExt = "wav";
            this.openSoundFileDialog.Filter = "Sound files|*.wav;*.mp3|All Files|*.*";
            this.openSoundFileDialog.Title = "MIDI Binder Sound Selection...";
            this.openSoundFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openSoundFileDialog_FileOk);
            // 
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayNotifyIcon.BalloonTipText = "Minimised";
            this.trayNotifyIcon.BalloonTipTitle = "MIDI Binder";
            this.trayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayNotifyIcon.Icon")));
            this.trayNotifyIcon.Text = "MIDI Binder";
            this.trayNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayNotifyIcon_MouseDoubleClick);
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimiseToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.ShowImageMargin = false;
            this.mainContextMenuStrip.Size = new System.Drawing.Size(136, 26);
            this.mainContextMenuStrip.Text = "Window";
            // 
            // minimiseToolStripMenuItem
            // 
            this.minimiseToolStripMenuItem.Name = "minimiseToolStripMenuItem";
            this.minimiseToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.minimiseToolStripMenuItem.Text = "Minimise to tray";
            this.minimiseToolStripMenuItem.Click += new System.EventHandler(this.minimiseToolStripMenuItem_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 306);
            this.ContextMenuStrip = this.mainContextMenuStrip;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 345);
            this.Name = "MainForm";
            this.Text = "MIDI Binder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.bindingPanel.ResumeLayout(false);
            this.bindingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteNumericUpDown)).EndInit();
            this.mainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ListView bindingsListView;
        private Label label1;
        private ComboBox midiDevicesCombo;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button addBindingButton;
        private Button deleteBindingButton;
        private Panel panel1;
        private Panel bindingPanel;
        internal NumericUpDown noteNumericUpDown;
        internal Button detectButton;
        private TextBox bindingNameTextBox;
        private Label label4;
        private ComboBox outputKeyCombo;
        private Label label3;
        private Label label5;
        private ComboBox outputFunctionCombo;
        private Label label6;
        private TextBox outputCommandTextBox;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button saveButton;
        private Button loadButton;
        private Label midiNoteLabel;
        private Label label7;
        private TextBox browseSoundTextBox;
        internal Button browseSoundButton;
        internal OpenFileDialog openSoundFileDialog;
        private NotifyIcon trayNotifyIcon;
        private ContextMenuStrip mainContextMenuStrip;
        private ToolStripMenuItem minimiseToolStripMenuItem;
        private ColumnHeader columnHeader1;
    }
}