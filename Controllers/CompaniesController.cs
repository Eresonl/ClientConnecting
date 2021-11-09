using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientConnecting.Models;
using ClientConnecting.Services;

namespace ClientConnecting.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyService _companyService;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;

        private readonly ClientConnectingContext _context;

        public CompaniesController(CompanyService companyService, CategoryService categoryService, ProductService productService )
        {
            _companyService = companyService;
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var list = await _companyService.FindAllAsync();
            return View(list);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
/*            var products = _productService.
            if (id == null)
            {
                return NotFound();
            }
*/
            var obj = await _companyService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Companies/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.FindAllAsync();
            var viewModel = new CompanyFormViewModel { Categories = categories };
            return View(viewModel);
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            await _companyService.InsertAsync(company);
            return RedirectToAction(nameof(Index));
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cnpj,Address,CategoryId,Email,ImagemLogo")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
        public async Task<IActionResult> SimpleSearch(string name)
        {
            ViewData["SearchName"] = name;
            var result = await _companyService.FindByNameAsync(name);
            return View(result);
        }
    }
}
