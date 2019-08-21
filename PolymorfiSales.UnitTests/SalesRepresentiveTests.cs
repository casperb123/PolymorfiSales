using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PolymorfiSales.UnitTests
{
    public class SalesRepresentiveTests
    {
        [Theory]
        [InlineData(5_000, 20, 1_500)]
        [InlineData(13_500, 17, 1_350)]
        public void EarningsTest(decimal salary, double commisionRate, decimal weeklySalary)
        {
            SalesRepresentive salesRepresentive = new SalesRepresentive(salary, "Casper", commisionRate, weeklySalary);

            Assert.True(salesRepresentive.Earnings() == salesRepresentive.Salary + salesRepresentive.WeeklySales * (decimal)salesRepresentive.CommisionRate / 100);
        }

        [Theory]
        [InlineData(5_000, 20, 1_500)]
        [InlineData(17_645, 16.5, 2_152)]
        public void GetPaymentAmountTest(decimal salary, double commisionRate, decimal weeklySalary)
        {
            SalesRepresentive salesRepresentive = new SalesRepresentive(salary, "Casper", commisionRate, weeklySalary);

            Assert.True(salesRepresentive.GetPaymentAmount() == salesRepresentive.Earnings() * 0.15m);
        }

        [Fact]
        public void PaymentsTest()
        {
            List<IPayable> payables = new List<IPayable>();

            for (int i = 0; i < 5; i++)
            {
                SalesRepresentive salesRepresentive = new SalesRepresentive(10_000, "Casper", 10, 1_500);
                payables.Add(salesRepresentive);
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

            Assert.True(GetTotalPaymentAmount(payables) == 7_912.5m);
        }
    }
}
