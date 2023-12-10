using System;
using Microsoft.EntityFrameworkCore;
using test6.DB;
using test6.Models;
using test6.Repository.GenericRepository;

namespace test6.Repository.ClientRepository
{
    public class ClientRepository:GenericRepository<Client>,IClientRepository
    {


        public ClientRepository(DBContext context):base(context) 
        {
           
        }

    }
}

