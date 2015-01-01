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

namespace PHP_obfucator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            fileState = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/phpobfu.bin";
            separator = ";;;)0;;";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(733, 242);
            webBrowser1.Navigate("about:blank");
            loadState();
            webBrowser1.DocumentCompleted += delegate {
                webBrowser1.Document.Window.ScrollTo(new Point(0, webBrowser1.Document.Body.ScrollRectangle.Height));
            };
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            showFolderSelector(txtSource, "ការជ្រើសរើស ទីតាំងប្រភពឯកសារ");
        }

        bool isStop = false;
        string fileState;
        string separator = ";;;)0;;";
        void showFolderSelector(TextBox txt, string title)
        {
            bool isValid = false;
            while (isValid == false)
            {
                fileFolderDialog1.Dialog.Title = title;
                DialogResult dResult = fileFolderDialog1.ShowDialog();
                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    txt.Text = fileFolderDialog1.SelectedPath;
                    if (System.IO.File.Exists(txt.Text))
                    {
                        txt.Text = System.IO.Directory.GetParent(txt.Text).FullName;
                    }

                    isValid = true;
                }
                else if (dResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    isValid = true;
                }
                saveState();
            }
        }

        private string status = "";
        private void btnProtect_Click(object sender, EventArgs e)
        {
            saveState();
            if (btnProtect.Text == "ការពារ")
            {
                if (txtSource.Text == "")
                {
                    MessageBox.Show("សូមអភ័យទោស ទីតាំងប្រភពឯកសារ មិនអាចទទេរបានទេ!");
                    return;
                }
                if (txtDest.Text == "")
                {
                    MessageBox.Show("សូមអភ័យទោស ទីតាំងគោលដៅឯកសារ មិនអាចទទេរបានទេ!");
                    return;
                }

                status = "";
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.Value = 20;
                this.Size = new Size(733, 501);   
                btnSource.Enabled = false;
                btnDest.Enabled = false;
                groupBox1.Enabled = false;
                btnProtect.Text = "បោះបង់";
                this.Refresh();
                isStop = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                isStop = true;
                backgroundWorker1.CancelAsync();
                while (backgroundWorker1.IsBusy) Application.DoEvents();
                addStatus("ការការពារត្រូវបានបញ្ចប់ដោយអ្នកប្រើប្រាស់");
                enableControls();
            }
        }

        void addStatus(string html_Status)
        {
            statements(delegate
            {
                status += html_Status + "<br/>";
                webBrowser1.DocumentText = "<body style='background-color:#f0f0f0; border:1px solid #fff; width:100%;'><div style='width:auto; white-space: nowrap'>" + status + "</div></body>";
            });
        }

        void setPercent(int percent)
        {
            statements(delegate
           {
               progressBar1.Value = percent;
           });
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            addStatus("កំពុងដំណើរការ...");
            System.Threading.Thread.Sleep(1000);
            addStatus("កំពុងចម្លងឯកសារ...");
            core d_core = new core();
            string searchPattern = "*.*";

            statements(delegate
            {
                if (chkCopyPhpOnly.Checked) searchPattern = "*.php";
            });

            if (Directory.Exists(txtDest.Text) == false) Directory.CreateDirectory(txtDest.Text);
            {
                string[] f = Directory.GetFiles(txtDest.Text, "*.*", SearchOption.AllDirectories);
                if (f.Length > 0)
                {
                    if (MessageBox.Show("ទីតាំងគោលដៅឯកសារ មិនមែនជាទីតាំងទទេរទេ។ តើ​លោក​អ្នក​ចង់ឱ្យ​កម្មវិធី​ធ្វើការ​បង្កើត​ទីតាំងថ្មី​ដែល​មាន​ឈ្មោះ​ប្រហាក់​ប្រហែល​នេះដែរឬទេ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int a = 0;
                        string sub = "";
                        while (Directory.Exists(txtDest.Text + " " + sub))
                        {
                            a++;
                            sub = " (" + a + ")";
                        }
                        statements(delegate { txtDest.Text += " " + sub; });
                    }
                    else
                    {
                        addStatus("ការការពារត្រូវបានបញ្ចប់។ សូមមេត្តាជ្រើរើសទីតាំងគោលដៅឯកសារ ឱ្យបានត្រឹមត្រូវ");
                        enableControls();
                        return;
                    }
                }
                f = new string[0];
            }

            d_core.copyFiles(txtSource.Text.Trim(), txtDest.Text.Trim(), searchPattern);

            addStatus("ស្វែងរកឯកសារត្រូវការពារ...");
            string[] files = Directory.GetFiles(txtDest.Text.Trim(), "*.php", SearchOption.AllDirectories);
            addStatus("រកឃើញឯកសារចំនួន <b>" + files.Length.convertToKhmer() + "</b> ដែលត្រូវការពារ...");
            addStatus("រៀបចំដំណើរការការពារ...");
            statements(delegate
            {
                d_core.protectVariable = chkProtectVariable.Checked;
                d_core.protectFunction = chkProtectFunction.Checked;
                d_core.protectClass = chkProtectClass.Checked;
                d_core.advanceProtect = chkAdvanceProtect.Checked;
            });
            d_core.sniff_variables(txtSource.Text.Trim());

            addStatus("ចាប់ផ្តើមដំណើរការការពារ...");

            statements(delegate
            {
                progressBar1.Value = 0;
                progressBar1.Style = ProgressBarStyle.Blocks;
            });


            int i = 0;
            foreach (string fileName in files)
            {
                if (isStop == true) return;
                addStatus("ការពារ៖ <b>" + fileName + "</b>");
                try
                {
                    d_core.startObfucate(fileName);
                    addStatus("---------->ស្ថានភាព៖ ជោគជ័យ");
                    i++;
                }
                catch  { addStatus("---------->ស្ថានភាព៖ បរាជ័យ"); }
            }

            enableControls();
            addStatus("ឯកសារចំនួន <b>" + i.convertToKhmer() + "</b> ត្រូវបានការពារ!");
        }

        void enableControls()
        {
            isStop = false;
            statements(delegate
            {
                progressBar1.Value = 100;
                progressBar1.Style = ProgressBarStyle.Blocks;
                btnSource.Enabled = true;
                groupBox1.Enabled = true;
                btnDest.Enabled = true;
                btnProtect.Text = "ការពារ";
            });
        }

        void statements(Action ac)
        {
            this.Invoke(new MethodInvoker(ac));
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            showFolderSelector(txtDest, "ការជ្រើសរើស ទីតាំងគោលដៅឯកសារ");
        }

        private void saveState(){
            string dest = txtDest.Text.Trim() + separator + txtSource.Text.Trim() + separator;
            string ch = (chkCopyPhpOnly.Checked ? "1" : "0") + "|" + (chkAdvanceProtect.Checked ? "1" : "0") + "|" +
                 (chkProtectVariable.Checked ? "1" : "0") + "|" + (chkProtectFunction.Checked ? "1" : "0") + "|" +
                 (chkProtectClass.Checked ? "1" : "0");
            dest += ch;
            dest = dest.CompressString();
            File.WriteAllText(fileState, dest);
        }

        private void loadState()
        {
            if (File.Exists(fileState))
            {
                Func<string, bool> fn = new Func<string,bool>(delegate(string s){
                    if (s == "1") return true;
                    return false;
                });

                string str = File.ReadAllText(fileState);
                str = str.DecompressString();
                string[] a = str.Split(new string[] { separator }, StringSplitOptions.None);
                txtDest.Text = a[0];
                txtSource.Text = a[1];
                str = a[2];
                a = str.Split('|');
                chkCopyPhpOnly.Checked = fn(a[0]);
                chkAdvanceProtect.Checked = fn(a[1]);
                chkProtectVariable.Checked = fn(a[2]);
                chkProtectFunction.Checked = fn(a[3]);
                chkProtectClass.Checked = fn(a[4]);
            }
            else
            {
                label3_Click(null, null);
            }
        }

        private void chkAdvanceProtect_CheckedChanged(object sender, EventArgs e)
        {
            saveState();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.ShowDialog();
        }

    }
}
