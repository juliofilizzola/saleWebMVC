using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Data;
using SaleWebMVC.Models;

namespace SaleWebMVC.Service;

public class DepartmentService(SaleWebMvcContext context) {
    private  readonly SaleWebMvcContext _context = context;

    public async Task<List<Department>> FindAll() {
        return await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }

    public void Insert(Department obj) {
        _context.Department.Add(obj);
        _context.SaveChanges();
    }
}