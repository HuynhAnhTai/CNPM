using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Tests
{
    [TestClass()]
    public class StudentManagerTests
    {
        [TestMethod()]
        public void addStudentTest()
        {
            StudentManager manager = new StudentManager();
            Student s1 = new Student("1", "Anh", 8, 8);
            Student s2 = new Student("1", "Tai", 8, 8);

            bool kq1 = manager.addStudent(s1);
            bool kq2 = manager.addStudent(s2);



            Assert.IsTrue(kq1);
            Assert.IsFalse(kq2);
            Assert.AreEqual(1, manager.size());
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void addStudentTest2()
        {
            StudentManager manager = new StudentManager();
            Student s3 = new Student(null, null, 0, 0);


            manager.addStudent(s3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void getStudentAtTest()
        {
            StudentManager manager = new StudentManager();

            int position = manager.size() + 1;
            Student student = manager.getStudentAt(position);

        }

        [TestMethod()]
        public void getStudentAtTest2()
        {
            StudentManager manager = new StudentManager();
            Student s1 = new Student("1", "Anh", 8, 8);
            manager.addStudent(s1);

            Student student = manager.getStudentAt(0);
            Assert.IsNotNull(student);

        }

        [TestMethod()]
        public void findStudentByAgeTest()
        {
            StudentManager manager = new StudentManager();
            Student sv = manager.findStudentByAge(8);
            Assert.IsNull(sv);
        }

        [TestMethod()]
        public void findStudentByAgeTest2()
        {
            StudentManager manager = new StudentManager();
            Student s1 = new Student("1", "Anh", 8, 8);
            manager.addStudent(s1);

            Student sv = manager.findStudentByAge(8);
            Assert.IsNotNull(sv);
        }

        [TestMethod()]
        public void getAverageScoreTest()
        {
            StudentManager manager = new StudentManager();
            Student s1 = new Student("1", "Anh", 8, 8);
            Student s2 = new Student("2", "Anh", 8, 8);
            manager.addStudent(s1);
            manager.addStudent(s2);

            double dtb = manager.getAverageScore();
            Assert.IsNotNull(dtb);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void getAverageScoreTest2()
        {
            StudentManager manager = new StudentManager();

            double dtb = manager.getAverageScore();
        }
    }
}