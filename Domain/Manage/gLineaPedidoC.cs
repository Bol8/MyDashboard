﻿using System;
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
    public class gLineaPedidoC : GenericRepository<Entities,Linea_pedido_c>
    {
       public gLineaPedidoC() { }
    }
}
