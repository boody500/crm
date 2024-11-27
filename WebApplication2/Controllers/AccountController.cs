using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.Xrm.Tooling.Connector;
using System.Web.Mvc;
using System;
using Microsoft.Xrm.Sdk.Organization;
using System.Drawing.Printing;
using System.Diagnostics;
namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private static CRMModel model = new CRMModel();
        private static CRMServices crm = new CRMServices();
        private static User current_user;
        private static CrmServiceClient client;

        public AccountController() { client = crm.ConnectToCrm(); }
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            // Implement authentication logic here
            // This is a simple example. Replace with actual authentication.
            if (ModelState.IsValid)
            {
                // TODO: Authenticate user
                //return RedirectToAction("Index", "Home");
                if (model.QueryExpressionExample(client, user))
                {
                    Debug.WriteLine("true");
                    //call method that passes the user to display
                    current_user = user;
                    return RedirectToAction("ViewProfile");

                }


                else
                {
                    Debug.WriteLine("false");
                    ViewBag.AlertMessage = "Email or Password are incorrect";
                }


            }
            return View(user);


        }

        // GET: /Account/SignUp
        public ActionResult SignUp()
        {
            Debug.WriteLine("sign up page");
            return View();
        }

        // POST: /Account/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            Debug.WriteLine("crm connection");

            if (ModelState.IsValid)
            {
                // TODO: Register user

                model.CreateContactExample(client, user);
                Debug.WriteLine("contact created");
                return RedirectToAction("Login");

            }
            return View(user);
        }




        public ActionResult ViewProfile()
        {
            Debug.WriteLine("view profile page");
            if (current_user == null)
            {
                ViewBag.AlertMessage = "you must login first";
                return RedirectToAction("Login");


            }

            return View(current_user);
        }

        public ActionResult FeaturePage()
        {
            var products = model.RetriveProducts(client);
            return View(products);
        }


        // POST: /Account/FeaturePage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeaturePage(Cases cases)
        {
            Debug.WriteLine("crm connection");

            if (ModelState.IsValid)
            {
                // TODO: Register user

                model.CreateCaseExample(client, current_user, cases);
                Debug.WriteLine("case created");
                return RedirectToAction("ViewProfile");

            }
            return View(cases);
        }
    }
}
