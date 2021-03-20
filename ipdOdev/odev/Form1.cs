using System;
using System.Reflection;
using System.Windows.Forms;

namespace ipdOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adres = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                
                double x = Convert.ToDouble(textBox1.Text);

                var DllAdresi = Assembly.LoadFile(adres +@"\hesaplama.dll").GetType("hesaplama.hesaplama");
                var getHesapla = Activator.CreateInstance(DllAdresi);
                var hesaplaFunk = DllAdresi.GetMethod("Hesaplama");
                var sonuc = (double)hesaplaFunk.Invoke(getHesapla, new object[] { x });

                Console.WriteLine(sonuc);
                label1.Text = "Sonuc = ";
                label1.Text += sonuc.ToString();
            }
                
        }
    }
}
