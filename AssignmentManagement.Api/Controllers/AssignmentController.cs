
using Microsoft.AspNetCore.Mvc;
using AssignmentManagement.Core;


namespace AssignmentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> GetAll()
        {
            var assignments = _assignmentService.ListAll();
            return Ok(assignments);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Assignment assignment)
        {
            if (assignment == null)
            {
                return BadRequest("Assignment object cannot be null.");
            }

            _assignmentService.AddAssignment(assignment);
            return CreatedAtAction(nameof(GetAll), new { title = assignment.Title }, assignment);
        }

        [HttpDelete("{title}")]
        public IActionResult Delete(string title)
        {
            _assignmentService.DeleteAssignment(title);
            return NoContent();
        }
    }
}
