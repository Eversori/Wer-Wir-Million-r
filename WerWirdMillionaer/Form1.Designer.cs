namespace WerWirdMillionaer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonNormalPlay = new System.Windows.Forms.Button();
            this.buttonRiskPlay = new System.Windows.Forms.Button();
            this.labelname = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonNormalPlay
            // 
            this.buttonNormalPlay.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonNormalPlay.FlatAppearance.BorderSize = 5;
            this.buttonNormalPlay.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNormalPlay.ForeColor = System.Drawing.Color.Teal;
            this.buttonNormalPlay.Location = new System.Drawing.Point(826, 41);
            this.buttonNormalPlay.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonNormalPlay.Name = "buttonNormalPlay";
            this.buttonNormalPlay.Size = new System.Drawing.Size(216, 76);
            this.buttonNormalPlay.TabIndex = 0;
            this.buttonNormalPlay.Text = "Normal";
            this.buttonNormalPlay.UseVisualStyleBackColor = false;
            this.buttonNormalPlay.Click += new System.EventHandler(this.starteNormalesSpiel);
            // 
            // buttonRiskPlay
            // 
            this.buttonRiskPlay.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonRiskPlay.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.buttonRiskPlay.FlatAppearance.BorderSize = 5;
            this.buttonRiskPlay.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRiskPlay.ForeColor = System.Drawing.Color.Maroon;
            this.buttonRiskPlay.Location = new System.Drawing.Point(826, 145);
            this.buttonRiskPlay.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonRiskPlay.Name = "buttonRiskPlay";
            this.buttonRiskPlay.Size = new System.Drawing.Size(216, 76);
            this.buttonRiskPlay.TabIndex = 1;
            this.buttonRiskPlay.Text = "Risiko";
            this.buttonRiskPlay.UseVisualStyleBackColor = false;
            this.buttonRiskPlay.Click += new System.EventHandler(this.buttonRiskPlay_Click);
            // 
            // labelname
            // 
            this.labelname.AutoSize = true;
            this.labelname.BackColor = System.Drawing.Color.Transparent;
            this.labelname.ForeColor = System.Drawing.Color.White;
            this.labelname.Location = new System.Drawing.Point(17, 23);
            this.labelname.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelname.Name = "labelname";
            this.labelname.Size = new System.Drawing.Size(274, 31);
            this.labelname.TabIndex = 2;
            this.labelname.Text = "Bitte Name eingeben:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(36, 79);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(287, 38);
            this.textBoxName.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelname);
            this.Controls.Add(this.buttonRiskPlay);
            this.Controls.Add(this.buttonNormalPlay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Wer wird Millionär";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNormalPlay;
        private System.Windows.Forms.Button buttonRiskPlay;
        private System.Windows.Forms.Label labelname;
        private System.Windows.Forms.TextBox textBoxName;
    }
}

