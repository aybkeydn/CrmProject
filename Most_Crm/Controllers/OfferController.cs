using Microsoft.AspNetCore.Mvc;
using Most_Crm.Data;
using Most_Crm.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Most_Crm.DTOs;

using System;

namespace Most_Crm.Controllers
{
    public class OfferController : Controller
    {
        private readonly CRMDbContext _context;

        public OfferController(CRMDbContext context)
        {
            _context = context;
        }

        // Teklif Listesi
        public async Task<IActionResult> Index()
        {
            var offers = await _context.Offers
                .Include(o => o.Customer)
                .Include(o => o.ContactPersonEntity) 
                .ToListAsync();

            return View(offers);
        }


        // Yeni Teklif Ekleme Sayfası (Create - GET)
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        // Yeni Teklif Kaydetme (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OfferDTO offerDto)
        {
            if (ModelState.IsValid)
            {
                int customerId;

                // Eğer yeni müşteri girildiyse (CustomerID boşsa)
                if (offerDto.CustomerID == 0)
                {
                    var newCustomer = new Customer
                    {
                        NameSurname = offerDto.ContactPerson ?? offerDto.CompanyName ?? "Bilinmeyen",
                        PhoneNumber = offerDto.PhoneNumber,
                        Email = offerDto.Email,
                        CompanyName = offerDto.CompanyName,
                        CariKod = DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                        CustomerType = "Yeni",
                        Sector = "Belirtilmedi",
                        Status = "Pasif",
                        City = offerDto.City,
                        Country = offerDto.Country
                    };

                    _context.Customers.Add(newCustomer);
                    await _context.SaveChangesAsync();

                    customerId = newCustomer.CustomerID;
                }
                else
                {
                    customerId = offerDto.CustomerID;
                    
                }

                // Yeni teklif oluştur
                var offer = new Offer
                {
                    CustomerID = customerId,
                    OfferStatus = offerDto.OfferStatus,
                    FollowUp = offerDto.FollowUp,
                    OfferRejectionReason = offerDto.OfferRejectionReason,
                    CreatedAt = DateTime.Now,
                    Year = offerDto.Year,
                    Month = offerDto.Month,
                    OfferNumber = offerDto.OfferNumber,
                    Status2 = offerDto.Status2,
                    Description = offerDto.Description,
                    Group = offerDto.Group,
                    CompanyName = offerDto.CompanyName,
                    ContactPerson = offerDto.ContactPerson,
                    PhoneNumber = offerDto.PhoneNumber,
                    Email = offerDto.Email,
                    Source = offerDto.Source,
                    OfferDate = offerDto.OfferDate,
                    Amount = offerDto.Amount,

                    

                    DueDate = DateTime.Today
                };

                _context.Offers.Add(offer);
                await _context.SaveChangesAsync();

                var customer = await _context.Customers.FindAsync(customerId);

                // Takibe alınmak istenmişse ekstra kayıt oluştur
                if (offerDto.FollowUp)
                {
                    var followNote = new Transaction
                    {
                        CompanyName = customer?.CompanyName ?? "Bilinmeyen Şirket",
                        Description = customer?.NameSurname + " adlı müşteri Reddedildi ve Takibe Alındı",
                        PerformedBy = User.Identity?.Name ?? "Sistem",
                        CreatedAt = DateTime.Now
                    };

                    _context.Transactions.Add(followNote);
                    await _context.SaveChangesAsync();
                }

                // Genel işlem kaydı
                var transaction = new Transaction
                {
                    CompanyName = customer?.CompanyName ?? "Bilinmeyen Şirket",
                    Description = customer?.NameSurname + " adlı müşteriye teklif oluşturuldu",
                    PerformedBy = User.Identity?.Name ?? "Sistem",
                    CreatedAt = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                // ✅ Teklif durumu kontrolüyle yönlendirme
                if (offer.OfferStatus?.ToLower() == "reddedildi")
                {
                    return RedirectToAction("FollowUps");
                }

                return RedirectToAction(nameof(Index));
            }

            // ❗ ModelState geçersizse müşteri listesini tekrar ViewBag'e yükle
            ViewBag.Customers = await _context.Customers.ToListAsync();
            return View(offerDto);
        }



        // Teklif Silme (Delete - GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
                return NotFound();

            return View(offer);
        }

