using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;


namespace İnstagramChecker
{
    public partial class Form1 : Form
    {

        public static Form1 form1 = new Form1();
        HttpClient baglanti = new HttpClient();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Boş Metin Girilemez");
            }
            else
            {
                listBox1.Items.Add(textBox1.Text.ToString());
            }
            textBox1.Text = "";
        }

        public async void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            int adet = (100/listBox1.Items.Count);
            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                progressBar1.Value = progressBar1.Value + adet;
                var url = "https://www.instagram.com/";
                string kullaniciadi = listBox1.Items[i].ToString();
                HttpResponseMessage httpResponseMessage = await baglanti.GetAsync(url + kullaniciadi);
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    listBox2.Items.Add(kullaniciadi + " Kullanımda");
                }
                else
                {
                    listBox2.Items.Add(kullaniciadi + " Boş");
                }
            }
            progressBar1.Value = 0;
            button1.Enabled = true;
            listBox1.Items.Clear();

        }

       
       
    }
}
