using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Not_Kayıt_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara; // public ile diğer formdan ulaşılabilir nesne türettik
        public string durum1;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FIKBBE9;Initial Catalog=DbNotKayıt;Integrated Security=True"); //bağlantı olduğunu @ ile beliritp connection cümlemizi yazıyoruz 
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
           
            baglanti.Open(); //oluşturduğumuz bağlantıyı open ile açtık
            SqlCommand komut = new SqlCommand("Select * From TBLDERS where OGRNUMARA=@p1", baglanti); //@ ile p1 e değere atayacağız
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text=dr[2].ToString() + " " + dr[3].ToString();
                LblSınav1.Text = dr[4].ToString();
                LblSınav2.Text = dr[5].ToString();
                LblSınav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();
            }
                   baglanti.Close();
                      
        }
    }
}
