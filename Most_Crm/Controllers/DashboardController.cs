using Microsoft.AspNetCore.Mvc;
using Most_Crm.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Most_Crm.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly CRMDbContext _context;

        public DashboardController(CRMDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string dateFilter = "all")
        {

            DateTime startDate = DateTime.MinValue;

            switch(dateFilter)
            {
                case "today":
                    startDate = DateTime.UtcNow.Date;
                    break;
                case "last7":
                    startDate = DateTime.UtcNow.AddDays(-7);
                    break;
                case "last30":
                    startDate = DateTime.UtcNow.AddDays(-30);
                    break;
                case "thisyear":
                    startDate = new DateTime(DateTime.UtcNow.Year, 1, 1);
                    break;
                default:
                    startDate = DateTime.MinValue;
                    break;
            }


            // Tüm teklifleri durumlara göre al
            var confirmedOfferList = await _context.Offers
                .Where(o => o.OfferStatus == "Onaylandı" && o.CreatedAt >=startDate)
                .ToListAsync();

            var pendingOfferList = await _context.Offers
                .Where(o => o.OfferStatus == "Beklemede" && o.CreatedAt >= startDate)
                .ToListAsync();

            var pendingOffers = await _context.Offers
                .Where(o => o.OfferStatus == "Beklemede" && o.CreatedAt >= startDate)
                .CountAsync(); 

            var rejectedOfferList = await _context.Offers
               .Where(o => o.OfferStatus == "Reddedildi" && o.CreatedAt >= startDate)
               .ToListAsync();

            var rejectedOffers = await _context.Offers
                .Where(o => o.OfferStatus == "Reddedildi" && o.CreatedAt >= startDate)
                .CountAsync();

            // Most Idea ve Most Digital müşteri sayıları



            var mostIdeaCustomers = await _context.Customers
                .Where(c => c.CompanyName == "Most Idea" && c.CreatedAt >= startDate)
                .CountAsync();

            var mostDigitalCustomers = await _context.Customers
                .Where(c => c.CompanyName == "Most Digital" && c.CreatedAt >= startDate)
                .CountAsync();


            // Tüm müşteri sayısı
            var totalCustomers = await _context.Customers
                .Where(c => c.CreatedAt >= startDate)
                .CountAsync();

            // Son 5 işlem
            var recentTransactions = await _context.Transactions
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .ToListAsync();

            // ViewBag ile frontend'e taşı
            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.ConfirmedOffers = confirmedOfferList.Count;
            ViewBag.ConfirmedTotalAmount = confirmedOfferList.Sum(o => o.Amount ?? 0);
            ViewBag.PendingOffers = pendingOffers;
            ViewBag.PendingTotalAmount = pendingOfferList.Sum(o => o.Amount ?? 0);
            ViewBag.RejectedOffers = rejectedOffers;
            ViewBag.RejectedTotalAmount = rejectedOfferList.Sum(o => o.Amount ?? 0);
            ViewBag.MostIdeaCustomers = mostIdeaCustomers;
            ViewBag.MostDigitalCustomers = mostDigitalCustomers;
            ViewBag.RecentTransactions = recentTransactions;

            return View();
        }
    }
}
