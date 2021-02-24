using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moment3.Data;
using Moment3.Models;

namespace Moment3.Controllers
{   
    public class HomeController : Controller
    {
        private DataContext dataContext;

        public HomeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
            dataContext.Database.EnsureCreated();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }
        
       
        


    }
  

}