        // Teklif Silme Onayı (Delete - POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }


            var customer = await _context.Customers.FindAsync(offer.CustomerID);
            string companyName = customer?.CompanyName ?? "Bilinmeyen Şirket";

            // Teklifi siler
            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            var transaction = new Transaction
            {
                CompanyName = companyName,
                Description = customer.NameSurname + " " + "adlı müşterinin teklifi silindi",
                PerformedBy = User.Identity?.Name ?? "Sistem",
                CreatedAt = DateTime.Now
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Silme işlemi sonrası listeye yönlendirme
        }


        // Teklif Düzenleme Sayfası (Edit - GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
                return NotFound();

            var customer = await _context.Customers.FindAsync(offer.CustomerID);
            ViewBag.CustomerName = customer?.NameSurname ?? "Bilinmeyen Müşteri";

            var offerDto = new OfferDTO
            {
                OfferID = offer.OfferID,
                CustomerID = offer.CustomerID,
                OfferStatus = offer.OfferStatus,
                OfferRejectionReason = offer.OfferRejectionReason,
                CreatedAt = offer.CreatedAt,
                Year = offer.Year,
                Month = offer.Month,
                OfferNumber = offer.OfferNumber,
                Status2 = offer.Status2,
                Description = offer.Description,
                Group = offer.Group,
                ServiceDetail = offer.ServiceDetail,
                CompanyName = offer.CompanyName,
                ContactPerson = offer.ContactPerson,
                PhoneNumber = offer.PhoneNumber,
                Email = offer.Email,
                Source = offer.Source,
                OfferDate = offer.OfferDate,
                Amount = offer.Amount,
                DueDate = offer.DueDate
            };

            return View(offerDto);
        }


        //Teklif düzenleme(POST)

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, OfferDTO offerDto)
        {
            if (id != offerDto.OfferID)
                return NotFound();

            if (ModelState.IsValid)
            {
                var offer = await _context.Offers.FindAsync(id);
                if (offer == null)
                    return NotFound();

                // Güncelleme işlemleri
                offer.OfferStatus = offerDto.OfferStatus;
                offer.OfferRejectionReason = offerDto.OfferRejectionReason;
                offer.Year = offerDto.Year;
                offer.Month = offerDto.Month;
                offer.OfferNumber = offerDto.OfferNumber;
                offer.Description = offerDto.Description;
                offer.Group = offerDto.Group;
                offer.ServiceDetail = offerDto.ServiceDetail;
                offer.CompanyName = offerDto.CompanyName;
                offer.ContactPerson = offerDto.ContactPerson;
                offer.PhoneNumber = offerDto.PhoneNumber;
                offer.Email = offerDto.Email;
                offer.Source = offerDto.Source;
                offer.OfferDate = offerDto.OfferDate;
                offer.Amount = offerDto.Amount;
                offer.DueDate = offerDto.DueDate;

                _context.Update(offer);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // Hatalıysa sayfa tekrar gösterilir
            var customer = await _context.Customers.FindAsync(offerDto.CustomerID);
            ViewBag.CustomerName = customer?.NameSurname ?? "Bilinmeyen Müşteri";

            return View(offerDto);
        }

        public async Task<IActionResult> FollowUps()
        {
            var followedOffers = await _context.Offers
      .Include(o => o.Customer)
          .ThenInclude(c => c.ContactPersons)
      .Where(o => o.FollowUp == true)
      .ToListAsync();


            return View(followedOffers);
        }


    }
}
