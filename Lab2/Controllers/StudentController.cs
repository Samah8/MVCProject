using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class StudentController : Controller
    {
        StudentDB DB = new StudentDB();
        DepartmentDB Department = new DepartmentDB();
        public IActionResult Index()
        {
            
            return View(DB.getAll());
        }

        [HttpPost]
        public IActionResult Create(Student std ,IFormFile imgStd)
        {
           if(imgStd!=null)
           {
             Student s=DB.Add(std);
             string imgName=s.Id.ToString()+"."+imgStd.FileName.Split(".").Last();
              s.imgName = imgName;
                if (ModelState.IsValid)
            {
                    using (var obj = new FileStream(@".\wwwroot\images\" + imgName, FileMode.Create))
                    {
                        imgStd.CopyToAsync(obj);
                        DB.UpdateImage(s);
                    }
                }
                
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Create()
        {
            ViewData["depts"] = Department.getAll();
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            Student std = DB.getByID(id.Value);
            if (std != null)
                return View(std);
            else
                return NotFound();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            Student std = DB.getByID(id.Value);
            if (std != null)
                return View(std);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
           if(ModelState.IsValid)
            {
                DB.Update(std);
                return RedirectToAction("index");
            }
            else
                return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            Student std = DB.getByID(id.Value);
            if (std != null)
                return View(std);
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
