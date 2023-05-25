namespace Lab2.Models
{
    public class DepartmentMoc
    {
        static List<Department> depts = new List<Department>()
        {
            new Department (){Id=1,Name="PD",Capacity=44 } ,
            new Department (){Id=2,Name="OS",Capacity=30 },
            new Department (){Id=3,Name="AI",Capacity=20 }
        };
        public List<Department> getAll()
        {
            return depts;
        }

        public void Add(Department department)
        {
                depts.Add(department);
        }

        public Department getByID(int id)
        {
            Department department = depts.FirstOrDefault(dept => dept.Id == id);
            return department;
        }

        public void Update(Department dept)
        {
            Department old = depts.FirstOrDefault(department => department.Id == dept.Id);
            if (old != null)
            {
                old.Name = dept.Name;
                dept.Capacity = dept.Capacity;
            }
        }

        public void Delete(int id)
        {
            Department dept = depts.FirstOrDefault(department => department.Id == id);
            depts.Remove(dept);
        }
    }
}
