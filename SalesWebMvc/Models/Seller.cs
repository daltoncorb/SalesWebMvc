using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Campo deve ser preenchido entre 2 e 40!")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }  

        [Required(ErrorMessage ="Aniversário é obrigatório")]
        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="Verifique o valor no salário")]
        [Display(Name ="Salário Base")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Range(maximum:8000, minimum : 100, ErrorMessage = "Verifique os valores entre 100 e 8000" )]
        public double BaseSalary { get; set; }

        [Display(Name ="Departamento")]
        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
            
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime startDate, DateTime endDate)
        {
            return Sales.Where(s => s.Date >= startDate && s.Date <= endDate).Sum(s => s.Amount);
        }
    }
}
