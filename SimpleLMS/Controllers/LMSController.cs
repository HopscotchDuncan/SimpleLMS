using Microsoft.AspNetCore.Mvc;

namespace SimpleLMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LMSController : ControllerBase
    {

        private readonly ILogger<LMSController> _logger;

        public LMSController(ILogger<LMSController> logger)
        {
            _logger = logger;
        }

        //C
        [HttpPost("~/CreateModule")]
        public string CreateModule(Module module)
        {
            return "Created Module with id: " + module.ID;
        }

        [HttpPost("~/CreateAssignment")]
        public string CreateAssignment(Assignment assignment)
        {
            return "Created Assignment with id: " + assignment.ID;
        }

        [HttpPost("~/CreateCourse")]
        public string CreateCourse(Course course)
        {
            return "Created Course with id: " + course.ID;
        }

        //R
        [HttpGet("~/GetAssignment")]
        public string GetAssignment(int id)
        {
            return "Get Assignment with id: " + id;
        }

        [HttpGet("~/GetCourse")]
        public string GetCourse(int id)
        {
            return "Get Course with id: " + id;
        }

        [HttpGet("~/GetModule")]
        public string GetModule(int id)
        {
            return "Get Module with id: " + id;
        }

        //U
        [HttpPut("~/UpdateModule")]
        public string UpdateModule(Module module)
        {
            return "Updated Module with id: " + module.ID;
        }

        [HttpPut("~/UpdateAssignment")]
        public string UpdateAssignment(Assignment assignment)
        {
            return "Updated Assignment with id: " + assignment.ID;
        }

        [HttpPut("~/UpdateCourse")]
        public string UpdateCourse(Course course)
        {
            return "Updated Course with id: " + course.ID;
        }

        //D
        [HttpDelete("~/DeleteModule")]
        public string DeleteModule(int id)
        {
            return "Deleted Module with id: " + id;
        }   

        [HttpDelete("~/DeleteAssignment")]
        public string DeleteAssignment(int id)
        {
            return "Deleted Assignment with id: " + id;
        }

        [HttpDelete("~/DeleteCourse")]
        public string DeleteCourse(int id)
        {
            return "Deleted Course with id: " + id;
        }
    }
}