namespace GTAVPriorityTool
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Instruction = new System.Windows.Forms.Label();
            this.Priority = new System.Windows.Forms.ComboBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.SetGTAVPriority = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Instruction
            // 
            this.Instruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.Instruction.Location = new System.Drawing.Point(0, 0);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(419, 23);
            this.Instruction.TabIndex = 0;
            this.Instruction.Text = "Which level of priority do you want it to use?";
            this.Instruction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Priority
            // 
            this.Priority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Priority.FormattingEnabled = true;
            this.Priority.Items.AddRange(new object[] {
            "Idle",
            "Below normal",
            "Normal",
            "Above normal",
            "High",
            "Real-Time"});
            this.Priority.Location = new System.Drawing.Point(12, 25);
            this.Priority.Name = "Priority";
            this.Priority.Size = new System.Drawing.Size(395, 21);
            this.Priority.TabIndex = 1;
            this.Priority.SelectedIndexChanged += new System.EventHandler(this.Priority_SelectedIndexChanged);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Location = new System.Drawing.Point(332, 62);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "OK";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(9, 54);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(317, 34);
            this.Status.TabIndex = 3;
            this.Status.Text = "Status:\r\nIdle";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetGTAVPriority
            // 
            this.SetGTAVPriority.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SetGTAVPriority_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 97);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.Priority);
            this.Controls.Add(this.Instruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA V Priority Tool";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Instruction;
        private System.Windows.Forms.ComboBox Priority;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label Status;
        private System.ComponentModel.BackgroundWorker SetGTAVPriority;
    }
}

