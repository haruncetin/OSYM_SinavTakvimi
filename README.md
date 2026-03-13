# ÖSYM Sınav Takvimi

## Proje Hakkında
ÖSYM Sınav Takvimi, Öğrenci Seçme ve Yerleştirme Merkezi (ÖSYM) tarafından gerçekleştirilen sınavların güncel takibini kolaylaştırmak amacıyla geliştirilmiş bir yazılım projesidir. Bu uygulama, kullanıcıların sınav süreçlerindeki tüm kritik tarihleri tek bir ekrandan, karmaşadan uzak bir şekilde izleyebilmesini sağlar.

## Temel Özellikler
Uygulama, adayların sınav süreçlerini daha iyi yönetebilmesi için aşağıdaki işlevleri sunmaktadır:
* **Zaman Takibi ve Geri Sayım:** Sınavın kendisine, başvuru başlangıç ve bitiş tarihlerine, geç başvuru tarihine ve sonuç açıklama tarihine tam olarak ne kadar zaman kaldığını gösterir.
* **Gelişmiş Arama:** ÖSYM'nin düzenlediği çok sayıdaki sınav arasında filtreleme ve arama yaparak istenilen sınava hızlıca ulaşılmasını sağlar.
* **Tek Noktadan Kontrol:** Farklı web sayfaları arasında gezinme zorunluluğunu ortadan kaldırarak tüm takvim verilerini merkezi bir arayüzde birleştirir.

## Proje Mimarisi ve Bileşenler
Yazılım, sürdürülebilirlik ve modülerlik ilkelerine göre farklı dizinlere ayrılarak tasarlanmıştır:
* **OSYM_Crawler:** Sınav takvimi verilerini ilgili kaynaklardan elde etmek ve güncellemek için kullanılan veri çekme (crawling) modülüdür.
* **Viewer:** Çekilen verilerin kullanıcıya görsel olarak sunulduğu arayüz projesidir.
* **AppLog:** Uygulamanın çalışma zamanındaki işlemlerinin, uyarıların ve olası hataların kayıt altına alındığı log (günlük) yönetim bileşenidir.
* **OSYM_SinavTakvimi:** Projenin ana iskeletini ve iş mantığını (business logic) oluşturan temel dizindir.

## Kullanılan Teknolojiler
* **Programlama Dili:** C# (%100)
* **Geliştirme Ortamı:** Microsoft Visual Studio

## Kurulum ve Çalıştırma
Projeyi kendi yerel ortamınızda test etmek veya geliştirmek için aşağıdaki adımları takip edebilirsiniz:

1. Depoyu yerel bilgisayarınıza klonlayın:
   ```bash
   git clone [https://github.com/haruncetin/OSYM_SinavTakvimi.git](https://github.com/haruncetin/OSYM_SinavTakvimi.git)
   ```

2. Klonlama işlemi tamamlandıktan sonra proje klasörüne gidin:
   ```bash
   cd OSYM_SinavTakvimi
   ```

3. Dizin içerisinde bulunan `OSYM_SinavTakvimi.sln` çözüm (solution) dosyasını Microsoft Visual Studio ile açın.

4. Gerekli kütüphanelerin yüklenebilmesi için projeye sağ tıklayıp "Restore NuGet Packages" (NuGet Paketlerini Geri Yükle) işlemini gerçekleştirin.

5. Uygulamayı derleyin (Build) ve çalıştırın (Start).
