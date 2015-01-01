using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace db_encrypt_decrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Sorry File To Process cannot be empty!"); return;
            }
            if (!File.Exists(textBox1.Text.Trim()))
            {
                MessageBox.Show("No File Found!"); return;
            }

            bool isEncrypt = false;
            string str = "";
            string key = "Leamlidara@168!amb*";
            try
            {
                str = Security.DecryptStringAES(File.ReadAllText(textBox1.Text.Trim()), key);
            }
            catch {
                str = Security.EncryptStringAES(File.ReadAllText(textBox1.Text.Trim()), key);
                isEncrypt = true;
            }
            File.Delete(textBox1.Text.Trim());
                File.WriteAllText(textBox1.Text.Trim(), str);
                if (isEncrypt == true) MessageBox.Show("Encrypt Success!");
                else MessageBox.Show("Decrypt Success!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}
