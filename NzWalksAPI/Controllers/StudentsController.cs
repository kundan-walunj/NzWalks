using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NzWalksAPI.Controllers
{
        //  get: http://localhost:portno/api/Students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]  //fun below responds to get http req
        public IActionResult GetStudentsNames()
        {
            string[] students = new string[] {"kundan","manav","faizan","Raju" };
            return Ok(students);
        }
    }
}
