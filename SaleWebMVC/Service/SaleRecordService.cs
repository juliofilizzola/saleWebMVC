using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Data;
using SaleWebMVC.Models;

namespace SaleWebMVC.Service;

public class SaleRecordService(SaleWebMvcContext context) {
    public async Task<List<SaleRecord>> FindAll() {
        return await context.SaleRecord.OrderBy(sr => sr.Date).ToListAsync();
    }
}