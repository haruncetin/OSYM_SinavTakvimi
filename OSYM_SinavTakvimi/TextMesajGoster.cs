using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSYM_SinavTakvimi
{
    public partial class TextMesajGoster : Form
    {
        public string Mesaj { get; private set; }
        public string Baslik { get; private set; }

        public TextMesajGoster()
        {
            InitializeComponent();
        }

        public TextMesajGoster(string mesaj, string baslik)
        {
            this.Mesaj = mesaj;
            this.Baslik = baslik;
            InitializeComponent();
        }

        private void TextMesajGoster_Load(object sender, EventArgs e)
        {
            this.Text = this.Baslik;
            richTextBox1.Font = new Font(new FontFamily("Courier New"), 11, FontStyle.Regular);
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = this.Mesaj;
        }
    }
}
