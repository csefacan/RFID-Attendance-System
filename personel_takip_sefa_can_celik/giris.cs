using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SQLite;
using personel_takip_sefa_can_celik;

namespace PersonelTakipSistemi
{
    public partial class giris : Form
    {
        public static string SonOkunanKart = "";

       
        private Timer bekletmeTimer;

        public giris()
        {
            InitializeComponent();

           
            bekletmeTimer = new Timer();
            bekletmeTimer.Interval = 3000;
            bekletmeTimer.Tick += BekletmeTimer_Tick;

            //  Kopuk bağlantıyı engellemek için sensör okuma olayını bağlıyoruz!
            serialPort1.DataReceived += serialPort1_DataReceived;
        }

      
        private void BekletmeTimer_Tick(object sender, EventArgs e)
        {
            bekletmeTimer.Stop(); 
            lblDurum.Text = "Sistem Hazır. Lütfen Kart Okutun...";
            lblDurum.ForeColor = System.Drawing.Color.Blue;
        }

        private void btnPersonelYonetimi_Click(object sender, EventArgs e)
        {
            FrmPersonel1 frm = new FrmPersonel1();
            FormGetir(frm);
        }

        private void btnKartYonetimi_Click(object sender, EventArgs e)
        {
            FrmKart frm = new FrmKart();
            FormGetir(frm);
        }

        private void FormGetir(Form frm)
        {
            try
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                Control container = null;
                if (this.Controls.ContainsKey("panel1")) container = this.Controls["panel1"];
                else if (this.Controls.ContainsKey("panelMain")) container = this.Controls["panelMain"];
                else container = this;
                container.Controls.Clear();
                container.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();
            }
            catch
            {
                frm.Show();
            }
        }

        private void VeritabaniniHazirla()
        {
            string dbPath = "IKSistemi.db";
            string connString = "Data Source=IKSistemi.db;Version=3;";

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = @"
                        CREATE TABLE Personeller (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Ad TEXT, 
                            Soyad TEXT,
                            Telefon TEXT,
                            Adres TEXT,
                            Departman TEXT,
                            KartUID TEXT UNIQUE
                        );
                        CREATE TABLE GirisCikis (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            KartUID TEXT, 
                            IslemZamani TEXT, 
                            Durum TEXT
                        );";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void giris_Load(object sender, EventArgs e)
        {
            VeritabaniniHazirla();
            string[] portlar = SerialPort.GetPortNames();
            cmbPort.Items.AddRange(portlar);
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            if (cmbPort.SelectedIndex != -1)
            {
                // Eğer port zaten açıksa önce kapatalım ki hata vermesin
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                serialPort1.PortName = cmbPort.SelectedItem.ToString();
                serialPort1.BaudRate = 9600;
                serialPort1.Open();

                lblDurum.Text = "Sistem Hazır. Lütfen Kart Okutun...";
                lblDurum.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                MessageBox.Show("Lütfen önce listeden bir Port seçin!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Port kapalıysa veya veri gelmediyse işlemi durdur 
                if (!serialPort1.IsOpen || serialPort1.BytesToRead == 0) return;

                string okunanUID = serialPort1.ReadLine().Trim();

                //Gelen veri boşsa işlem yapma
                if (string.IsNullOrEmpty(okunanUID)) return;

                SonOkunanKart = okunanUID;

                string simdikizaman = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                this.Invoke(new MethodInvoker(delegate {

                    //Personel kontrolü 
                    bool personelVarMi = false;
                    string adSoyad = "";

                    using (var conn = new SQLiteConnection("Data Source=IKSistemi.db;Version=3;"))
                    {
                        conn.Open();
                        string query = "SELECT Ad, Soyad FROM Personeller WHERE KartUID=@uid";
                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", okunanUID);
                            using (var dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    personelVarMi = true;
                                    adSoyad = dr["Ad"].ToString() + " " + dr["Soyad"].ToString();
                                }
                            }
                        }
                    }

                    // Loglama işlemi ve Giriş/Çıkış Algoritması
                    using (var conn = new SQLiteConnection("Data Source=IKSistemi.db;Version=3;"))
                    {
                        conn.Open();
                        if (personelVarMi)
                        {
                            // Kişinin son işlemini buluyoruz
                            string sonDurum = "Çıkış Yaptı"; 
                            string checkLastQuery = "SELECT Durum FROM GirisCikis WHERE KartUID = @uid AND Durum != 'Geçersiz Kart Denemesi' ORDER BY Id DESC LIMIT 1";

                            using (var cmdLast = new SQLiteCommand(checkLastQuery, conn))
                            {
                                cmdLast.Parameters.AddWithValue("@uid", okunanUID);
                                object result = cmdLast.ExecuteScalar();
                                if (result != null)
                                {
                                    sonDurum = result.ToString();
                                }
                            }

                          
                            string yeniDurum = (sonDurum == "Giriş Yaptı") ? "Çıkış Yaptı" : "Giriş Yaptı";
                            System.Drawing.Color mesajRengi = (yeniDurum == "Giriş Yaptı") ? System.Drawing.Color.Green : System.Drawing.Color.Orange;

                           
                            string karsilamaMetni = (yeniDurum == "Giriş Yaptı") ? "Hoşgeldin" : "İyi Günler";

                            lblDurum.Text = $"{yeniDurum}!\n{karsilamaMetni}, {adSoyad}\nSaat: {simdikizaman}";
                            lblDurum.ForeColor = mesajRengi;

                      
                            string insertQuery = "INSERT INTO GirisCikis (KartUID, IslemZamani, Durum) VALUES (@uid, @tarih, @durum)";
                            using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@uid", okunanUID);
                                insertCmd.Parameters.AddWithValue("@tarih", simdikizaman);
                                insertCmd.Parameters.AddWithValue("@durum", yeniDurum);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            lblDurum.Text = $"GEÇERSİZ KART!\nTanımsız Kart: {okunanUID}\nSaat: {simdikizaman}";
                            lblDurum.ForeColor = System.Drawing.Color.Red;

                            string insertQuery = "INSERT INTO GirisCikis (KartUID, IslemZamani, Durum) VALUES (@uid, @tarih, 'Geçersiz Kart Denemesi')";
                            using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@uid", okunanUID);
                                insertCmd.Parameters.AddWithValue("@tarih", simdikizaman);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    bekletmeTimer.Start();
                }));
            }
            catch (System.IO.IOException)
            {
                //  Arka planda port bağlantısı koparsa veya hayalet sinyal gelirse
                // bu hatayı tamamen sessizce yoksayıyoruz. Program çökmüyor.
            }
            catch (Exception ex)
            {
                // Kalan diğer beklenmedik hatalar için (İsteğe bağlı konsola yazdırılabilir)
                Console.WriteLine("Beklenmeyen Hata: " + ex.Message);
            }
        }
    }
}