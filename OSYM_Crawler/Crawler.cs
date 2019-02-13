using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLog;

namespace OSYM_Crawler
{
    public static class Crawler
    {
        public static bool Crawl_OSYM()
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                string osym_link = "http://www.osym.gov.tr";
                HtmlDocument document = web.Load(osym_link);
                HtmlNode sinav_takivimi_linki_nodu = document.DocumentNode.SelectSingleNode("//a[@id='DalLink2']");
                StringBuilder link_builder = new StringBuilder();
                link_builder.Append(osym_link);
                link_builder.Append(sinav_takivimi_linki_nodu.Attributes["href"].Value);
                HtmlDocument takvim_document = web.Load(link_builder.ToString());
                string takvim_basligi = takvim_document.DocumentNode.SelectSingleNode("//div[@id='upTakvim']/div/div[1]/h1").InnerText.Trim();
                HtmlNode[] takvim_tablosu = takvim_document.DocumentNode.SelectNodes("//div[@id='pnlSinavTakvimiBaslik']/following-sibling::div[@class='row']").ToArray();
                HtmlNode[] uyarilar = takvim_document.DocumentNode.SelectNodes("//div[@id='upTakvim']/div/div[3]").ToArray();
                SinavTakvimi sinav_takvimi = new SinavTakvimi();
                sinav_takvimi.Baslik = takvim_basligi;
                HtmlNode baslik_satiri = takvim_document.DocumentNode.SelectNodes("//div[@id='pnlSinavTakvimiBaslik']//div").FirstOrDefault(); //q_takvim_tablosu.Dequeue();
                int baslik_say = baslik_satiri.ChildNodes.Count;

                List<Kolon> kolonlar = new List<Kolon>();

                foreach (HtmlNode baslik in baslik_satiri.ChildNodes)
                {
                    String baslik_text = baslik.InnerText.Trim();
                    if (!baslik_text.Equals(String.Empty))
                    {
                        Log.i("Başlık Etiketi: " + baslik_text, false);
                        kolonlar.Add(new Kolon() { Etiketi = baslik_text });
                    }
                }

                Log.i("Başlık Kolonları sayısı: " + kolonlar.Count, false);

                sinav_takvimi.Kolonlar = kolonlar;

                List<Sinav> sinavlar = new List<Sinav>();
                foreach (HtmlNode item in takvim_tablosu)
                {
                    if (item.ChildNodes.Count > 1)
                    {
                        Sinav sinav = new Sinav();
                        HtmlNode[] sutunlar = item.Elements("div").ToArray();
                        HtmlNode sinavin_adi_nodu = sutunlar[0];
                        HtmlNode sinavin_tarihi_nodu = sutunlar[1];
                        HtmlNode basvuru_nodu = sutunlar[2];
                        HtmlNode gec_basvuru_nodu = sutunlar[3];
                        HtmlNode sonuc_tarihi_nodu = sutunlar[4];

                        sinav.Adi = sinavin_adi_nodu.SelectSingleNode(".//br/following-sibling::text()[1]").InnerText.Trim();
                        sinav.KisaAdi = sinavin_adi_nodu.Element("strong").InnerText.Trim();
                        sinav.Aciklama = sinavin_adi_nodu.SelectSingleNode(".//br/following-sibling::text()[2]").InnerText.Trim();
                        sinav.Baglanti = osym_link + sinavin_adi_nodu.Element("strong").Element("a").Attributes["href"].Value;

                        if (!sinavin_tarihi_nodu.InnerText.Trim().Equals(String.Empty))
                        {
                            sinav.Tarihi = DateTime.Parse(sinavin_tarihi_nodu.InnerText.Trim());
                        }
                        else
                        {
                            sinav.Tarihi = null;
                        }

                        if (!basvuru_nodu.InnerText.Trim().Equals(String.Empty))
                        {
                            Basvuru basvuru = new Basvuru();
                            string basvuru_baslangic_tarihi = basvuru_nodu.SelectSingleNode(".//br/preceding-sibling::text()").InnerText.Trim();
                            string basvuru_bitis_tarihi = basvuru_nodu.SelectSingleNode(".//br/following-sibling::text()").InnerText.Trim();
                            basvuru.BaslangicTarihi = DateTime.Parse(basvuru_baslangic_tarihi);
                            basvuru.BitisTarihi = DateTime.Parse(basvuru_bitis_tarihi);
                            sinav.Basvuru = new List<Basvuru>() { basvuru };
                        }
                        else
                        {
                            sinav.Basvuru = null;
                        }

                        if (!gec_basvuru_nodu.InnerText.Trim().Equals(String.Empty))
                        {
                            Basvuru gecbasvuru = new Basvuru();
                            string gec_basvuru_baslangic_tarihi = gec_basvuru_nodu.SelectSingleNode(".//br/preceding-sibling::text()").InnerText.Trim();
                            string gec_basvuru_bitis_tarihi = gec_basvuru_nodu.SelectSingleNode(".//br/following-sibling::text()").InnerText.Trim();
                            gecbasvuru.BaslangicTarihi = DateTime.Parse(gec_basvuru_baslangic_tarihi);
                            gecbasvuru.BitisTarihi = DateTime.Parse(gec_basvuru_bitis_tarihi);
                            sinav.GecBasvuru = new List<Basvuru>() { gecbasvuru };
                        }
                        else
                        {
                            sinav.GecBasvuru = null;
                        }
                        if (!sonuc_tarihi_nodu.InnerText.Trim().Equals(String.Empty))
                        {
                            sinav.SonucAciklamaTarihi = DateTime.Parse(sonuc_tarihi_nodu.InnerText.Trim());
                        }
                        else
                        {
                            sinav.SonucAciklamaTarihi = null;
                        }
                        sinavlar.Add(sinav);
                    }
                }
                sinav_takvimi.Sinavlar = sinavlar;
                string json = JsonConvert.SerializeObject(sinav_takvimi);
                StreamWriter sw = new StreamWriter(new FileStream(String.Format("sinav-takvimi-{0}.json",sinav_takvimi.Donem), FileMode.Create));
                sw.Write(json);
                sw.Close();
                Log.i("Takvim başarılı bir şekilde güncellendi." + String.Format("Dönem ({0})", sinav_takvimi.Donem), true);
                return true;
            }
            catch (Exception ex)
            {
                Log.e(ex.Message);
                return false;
            }
        }
    }
}
