using PersonelTakipSistemi;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace personel_takip_sefa_can_celik
{
    public partial class FrmKart : Form
    {
        string connString = "Data Source=IKSistemi.db;Version=3;";

        public FrmKart()
        {
            InitializeComponent();
        }

        private void FrmKart_Load(object sender, EventArgs e)
        {
            PersonelleriComboboxaDoldur();
        }


        private void btnYenile_Click(object sender, EventArgs e)
        {
            PersonelleriComboboxaDoldur();
            MessageBox.Show("Personel listesi veritabanından başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    cmbPersonel.DataSource = dt;
                    cmbPersonel.DisplayMember = "AdSoyad"; 
                    cmbPersonel.ValueMember = "Id";        

                    // Başlangıçta seçim boş gelsin
                    cmbPersonel.SelectedIndex = -1;
                    lblMevcutKart.Text = "Mevcut Kart: -";
                }
            }
        }

    
        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPersonel.SelectedIndex != -1 && cmbPersonel.SelectedItem is DataRowView)
            {
                DataRowView row = (DataRowView)cmbPersonel.SelectedItem;
                string mevcutKart = row["KartUID"].ToString();

                if (string.IsNullOrEmpty(mevcutKart))
                {
                    lblMevcutKart.Text = "Mevcut Kart: Atanmamış";
                    lblMevcutKart.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMevcutKart.Text = "Mevcut Kart: " + mevcutKart;
                    lblMevcutKart.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                if (lblMevcutKart != null)
                {
                    lblMevcutKart.Text = "Mevcut Kart: -";
                    lblMevcutKart.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void btnSensorOku_Click(object sender, EventArgs e)
        {
            if (giris.SonOkunanKart != "")
            {
                txtKartUID.Text = giris.SonOkunanKart;
            }
            else
            {
                MessageBox.Show("Lütfen önce sensöre bir kart okutun!");
            }
        }

        private void btnAta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKartUID.Text))
            {
                MessageBox.Show("Lütfen önce sensörden bir kart okutun!");
                return;
            }

            if (cmbPersonel.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen listeden bir personel seçin!");
                return;
            }

            string okunanKart = txtKartUID.Text;
            string seciliPersonelId = cmbPersonel.SelectedValue.ToString();

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                    // Ssisteme kayıtlı kart kontrolünü yaptım burada!!!!!!!!!
                string checkSql = "SELECT (Ad || ' ' || Soyad) as AdSoyad FROM Personeller WHERE KartUID = @uid";
                using (var checkCmd = new SQLiteCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@uid", okunanKart);
                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show($"Bu kart zaten sisteme ekli!\nKartın Sahibi: {result.ToString()}", "Atama Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            
                string updateSql = "UPDATE Personeller SET KartUID=@uid WHERE Id=@id";
                using (var cmd = new SQLiteCommand(updateSql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", okunanKart);
                    cmd.Parameters.AddWithValue("@id", seciliPersonelId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Kart başarıyla personele tanımlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ekranı güncelle
                    PersonelleriComboboxaDoldur();
                    txtKartUID.Clear();
                }
            }
        }

        
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (cmbPersonel.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kartı silinecek personeli seçin!");
                return;
            }

            DialogResult cevap = MessageBox.Show("Seçili personelin kart atamasını silmek istediğinize emin misiniz?", "Kart Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                // ID'yi güvenli bir şekilde Integer olarak alıyoruz
                int seciliPersonelId = Convert.ToInt32(cmbPersonel.SelectedValue);

                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = "UPDATE Personeller SET KartUID = NULL WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", seciliPersonelId);
                        int etkilenenSatir = cmd.ExecuteNonQuery();

                        if (etkilenenSatir > 0)
                        {
                            MessageBox.Show("Personelin kart ataması başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi yapılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Ekranı güncelle
                        PersonelleriComboboxaDoldur();
                        txtKartUID.Clear();
                    }
                }
            }
        }

        private void FrmKart_Load_1(object sender, EventArgs e)
        {

        }
    }
}