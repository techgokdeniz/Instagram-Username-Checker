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
            btn4.Enabled = false;
            textBox2.Enabled = false;
           
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
            int adet = listBox1.Items.Count;
            int values = 100 / adet;
            if(adet==0)
            {
                MessageBox.Show("LIST IS EMPTY");
            }
            else
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {

                    progressBar1.Value = progressBar1.Value + values;
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
            }

            progressBar1.Value = 0;
            button1.Enabled = true;
            listBox1.Items.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            btn4.Enabled = true;
            textBox2.Enabled = true;
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                if(op.ShowDialog()==DialogResult.OK)
                {
                    textBox2.Text = op.FileName;
                }
            }
            catch
            {

            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(textBox2.Text.Trim());
                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
                catch { }
            }
            catch
            {

            }

        }

        
    }
}
