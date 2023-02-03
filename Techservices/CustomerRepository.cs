using Dapper;
using MySqlX.XDevAPI;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Techservices.Models;
using Azure.Core;

namespace Techservices
{
    public class CustomerRepository : ICustomerRepository
    {

        public readonly IDbConnection _conn;


        public CustomerRepository(IDbConnection conn)
        {


            _conn = conn;
        }

        

        public IEnumerable<infocustomer> GetInfocustomers()
        {
            return _conn.Query<infocustomer>("SELECT * FROM  customers;");
        }


        public void createCustomer(infocustomer customer)
        {
            
            _conn.Execute("INSERT INTO customers (IDCUSTOMERS, NAME, LASTNAME, ADDRESS, PHONE, SERVICEDATE, DEVICE, COMMENTS) VALUES ( @idcustomers, @name, @lastname, @address,@phone,@servicedate,@device,@comments);",
            new { idcustomers = customer.idcustomers, name = customer.name, lastname = customer.lastname, address = customer.address, phone = customer.phone, servicedate = customer.servicedate, device = customer.device, comments = customer.comments });

        }
        //public IEnumerable<Createcustomer> Getclients()
        //{
          //  return _conn.Query<Createcustomer>("SELECT * FROM customers;");

       // }

        public infocustomer AssingCustomer()
        {
            // var clientsList = Getclients();
            var clients = new infocustomer();
           
            return clients;

        }

        
}   }
