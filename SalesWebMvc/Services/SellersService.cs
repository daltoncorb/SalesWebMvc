using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellersService
    {
        private readonly SalesWebMvcContext _context;

        public SellersService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> FindAllById(int id)
        {
            return await _context.Seller.Include(d => d.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        //Troca o void por task
        public async Task AddSellerAsync(Seller seller)
        {            
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSeller(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateSeller(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(s => s.Id == seller.Id);

            if (!hasAny)
                throw new NotFoundExceptions("O código desse vendedor não foi localizado !");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException("Erro de concorrência : " + e.Message);
            }
        }
    }
}
