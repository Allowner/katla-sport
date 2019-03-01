using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;
using DbItem = KatlaSport.DataAccess.ProductStore.StoreItem;

namespace KatlaSport.Services.HiveManagement
{
    public class HiveSectionProductService : IHiveSectionProductService
    {
        private readonly IProductStoreContext _context;

        public HiveSectionProductService(IProductStoreContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<HiveSectionProduct> CreateHiveSectionProductAsync(UpdateHiveSectionProductRequest createRequest)
        {
            var dbStoreItems = await _context.Items.Where(p => p.ProductId == createRequest.ProductId && p.HiveSectionId == createRequest.HiveSectionId).ToArrayAsync();

            if (dbStoreItems.Length > 0)
            {
                throw new RequestedResourceHasConflictException("ProductId");
            }

            var dbStoreItem = Mapper.Map<UpdateHiveSectionProductRequest, DbItem>(createRequest);
            _context.Items.Add(dbStoreItem);

            await _context.SaveChangesAsync();

            return Mapper.Map<HiveSectionProduct>(dbStoreItem);
        }

        public async Task DeleteHiveSectionProductAsync(int productId)
        {
            var dbStoreItems = await _context.Items.Where(p => p.Id == productId).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];
            if (dbStoreItem.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Items.Remove(dbStoreItem);
            await _context.SaveChangesAsync();
        }

        public async Task<HiveSectionProduct> GetHiveSectionProductAsync(int id)
        {
            var dbStoreItems = await _context.Items.Where(s => s.Id == id).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbItem, HiveSectionProduct>(dbStoreItems[0]);
        }

        public async Task<List<HiveSectionProduct>> GetHiveSectionProductsAsync()
        {
            var dbStoreItems = await _context.Items.OrderBy(s => s.Id).ToArrayAsync();
            var storeItems = dbStoreItems.Select(s => Mapper.Map<HiveSectionProduct>(s)).ToList();
            return storeItems;
        }

        public async Task<List<HiveSectionProduct>> GetHiveSectionProductsAsync(int hiveSectionId)
        {
            var dbStoreItems = await _context.Items.Where(s => s.HiveSectionId == hiveSectionId).OrderBy(s => s.Id).ToArrayAsync();
            var storeItems = dbStoreItems.Select(s => Mapper.Map<HiveSectionProduct>(s)).ToList();
            return storeItems;
        }

        public async Task SetDeliveredStatusAsync(int productId, bool deliveredStatus)
        {
            var dbStoreItems = await _context.Items.Where(c => productId == c.Id).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            if (dbStoreItem.IsDelivered != deliveredStatus)
            {
                dbStoreItem.IsDelivered = deliveredStatus;
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetStatusAsync(int productId, bool deletedStatus)
        {
            var dbStoreItems = await _context.Items.Where(c => productId == c.Id).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            if (dbStoreItem.IsDeleted != deletedStatus)
            {
                dbStoreItem.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<HiveSectionProduct> UpdateHiveSectionProductAsync(int productId, UpdateHiveSectionProductRequest updateRequest)
        {
            var dbStoreItems = await _context.Items.Where(p => p.ProductId == updateRequest.ProductId && p.Id != productId).ToArrayAsync();
            if (dbStoreItems.Length > 0)
            {
                throw new RequestedResourceHasConflictException("productId");
            }

            dbStoreItems = await _context.Items.Where(p => p.Id == productId).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            Mapper.Map(updateRequest, dbStoreItem);

            await _context.SaveChangesAsync();

            return Mapper.Map<HiveSectionProduct>(dbStoreItem);
        }
    }
}
