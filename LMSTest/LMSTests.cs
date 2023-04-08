using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using SimpleLMS.Controllers;

namespace LMSTest
{
    [TestClass]
    public class LMSTests
    {
        readonly LMSController controller = new LMSController(Mock.Of<ILogger<LMSController>>());

        [TestMethod]
        public void TestCreateCourse()
        {
            string expected = "Created Course with id: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            string actual = controller.CreateCourse(course);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreateModule()
        {
            string expected = "Created Module with id: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            controller.CreateCourse(course);
            string actual = controller.CreateModule(module);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreateAssignment()
        {
            string expected = "Created Assignment with id: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            Assignment assignment = new Assignment { ID = 10, Name = "Web API", DueDate = DateTime.Now, Grade = 90, Module = module };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            string actual = controller.CreateAssignment(assignment);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetAssignment()
        {
            string expected = "ID: 10, Name: LMS, Grade: 10, DueDate: " + DateTime.Now + ", ModuleID: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            Assignment assignment = new Assignment {ID = 10, Name = "LMS", Grade = 10, DueDate = DateTime.Now, Module = module };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            controller.CreateAssignment(assignment);
            string actual = controller.GetAssignment(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCourse()
        {
            string expected = "ID: 10, Name: Web Architecture";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            controller.CreateCourse(course);
            string actual = controller.GetCourse(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetModule()
        {
            string expected = "ID: 10, Name: Week 10, CourseID: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            string actual = controller.GetModule(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateModule()
        {
            string expected = "Updated Module with id: 10";
            Module module = new Module { ID = 10, Name = "Week 10" };
            string actual = controller.UpdateModule(module);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateAssignment()
        {
            string expected = "Updated Assignment with id: 10";
            Assignment assignment = new Assignment { ID = 10, Name = "Web API", DueDate = DateTime.Now, Grade = 90 };
            string actual = controller.UpdateAssignment(assignment);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateCourse()
        {
            string expected = "Updated Course with id: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            string actual = controller.UpdateCourse(course);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteModule()
        {
            string expected = "Deleted Module with id: 10";
            string actual = controller.DeleteModule(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteAssignment()
        {
            string expected = "Deleted Assignment with id: 10";
            string actual = controller.DeleteAssignment(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteCourse()
        {
            string expected = "Deleted Course with id: 10";
            string actual = controller.DeleteCourse(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequiredTest1()
        {
            string expected = "ID: 10, Name: Web Architecture";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            controller.CreateCourse(course);
            string actual = controller.GetCourse(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequiredTest2()
        {
            string expected = "ID: 10, Name: Web ArchitectureID: 10, Name: Week 10, CourseID: 10ID: 20, Name: Week 10, CourseID: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            Module module2 = new Module { ID = 20, Name = "Week 10", Course = course };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            controller.CreateModule(module2);
            string actual = controller.GetCourse(10);
            actual += controller.GetModuleByCourseID(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequiredTest3()
        {
            string expected = "ID: 10, Name: Web ArchitectureID: 20, Name: Web ArchitectureID: 30, Name: Web Architecture";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Course course2 = new Course { ID = 20, Name = "Web Architecture" };
            Course course3 = new Course { ID = 30, Name = "Web Architecture" };
            controller.CreateCourse(course);
            controller.CreateCourse(course2);
            controller.CreateCourse(course3);
            string actual = controller.GetCourse(10);
            actual += controller.GetCourse(20);
            actual += controller.GetCourse(30);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequiredTest4()
        {
            string expected = "ID: 10, Name: Web API, Grade: 90, DueDate: " + DateTime.Now + ", ModuleID: ID: 30, Name: Web API, Grade: 90, DueDate: " + DateTime.Now + ", ModuleID: ";
            Assignment assignment = new Assignment { ID = 10, Name = "Web API", DueDate = DateTime.Now, Grade = 90, Module = null };
            Assignment assignment2 = new Assignment { ID = 20, Name = "Web API", DueDate = DateTime.Now, Grade = 90, Module = null };
            Assignment assignment3 = new Assignment { ID = 30, Name = "Web API", DueDate = DateTime.Now, Grade = 90, Module = null };
            controller.CreateAssignment(assignment);
            controller.CreateAssignment(assignment2);
            controller.CreateAssignment(assignment3);
            controller.DeleteAssignment(20);
            string actual = controller.GetAssignment(10);
            actual += controller.GetAssignment(20);
            actual += controller.GetAssignment(30);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadFullRelationships()
        {
            string expected = "ID: 10, Name: Web ArchitectureID: 10, Name: Week 10, CourseID: 10ID: 10, Name: LMS, Grade: 10, DueDate: " + DateTime.Now + ", ModuleID: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            Assignment assignment = new Assignment { ID = 10, Name = "LMS", Grade = 10, DueDate = DateTime.Now, Module = module };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            controller.CreateAssignment(assignment);
            string actual = controller.GetCourse(10);
            actual += controller.GetModule(10);
            actual += controller.GetAssignment(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAssignmentIndependenceAndDependence()
        {
            string expected = "ID: 10, Name: LMS, Grade: 10, DueDate: " + DateTime.Now + ", ModuleID: 10ID: 20, Name: LMS, Grade: 10, DueDate: " + DateTime.Now + ", ModuleID: ";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            Assignment assignment = new Assignment { ID = 10, Name = "LMS", Grade = 10, DueDate = DateTime.Now, Module = module };
            Assignment assignment2 = new Assignment { ID = 20, Name = "LMS", Grade = 10, DueDate = DateTime.Now, Module = null };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            controller.CreateAssignment(assignment);
            controller.CreateAssignment(assignment2);
            string actual = controller.GetAssignment(10);
            actual += controller.GetAssignment(20);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultipleAssignmentsUnderModule()
        {
            string expected = "ID: 10, Name: LMS, Grade: 10, DueDate: " + DateTime.Now + ", ModuleID: 10ID: 20, Name: LMS, Grade: 10, DueDate: " + DateTime.Now + ", ModuleID: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            Module module = new Module { ID = 10, Name = "Week 10", Course = course };
            Assignment assignment = new Assignment { ID = 10, Name = "LMS", Grade = 10, DueDate = DateTime.Now, Module = module };
            Assignment assignment2 = new Assignment { ID = 20, Name = "LMS", Grade = 10, DueDate = DateTime.Now, Module = module };
            controller.CreateCourse(course);
            controller.CreateModule(module);
            controller.CreateAssignment(assignment);
            controller.CreateAssignment(assignment2);
            string actual = controller.GetAssignmentByModuleID(10);
            Assert.AreEqual(expected, actual);
        }
    }
}