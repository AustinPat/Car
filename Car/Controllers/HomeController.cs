using Car.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Car.Controllers
{
    public class HomeController : Controller
    {
        

        public object Dui { get; private set; }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        

public ActionResult Car_Info(string firstName, string lastName, string emailAddress, DateTime dateofbirth , int caryear, string carmake, string carmodel, int speedingtickets, string dui, string coverage, int? total )

        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(carmake) || string.IsNullOrEmpty(carmodel))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (Car_InsuranceEntities db = new Car_InsuranceEntities())
                {
                    var signup = new Car_Insurance();
                    signup.FirstName = firstName;
                    signup.Lastname = lastName;
                    signup.EmailAddress = emailAddress;
                    signup.DateOfBirth = dateofbirth;
                    signup.CarYear = caryear;
                    signup.SpeedingTickets = speedingtickets;
                    signup.Dui = dui;
                    signup.Coverage = coverage;
                    signup.Total = total;






                    








                      
                    total = 50;
                    var today = DateTime.Today;
                    var age = today.Year - dateofbirth.Year;
                    if (dateofbirth > today.AddYears(-25))
                    {
                        total = total + 25;
                    }
                    else if (dateofbirth > today.AddYears(-18))
                    {
                        total = total + 100;

                    }
                    else if (dateofbirth > today.AddYears(-100))
                    {
                        total = total + 25;
                    }


                    if (caryear < 2000)
                    {
                        total = total + 25;
                    }
                    else if (caryear > 2015)
                    {
                        total = total + 25;
                    }

                    if (carmake == "Porsche")
                    {
                        total = total + 25;
                    }

                    if (carmake == "Porsche" && carmodel == "911 Carrera")
                    {
                        total = total + 25;
                    }
                    //    foreach (var ticket in speedingtickets)
                    //{

                    //}
                    if (speedingtickets > 0)
                    {
                        total = total + (speedingtickets * 10);
                    }



                    if (dui == "Yes" || dui == "yes" || dui == "yeah")
                    {
                        total = total + (total * 25 / 100);
                    }
                    else
                    {
                        total = total + 0;
                    }



                    if (coverage == "Yes" || coverage == "yes" || coverage == "yeah")
                    {
                        total = total + (total * 50 / 100);
                    }
                    else
                    {
                        total = total + 0;
                    }


                    signup.Total = total;

                    db.Car_Insurance.Add(signup);
                    db.SaveChanges();
                    
                    @ViewBag.Total = total;


                    
                    return View("Total");


                }
                 
                   


            }

            
        }
        
    }
}