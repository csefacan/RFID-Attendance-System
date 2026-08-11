using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; 

namespace personel_takip_sefa_can_celik
{
    public partial class FrmPersonel1 : Form
    {
        
        string connString = "Data Source=IKSistemi.db;Version=3;";

        public FrmPersonel1()
        {
            InitializeComponent();
        }

        private void FrmPersonel1_Load(object sender, EventArgs e)
        {
            // Form ekrana ilk geldiği anda veritabanındaki tüm personelleri tabloya çek!
            PersonelleriListele();
        }

        private void PersonelleriListele()
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "SELECT * FROM Personeller";
                using (var da = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "INSERT INTO Personeller (Ad, Soyad, Telefon, Adres, Departman) VALUES (@ad, @soyad, @tel, @adres, @dep)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@tel", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                    cmd.Parameters.AddWithValue("@dep", txtDepartman.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Personel başarıyla sisteme eklendi. (Henüz kart atanmadı)", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

          
            PersonelleriListele();

      
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtDepartman.Clear();
        }

       
        private void btnSil_Click(object sender, EventArgs e)
        {
        
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index == -1)
            {
                MessageBox.Show("Lütfen silmek istediğiniz personeli tablodan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

 
            int seciliId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            string seciliAdSoyad = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();

      
            DialogResult cevap = MessageBox.Show($"{seciliAdSoyad} isimli personeli sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Personel Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
            
                    string sql = "DELETE FROM Personeller WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", seciliId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Personel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

       
                PersonelleriListele();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
        }
    }
}