using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Techservices.Models;

namespace Techservices.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository repo;

        public CustomerController(ICustomerRepository repo)
        {


            this.repo = repo;
        }

        [Authorize]
        public IActionResult Cxinfo()
        {

            var customer = repo.GetInfocustomers();
            return View(customer);
        }

    



        public IActionResult InsertCustomer()
        {

            var clients = repo.AssingCustomer();
            return View(clients);
        }



        public IActionResult InsertCustomerToDatabase(infocustomer customerToInsert)
        {
            repo.createCustomer(customerToInsert);

            return RedirectToAction("Cxinfo");
        }

        //public IActionResult customerupdate()
        //{
        //    infocustomer customer = (infocustomer)repo.GetInfocustomers();

        //    if (customer == null)
        //    {
        //        return View("customerNotFound");
        //    }

        //    return View(customer);
        //}


        //public IActionResult UpdatecustomerToDatabase(infocustomer customer) 
        //{ 

        //    repo.UpdateCustomer(customer);
        //    return RedirectToAction("Customer", new { customer = customer });


        //}

        public IActionResult deletecustomer(infocustomer customer)
        {
            repo.deleteCustomer(customer);
            return RedirectToAction("Cxinfo");

        }



    }
}
