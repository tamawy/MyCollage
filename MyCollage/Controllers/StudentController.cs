using MyCollage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCollage.ViewModel;

namespace MyCollage.Controllers
{
    public class StudentController : Controller
    {
        CollageDBEntities db = new CollageDBEntities();
        
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Student.OrderByDescending(item => item.ID).ToList());
        }

        [ActionName("search")]
        public ActionResult Details(int? id)
        {
            Student student = null;
            if(id != null)
            {
                student = db.Student.Where(z => z.ID == id).FirstOrDefault();
            }
            return View("Details", student);
        }

        // GET : Add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(StudentVM student)
        {
            Student obj = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Password = student.Password
            };

            db.Student.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Student student = null;
            StudentVM studentVM = new StudentVM();
            if(id != null)
            {
                student = db.Student.Where(item => item.ID == id).FirstOrDefault();
                if(student != null)
                {
                    studentVM.FirstName = student.FirstName;
                    studentVM.LastName = student.LastName;
                    studentVM.Email = student.Email;
                    studentVM.Password = student.Password;
                }
            }
            return View(studentVM);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            Student student = 
                db.Student.Where(item => item.ID == studentVM.ID).FirstOrDefault();
            if(student != null)
            {
                student.FirstName = studentVM.FirstName;
                student.LastName = studentVM.LastName;
                student.Email = studentVM.Email;
                student.Password = studentVM.Password;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Student studnet = db.Student.Where(item => item.ID == id).FirstOrDefault();
                if(studnet != null)
                {
                    db.Student.Remove(studnet);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}