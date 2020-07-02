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

        public IActionResult Index()
        {
            List<Seller> list = _sellersService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersService.AddSeller(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Não foi passado o código para exclusão"});

            var obj = _sellersService.FindAllById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "O código passado não foi localizado !"});

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersService.RemoveSeller(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var obj = _sellersService.FindAllById(id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Não foram localizados os dados de acordo com o código do Vendedor" });
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Não foi passado o código para alteração" }); 

            var obj = _sellersService.FindAllById(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "O código para alteração não existe" });

            List<Department> department = _departmentService.FindAll();
            SellerFormViewModel sellerFormViewModel = new SellerFormViewModel() { Seller = obj, Departments = department };
            return View(sellerFormViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { message = "Os código estão diferentes!"});
            try
            {
                _sellersService.UpdateSeller(seller);
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
