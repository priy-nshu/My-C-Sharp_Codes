using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CustomerType
{
    Basic,
    Premium,
    SpecialCustomer
}
public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public CustomerType customerTye { get; set; }
    public int Age { get; set; }

    public bool IsSeniorCitizen()
    {
        if (Age >= 60) { 
         return true;
        }
        return false;
    }

}