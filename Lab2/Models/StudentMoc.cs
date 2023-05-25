using Microsoft.AspNetCore.Mvc;

namespace Lab2.Models
{
    public class StudentMoc
    {
        static List<Student> stds = new List<Student>
        {
            new Student(){Id=1,Name="Samah",DeptID=1},
            new Student(){Id=2,Name="Mhmd",DeptID=2},
            new Student(){Id=3,Name="Mai",DeptID=3},
        };
        public List<Student> getAll()
        {
            return stds;
        }

        public void Add(Student student)
        {
          
                stds.Add(student);
    
        }

        public Student getByID(int id)
        {
            Student std=stds.FirstOrDefault(student=>student.Id==id);
            return std;
        }

        public void Update(Student std)
        {
           Student old = stds.FirstOrDefault(student => student.Id == std.Id);
            if (old != null)
            {
               old.Name = std.Name;
                old.DeptID = std.DeptID;
            }
        }

        public void Delete(int id)
        {
            Student std =stds.FirstOrDefault(student=>student.Id==id);
            stds.Remove(std);
        }
    }
}
