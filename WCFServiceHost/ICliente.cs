using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using WCFServiceHost.Models;

namespace WCFServiceHost
{
    [ServiceContract]
    public interface ICliente
    {
        [OperationContract]
        Task<List<Cliente>> GetAll();

        [OperationContract]
        Task<Cliente> GetClienteById(long id);

        [OperationContract]
        Task<Cliente> Add(Cliente cliente);

        [OperationContract]
        Task<Cliente> Update(Cliente cliente);

        [OperationContract]
        Task<bool> DeleteClienteById(long id);
    }
}