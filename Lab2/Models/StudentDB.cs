namespace Lab2.Models
{
    public class StudentDB
    {
        LabDB db = new LabDB();
        public List<Student> getAll()
        {
            return db.Students.ToList();
        }

        public Student Add(Student student)
        {

         db.Students.Add(student);
            db.SaveChanges();
            return student;
        }

        public Student getByID(int id)
        {
            Student std = db.Students.FirstOrDefault(student => student.Id == id);
            return std;
        }

        public void Update(Student std)
        {
            Student old = db.Students.FirstOrDefault(student => student.Id == std.Id);
            if (old != null)
            {
                old.Name = std.Name;
                old.DeptID = std.DeptID;
            }
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student std = db.Students.FirstOrDefault(student => student.Id == id);
            db.Students.Remove(std);
            db.SaveChanges();
        }

        public void UpdateImage(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
    }
}
