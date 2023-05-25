namespace Lab2.Models
{
    public class DepartmentDB
    {
        LabDB db= new LabDB();
        public List<Department> getAll()
        {
            return db.Departments.ToList() ;
        }

        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }

        public Department getByID(int id)
        {
            Department department = db.Departments.FirstOrDefault(dept => dept.Id == id);
            return department;
        }

        public void Update(Department dept)
        {
            Department old = db.Departments.FirstOrDefault(department => department.Id == dept.Id);
            if (old != null)
            {
                old.Name = dept.Name;
                dept.Capacity = dept.Capacity;
                db.SaveChanges();
            }
            

        }

        public void Delete(int id)
        {
            Department dept = db.Departments.FirstOrDefault(department => department.Id == id);
            db.Departments.Remove(dept);
            db.SaveChanges();

        }
    }
}
