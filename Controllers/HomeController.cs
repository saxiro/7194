using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices]DataContext context)
        {
            var employee = new User { Id = 1, Username = "robin", Password = "123", Role = "employee" };
            var manager = new User { Id = 2, Username = "batman", Password = "123", Role = "manager" };
            var category = new Category { Id = 1, Title = "Informática" };
            var product = new Product { Id = 1, Category = category, Title = "Mouse", CategoryId = 1, Price = 299, Description = "Mouse Gamer" };

            context.Users.Add(employee);
            context.Users.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new
            { 
                message = "Dados configurados"
            });
        }
    }
}
