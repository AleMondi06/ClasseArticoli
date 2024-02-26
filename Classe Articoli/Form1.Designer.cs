namespace Classe_Articoli
{
    partial class Form1
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
            this.ALIMENTARI = new System.Windows.Forms.Button();
            this.NON_ALIMENTARI = new System.Windows.Forms.Button();
            this.ALIMENTARI_FRESCHI = new System.Windows.Forms.Button();
            this.SCONTRINO = new System.Windows.Forms.Button();
            this.EXIT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ALIMENTARI
            // 
            this.ALIMENTARI.Location = new System.Drawing.Point(50, 69);
            this.ALIMENTARI.Name = "ALIMENTARI";
            this.ALIMENTARI.Size = new System.Drawing.Size(181, 102);
            this.ALIMENTARI.TabIndex = 2;
            this.ALIMENTARI.Text = "ALIMENTARI";
            this.ALIMENTARI.UseVisualStyleBackColor = true;
            this.ALIMENTARI.Click += new System.EventHandler(this.ALIMENTARI_Click_1);
            // 
            // NON_ALIMENTARI
            // 
            this.NON_ALIMENTARI.Location = new System.Drawing.Point(296, 69);
            this.NON_ALIMENTARI.Name = "NON_ALIMENTARI";
            this.NON_ALIMENTARI.Size = new System.Drawing.Size(181, 102);
            this.NON_ALIMENTARI.TabIndex = 3;
            this.NON_ALIMENTARI.Text = "NON ALIMENTARI";
            this.NON_ALIMENTARI.UseVisualStyleBackColor = true;
            this.NON_ALIMENTARI.Click += new System.EventHandler(this.NON_ALIMENTARI_Click_1);
            // 
            // ALIMENTARI_FRESCHI
            // 
            this.ALIMENTARI_FRESCHI.Location = new System.Drawing.Point(529, 69);
            this.ALIMENTARI_FRESCHI.Name = "ALIMENTARI_FRESCHI";
            this.ALIMENTARI_FRESCHI.Size = new System.Drawing.Size(181, 102);
            this.ALIMENTARI_FRESCHI.TabIndex = 4;
            this.ALIMENTARI_FRESCHI.Text = "ALIMENTARI FRESCHI";
            this.ALIMENTARI_FRESCHI.UseVisualStyleBackColor = true;
            this.ALIMENTARI_FRESCHI.Click += new System.EventHandler(this.ALIMENTARI_FRESCHI_Click_1);
            // 
            // SCONTRINO
            // 
            this.SCONTRINO.Location = new System.Drawing.Point(50, 275);
            this.SCONTRINO.Name = "SCONTRINO";
            this.SCONTRINO.Size = new System.Drawing.Size(181, 95);
            this.SCONTRINO.TabIndex = 5;
            this.SCONTRINO.Text = "STAMPA SCONTRINO";
            this.SCONTRINO.UseVisualStyleBackColor = true;
            this.SCONTRINO.Click += new System.EventHandler(this.SCONTRINO_Click_1);
            // 
            // EXIT
            // 
            this.EXIT.Location = new System.Drawing.Point(529, 275);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(181, 95);
            this.EXIT.TabIndex = 7;
            this.EXIT.Text = "EXIT";
            this.EXIT.UseVisualStyleBackColor = true;
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ARTICOLI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.SCONTRINO);
            this.Controls.Add(this.ALIMENTARI_FRESCHI);
            this.Controls.Add(this.NON_ALIMENTARI);
            this.Controls.Add(this.ALIMENTARI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ALIMENTARI;
        private System.Windows.Forms.Button NON_ALIMENTARI;
        private System.Windows.Forms.Button ALIMENTARI_FRESCHI;
        private System.Windows.Forms.Button SCONTRINO;
        private System.Windows.Forms.Button EXIT;
        private System.Windows.Forms.Label label1;
    }
}

