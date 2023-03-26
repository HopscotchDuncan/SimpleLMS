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
        public void TestCreateModule()
        {
            string expected = "Created Module with id: 10";
            Module module = new Module { ID = 10, Name = "Week 10" };
            string actual = controller.CreateModule(module);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreateAssignment()
        {
            string expected = "Created Assignment with id: 10";
            Assignment assignment = new Assignment { ID = 10, Name = "Web API", DueDate = DateTime.Now, Grade = 90 };
            string actual = controller.CreateAssignment(assignment);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreateCourse()
        {
            string expected = "Created Course with id: 10";
            Course course = new Course { ID = 10, Name = "Web Architecture" };
            string actual = controller.CreateCourse(course);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetAssignment()
        {
            string expected = "Get Assignment with id: 10";
            string actual = controller.GetAssignment(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCourse()
        {
            string expected = "Get Course with id: 10";
            string actual = controller.GetCourse(10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetModule()
        {
            string expected = "Get Module with id: 10";
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
    }
}