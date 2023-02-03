
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Techservices.Models;

namespace Techservices
{
    public interface ICustomerRepository
    {

        public IEnumerable<infocustomer> GetInfocustomers();

        public void createCustomer(infocustomer customer);

       

       
        //public IEnumerable<Createcustomer>Getclients();

        public infocustomer AssingCustomer();

    }
}
