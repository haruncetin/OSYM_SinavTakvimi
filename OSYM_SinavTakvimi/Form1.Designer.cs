namespace OSYM_SinavTakvimi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTakvim = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.update_app = new System.Windows.Forms.ToolStripMenuItem();
            this.update_db = new System.Windows.Forms.ToolStripMenuItem();
            this.app_log = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.txtDonem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTakvimSec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtUyarilar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakvim)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTakvim
            // 
            this.dgvTakvim.AllowUserToAddRows = false;
            this.dgvTakvim.AllowUserToDeleteRows = false;
            this.dgvTakvim.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTakvim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTakvim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTakvim.Location = new System.Drawing.Point(0, 0);
            this.dgvTakvim.Name = "dgvTakvim";
            this.dgvTakvim.ReadOnly = true;
            this.dgvTakvim.RowHeadersVisible = false;
            this.dgvTakvim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTakvim.Size = new System.Drawing.Size(951, 293);
            this.dgvTakvim.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(951, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts
            // 
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(34, 17);
            this.ts.Text = "Hazır";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.update_app,
            this.update_db,
            this.app_log,
            this.about,
            this.help,
            this.exit});
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(54, 20);
            this.toolStripSplitButton1.Text = "Menü";
            // 
            // update_app
            // 
            this.update_app.Name = "update_app";
            this.update_app.Size = new System.Drawing.Size(226, 22);
            this.update_app.Text = "Güncellemeleri Denetle";
            this.update_app.Click += new System.EventHandler(this.update_app_Click);
            // 
            // update_db
            // 
            this.update_db.Name = "update_db";
            this.update_db.Size = new System.Drawing.Size(226, 22);
            this.update_db.Text = "Takvim Veritabanını Güncelle";
            this.update_db.Click += new System.EventHandler(this.update_db_Click);
            // 
            // app_log
            // 
            this.app_log.Name = "app_log";
            this.app_log.Size = new System.Drawing.Size(226, 22);
            this.app_log.Text = "Uygulama Günlük Kaydı";
            this.app_log.Click += new System.EventHandler(this.app_log_Click);
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(226, 22);
            this.about.Text = "Hakkında";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(226, 22);
            this.help.Text = "Yardım";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(226, 22);
            this.exit.Text = "Çıkış";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAra);
            this.panel1.Controls.Add(this.txtDonem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbTakvimSec);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 45);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ara";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(590, 14);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(349, 20);
            this.txtAra.TabIndex = 4;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // txtDonem
            // 
            this.txtDonem.Enabled = false;
            this.txtDonem.Location = new System.Drawing.Point(396, 14);
            this.txtDonem.Name = "txtDonem";
            this.txtDonem.ReadOnly = true;
            this.txtDonem.Size = new System.Drawing.Size(73, 20);
            this.txtDonem.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dönem";
            // 
            // cbTakvimSec
            // 
            this.cbTakvimSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTakvimSec.FormattingEnabled = true;
            this.cbTakvimSec.Location = new System.Drawing.Point(90, 14);
            this.cbTakvimSec.Name = "cbTakvimSec";
            this.cbTakvimSec.Size = new System.Drawing.Size(242, 21);
            this.cbTakvimSec.TabIndex = 1;
            this.cbTakvimSec.SelectedIndexChanged += new System.EventHandler(this.cbTakvimSec_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Takvim Seçin";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(951, 412);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTakvim);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtUyarilar);
            this.splitContainer1.Size = new System.Drawing.Size(951, 412);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtUyarilar
            // 
            this.txtUyarilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUyarilar.Location = new System.Drawing.Point(0, 0);
            this.txtUyarilar.Multiline = true;
            this.txtUyarilar.Name = "txtUyarilar";
            this.txtUyarilar.Size = new System.Drawing.Size(951, 115);
            this.txtUyarilar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 479);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakvim)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTakvim;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem update_app;
        private System.Windows.Forms.ToolStripMenuItem update_db;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem app_log;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTakvimSec;
        private System.Windows.Forms.TextBox txtDonem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtUyarilar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAra;
    }
}

