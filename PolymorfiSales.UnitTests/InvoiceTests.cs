using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PolymorfiSales.UnitTests
{
    public class InvoiceTests
    {
        [Fact]
        public void EqualsTest()
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                Product product = new Product(5, 50, "Kaffe");
                products.Add(product);
            }

            Invoice invoice = new Invoice(products);
            Invoice invoice1 = new Invoice(products);

            Assert.True(invoice.Equals(invoice1));
        }
    }
}
