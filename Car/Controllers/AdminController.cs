using Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            using(Car_InsuranceEntities db = new Car_InsuranceEntities())
            {

                var signups = db.Car_Insurance.Where(x => x.Removed == null).ToList();

                var signupVms = new List<Objects>();
                foreach (var signup in signups)
                {
                    var signupVm = new Objects();
                    signupVm.Id = signup.id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.Lastname;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVm.Total = Convert.ToInt32(signup.Total);
                    

                    
                    
                    signupVms.Add(signupVm);
                }

                return View(signupVms);

            }
    
            

          
        }
    }
}