namespace personel_takip_sefa_can_celik
{
    partial class FrmKart
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
            this.cmbPersonel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKartUID = new System.Windows.Forms.TextBox();
            this.btnAta = new System.Windows.Forms.Button();
            this.btnSensorOku = new System.Windows.Forms.Button();
            this.lblMevcutKart = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblmevcutText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPersonel
            // 
            this.cmbPersonel.FormattingEnabled = true;
            this.cmbPersonel.Location = new System.Drawing.Point(533, 69);
            this.cmbPersonel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPersonel.Name = "cmbPersonel";
            this.cmbPersonel.Size = new System.Drawing.Size(197, 24);
            this.cmbPersonel.TabIndex = 0;
            this.cmbPersonel.SelectedIndexChanged += new System.EventHandler(this.cmbPersonel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(388, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Personel Seç";
            // 
            // txtKartUID
            // 
            this.txtKartUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKartUID.Location = new System.Drawing.Point(393, 287);
            this.txtKartUID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKartUID.Name = "txtKartUID";
            this.txtKartUID.Size = new System.Drawing.Size(337, 22);
            this.txtKartUID.TabIndex = 17;
            // 
            // btnAta
            // 
            this.btnAta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAta.Location = new System.Drawing.Point(393, 118);
            this.btnAta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAta.Name = "btnAta";
            this.btnAta.Size = new System.Drawing.Size(339, 48);
            this.btnAta.TabIndex = 18;
            this.btnAta.Text = "Kartı Ata";
            this.btnAta.UseVisualStyleBackColor = true;
            this.btnAta.Click += new System.EventHandler(this.btnAta_Click);
            // 
            // btnSensorOku
            // 
            this.btnSensorOku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSensorOku.Location = new System.Drawing.Point(393, 321);
            this.btnSensorOku.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSensorOku.Name = "btnSensorOku";
            this.btnSensorOku.Size = new System.Drawing.Size(339, 49);
            this.btnSensorOku.TabIndex = 19;
            this.btnSensorOku.Text = "Sensörü Oku";
            this.btnSensorOku.UseVisualStyleBackColor = true;
            this.btnSensorOku.Click += new System.EventHandler(this.btnSensorOku_Click);
            // 
            // lblMevcutKart
            // 
            this.lblMevcutKart.AutoSize = true;
            this.lblMevcutKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMevcutKart.Location = new System.Drawing.Point(631, 33);
            this.lblMevcutKart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMevcutKart.Name = "lblMevcutKart";
            this.lblMevcutKart.Size = new System.Drawing.Size(76, 16);
            this.lblMevcutKart.TabIndex = 20;
            this.lblMevcutKart.Text = "Mevcut Kart";
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(393, 174);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(339, 46);
            this.btnSil.TabIndex = 21;
            this.btnSil.Text = "Kartı Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblmevcutText
            // 
            this.lblmevcutText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblmevcutText.Location = new System.Drawing.Point(388, 33);
            this.lblmevcutText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmevcutText.Name = "lblmevcutText";
            this.lblmevcutText.Size = new System.Drawing.Size(235, 32);
            this.lblmevcutText.TabIndex = 22;
            this.lblmevcutText.Text = "Mevcut Kartın UUID adresi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(489, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Son Okunan Kart";
            // 
            // FrmKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblmevcutText);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.lblMevcutKart);
            this.Controls.Add(this.btnSensorOku);
            this.Controls.Add(this.btnAta);
            this.Controls.Add(this.txtKartUID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPersonel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmKart";
            this.Text = "Kart Atama";
            this.Load += new System.EventHandler(this.FrmKart_Load_1);
            this.VisibleChanged += new System.EventHandler(this.FrmKart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKartUID;
        private System.Windows.Forms.Button btnAta;
        private System.Windows.Forms.Button btnSensorOku;
        private System.Windows.Forms.Label lblMevcutKart;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblmevcutText;
        private System.Windows.Forms.Label label2;
    }
}