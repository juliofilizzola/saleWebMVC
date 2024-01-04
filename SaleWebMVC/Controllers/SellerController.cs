using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Models;
using SaleWebMVC.Models.ViewModel;
using SaleWebMVC.Service;

namespace SaleWebMVC.Controllers
{
    public class SellerController(SellerService context, DepartmentService departmentService) : Controller {
        private readonly DepartmentService _departmentService = departmentService;
        private readonly SellerService _sellerService = context;

        // GET: Seller
        public async Task<ViewResult> Index() {
            var response = await _sellerService.FindAll();
            return View(response);
        }

        // GET: Seller/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var seller = await _sellerService.FindByIdAsync(id);
            if (seller == null) {
                return NotFound();
            }

            return View(seller);
        }

        // GET: Seller/Create
        public IActionResult Create() {
            var dep = _departmentService.FindAll();

            var viewModel = new SellerFormViewModel { Departments = dep };
            return View(viewModel);
        }

        // POST: Seller/Create
        // To protect from overcasting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            // if (!ModelState.IsValid) return View(seller);
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        // GET: Seller/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var seller = await _sellerService.FindByIdAsync(id);

            if (seller == null) {
                return NotFound();
            }

            return View(seller);
        }

        // POST: Seller/Edit/5
        // To protect from overcasting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,BaseSalary,BirthDate")] Seller seller) {
            if (id != seller.Id) {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(seller);
            try {
                await _sellerService.UpdateAsync(seller);
            } catch (DbUpdateConcurrencyException) {
                if (!SellerExists(seller.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Seller/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var seller = await _sellerService.FindByIdAsync(id);
            if (seller == null) {
                return NotFound();
            }

            await  _sellerService.RemoveAsync(id);

            return View(seller);
        }

        // POST: Seller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id) {
            return _sellerService.SellerExists(id);
        }
    }
}