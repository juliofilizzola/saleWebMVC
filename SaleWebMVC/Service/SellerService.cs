using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Data;
using SaleWebMVC.Models;
using SaleWebMVC.Service.Exceptions;

namespace SaleWebMVC.Service;

public class SellerService(SaleWebMvcContext context) {
    private readonly SaleWebMvcContext _context = context;

    public async Task<List<Seller>> FindAll() {
        return await _context.Seller.ToListAsync();
    }

    public async Task InsertAsync(Seller obj) {
        obj.Department = _context.Department.First();
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<Seller?> FindByIdAsync(int? id) {
        return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
    }

    public async Task RemoveAsync(int? id)
    {
        try
        {
            var obj = await _context.Seller.FindAsync(id);
            if (obj == null) {
                throw new NotFoundException("Seller Not Found");
            }
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e) {
            throw new IntegrityException("Can't delete seller because he/she has sales error" + " " + e.Message);
        }
    }

    public async Task UpdateAsync(Seller obj) {
        var hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
        if (!hasAny) {
            throw new NotFoundException("Id not found");
        }
        try {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException e) {
            throw new DbConcurrencyException(e.Message);
        }
    }

    public bool SellerExists(int id) {
        return _context.Seller.Any(x => x.Id == id);
    }
}