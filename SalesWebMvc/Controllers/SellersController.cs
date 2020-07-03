using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentService _departmentService;


        public SellersController(SellersService sellersService, DepartmentService departmentService)
        {
            _sellersService = sellersService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            List<Seller> list = await _sellersService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var dp = await _departmentService.FindAllAsync();
                var vm = new SellerFormViewModel() { Seller = seller, Departments = dp };
                return View(vm);
            }
            await _sellersService.AddSellerAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Não foi passado o código para exclusão"});

            var obj = await _sellersService.FindAllById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "O código passado não foi localizado !"});

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellersService.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var obj = await _sellersService.FindAllById(id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Não foram localizados os dados de acordo com o código do Vendedor" });
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Não foi passado o código para alteração" }); 

            var obj = await _sellersService.FindAllById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "O código para alteração não existe" });

            List<Department> department = await _departmentService.FindAllAsync();
            SellerFormViewModel sellerFormViewModel = new SellerFormViewModel() { Seller = obj, Departments = department };
            return View(sellerFormViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { message = "Os código estão diferentes!"});
            try
            {
                await _sellersService.UpdateSeller(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundExceptions)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }

        public IActionResult Error(string message)
        {
            var errorViewModel = new ErrorViewModel() {
                message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            return View(errorViewModel);
        }
    }
}
