namespace CPW219_CRUD_Troubleshooting.Models
{
    public static class StudentDb
    {
        public static Student Add(Student s, SchoolContext db)
        {
            //Add student to context
            db.Students.Add(s);
            return s;
        }

        public static List<Student> GetStudents(SchoolContext context)
        {
            return (from s in context.Students
                    select s).ToList();
        }

        public static Student GetStudent(SchoolContext context, int id)
        {
            Student s2 = context
                            .Students
                            .Where(s => s.StudentId == id)
                            .Single();
            return s2;
        }

        public static void Delete(SchoolContext context, Student s)
        {
            context.Students.Remove(s);
            context.SaveChanges();
        }

        public static void Update(SchoolContext context, Student s)
        {
            //Mark the object as deleted
            context.Students.Update(s);

            //Send delete query to database
            context.SaveChanges();
        }
    }
}
