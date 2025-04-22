using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Most_Crm.Data;
using Most_Crm.Models;

namespace Most_Crm.Controllers
{
    public class ContactPersonController : Controller
    {
        private readonly CRMDbContext _context;

        public ContactPersonController(CRMDbContext context)
        {
            _context = context;
        }

        // POST: Yeni ilgili kişi ekle
        [HttpPost]
        public async Task<IActionResult> Add(ContactPerson contact)
        {
            if (ModelState.IsValid)
            {
                _context.ContactPeople.Add(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Customer", new { id = contact.CustomerID });
        }

        // (İsteğe bağlı) müşteri ID'ye göre tüm kişileri JSON olarak getir
        [HttpGet]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var contacts = await _context.ContactPeople
                .Where(c => c.CustomerID == customerId)
                .Select(c => new { c.Name, c.Email, c.PhoneNumber })
                .ToListAsync();

            return Json(contacts);
        }
    }
}
