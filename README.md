Bu CRM projesi oldukça kapsamlı bir içeriğe sahiptir.Şirketlerin müşteri, teklif ve kullanıcı yönetimini kolaylaştıran, ASP.NET Core tabanlı  etkili bir CRM (Müşteri İlişkileri Yönetimi) uygulamasıdır.

📌 Özellikler
✅ Müşteri kayıt ve yönetimi (Yeni müşteri ekleme, güncelleme, silme)

✅ Teklif oluşturma ve takip sistemi

✅ Yedek iletişim kişisi (backup contact person) ekleme özelliği

✅ Teklif durumu yönetimi: Onaylandı, Reddedildi vb.

✅ Reddedilen teklifler için kullanıcıyı bilgilendiren uyarı sistemi (popup/modal)

✅ Dashboard üzerinden filtrelenebilir teklif analizleri (son 7 gün, 30 gün, bu yıl vb.)

✅ Kullanıcı kayıt ve giriş işlemleri (giriş yapılmadan sayfalara erişim engeli)

✅ ASP.NET MVC mimarisi ile modüler yapı

✅ Responsive ve kullanımı kolay arayüz (Bootstrap ile)

✅ Entity Framework Core kullanılarak veri erişimi

✅ E-posta gönderildi / Telefonla arandı bilgileri ile iletişim takibi

✅ Teklif formunda kayıtlı ya da yeni müşteri seçebilme imkanı

✅ Teklif formunda müşteriyle birlikte yedek telefon ve mail bilgileri girme özelliği


📁 Proje Yapısı
bash
Kopyala
Düzenle
Most_Crm/
│
├── Controllers/               # Müşteri, Teklif ve Dashboard controller’ları
│   ├── CustomersController.cs
│   ├── OffersController.cs
│   └── DashboardController.cs
│
├── DTO/                      # Veri taşıma (Data Transfer Object) sınıfları
│   └── OfferDTO.cs, CustomerDTO.cs
│
├── Data/                     # DbContext ve bağlantı ayarları
│   └── CRMDbContext.cs
│
├── Migrations/               # EF Core migration dosyaları
│
├── Models/                   # Veritabanı modelleri
│   ├── Customer.cs
│   ├── Offer.cs
│   └── ContactPerson.cs
│
├── Views/                    # Razor View’lar (Sayfa yapıları)
│   ├── Offers/
│   ├── Customers/
│   └── Shared/
│
├── wwwroot/                  # Statik dosyalar (CSS, JS, ikonlar)
│
├── appsettings.json          # Genel konfigürasyon dosyası
├── appsettings.Development.json
├── Program.cs                # Uygulama giriş noktası
├── Most_Crm.csproj           # Proje yapılandırma dosyası
└── Most_Crm_SLN.sln          # Çözüm dosyası (Visual Studio)


🔧 Kullanılan Teknolojiler
ASP.NET Core MVC

Entity Framework Core (Code First)

Microsoft SQL Server

Razor Pages & Layouts

LINQ

C#

Bootstrap 5

HTML/CSS/JavaScript


🚀 Projenin Çalıştırılması
bash
Kopyala
Düzenle
# 1. Depoyu klonlayın
git clone https://github.com/aybkeydn/CrmProject.git

# 2. Visual Studio ile açın

# 3. Paketleri geri yükleyin ve veritabanı bağlantı dizesini kendi bağlantınıza göre değiştirin ve kontrol edin

# 4. Migration'ları uygulayın (Package Manager Console):
Update-Database

# 5. Uygulamayı çalıştırın (IIS Express veya kestirme tuş: Ctrl+F5)
