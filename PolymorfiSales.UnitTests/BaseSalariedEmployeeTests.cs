using System;
using System.Collections.Generic;
using Xunit;

namespace PolymorfiSales.UnitTests
{
    public class BaseSalariedEmployeeTests
    {
        [Theory]
        [InlineData(50_000)]
        [InlineData(100_000)]
        public void EarningsTest(decimal salary)
        {
            BaseSalariedEmployee baseSalariedEmployee = new BaseSalariedEmployee(salary, "Casper");

            Assert.True(baseSalariedEmployee.Earnings() == baseSalariedEmployee.Salary);
        }

        [Theory]
        [InlineData(100_000)]
        [InlineData(50_000)]
        public void GetPaymentAmountTest(decimal salary)
        {
            BaseSalariedEmployee baseSalariedEmployee = new BaseSalariedEmployee(salary, "Casper");

            Assert.True(baseSalariedEmployee.GetPaymentAmount() == baseSalariedEmployee.Earnings() * 0.15m);
        }

        [Fact]
        public void PaymentsTest()
        {
            List<IPayable> payables = new List<IPayable>();

            for (int i = 0; i < 5; i++)
            {
                BaseSalariedEmployee baseSalariedEmployee = new BaseSalariedEmployee(10_000, "Casper");
                payables.Add(baseSalariedEmployee);
            }

            for (int i = 0; i < 3; i++)
            {
                List<Product> products = new List<Product>() { new Product(1, 100, "Kaffe") };

                Invoice invoice = new Invoice(products);
                payables.Add(invoice);
            }

            decimal GetTotalPaymentAmount(List<IPayable> iPayables)
            {
                decimal totalAmount = 0;
                iPayables.ForEach(ip => totalAmount += ip.GetPaymentAmount());

                return totalAmount;
            }

            Assert.True(GetTotalPaymentAmount(payables) == 7_800);
        }
    }
}
