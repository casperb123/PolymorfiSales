using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PolymorfiSales.UnitTests
{
    public class IEquatableTests
    {
        [Fact]
        public void BaseSalariedEmployeeTest()
        {
            BaseSalariedEmployee baseSalariedEmployee = new BaseSalariedEmployee(1_000, "Casper");
            BaseSalariedEmployee baseSalariedEmployee1 = new BaseSalariedEmployee(1_000, "Casper");

            Assert.True(baseSalariedEmployee.Equals(baseSalariedEmployee1) && baseSalariedEmployee.GetHashCode() == baseSalariedEmployee1.GetHashCode());
        }

        [Fact]
        public void InvoiceTest()
        {
            List<Product> products = new List<Product>();
            List<Product> products1 = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                Product product = new Product(5, 50, "Kaffe");
                products.Add(product);
            }

            for (int i = 0; i < 10; i++)
            {
                Product product = new Product(5, 50, "Kaffe");
                products1.Add(product);
            }

            Invoice invoice = new Invoice(products);
            Invoice invoice1 = new Invoice(products1);

            Assert.True(invoice.Equals(invoice1));
        }

        [Fact]
        public void ProductTest()
        {
            Product product = new Product(10, 100, "Kaffe");
            Product product1 = new Product(10, 100, "Kaffe");

            Assert.True(product.Equals(product1));
        }

        [Fact]
        public void SalesRepresentiveTest()
        {
            SalesRepresentive salesRepresentive = new SalesRepresentive(10_000, "Casper", 15, 1_500);
            SalesRepresentive salesRepresentive1 = new SalesRepresentive(10_000, "Casper", 15, 1_500);

            Assert.True(salesRepresentive.Equals(salesRepresentive1));
        }
    }
}
