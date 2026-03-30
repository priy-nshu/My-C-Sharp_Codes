using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CustomerOrderSvc
    {

    private List<Order> lstOrder = null;
    public CustomerOrderSvc() { 

        lstOrder =new List<Order>()
        {
            new Order(){OrderId=1,ProductId=25,ProductQuantity=1,Amount=100},
            new Order(){OrderId=2,ProductId=31,ProductQuantity=2,Amount=200},
            new Order(){OrderId=3,ProductId=43,ProductQuantity=1,Amount=150},
            new Order(){OrderId=4,ProductId=21,ProductQuantity=3,Amount=300},
            new Order(){OrderId=5,ProductId=43,ProductQuantity=2,Amount=440},
        };
    }
    public void ApplyDiscount(Customer customer, Order order)
    {
        if (customer.customerTye == CustomerType.Premium)
        {
            order.Amount =order.Amount - ((order.Amount*10)/100);
        }
        else if(customer.customerTye == CustomerType.SpecialCustomer)
        {
            order.Amount = order.Amount - ((order.Amount * 15) / 100);
        }
    }
     public List<Order> GetOrders() { return lstOrder; }

    public Order GetOrderById(int OrdId) { return lstOrder.Single(o => o.OrderId == OrdId); }

    public List<Order> GetOrdersByProductId(int ProdId) { 
        return lstOrder.Where(o => o.ProductId == ProdId).ToList();
    }
}

