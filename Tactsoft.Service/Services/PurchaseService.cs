using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        private readonly AppDbContext _context;

        public PurchaseService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public Task DeleteRangeAsync(Purchase purchase)
        {
            List<PurchaseItem> purchaseItems = _context.PurchaseItems.Where(x => x.PurchaseId == purchase.Id).ToList();
            _context.PurchaseItems.RemoveRange(purchaseItems);
            _context.SaveChanges();

            _context.Attach(purchase);
            _context.Entry(purchase).State = EntityState.Deleted;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Purchase GetItems(int id)
        {
            Purchase item = _context.Purchases.Where(x=>x.Id== id)
                .Include(i=>i.PurchaseItems)
                .ThenInclude(i=>i.Item)
                .FirstOrDefault();
            item.PurchaseItems.ForEach(x=>x.Amount = x.Quantity * x.PurchasePrice);

            return item;
        }

        public Task UpdateRangeAsync(Purchase purchase)
        {
            List<PurchaseItem> purchaseItems = _context.PurchaseItems.Where(x=>x.PurchaseId== purchase.Id).ToList();
            _context.PurchaseItems.RemoveRange(purchaseItems);
            _context.SaveChanges();

            _context.Attach(purchase);
            _context.Entry(purchase).State = EntityState.Modified;
            _context.PurchaseItems.AddRange(purchase.PurchaseItems);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
