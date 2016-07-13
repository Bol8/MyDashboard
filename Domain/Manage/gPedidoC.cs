using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Interfaces;
using Elmah;
using System.Data.Entity;
using Domain.Connection;


namespace Domain.Manage
{
    public class gPedidoC : GenericRepository<Entities , Pedido_c>, IOrderLineServices<Linea_pedido_c>
    {
        public gPedidoC() { }

        public void addOrderLine(Linea_pedido_c element)
        {
           
        }
    }
}
