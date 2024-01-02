namespace SaleWebMVC.Models;

public class Seller {
    public int        Id         { get; set; }
    public string     Name       { get; set; }
    public string     Email      { get; set; }
    public double     BaseSalary { get; set; }
    public DateTime   BirthDate  { get; set; }
    public Department Department { get; set; }
    public ICollection<SaleRecord> Sales { get; set; } = new List<SaleRecord>();

    public void AddSales(SaleRecord sr) {
        Sales.Add(sr);
    }

    public void RemoveSale(SaleRecord sr) {
        Sales.Remove(sr);
    }

    public double TotalSales(DateTime initial, DateTime final) {
        return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
    }
}