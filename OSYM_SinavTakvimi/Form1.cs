using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading;

namespace OSYM_SinavTakvimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] takvimler = Directory.GetFiles(".\\takvim_data", "*.json", SearchOption.AllDirectories);
            cbTakvimSec.Items.Clear();
            foreach (string takvim in takvimler)
            {
                FileInfo f_takvim = new FileInfo(takvim);

                cbTakvimSec.Items.Add(f_takvim.Name);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz?", this.Text, MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void update_db_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string filename = Crawler.OSYMdenGetir();
            if (filename != null)
            {
                Cursor = Cursors.Default;
                string[] takvimler = Directory.GetFiles(".\\takvim_data", "*.json", SearchOption.AllDirectories);
                cbTakvimSec.Items.Clear();
                foreach (string takvim in takvimler)
                {
                    FileInfo f_takvim = new FileInfo(takvim);

                    cbTakvimSec.Items.Add(f_takvim.Name);
                }
                SinavTakvimi tk = Takvim.DosyadanYukle(filename);
                this.Text = tk.Baslik + "(" + tk.Donem + ")";
                txtDonem.Text = tk.Donem.ToString();
                Takvim.Goster(tk, dgvTakvim);
                MessageBox.Show("Takvim veritabanı güncellendi!", this.Text);
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Takvim veritabanı güncelleneMEdi! Lütfen detaylar için günlük kaydına (app.log) bakın.", this.Text);
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            string mesaj = Properties.Settings.Default.about;
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream("about.txt", FileMode.Create));
                sw.Write(mesaj);
                sw.Close();
            }
            catch (Exception)
            {

            }
            new TextMesajGoster(mesaj, this.Text + " - Hakkında").ShowDialog();
        }

        private void update_app_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu işlev henüz hazır değil!", this.Text);
        }

        private void app_log_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(new FileStream("app.log", FileMode.Open));
                string logs = sr.ReadToEnd();
                new TextMesajGoster(logs, "Uygulama Günlüğü").ShowDialog();
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("app.log dosyası henüz mevcut değil ya da okunurken hata oluştu!", this.Text);
                this.Close();
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(new FileStream("help.txt", FileMode.Open));
                string logs = sr.ReadToEnd();
                new TextMesajGoster(logs, "Yardım").ShowDialog();
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("help.txt dosyası okunurken hata oluştu!", this.Text);
                this.Close();
            }
        }

        private void cbTakvimSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = ".\\takvim_data\\" + cbTakvimSec.SelectedItem.ToString();
            SinavTakvimi takvim = Takvim.DosyadanYukle(filename);
            this.Text = takvim.Baslik + "(" + takvim.Donem + ")";
            txtDonem.Text = takvim.Donem.ToString();
            StringBuilder sb = new StringBuilder();
            foreach (string item in takvim.Uyarilar)
            {
                sb.Append(item).Append("\r\n");
            }
            txtUyarilar.Text = sb.ToString();
            Takvim.Goster(takvim, dgvTakvim);
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            new Thread(()=>{
                dgvTakvim.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTakvim.ClearSelection();
                foreach (DataGridViewRow row in dgvTakvim.Rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        object cellValue = (cell as DataGridViewTextBoxCell).Value;
                        if (cellValue != null)
                        {
                            string textVal = cellValue.ToString();
                            Console.WriteLine(textVal);
                            if (textVal.Contains(txtAra.Text))
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
                if (txtAra.Text == string.Empty)
                {
                    dgvTakvim.ClearSelection();
                }
            }).Start();
        }
    }
}
