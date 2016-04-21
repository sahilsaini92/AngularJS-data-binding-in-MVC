using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapAngularMvc.Models;

namespace BootstrapAngularMvc.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Employee()
        {
            return View();
        }

        //For getting the all records from database.		
        public JsonResult getAll()
        {
            using (OmanERP_SahilEntities dataContext = new OmanERP_SahilEntities())
            {
                var employeeList = (from E in dataContext.Employees
                                    join dep in dataContext.Departments on E.DepartmentID equals dep.Id
                                    join dsg in dataContext.Designations on E.DesignationID equals dsg.Id
                                    orderby E.Id
                                    select new
                                    {
                                        E.Id,
                                        E.name,
                                        E.DOB,
                                        E.Gender,
                                        E.Email,
                                        E.Mobile,
                                        E.Address,
                                        E.JoiningDate,
                                        dep.DepartmentName,
                                        E.DepartmentID,
                                        dsg.DesignationName,
                                        E.DesignationID
                                    }).ToList();
                var JsonResult = Json(employeeList, JsonRequestBehavior.AllowGet);
                JsonResult.MaxJsonLength = int.MaxValue;
                return JsonResult;
            }
        }
    }
}
