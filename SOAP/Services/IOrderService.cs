using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SOAP.Services
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IEnumerable<Order> GetOrders();

        [OperationContract]
        Order GetOrder(int id);

        [OperationContract]
        bool AddOrder(Order order);

        [OperationContract]
        bool UpdateOrder(Order order);

        [OperationContract]
        bool DeleteOrder(int id);
    }
}
