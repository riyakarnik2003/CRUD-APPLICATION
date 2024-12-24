using System.Diagnostics;
using CRUDAppUsingAdo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAppUsingAdo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StudentDBContext studentDBContext = new StudentDBContext();
            List<Student> stu = studentDBContext.GetStudents();

            return View(stu);
        }

        public ActionResult Create(Student stu)
        {
            if (ModelState.IsValid == true)
            {
                StudentDBContext sdb = new StudentDBContext();
                bool check = sdb.AddStudent(stu);
                if (check)
                {
                    TempData["Insert msg"] = "Data inserted successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }


            return View();
        }


        //}


        public ActionResult Edit(int id)
        {
            StudentDBContext sdb = new StudentDBContext();
            var row = sdb.GetStudents().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int id, Student stu)
        {
            if (ModelState.IsValid == true)
            {
                StudentDBContext sdb = new StudentDBContext();
                bool check = sdb.UpdateStudent(stu);
                if (check)
                {
                    TempData["Update msg"] = "Data updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();


        }

        public ActionResult Delete(int id)
        {
            StudentDBContext sdb = new StudentDBContext();
            var row = sdb.GetStudents().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, Student stu)
        {

            StudentDBContext sdb = new StudentDBContext();
            bool check = sdb.DeleteStudent(id);
            if (check == true)
            {
                //TempData["delete msg"] = "Data deletetd successfully";

                return RedirectToAction("Index");
            }

            return View();
        }



        public ActionResult Details(int id)
        {
            StudentDBContext sdb = new StudentDBContext();
            var row = sdb.GetStudents().Find(model => model.id == id);
           
            return View(row);
        }
    }
}

   
