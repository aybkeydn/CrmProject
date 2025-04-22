# CRM Projesi

Bu proje, şirketlerin müşteri, teklif ve kullanıcı yönetimini kolaylaştıran, ASP.NET Core tabanlı etkili bir CRM (Müşteri İlişkileri Yönetimi) uygulamasıdır. Modern mimarisi ve kullanıcı dostu arayüzü ile firmaların iş süreçlerini dijitalleştirerek takip edilebilir, ölçeklenebilir ve analiz edilebilir hale getirir.

---

## 📌 Özellikler

- ✅ **Müşteri Kayıt ve Yönetimi**: Yeni müşteri ekleme, güncelleme, silme işlemleri
- ✅ **Teklif Oluşturma ve Takip Sistemi**
- ✅ **Yedek İletişim Kişisi (Backup Contact Person) Ekleme Özelliği**
- ✅ **Teklif Durumu Yönetimi**: Onaylandı, Reddedildi vb.
- ✅ **Reddedilen Teklifler İçin Uyarı Sistemi**: Popup/modal ile kullanıcıyı bilgilendirme
- ✅ **Dashboard Üzerinden Filtrelenebilir Teklif Analizleri**: Son 7 gün, 30 gün, bu yıl vb.
- ✅ **Kullanıcı Kayıt ve Giriş İşlemleri**: Yetkilendirme ile korunan alanlar
- ✅ **Modüler ASP.NET MVC Mimarisi**
- ✅ **Responsive ve Kullanımı Kolay Arayüz (Bootstrap 5)**
- ✅ **Entity Framework Core Kullanılarak Veri Erişimi**
- ✅ **İletişim Takibi**: E-posta gönderildi / Telefonla arandı bilgileri
- ✅ **Yeni veya Kayıtlı Müşteri Seçimi ile Teklif Oluşturma**
- ✅ **Yedek Telefon ve Mail Bilgileri Girme Özelliği Teklif Formunda**

---

## 📁 Proje Yapısı

Most_Crm/
│
├── Controllers/                       
│   └── ContactPersonController.cs     
│   └── CustomerController.cs          
│   └── DashboardController.cs         
│   └── OfferController.cs             
│   └── UserController.cs              
│
├── DTO/                               
│   └── ContactPersonDTO.cs            
│   └── CustomerDTO.cs                 
│   └── OfferDTO.cs                    
│   └── UserDTO.cs                     
│
├── Data/                              
│   └── CRMDbContext.cs                
│
├── Migrations/                        
│         
│
├── Models/                            
│   └── ContactPerson.cs               
│   └── Customer.cs                    
│   └── Offer.cs                       
│   └── Transaction.cs                 
│   └── User.cs                        
│
├── Views/                             
│   └── ContactPerson/                 
│   └── Customers/                     
│   └── Dashboard/                     
│   └── Offers/                        
│   └── Shared/                        
│   └── Users/                         
│
├── wwwroot/                           
│   └── css/                           
│   └── js/                            
│   └── img/                           
│
├── appsettings.json                   
├── appsettings.Development.json       
├── Program.cs                         
├── Most_Crm.csproj                    
└── Most_Crm_SLN.sln


## 🔧 Kullanılan Teknolojiler

- **ASP.NET Core MVC**
- **Entity Framework Core (Code First)**
- **Microsoft SQL Server**
- **Razor Pages & Layouts**
- **LINQ**
- **C#**
- **Bootstrap 5**
- **HTML / CSS / JavaScript**

---

## 🚀 Projenin Çalıştırılması

```bash
# 1. Depoyu klonlayın
git clone https://github.com/aybkeydn/CrmProject.git

# 2. Visual Studio ile açın

# 3. Paketleri geri yükleyin ve veritabanı bağlantı dizesini kendi SQL Server bağlantınıza göre düzenleyin

# 4. Migration'ları uygulayın (Package Manager Console):
Update-Database

# 5. Uygulamayı çalıştırın:
Ctrl + F5 veya IIS Express üzerinden 
