using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class DepartmentController : Controller
    {
      
        DepartmentDB DB= new DepartmentDB();
        public IActionResult Index()
        {

            return View(DB.getAll());
        }

        [HttpPost]            //Action Selector
        public IActionResult Create(Department dept) 
        {
            if (ModelState.IsValid)
            {
                DB.Add(dept);
                //  return View("Index",depts);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Create()
        {
            return View("create");
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            Department dept = DB.getByID(id.Value);
            if (dept != null)
                return View(dept);
            else
                return NotFound();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            Department dept = DB.getByID(id.Value);
            if (dept != null)
                return View(dept);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                DB.Update(dept);
                return RedirectToAction("index");
            }
            else
                return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            Department dept = DB.getByID(id.Value);
            if (dept != null)
                return View(dept);
            else
                return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult confirmedDelete(int id)
        {
            DB.Delete(id);
            return RedirectToAction("index");
        }
    }
}
