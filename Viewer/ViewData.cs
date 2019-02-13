using AppLog;
using Newtonsoft.Json;
using OSYM_Crawler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public class ViewData
    {
        public static string Baslik { get; set; }

        public static SinavTakvimi VerileriGoster(string filename, DataGridView gridview)
        {
            gridview.Rows.Clear();
            gridview.Columns.Clear();
            SinavTakvimi sinav_takvimi = null;
            try
            {
                StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
                sinav_takvimi = JsonConvert.DeserializeObject<SinavTakvimi>(sr.ReadToEnd());
                sr.Close();

                Baslik = sinav_takvimi.Baslik + " ("+ sinav_takvimi.Donem + ")";

                List<Sinav> sinavlar = sinav_takvimi.Sinavlar.ToList();
                DataGridViewTextBoxColumn sirano_kolonu = new DataGridViewTextBoxColumn();
                sirano_kolonu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                sirano_kolonu.FillWeight = 30;
                sirano_kolonu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridview.Columns.Add(sirano_kolonu);

                foreach (Kolon kolon in sinav_takvimi.Kolonlar)
                {
                    DataGridViewTextBoxColumn text_kolonu = new DataGridViewTextBoxColumn();
                    text_kolonu.Name = kolon.Etiketi;
                    text_kolonu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    text_kolonu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    gridview.Columns.Add(text_kolonu);
                }

                foreach (Sinav sinav in sinavlar)
                {
                    int satir_no = gridview.Rows.Add();
                    DataGridViewRow satir = gridview.Rows[satir_no];
                    satir.Cells[0].Value = satir_no + 1;
                    satir.Cells[1].Value = sinav.Adi + " - " + sinav.KisaAdi;
                    if (sinav.Tarihi.HasValue)
                    {
                        int zaman_farki = (sinav.Tarihi.Value - DateTime.Now).Days;
                        int zaman_farki_ay = (zaman_farki / 30);
                        string uyari = " (";
                        if (zaman_farki < 0)
                        {
                            zaman_farki = Math.Abs(zaman_farki);
                            if (zaman_farki < 30)
                            {
                                uyari += zaman_farki + " gün geçmiş)";
                            }
                            else
                            {
                                uyari += zaman_farki_ay + " ay geçmiş)";
                            }
                        }
                        else
                        {
                            if (zaman_farki == 0)
                            {
                                uyari = "Bugün son gün!)";
                            }
                            else if (zaman_farki < 30)
                            {
                                uyari += zaman_farki + " gün var)";
                            }
                            else
                            {
                                zaman_farki_ay = (zaman_farki / 30);
                                uyari += zaman_farki_ay + " ay var)";
                            }
                        }
                        satir.Cells[2].Value = sinav.Tarihi.Value.ToShortDateString() + uyari;
                    }
                    if (sinav.Basvuru != null)
                    {
                        foreach (Basvuru basvuru in sinav.Basvuru)
                        {
                            satir.Cells[3].Value += basvuru.Turu + (basvuru.Turu != null ? "\r\n" : "");
                            int zaman_farki = (basvuru.BaslangicTarihi.Value - DateTime.Now).Days;
                            string uyari = " (";
                            if (zaman_farki < 0)
                            {
                                uyari += "Başvurular başlamış)";
                            }
                            else
                            {
                                if (zaman_farki == 0)
                                {
                                    uyari += "Bugün başladı!)";
                                }
                                else if (zaman_farki < 30)
                                {
                                    uyari += zaman_farki + " gün var)";
                                }
                                else
                                {
                                    int zaman_farki_ay = (zaman_farki / 30);
                                    uyari += zaman_farki_ay + " ay var)";
                                }
                            }
                            satir.Cells[3].Value += basvuru.BaslangicTarihi.Value.ToShortDateString() + uyari + "\r\n";
                            zaman_farki = (basvuru.BitisTarihi.Value - DateTime.Now).Days;
                            uyari = " (";
                            if (zaman_farki < 0)
                            {
                                uyari += "Başvurular bitmiş!)";
                            }
                            else
                            {
                                if (zaman_farki == 0)
                                {
                                    uyari += "Bugün son gün!)";
                                }
                                else if (zaman_farki < 30)
                                {
                                    uyari += zaman_farki + " gün var)";
                                }
                                else
                                {
                                    int zaman_farki_ay = (zaman_farki / 30);
                                    uyari += zaman_farki_ay + " ay var)";
                                }
                            }
                            satir.Cells[3].Value += basvuru.BitisTarihi.Value.ToShortDateString() + uyari + ((basvuru.Turu != null && sinav.Basvuru.Last() != basvuru) ? "\r\n" : "");
                        }
                    }
                    if (sinav.GecBasvuru != null)
                    {
                        foreach (Basvuru basvuru in sinav.GecBasvuru)
                        {
                            satir.Cells[4].Value += basvuru.Turu + (basvuru.Turu != null ? "\r\n" : "");
                            int zaman_farki = (basvuru.BaslangicTarihi.Value - DateTime.Now).Days;
                            string uyari = " (";
                            if (zaman_farki < 0)
                            {
                                uyari += "Başvurular başlamış)";
                            }
                            else
                            {
                                if (zaman_farki == 0)
                                {
                                    uyari += "Bugün başladı!)";
                                }
                                else if (zaman_farki < 30)
                                {
                                    uyari += zaman_farki + " gün var)";
                                }
                                else
                                {
                                    int zaman_farki_ay = (zaman_farki / 30);
                                    uyari += zaman_farki_ay + " ay var)";
                                }
                            }
                            satir.Cells[4].Value += basvuru.BaslangicTarihi.Value.ToShortDateString() + uyari + "\r\n";
                            zaman_farki = (basvuru.BitisTarihi.Value - DateTime.Now).Days;
                            uyari = " (";
                            if (zaman_farki < 0)
                            {
                                uyari += "Başvurular bitmiş!)";
                            }
                            else
                            {
                                if (zaman_farki == 0)
                                {
                                    uyari += "Bugün son gün!)";
                                }
                                else if (zaman_farki < 30)
                                {
                                    uyari += zaman_farki + " gün var)";
                                }
                                else
                                {
                                    int zaman_farki_ay = (zaman_farki / 30);
                                    uyari += zaman_farki_ay + " ay var)";
                                }
                            }
                            satir.Cells[4].Value += basvuru.BitisTarihi.Value.ToShortDateString() + uyari + ((basvuru.Turu != null && sinav.GecBasvuru.Last() != basvuru) ? "\r\n" : "");
                        }
                    }
                    if (sinav.SonucAciklamaTarihi.HasValue)
                    {
                        int zaman_farki = (sinav.SonucAciklamaTarihi.Value - DateTime.Now).Days;
                        string uyari = " (";
                        if (zaman_farki < 0)
                        {
                            uyari += "Açıklanmış!)";
                        }
                        else
                        {
                            if (zaman_farki == 0)
                            {
                                uyari += "Bu gün açıklanıyor!)";
                            }
                            else if (zaman_farki < 30)
                            {
                                uyari += zaman_farki + " gün var)";
                            }
                            else
                            {
                                int zaman_farki_ay = (zaman_farki / 30);
                                uyari += zaman_farki_ay + " ay var)";
                            }
                        }
                        satir.Cells[5].Value = sinav.SonucAciklamaTarihi.Value.ToShortDateString() + uyari;
                    }
                    satir.Tag = sinav;
                }
            }
            catch (Exception ex)
            {
                Log.e(ex.Message);
            }
            return sinav_takvimi;
        }
    }
}
