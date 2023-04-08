using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Data.SQLite;

namespace SimpleLMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LMSController : ControllerBase
    {

        private readonly ILogger<LMSController> _logger;
        private SqliteConnection sqliteConnection = new SqliteConnection("Data Source=SimpleLMSDB.db");

        public LMSController(ILogger<LMSController> logger)
        {
            _logger = logger;
            TableSetup();
        }

        private void TableSetup()
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "DROP TABLE IF EXISTS Assignment";
            sqliteQuery.ExecuteNonQuery();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "DROP TABLE IF EXISTS Module";
            sqliteQuery.ExecuteNonQuery();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "DROP TABLE IF EXISTS Course";
            sqliteQuery.ExecuteNonQuery();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "CREATE TABLE \"Assignment\" ( \"ID\" INTEGER NOT NULL UNIQUE, \"Name\" TEXT NOT NULL, " +
                "\"Grade\" INTEGER, \"DueDate\" TEXT NOT NULL, \"ModuleID\" INTEGER, PRIMARY KEY(\"ID\" AUTOINCREMENT), " +
                "FOREIGN KEY(\"ModuleID\") REFERENCES Module(ID) )";
            sqliteQuery.ExecuteNonQuery();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "CREATE TABLE \"Course\" ( \"ID\" INTEGER NOT NULL UNIQUE, \"Name\" TEXT NOT NULL, PRIMARY KEY(\"ID\") )";
            sqliteQuery.ExecuteNonQuery();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "CREATE TABLE \"Module\" ( \"ID\" INTEGER NOT NULL UNIQUE, \"Name\" TEXT NOT NULL, \"CourseID\" INTEGER NOT NULL, " +
                "FOREIGN KEY(\"CourseID\") REFERENCES Course(ID), PRIMARY KEY(\"ID\") )";
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
        }

        //C
        [HttpPost("~/CreateModule")]
        public string CreateModule(Module module)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "INSERT INTO Module(ID, Name, CourseID) VALUES('" + module.ID + "', '" + module.Name + "', '" + module.Course.ID + "')";
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Created Module with id: " + module.ID;
        }

        [HttpPost("~/CreateAssignment")]
        public string CreateAssignment(Assignment assignment)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            if(assignment.Module == null)
            {
                sqliteQuery.CommandText = "INSERT INTO Assignment(ID, Name, Grade, DueDate) VALUES('" + assignment.ID + "', '" + assignment.Name + "', '"
                    + assignment.Grade + "', '" + assignment.DueDate.ToString() +  "')";
            }
            else
            {
                sqliteQuery.CommandText = "INSERT INTO Assignment(ID, Name, Grade, DueDate, ModuleID) VALUES('" + assignment.ID + "', '" + assignment.Name + 
                    "', '" + assignment.Grade + "', '" + assignment.DueDate.ToString() + "', '" + assignment.Module.ID + "')";
            }
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Created Assignment with id: " + assignment.ID;
        }

        [HttpPost("~/CreateCourse")]
        public string CreateCourse(Course course)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "INSERT INTO Course(ID, Name) VALUES('" + course.ID + "', '" + course.Name + "')";
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Created Course with id: " + course.ID;
        }

        //R
        [HttpGet("~/GetAssignment")]
        public string GetAssignment(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "SELECT * FROM Assignment WHERE ID = " + id ;
            SqliteDataReader sQLiteDataReader = sqliteQuery.ExecuteReader();
            string result = "";
            while (sQLiteDataReader.Read())
            {
                result += "ID: " + sQLiteDataReader["ID"] + ", ";
                result += "Name: " + sQLiteDataReader["Name"] + ", ";
                result += "Grade: " + sQLiteDataReader["Grade"] + ", ";
                result += "DueDate: " + sQLiteDataReader["DueDate"] + ", ";
                result += "ModuleID: " + sQLiteDataReader["ModuleID"];
            }
            sqliteConnection.Close();
            return result;
        }

        [HttpGet("~/GetCourse")]
        public string GetCourse(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "SELECT * FROM Course WHERE ID = " + id;
            SqliteDataReader sQLiteDataReader = sqliteQuery.ExecuteReader();
            string result = "";
            while (sQLiteDataReader.Read())
            {
                result += "ID: " + sQLiteDataReader["ID"] + ", ";
                result += "Name: " + sQLiteDataReader["Name"];
            }
            sqliteConnection.Close();
            return result;
        }

        [HttpGet("~/GetModule")]
        public string GetModule(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "SELECT * FROM Module WHERE ID = " + id;
            SqliteDataReader sQLiteDataReader = sqliteQuery.ExecuteReader();
            string result = "";
            while (sQLiteDataReader.Read())
            {
                result += "ID: " + sQLiteDataReader["ID"] + ", ";
                result += "Name: " + sQLiteDataReader["Name"] + ", ";
                result += "CourseID: " + sQLiteDataReader["CourseID"];
            }
            sqliteConnection.Close();
            return result;
        }

        [HttpGet("~/GetModuleByCourseID")]
        public string GetModuleByCourseID(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "SELECT * FROM Module WHERE CourseID = " + id;
            SqliteDataReader sQLiteDataReader = sqliteQuery.ExecuteReader();
            string result = "";
            while (sQLiteDataReader.Read())
            {
                result += "ID: " + sQLiteDataReader["ID"] + ", ";
                result += "Name: " + sQLiteDataReader["Name"] + ", ";
                result += "CourseID: " + sQLiteDataReader["CourseID"];
            }
            sqliteConnection.Close();
            return result;
        }

        [HttpGet("~/GetAssignmentByModuleID")]
        public string GetAssignmentByModuleID(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "SELECT * FROM Assignment WHERE ModuleID = " + id;
            SqliteDataReader sQLiteDataReader = sqliteQuery.ExecuteReader();
            string result = "";
            while (sQLiteDataReader.Read())
            {
                result += "ID: " + sQLiteDataReader["ID"] + ", ";
                result += "Name: " + sQLiteDataReader["Name"] + ", ";
                result += "Grade: " + sQLiteDataReader["Grade"] + ", ";
                result += "DueDate: " + sQLiteDataReader["DueDate"] + ", ";
                result += "ModuleID: " + sQLiteDataReader["ModuleID"];
            }
            sqliteConnection.Close();
            return result;
        }

        //U
        [HttpPut("~/UpdateModule")]
        public string UpdateModule(Module module)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "UPDATE Module SET Name = '" + module.Name + "' WHERE ID = " + module.ID;
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Updated Module with id: " + module.ID;
        }

        [HttpPut("~/UpdateAssignment")]
        public string UpdateAssignment(Assignment assignment)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "UPDATE Assignment SET Name = '" + assignment.Name + "', Grade = " + assignment.Grade + 
                ", DueDate = '" + assignment.DueDate.ToString() + "' WHERE ID = " + assignment.ID;
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Updated Assignment with id: " + assignment.ID;
        }

        [HttpPut("~/UpdateCourse")]
        public string UpdateCourse(Course course)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "UPDATE Course SET Name = '" + course.Name + "' WHERE ID = " + course.ID;
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Updated Course with id: " + course.ID;
        }

        //D
        [HttpDelete("~/DeleteModule")]
        public string DeleteModule(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "DELETE FROM Module WHERE ID = " + id;
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Deleted Module with id: " + id;
        }   

        [HttpDelete("~/DeleteAssignment")]
        public string DeleteAssignment(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "DELETE FROM Assignment WHERE ID = " + id;
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Deleted Assignment with id: " + id;
        }

        [HttpDelete("~/DeleteCourse")]
        public string DeleteCourse(int id)
        {
            sqliteConnection.Open();
            var sqliteQuery = new SqliteCommand();
            sqliteQuery = sqliteConnection.CreateCommand();
            sqliteQuery.CommandText = "DELETE FROM Course WHERE ID = " + id;
            sqliteQuery.ExecuteNonQuery();
            sqliteConnection.Close();
            return "Deleted Course with id: " + id;
        }
    }
}