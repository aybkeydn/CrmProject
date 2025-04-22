using Microsoft.AspNetCore.Mvc;
using Most_Crm.Data;
using Most_Crm.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Most_Crm.DTOs;


namespace Most_Crm.Controllers
{
    public class CustomerController : Controller
    {

        private readonly CRMDbContext _context;

        public CustomerController(CRMDbContext context)
        {
            _context = context;
        }

        // Müşteri Listesi (Index)
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync(); //ana sayfada müşterilerin olduğu bir liste oluşturur
            return View(customers);
        }

        // Yeni Müşteri Ekleme Sayfası (Create - GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Müşteri Kaydetme (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerDTO customerDto)
        {
            if (ModelState.IsValid)
            {
                var now = DateTime.UtcNow;

               

                var customer = new Customer    //yeni müşteriyi kaydederken gerekli olan bilgileri tanımlar ve dtodan bu bilgileri çeker
                {
                    NameSurname = customerDto.NameSurname,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber,
                    Sector = customerDto.Sector,
                    Status = customerDto.Status,
                    EmailSentAt = customerDto.EmailSentAt ?? (customerDto.EmailSentAt.HasValue ? customerDto.EmailSentAt : DateTime.Now),
                    PhoneCallAt = customerDto.PhoneCallAt ?? (customerDto.PhoneCallAt.HasValue ? customerDto.PhoneCallAt : DateTime.Now),
                    CustomerType = customerDto.CustomerType,
                    CompanyName = customerDto.CompanyName,
                    Country = customerDto.Country, 
                    City = customerDto.City,

                    CreatedAt = DateTime.UtcNow,

                    CariKod = "2014" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Turkey Standard Time").ToString("MMddHHmm")



                };




               

                _context.Customers.Add(customer); //veritabanına ulaşıp yeni bir müşteri kaydı ekler
                await _context.SaveChangesAsync();

                // Yeni işlem kaydı oluşturmak için (her yeni müşteri eklendiğinde "son işlemler" kısmına dinamik bir şekilde ulaşır)
                var transaction = new Transaction
                {
                    CompanyName = customer.CompanyName,
                    Description = customer.NameSurname + " " + "adlı müşteri oluşturuldu",
                    PerformedBy = User.Identity?.Name ?? "Sistem",
                    CreatedAt = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); 

            }

            return View(customerDto);
        }



        // Müşteri Silme (Delete - GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers.FindAsync(id); //veritabanından nesneyi primary key'e göre bulur
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // Müşteri Silme Onayı (Delete - POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // CSRF (Cross-Site Request Forgery) saldırılarını önler
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                // Transaction kaydı ekler
                var transaction = new Transaction
                {
                    CompanyName = customer.CompanyName,
                    Description = customer.NameSurname + " " + "adlı müşteri silindi",
                    PerformedBy = User.Identity?.Name ?? "Sistem",
                    CreatedAt = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        //güncelleme sayfası
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers
                .Include(c => c.Offers) //müşteriye ait teklif bilgilerini de getirir
                .Include(c => c.ContactPersons)
                .FirstOrDefaultAsync(m => m.CustomerID == id);

            if (customer == null)
                return NotFound();

            // Modeli DTO'ya çevirir
            var customerDto = new CustomerDTO
            {
                CustomerID = customer.CustomerID,
                NameSurname = customer.NameSurname,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Sector = customer.Sector,
                Status = customer.Status,
                CustomerType = customer.CustomerType,
                CompanyName = customer.CompanyName,
                ContactPersons = customer.ContactPersons.ToList(),
                EmailSent = customer.EmailSent,
                Country = customer.Country,
                City = customer.City,
                PhoneCallMade = customer.PhoneCallMade,
                EmailSentAt = customer.EmailSentAt,
                PhoneCallAt = customer.PhoneCallAt,
                Offers = customer.Offers.Select(o => new OfferDTO //her teklif için ayrı bir OfferDTO nesnesi oluşturur
                {
                    OfferID = o.OfferID,
                    OfferStatus = o.OfferStatus,
                    OfferRejectionReason = o.OfferRejectionReason,
                    CreatedAt = o.CreatedAt

                }).ToList()
            };

            return View(customerDto);
        }


        // Müşteri Düzenleme Sayfası (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers
                                         .Include(c => c.Offers)
                                         .FirstOrDefaultAsync(c => c.CustomerID == id);

            if (customer == null)
                return NotFound();

            var customerDto = new CustomerDTO
            {
                CustomerID = customer.CustomerID,
                NameSurname = customer.NameSurname,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Sector = customer.Sector,
                Status = customer.Status,
                EmailSentAt = customer.EmailSentAt,
                PhoneCallAt = customer.PhoneCallAt,
                Country = customer.Country,
                City = customer.City,
                CustomerType = customer.CustomerType,
                CompanyName = customer.CompanyName,
                Offers = customer.Offers.Select(o => new OfferDTO
                {
                    OfferID = o.OfferID,
                    OfferStatus = o.OfferStatus
                }).ToList()
            };

            return View(customerDto);
        }



        // Müşteri Güncelleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerDTO customerDto)
        {
            if (id != customerDto.CustomerID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(customerDto);
            }


            var customer = await _context.Customers
                                         .Include(c => c.Offers)
                                         .FirstOrDefaultAsync(c => c.CustomerID == id);

            if (customer == null)
                return NotFound();


            customer.NameSurname = customerDto.NameSurname;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Sector = customerDto.Sector;
            customer.Status = customerDto.Status;
            customer.CustomerType = customerDto.CustomerType;
            customer.CompanyName = customerDto.CompanyName;

            // E-posta ve telefon durumu güncelleme
            customer.EmailSent = customerDto.EmailSent;
            customer.PhoneCallMade = customerDto.PhoneCallMade;

            // Eğer e-posta/telefon işlemi yeni yapıldıysa zamanını atama
            customer.EmailSentAt = customerDto.EmailSent ? customer.EmailSentAt ?? DateTime.Now : null;
            customer.PhoneCallAt = customerDto.PhoneCallMade ? customer.PhoneCallAt ?? DateTime.Now : null;


            //Teklif Güncelleme
            foreach (var offerDto in customerDto.Offers)
            {
                var existingOffer = customer.Offers.FirstOrDefault(o => o.OfferID == offerDto.OfferID);
                if (existingOffer != null)
                {
                    existingOffer.OfferStatus = offerDto.OfferStatus;
                }
            }

            try
            {
                await _context.SaveChangesAsync();


                var transaction = new Transaction
                {
                    CompanyName = customer.CompanyName,
                    Description = customer.NameSurname + " " + "adlı müşterinin bilgisi güncellendi",
                    PerformedBy = User.Identity?.Name ?? "Sistem",
                    CreatedAt = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException) // eş zamanlılık(aynı anda 2 adminin işlem yapması durumu) hatası oluşmaması için önlem alır
            {
                if (!_context.Customers.Any(e => e.CustomerID == id))
                    return NotFound();
                else
                    throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByCompany(string company)
        {
            var customers = await _context.Customers
                .Where(c => c.CompanyName == company)
                .Select(c => new
                {
                    id = c.CustomerID,
                    nameSurname = c.NameSurname,
                    email = c.Email
                })
                .ToListAsync();

            return Json(customers);
        }







    }
}

