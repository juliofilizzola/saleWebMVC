using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SaleWebMVC.Models.ViewModel;
using SaleWebMVC.Service;

namespace SaleWebMVC.Controllers;

public class HomeController : Controller {
    private readonly DepartmentsController   _departmentsController;
    private readonly DepartmentService       _departmentService;
    private readonly ILogger<HomeController> _logger;
    private readonly SaleRecordService       _saleService;
    private readonly SellerService           _sellerService;

    public HomeController(ILogger<HomeController> logger,        DepartmentService departmentService,
                          SellerService           sellerService, SaleRecordService saleRecordService,
                          DepartmentsController   departmentsController) {
        _logger                = logger;
        _departmentService     = departmentService;
        _sellerService         = sellerService;
        _saleService           = saleRecordService;
        _departmentsController = departmentsController;
        _departmentsController = departmentsController;
    }

    public async Task<IActionResult> Index() {
        var departments = await _departmentService.FindAll();
        var sellers     = await _sellerService.FindAll();
        var saleRecords = await _saleService.FindAll();
        var viewModel = new HomeViewModel {
            Departments = departments,
            Sellers     = sellers,
            SaleRecords = saleRecords
        };
        return View(viewModel);
    }

    public IActionResult Privacy() {
        return View();
    }

    public async Task<IActionResult> EditDepartments(int? id) {
        return await _departmentsController.Edit(id);
    }

    public async Task<IActionResult> DetailsDepartments(int? id) {
        return await _departmentsController.Details(id);
    }

    public async Task<IActionResult> DeleteDepartments(int? id) {
        return await _departmentsController.Delete(id);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}