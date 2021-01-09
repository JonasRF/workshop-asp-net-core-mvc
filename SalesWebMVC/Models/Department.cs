using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSallers(Seller seller)
        {
            sellers.Add(seller);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return sellers.Sum(saller => saller.TotalSales(inicial, final));
        }
    }
}
