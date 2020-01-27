using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCollage.Models;
using MyCollage.ViewModel;

namespace MyCollage.Controllers
{
    public class DepartmentController : Controller
    {
        CollageDBEntities db = new CollageDBEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department.OrderByDescending(item => item.ID).ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DepartmentVM departmentVM)
        {

            if(departmentVM != null)
            {
                Department department = new Department()
                {
                    Name = departmentVM.Name
                };
                db.Department.Add(department);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Department department = null;
            DepartmentVM departmentVM = new DepartmentVM();
            if(id != null)
            {
                department = db.Department.Where(item => item.ID == id)
                    .FirstOrDefault();

                if (department != null)
                {
                    departmentVM.ID = department.ID;
                    departmentVM.Name = department.Name;
                }

            }
            return View(departmentVM);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentVM departmentVM)
        {
            if(departmentVM != null)
            {
                Department department = db.Department.
                    Where(item => item.ID == departmentVM.ID).FirstOrDefault();
                if (department != null)
                {
                    department.Name = departmentVM.Name;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                Department department = db.Department.
                    Where(item => item.ID == id).FirstOrDefault();
                if (department != null)
                {
                    db.Department.Remove(department);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}