using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfiSales
{
    public interface IPayable
    {
        decimal GetPaymentAmount();
    }
}
