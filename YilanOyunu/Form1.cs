using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YilanOyunu
{
    public partial class Form1 : Form
    {
        private Label yilanKafasi;
        private int yilanParcasiArasiMesafe = 2;
        private int yilanParcasiSayisi;
        private int yilanBoyutu=20;
        private int yemBoyutu = 20;
        private Label yem;
        private Random rnd;
        private HareketYonu yon;
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yilanParcasiSayisi = 0;
            YemOlustur();
            YeminYeriniDegistir();
            YilaniYerlestir();
            yon = HareketYonu.Saga;
            timerYılanHaraket.Enabled = true;
            Sifirla();
        }
        private void YenidenBaslat()
        {
            lblPuan2.Text = "0";
            lblSure.Text = "0";
            Sifirla();
        }
        private void Sifirla()
        {
            this.pnl.Controls.Clear();
            yilanParcasiSayisi = 0;
            YemOlustur();
            YeminYeriniDegistir();
            YilaniYerlestir();
            yon = HareketYonu.Saga;
            timerYılanHaraket.Enabled = true;
            timer1.Enabled = true;
        }
        public Label YilanParcasiOlustur(int locationX, int locationY)
        {
            yilanParcasiSayisi++;
            //yılanı lbl ile oluşturuyoruz
            Label lbl = new Label()
            {
                Name = "yilanParca" + yilanParcasiSayisi,
                BackColor = Color.Red,
                Width = yilanBoyutu,
                Height= yilanBoyutu,
                Location = new Point(locationX, locationY)
            };
            //kontrol ediceğimiz labeli panelin içine ekleme yapıyoruz
            this.pnl.Controls.Add(lbl);
            return lbl;
        }
        private void YilaniYerlestir()
        {
            yilanKafasi = YilanParcasiOlustur(0,0);
            yilanKafasi.Text = ":";
            yilanKafasi.TextAlign = ContentAlignment.MiddleCenter;
            yilanKafasi.ForeColor = Color.White;
            //paneli yılanı ortaya oturtmak için ikiye bölme işlemi yapıyoruz
            var locationX = (pnl.Width / 2) - (yilanKafasi.Width / 2);
            var locationY = (pnl.Height / 2) - (yilanKafasi.Height / 2);
            yilanKafasi.Location = new Point(locationX, locationY);
        }
        private void YemOlustur()
        {
            Label lbl = new Label()
            {
                Name = "yem",
                BackColor = Color.Yellow,
                Width = yemBoyutu,
                Height = yemBoyutu,
                
            };
            yem = lbl;
            //kontrol ediceğimiz labeli panelin içine ekleme yapıyoruz
            this.pnl.Controls.Add(lbl);
            
        }
        //yılan yem ile temas ettiğinde yemin yerini değiştirir
        private void YeminYeriniDegistir()
        {
            var locationX = 0;
            var locationY = 0;

            bool durum;
            do
            {
                durum = false;
                //yemin oluşacağı yerin locationını random belirleme
                locationX = rnd.Next(0, pnl.Width - yemBoyutu);
                locationY = rnd.Next(0, pnl.Height - yemBoyutu);
                //yilanın konumunu bulma
                var rect1 = new Rectangle(new Point(locationX, locationY), yem.Size);
                foreach (Control control in pnl.Controls)
                {
                    //gelen control label ise ve içinde Name i yilanParca geçiyorsa
                    if (control is Label && control.Name.Contains("yilanParca"))
                    {
                        var rect2 = new Rectangle(control.Location, control.Size);
                        //yem yılanın üzerine gelip gelmediğini kontrol için
                        if (rect1.IntersectsWith(rect2))
                        {
                            durum = true;
                            break;
                        }
                    }
                }
            } 
            while (durum);
            yem.Location = new Point(locationX, locationY);
        }
        private enum HareketYonu
        {
            Yukari,
            Asagi,
            Sola,
            Saga
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //basılan tuşu keycode aktarıyor
            var keyCode = e.KeyCode;
            if (yon == HareketYonu.Sola && keyCode == Keys.D
                || yon == HareketYonu.Saga && keyCode == Keys.A
                || yon == HareketYonu.Yukari && keyCode == Keys.S
                || yon == HareketYonu.Asagi && keyCode == Keys.W)
            {
                return;
            }


            
            //basılan tuşa göre yön veriyor
            switch (keyCode) 
            {
                case Keys.W:
                    yon = HareketYonu.Yukari;
                    break;
                case Keys.S:
                    yon = HareketYonu.Asagi;
                    break;
                case Keys.A:
                    yon = HareketYonu.Sola;
                    break;
                case Keys.D:
                    yon = HareketYonu.Saga;
                    break;
                //p tuşuna basılırsa oyun duru
                case Keys.P:
                    timerYılanHaraket.Enabled = false;
                    timer1.Enabled = false;
                    break;
                //c tuşuna basılırsa oyun devam eder
                case Keys.C:
                    timerYılanHaraket.Enabled = true;
                    timer1.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void timerYılanHaraket_Tick(object sender, EventArgs e)
        {
            YilanKafasiTakipEt();
            YilaniYurut();
            YilanYemiYedimi();
            OyunBittimi();
        }

        private void YilaniYurut()
        {
            var locationX = yilanKafasi.Location.X;
            var locationY = yilanKafasi.Location.Y;
            switch (yon)
            {
                case HareketYonu.Yukari:
                    //yılanın boyutu kadar arasinda 2 cm olucak şekilde yukarı kayar
                    yilanKafasi.Location = new Point(locationX, locationY - (yilanKafasi.Width + yilanParcasiArasiMesafe));
                    break;
                case HareketYonu.Asagi:
                    yilanKafasi.Location = new Point(locationX, locationY + (yilanKafasi.Width + yilanParcasiArasiMesafe));
                    break;
                case HareketYonu.Sola:
                    yilanKafasi.Location = new Point(locationX - (yilanKafasi.Width + yilanParcasiArasiMesafe), locationY);
                    break;
                case HareketYonu.Saga:
                    yilanKafasi.Location = new Point(locationX + (yilanKafasi.Width + yilanParcasiArasiMesafe), locationY);
                    break;
                default:
                    break;
            }
        }

        private void YilanKafasiTakipEt()
        {
            //yilan parcası birden küçük veya eşitse for döngüsüne girmesin
            if (yilanParcasiSayisi <= 1) return;
            for (int i = yilanParcasiSayisi; i> 1; i--)
            {
                var sonrakiParca = (Label)pnl.Controls[i];
                var oncekiParca = (Label)pnl.Controls[i-1];
                sonrakiParca.Location = oncekiParca.Location;
            }
        }
        private void OyunBittimi()
        {
            bool OyunBitti = false;
            //yılanın locationı
            var rect1 = new Rectangle(yilanKafasi.Location, yilanKafasi.Size);
            foreach (Control control in pnl.Controls)
            {
                if (control is Label && control.Name.Contains("yilanParca") && control.Name != yilanKafasi.Name)
                {
                    var rect2 = new Rectangle(control.Location, control.Size);
                    if (rect1.IntersectsWith(rect2))
                    {
                        OyunBitti = true;
                        break;
                    }
                }
            }
            if (OyunBitti)
            {
                timerYılanHaraket.Enabled = false;
                timer1.Enabled = false;
                DialogResult sonuc = MessageBox.Show("Puanınız: "+lblPuan2.Text,"Oyun Bitti",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                if (sonuc==DialogResult.OK)
                {
                    YenidenBaslat();
                }
            }
        }
        private void YilanYemiYedimi()
        {
            //yılanın locationı
            var rect1 = new Rectangle(yilanKafasi.Location, yilanKafasi.Size);
            //yemin locationı
            var rect2 = new Rectangle(yem.Location, yilanKafasi.Size);

            if (rect1.IntersectsWith(rect2))
            {
                lblPuan2.Text = (Convert.ToInt32(lblPuan2.Text) + 10).ToString();
                YeminYeriniDegistir();
                //panelin dışında lbl oluşturmak için 
                YilanParcasiOlustur(-yilanBoyutu,-yilanBoyutu);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSure.Text = (Convert.ToInt32(lblSure.Text) + 1).ToString();
        }
    }
}
