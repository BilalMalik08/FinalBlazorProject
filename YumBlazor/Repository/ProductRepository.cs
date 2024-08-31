﻿using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product obj)
        {
            await _db.Product.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Product.Include(p => p.Category).FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return false;
            }

            _db.Product.Remove(obj);
            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _db.Product.Include(p => p.Category).FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Product();
            }
            return obj;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb = await _db.Product.Include(p => p.Category).FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                return null;
            }
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.ImageUrl = obj.ImageUrl;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.Price = obj.Price;
            _db.Product.Update(objFromDb);
            await _db.SaveChangesAsync();
            return objFromDb;
        }
    }
}