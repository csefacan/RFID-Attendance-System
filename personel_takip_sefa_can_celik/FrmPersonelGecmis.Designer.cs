namespace personel_takip_sefa_can_celik
{
    partial class FrmPersonelGecmis
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
            this.cmbPersoneller = new System.Windows.Forms.ComboBox();
            this.lblPersonel = new System.Windows.Forms.Label();
            this.dgvGecmis = new System.Windows.Forms.DataGridView();
            this.btnSifirla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPersoneller
            // 
            this.cmbPersoneller.FormattingEnabled = true;
            this.cmbPersoneller.Location = new System.Drawing.Point(374, 12);
            this.cmbPersoneller.Name = "cmbPersoneller";
            this.cmbPersoneller.Size = new System.Drawing.Size(121, 21);
            this.cmbPersoneller.TabIndex = 0;
            this.cmbPersoneller.Click += new System.EventHandler(this.FrmPersonelGecmis_Load);
            // 
            // lblPersonel
            // 
            this.lblPersonel.AutoSize = true;
            this.lblPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPersonel.Location = new System.Drawing.Point(280, 13);
            this.lblPersonel.Name = "lblPersonel";
            this.lblPersonel.Size = new System.Drawing.Size(88, 16);
            this.lblPersonel.TabIndex = 1;
            this.lblPersonel.Text = "Personel Seç";
            // 
            // dgvGecmis
            // 
            this.dgvGecmis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGecmis.Location = new System.Drawing.Point(-3, 55);
            this.dgvGecmis.Name = "dgvGecmis";
            this.dgvGecmis.Size = new System.Drawing.Size(810, 396);
            this.dgvGecmis.TabIndex = 2;
            this.dgvGecmis.Click += new System.EventHandler(this.cmbPersoneller_SelectedIndexChanged);
            // 
            // btnSifirla
            // 
            this.btnSifirla.Location = new System.Drawing.Point(705, 4);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(83, 45);
            this.btnSifirla.TabIndex = 3;
            this.btnSifirla.Text = "Yenile";
            this.btnSifirla.UseVisualStyleBackColor = true;
            // 
            // FrmPersonelGecmis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSifirla);
            this.Controls.Add(this.dgvGecmis);
            this.Controls.Add(this.lblPersonel);
            this.Controls.Add(this.cmbPersoneller);
            this.Name = "FrmPersonelGecmis";
            this.Text = "Personel Giriş Kontrolü";
            this.Load += new System.EventHandler(this.FrmPersonelGecmis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersoneller;
        private System.Windows.Forms.Label lblPersonel;
        private System.Windows.Forms.DataGridView dgvGecmis;
        private System.Windows.Forms.Button btnSifirla;
    }
}