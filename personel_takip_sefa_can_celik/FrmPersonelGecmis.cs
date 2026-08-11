using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace personel_takip_sefa_can_celik
{
    public partial class FrmPersonelGecmis : Form
    {
        string connString = "Data Source=IKSistemi.db;Version=3;";

        public FrmPersonelGecmis()
        {
            InitializeComponent();
        }

        private void FrmPersonelGecmis_Load(object sender, EventArgs e)
        {
            PersonelleriComboboxaDoldur();
          
            TumGecmisiGetir();
        }

        private void PersonelleriComboboxaDoldur()
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "SELECT Id, (Ad || ' ' || Soyad) as AdSoyad, KartUID FROM Personeller";



                using (var da = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                   
                    cmbPersoneller.SelectedIndexChanged -= cmbPersoneller_SelectedIndexChanged;

                    cmbPersoneller.DataSource = dt;
                    cmbPersoneller.DisplayMember = "AdSoyad";
                    cmbPersoneller.ValueMember = "KartUID";

                    cmbPersoneller.SelectedIndex = -1; // Başlangıçta boş kalsın

                    // Event'i geri bağlıyoruz
                    cmbPersoneller.SelectedIndexChanged += cmbPersoneller_SelectedIndexChanged;
                }
            }
        }

      
        private void TumGecmisiGetir()
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                // JOIN işlemi ile personelin adını ve soyadını da getiriyoruz. 
                // Geçersiz kart basılmışsa p.Ad NULL olacağı için ekranda "Bilinmeyen Kart" yazdırıyoruz.
                string sql = @"
                    SELECT 
                        IFNULL(p.Ad || ' ' || p.Soyad, 'Tanımsız Kart') AS [Ad Soyad], 
                        g.KartUID AS [Kart Numarası], 
                        g.IslemZamani AS [İşlem Tarihi ve Saati], 
                        g.Durum AS [İşlem Durumu] 
                    FROM GirisCikis g 
                    LEFT JOIN Personeller p ON g.KartUID = p.KartUID 
                    ORDER BY g.Id DESC";

                using (var da = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dtAll = new DataTable();
                    da.Fill(dtAll);
                    dgvGecmis.DataSource = dtAll;
                }
            }
        }

        private void cmbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir kişi seçildiyse sadece onu getir
            if (cmbPersoneller.SelectedIndex != -1 && cmbPersoneller.SelectedValue != null && cmbPersoneller.SelectedValue is string)
            {
                string secilenKartUID = cmbPersoneller.SelectedValue.ToString();

                using (var conn = new SQLiteConnection(connString))
                {
                    // Inner join kullanıldı burada!!!!!!
                    conn.Open();
                    string sql = @"
                        SELECT 
                            (p.Ad || ' ' || p.Soyad) AS [Ad Soyad], 
                            g.KartUID AS [Kart Numarası], 
                            g.IslemZamani AS [İşlem Tarihi ve Saati], 
                            g.Durum AS [İşlem Durumu] 
                        FROM GirisCikis g 
                        INNER JOIN Personeller p ON g.KartUID = p.KartUID 
                        WHERE g.KartUID = @uid 
                        ORDER BY g.Id DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", secilenKartUID);
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dtGecmis = new DataTable();
                            da.Fill(dtGecmis);
                            dgvGecmis.DataSource = dtGecmis;
                        }
                    }
                }
            }
            else
            {
 
                TumGecmisiGetir();
            }
        }


        private void btnSifirla_Click(object sender, EventArgs e)
        {
            // Seçimi -1 yapmak otomatik olarak cmbPersoneller_SelectedIndexChanged 
            // olayını tetikleyecek ve "else" bloğuna düşüp tüm listeyi getirecektir.
            cmbPersoneller.SelectedIndex = -1;
        }
    }
}