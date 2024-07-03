using DbMyDemo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMyDemo.DataTransactions
{
    public class DBTrans
    {
        public string dbPath;
        private SQLiteConnection conn;


        public DBTrans(string _dbPath)
        {
            this.dbPath = _dbPath;
            Init();
        }
        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<StudentClass>();
            conn.CreateTable<CourseClass>();
            conn.CreateTable<EnrollClass>();
        }

        public List<StudentClass> GetStudents()
        {
            return conn.Table<StudentClass>().ToList();
        }

        public void AddStudent(StudentClass student)
        {
            conn.Insert(student);
        }
        public void DeleteStudent(int studentId)
        {
            conn.Delete<StudentClass>(studentId);
        }
        public List<CourseClass> GetAllCourses()
        {
            return conn.Table<CourseClass>().ToList();
        }

        public void AddCourse(CourseClass course)
        {
            conn.Insert(course);
        }

        public void DeleteCourse(int courseId)
        {
            conn.Delete<CourseClass>(courseId);
        }

        public void AddEnrollment(EnrollClass enrollment)
        {
            conn.Insert(enrollment);
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            conn.Delete<EnrollClass>(enrollmentId);
        }

        public void UpdateEnrollment(EnrollClass enrollment)
        {
            conn.Update(enrollment);
        }

        public List<EnrollClass> GetAllEnrollments()
        {
            return conn.Table<EnrollClass>().ToList();
        }
    }
}
