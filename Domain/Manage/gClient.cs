using Repository;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Elmah;
using Domain.Models.Cliente;
using AutoMapper;
using GenericRepository.Repository;

namespace Domain.Manage
{
    public class gClient : GenericRepository<Entities, Clientes>, IClientRepository
    {

        public gClient() { }

        public gClient(long id)
        {

        }


        public Clientes getSingle(long id)
        {
            var client = GetAll().FirstOrDefault(x => x.IdCliente == id);
            
            return client;
        }

        



        //public List<Clientes> getAll()
        //{
        //    var clients = GetAll().ToList();

        //    return clients;
        //}

    }
}
