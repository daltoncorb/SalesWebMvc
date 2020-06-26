using Remotion.Linq.Clauses;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext c)
        {
            _context = c;
        }

        public void AddSeed()
        {
            if(_context.Department.Any() || 
               _context.SalesRecord.Any() ||
               _context.Seller.Any())
            {
                return;
                //se a base estiver populada, cai fora 
            }

            Department d1 = new Department { Id = 1, Name = "Contabilidade" };
            Department d2 = new Department { Id = 2, Name = "Recursos Humanos" };
            Department d3 = new Department { Id = 3, Name = "Administrativo" };
            Department d4 = new Department { Id = 4, Name = "Desenvolvimento" };
            Department d5 = new Department { Id = 5, Name = "Eng. Elétrica" };

            Seller s1 = new Seller { Id = 10, Name = "Pedro Santos", Email = "ps@gmail.com", BirthDate = new DateTime(1969, 01, 28), Department = d1 };
            Seller s2 = new Seller { Id = 11, Name = "Mauro Genito", Email = "mg@gmail.com", BirthDate = new DateTime(2000, 10, 25), Department = d1 };
            Seller s3 = new Seller { Id = 12, Name = "Ricardo Silva", Email = "rs@gmail.com", BirthDate = new DateTime(1980, 06, 14), Department = d2 };
            Seller s4 = new Seller { Id = 13, Name = "Penelope Charmosa", Email = "pc@gmail.com", BirthDate = new DateTime(2003, 05, 21), Department = d2 };
            Seller s5 = new Seller { Id = 14, Name = "Saulo Ramos", Email = "sr@gmail.com", BirthDate = new DateTime(1997, 11, 02), Department = d3 };
            Seller s6 = new Seller { Id = 15, Name = "Felipe Neves", Email = "fn@gmail.com", BirthDate = new DateTime(1945, 09, 14), Department = d3 };
            Seller s7 = new Seller { Id = 16, Name = "Jairo Krieger", Email = "jk@gmail.com", BirthDate = new DateTime(2003, 07, 29), Department = d4 };
            Seller s8 = new Seller { Id = 17, Name = "Katya Samuray", Email = "ks@gmail.com", BirthDate = new DateTime(1995, 04, 13), Department = d5 };
            Seller s9 = new Seller { Id = 18, Name = "Luciane Amada", Email = "la@gmail.com", BirthDate = new DateTime(2001, 09, 23), Department = d4 };
            Seller s10 = new Seller { Id = 19, Name = "Flavio Silva", Email = "fs@gmail.com", BirthDate = new DateTime(1974, 01, 01), Department = d5 };

            SalesRecord sr1 = new SalesRecord { Id = 100, Seller = s1, Amount = 1200.00, Date = new DateTime(2020, 01, 05), Status = SaleStatus.Billed};
            SalesRecord sr2 = new SalesRecord { Id = 101, Seller = s2, Amount = 330.25, Date = new DateTime(2020, 02, 21), Status = SaleStatus.Canceled };
            SalesRecord sr3 = new SalesRecord { Id = 102, Seller = s3, Amount = 14.28, Date = new DateTime(2020, 03, 14), Status = SaleStatus.Pending };
            SalesRecord sr4 = new SalesRecord { Id = 103, Seller = s4, Amount = 38.23, Date = new DateTime(2020, 04, 17), Status = SaleStatus.Billed };
            SalesRecord sr5 = new SalesRecord { Id = 104, Seller = s5, Amount = 650.27, Date = new DateTime(2020, 05, 15), Status = SaleStatus.Canceled };
            SalesRecord sr6 = new SalesRecord { Id = 105, Seller = s6, Amount = 145.00, Date = new DateTime(2020, 01, 01), Status = SaleStatus.Pending };
            SalesRecord sr7 = new SalesRecord { Id = 106, Seller = s7, Amount = 180.00, Date = new DateTime(2020, 02, 03), Status = SaleStatus.Billed };
            SalesRecord sr8 = new SalesRecord { Id = 107, Seller = s8, Amount = 210.50, Date = new DateTime(2020, 03, 09), Status = SaleStatus.Canceled };
            SalesRecord sr9 = new SalesRecord { Id = 108, Seller = s9, Amount = 328.10, Date = new DateTime(2020, 04, 21), Status = SaleStatus.Pending };
            SalesRecord sr10 = new SalesRecord { Id = 109, Seller = s10, Amount = 85.23, Date = new DateTime(2020, 05, 29), Status = SaleStatus.Billed };

            SalesRecord sr11 = new SalesRecord { Id = 110, Seller = s1, Amount = 69.32, Date = new DateTime(2020, 01, 27), Status = SaleStatus.Canceled };
            SalesRecord sr12 = new SalesRecord { Id = 111, Seller = s2, Amount = 75.26, Date = new DateTime(2020, 02, 15), Status = SaleStatus.Pending };
            SalesRecord sr13 = new SalesRecord { Id = 112, Seller = s3, Amount = 55.41, Date = new DateTime(2020, 03, 11), Status = SaleStatus.Billed };
            SalesRecord sr14 = new SalesRecord { Id = 113, Seller = s4, Amount = 63.59, Date = new DateTime(2020, 04, 07), Status = SaleStatus.Canceled };
            SalesRecord sr15 = new SalesRecord { Id = 114, Seller = s5, Amount = 81.24, Date = new DateTime(2020, 05, 06), Status = SaleStatus.Pending };
            SalesRecord sr16 = new SalesRecord { Id = 115, Seller = s6, Amount = 79.26, Date = new DateTime(2020, 01, 09), Status = SaleStatus.Billed };
            SalesRecord sr17 = new SalesRecord { Id = 116, Seller = s7, Amount = 53.20, Date = new DateTime(2020, 02, 14), Status = SaleStatus.Canceled };
            SalesRecord sr18 = new SalesRecord { Id = 117, Seller = s8, Amount = 85.96, Date = new DateTime(2020, 03, 17), Status = SaleStatus.Pending };
            SalesRecord sr19 = new SalesRecord { Id = 118, Seller = s9, Amount = 72.14, Date = new DateTime(2020, 04, 16), Status = SaleStatus.Billed };
            SalesRecord sr20 = new SalesRecord { Id = 119, Seller = s10, Amount = 103.25, Date = new DateTime(2020, 05, 19), Status = SaleStatus.Canceled };

            SalesRecord sr21 = new SalesRecord { Id = 120, Seller = s1, Amount = 3.80, Date = new DateTime(2020, 01, 21), Status = SaleStatus.Pending };
            SalesRecord sr22 = new SalesRecord { Id = 121, Seller = s2, Amount = 19.60, Date = new DateTime(2020, 02, 08), Status = SaleStatus.Billed };
            SalesRecord sr23 = new SalesRecord { Id = 122, Seller = s3, Amount = 21.30, Date = new DateTime(2020, 03, 14), Status = SaleStatus.Canceled };
            SalesRecord sr24 = new SalesRecord { Id = 123, Seller = s4, Amount = 33.02, Date = new DateTime(2020, 04, 09), Status = SaleStatus.Pending };
            SalesRecord sr25 = new SalesRecord { Id = 124, Seller = s5, Amount = 29.65, Date = new DateTime(2020, 05, 24), Status = SaleStatus.Billed };
            SalesRecord sr26 = new SalesRecord { Id = 125, Seller = s6, Amount = 72.14, Date = new DateTime(2020, 01, 23), Status = SaleStatus.Canceled };
            SalesRecord sr27 = new SalesRecord { Id = 126, Seller = s7, Amount = 58.60, Date = new DateTime(2020, 02, 24), Status = SaleStatus.Pending };
            SalesRecord sr28 = new SalesRecord { Id = 127, Seller = s8, Amount = 36.00, Date = new DateTime(2020, 03, 28), Status = SaleStatus.Billed };
            SalesRecord sr29 = new SalesRecord { Id = 128, Seller = s9, Amount = 55.20, Date = new DateTime(2020, 04, 01), Status = SaleStatus.Canceled };
            SalesRecord sr30 = new SalesRecord { Id = 129, Seller = s10, Amount = 74.10, Date = new DateTime(2020, 05, 09), Status = SaleStatus.Pending };


            _context.Department.AddRange(d1, d2, d3, d4, d5);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10,
                sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20,
                sr21, sr22, sr23, sr24, sr25, sr26, sr27, sr28, sr29,sr30);

            _context.SaveChanges();

        }

    }
}
