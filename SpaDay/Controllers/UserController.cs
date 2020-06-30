using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModel;

namespace SpaDay.Controllers
{public class UserController : Controller
    {
        // GET: /user
        public IActionResult Index()
        {
            return View();
        }

        // GET: /user/add
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        // POST: /user
        [HttpPost("/user/add")]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
           {
            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password == addUserViewModel.Verify)
                {
                    User newUser = new User
                    {
                        Username = addUserViewModel.Username,
                        Password = addUserViewModel.Password,
                        Email = addUserViewModel.Email
                    }; 
                    return View("Index", newUser);
                }
                else
                {
                    ViewBag.error = "Passwords do not match! Try again!";
                    return View("Add", addUserViewModel);
                }
            }
            return View("Add", addUserViewModel);


        }
        
    }

}
