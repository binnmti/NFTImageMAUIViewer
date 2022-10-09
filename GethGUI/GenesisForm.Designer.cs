namespace GethGUI
{
    partial class GenesisForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.GenesisFileNameTextBox = new System.Windows.Forms.TextBox();
            this.PrivateButton = new System.Windows.Forms.Button();
            this.GenesisContextTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.GenesisFileNameButton = new System.Windows.Forms.Button();
            this.GenesisFileNameOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Genesis FileName";
            // 
            // GenesisFileNameTextBox
            // 
            this.GenesisFileNameTextBox.Location = new System.Drawing.Point(12, 37);
            this.GenesisFileNameTextBox.Name = "GenesisFileNameTextBox";
            this.GenesisFileNameTextBox.Size = new System.Drawing.Size(736, 31);
            this.GenesisFileNameTextBox.TabIndex = 1;
            this.GenesisFileNameTextBox.TextChanged += new System.EventHandler(this.GenesisFileNameTextBox_TextChanged);
            // 
            // PrivateButton
            // 
            this.PrivateButton.Location = new System.Drawing.Point(12, 74);
            this.PrivateButton.Name = "PrivateButton";
            this.PrivateButton.Size = new System.Drawing.Size(157, 34);
            this.PrivateButton.TabIndex = 2;
            this.PrivateButton.Text = "private template";
            this.PrivateButton.UseVisualStyleBackColor = true;
            this.PrivateButton.Click += new System.EventHandler(this.PrivateButton_Click);
            // 
            // GenesisContextTextBox
            // 
            this.GenesisContextTextBox.Location = new System.Drawing.Point(12, 114);
            this.GenesisContextTextBox.Multiline = true;
            this.GenesisContextTextBox.Name = "GenesisContextTextBox";
            this.GenesisContextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.GenesisContextTextBox.Size = new System.Drawing.Size(776, 344);
            this.GenesisContextTextBox.TabIndex = 3;
            this.GenesisContextTextBox.TextChanged += new System.EventHandler(this.GenesisContextTextBox_TextChanged);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(558, 464);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(112, 34);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Create";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(676, 464);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 34);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // GenesisFileNameButton
            // 
            this.GenesisFileNameButton.AutoSize = true;
            this.GenesisFileNameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GenesisFileNameButton.Location = new System.Drawing.Point(754, 37);
            this.GenesisFileNameButton.Name = "GenesisFileNameButton";
            this.GenesisFileNameButton.Size = new System.Drawing.Size(34, 35);
            this.GenesisFileNameButton.TabIndex = 6;
            this.GenesisFileNameButton.Text = "...";
            this.GenesisFileNameButton.UseVisualStyleBackColor = true;
            this.GenesisFileNameButton.Click += new System.EventHandler(this.GenesisFileNameButton_Click);
            // 
            // GenesisFileNameOpenFileDialog
            // 
            this.GenesisFileNameOpenFileDialog.DefaultExt = "json";
            this.GenesisFileNameOpenFileDialog.FileName = "openFileDialog1";
            this.GenesisFileNameOpenFileDialog.Filter = "json file|*.json";
            this.GenesisFileNameOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.GenesisFileNameOpenFileDialog_FileOk);
            // 
            // GenesisForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.GenesisFileNameButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.GenesisContextTextBox);
            this.Controls.Add(this.PrivateButton);
            this.Controls.Add(this.GenesisFileNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "GenesisForm";
            this.Text = "GenesisForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenesisForm_FormClosing);
            this.Shown += new System.EventHandler(this.GenesisForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox GenesisFileNameTextBox;
        private Button PrivateButton;
        private TextBox GenesisContextTextBox;
        private Button OkButton;
        private Button CancelButton;
        private Button GenesisFileNameButton;
        private OpenFileDialog GenesisFileNameOpenFileDialog;
    }
}