namespace SaleWebMVC.Models.ViewModel;

public class HomeViewModel {
    public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<SaleRecord> SaleRecords  { get; set; } = new List<SaleRecord>();
}