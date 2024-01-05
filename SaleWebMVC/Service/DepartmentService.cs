using SaleWebMVC.Data;
using SaleWebMVC.Models;

namespace SaleWebMVC.Service;

public class DepartmentService(SaleWebMvcContext context) {
    private  readonly SaleWebMvcContext _context = context;

    public List<Department> FindAll() {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }

    public void Insert(Department obj) {
        _context.Department.Add(obj);
        _context.SaveChanges();
    }
}