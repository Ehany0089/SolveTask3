using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace SolveTask3
{
    class Student
    {
        //Properties:
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> courses = [];

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
           
        }



        //Methods:
        public  bool Enroll(Course course)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId == course.CourseId)
                
                    return false;     
            }
            courses.Add(course);
            return true;

        }
        public bool Specific(int Courseid)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId ==Courseid)

                    return true;
                
            }

            return false;
        }
        public string PrintDetails()
        {
            string result;
            string allcourses = " ";
            if (courses.Count == 0)
            {
                result = "ID: " + StudentId
               + ", Name: " + Name
               + ", Age: " + Age + ",No courses enrolled" ;
                return result;
            }
            for (int i=0; i<courses.Count; i++)
            {
                allcourses += courses[i].Title + ",";
            }
            result = "ID: " + StudentId
        + ", Name: " + Name
        + ", Age: " + Age + ",courses:" + allcourses;
            return result;
        }
    }

    
    class Instructor
    {
        // Properties:
       public int InstructorId;
       public string Name;
       public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        // Methods:
        public  string PrintDetails()
        {
            string result = "instructorId : " + InstructorId + "name : "
                + Name + "specialization : " + Specialization;
            return result;
        }


    }
    class Course
    {
        //  Properties:
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        //Methods:
        public string PrintDetails()
        {
            string result = "courseId : " + CourseId
                + "title : " + Title
                + "instructor : " + Instructor.Name;

            return result;
        }

    }
    class School
    {
        // Properties:
        public List<Student> Students = [];
        public List<Course> Courses = [];
        public List<Instructor> Instructors = [];
        //public School(List<Student> students, List<Course> courses, List<Instructor> instructors)
        //{
        //    Students = students;
        //    Courses = courses;
        //    Instructors = instructors;
        //}

        // Methods:
        public bool AddStudent(Student student)
        {
            for (int i =0; i< Students.Count; i++)
            {
                if (Students[i].StudentId == student.StudentId)
                
                    return false;
            }
            Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)

                    return false;
            }
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructor.InstructorId)

                    return false;
            }
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            
            for (int i=0; i<Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                    return Students[i];
            }
            return null;
        }
        public Student FindStudent(string name)
        {

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Name == name)
                    return Students[i];
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                    return Courses[i];
            }
            return null;
        }
        public Course FindCourse(string title)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == title)
                    return Courses[i];
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                    return Instructors[i];
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
           if (student == null || course == null)
                return false;

            return student.Enroll(course);

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            int number;
            int id;
            string name;
            do
            {
                Console.WriteLine("Sample Console Menu (on the StudentManager):");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add Instructor");
                Console.WriteLine("3.Add Course");
                Console.WriteLine("4.Enroll Student in Course");
                Console.WriteLine("5.Show All Students ");
                Console.WriteLine("6.Show All Courses ");
                Console.WriteLine("7.Show All Instructors");
                Console.WriteLine("8.Find the student by id or name ");
                Console.WriteLine("9.Fine the course by id or name ");
                Console.WriteLine("10.Exit");
                Console.WriteLine("11. Check if the student enrolled in specific course");
                Console.WriteLine("12 Return the instructor name by course name");
                number = Convert.ToInt32(Console.ReadLine());
                
                switch (number)
                {
                    case 1:
                        int age;
                       
                        Console.WriteLine("enter student id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter student name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("enter student age: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        Student student1 = new Student(id, name, age);
                        if (school.AddStudent(student1))
                        {
                            Console.WriteLine("successful");
                        }
                        else
                        {
                            Console.WriteLine("Student ID already exists.");
                        }
                        break;
                    case 2:
                        string Specialization;
                        Console.WriteLine("enter instructor id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter instructor name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("enter instructor Specialization: ");
                        Specialization =Console.ReadLine();
                        Instructor instructor = new Instructor(id, name, Specialization);
                        if (school.AddInstructor(instructor))
                        {
                            Console.WriteLine("successful");
                        }
                        else
                        {
                            Console.WriteLine("Instructor ID already exists.");
                        }
                        break;
                    case 3:
                        int instructorid;
                        Console.WriteLine("enter Course id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Course name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("enter Course instructorid: ");
                        instructorid = Convert.ToInt32(Console.ReadLine());
                       Instructor instructor2= school.FindInstructor(instructorid);
                        if (instructor2 == null)
                        {
                            Console.WriteLine("instructor not found");
                            break;
                        }
                        Course course = new Course(id, name, instructor2);
                        if (school.AddCourse(course))
                        {
                            Console.WriteLine("successful");
                        }
                        else
                        {
                            Console.WriteLine("Course ID already exists.");
                        }
                        break;
                    case 4:
                        int coursid;
                        Console.WriteLine("enter student id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Course id: ");
                        coursid = Convert.ToInt32(Console.ReadLine());
                       
                        
                        if (school.EnrollStudentInCourse(id, coursid))
                        {
                            Console.WriteLine("successful");
                        }
                        else
                        {
                            Console.WriteLine("failed ");
                        }
                            break;
                    case 5:
                        if (school.Students.Count == 0)
                        {
                            Console.WriteLine("No students found. ");
                        }
                        else
                        {

                            for (int i = 0; i < school.Students.Count; i++)
                            {
                                Console.WriteLine(school.Students[i].PrintDetails());
                                
                            }
                        }
                        break;
                    case 6:
                        if (school.Courses.Count == 0)
                        {
                            Console.WriteLine("No courses found. ");
                        }
                        else
                        {

                            for (int i = 0; i < school.Courses.Count; i++)
                            {
                                Console.WriteLine(school.Courses[i].PrintDetails());

                            }
                        }
                        break;
                    case 7:
                        if (school.Instructors.Count == 0)
                        {
                            Console.WriteLine("No instructors found. ");
                        }
                        else
                        {

                            for (int i = 0; i < school.Instructors.Count; i++)
                            {
                                Console.WriteLine(school.Instructors[i].PrintDetails());

                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter student ID:");
                        int studentId = Convert.ToInt32(Console.ReadLine());

                        Student student = school.FindStudent(studentId);

                        if (student == null)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        else
                        {
                            Console.WriteLine(student.PrintDetails());
                        }

                        break;
                    case 9:
                        Console.WriteLine("Enter course ID:");
                        int courseId = Convert.ToInt32(Console.ReadLine());

                        Course cour = school.FindCourse(courseId);

                        if (cour == null)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        else
                        {
                            Console.WriteLine(cour.PrintDetails());
                        }
                        break;
                    case 10:
                        break;
                    case 11:
                        Console.WriteLine("search student id");
                        int stid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("search course id");
                        int courid = Convert.ToInt32(Console.ReadLine());
                       Student st = school.FindStudent(stid);
                        Course corse2 = school.FindCourse(courid);
                        if (st == null)
                        {
                            Console.WriteLine(" student id not found");
                        }else if (corse2 == null)
                        {
                            Console.WriteLine(" course id not found");
                        }
                        else
                        {

                            if (st.Specific(courid))
                            {
                                Console.WriteLine("true");
                            }
                            else
                            {
                                Console.WriteLine("false");
                            }
                        }
                        break;
                    case 12:
                        Console.WriteLine("search course title");
                        string title = Console.ReadLine();
                        Course cor =  school.FindCourse(title);
                        if (cor == null)
                        {
                            Console.WriteLine(" Course not found.");
                        }else
                        {
                            Console.WriteLine(cor.Instructor.Name);
                            
                        }
                        break;
                    default:
                        Console.WriteLine("in valide");
                        break;

                }
            } while (number != 10);

        }
      
    }
}
