# CRM Projesi

Bu proje, şirketlerin müşteri, teklif ve kullanıcı yönetimini kolaylaştıran, ASP.NET Core tabanlı etkili bir CRM (Müşteri İlişkileri Yönetimi) uygulamasıdır. Modern mimarisi ve kullanıcı dostu arayüzü ile firmaların iş süreçlerini dijitalleştirerek takip edilebilir, ölçeklenebilir ve analiz edilebilir hale getirir.

![image](https://github.com/user-attachments/assets/7d0c6c89-5b12-4fba-97f1-7da59fb57460)
![image](https://github.com/user-attachments/assets/a9cc0123-8ffc-4291-ab2f-7c7638e20c7a)
![image](https://github.com/user-attachments/assets/75e73395-cc90-4f90-b2e2-9d8092152fa0)
![image](https://github.com/user-attachments/assets/664301be-26d9-46e3-92ea-31ec7da44a90)
![image](https://github.com/user-attachments/assets/7aafd044-c9a3-49b8-9804-19a76f439acd)
![image](https://github.com/user-attachments/assets/003155dd-81e8-418b-8750-a29135d63973)



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
