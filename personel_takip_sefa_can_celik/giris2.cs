using personel_takip_sefa_can_celik;
using System;
using System.Windows.Forms;

namespace PersonelTakipSistemi 
{
    public partial class Giriş : Form
    {
        // Formları burada tanımlıyoruz ki sekmeler arası geçişte 
        // içlerindeki veriler ve Arduino bağlantısı kaybolmasın
        giris frmGiris = new giris();
        FrmPersonel1 frmPersonel = new FrmPersonel1();
        FrmKart frmKart = new FrmKart();

        public Giriş()
        {
            InitializeComponent();
        }
        
        
        // Formları panele gömen metod
        private void FormGetir(Form frm)
        {
            
            panel1.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
            frm.Show();
        }

      
        private void btnGiris_Click(object sender, EventArgs e)
        {
            FormGetir(frmGiris);
        }

        
        private void btnPersonel_Click(object sender, EventArgs e)
        {
            FormGetir(frmPersonel);
        }

    
        private void btnKart_Click(object sender, EventArgs e)
        {
            FormGetir(frmKart);
        }

        private void btnGecmis_Click(object sender, EventArgs e)
        {
            FrmPersonelGecmis frmGecmis = new FrmPersonelGecmis();
            FormGetir(frmGecmis);
        }

  
        private void giris2_Load(object sender, EventArgs e)
        {
            FormGetir(frmGiris);
        }


    }
}