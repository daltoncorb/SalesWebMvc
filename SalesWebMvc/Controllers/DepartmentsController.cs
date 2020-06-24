using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();

            list.Add(new Department() { Id = 1, Name = "Administrativo" });
            list.Add(new Department() { Id = 2, Name = "Rec. Humanos" });
            list.Add(new Department() { Id = 3, Name = "Comercial" });
            list.Add(new Department() { Id = 4, Name = "Publicidade" });
            list.Add(new Department() { Id = 5, Name = "Atendimento ao Cliente" });
            list.Add(new Department() { Id = 6, Name = "Produção" });
            list.Add(new Department() { Id = 7, Name = "Despacho" });

            return View(list);
        }
    }
}
