using Microsoft.AspNetCore.Mvc;
using Personal_Project.DAO;
using Personal_Project.Models;
using Personal_Project.Helper;
using Personal_Project.Helper;

namespace Personal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personal_ProjectController : ControllerBase
    {
        public readonly IPersonalDao _Personal_ProjectDao;

        public Personal_ProjectController(IPersonalDao Personal_ProjectDao)
        {
            _Personal_ProjectDao = Personal_ProjectDao;
        }


        [HttpGet]
        public async Task<ActionResult<List<PersonalData>>> Index()
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            List<PersonalData> players = await _Personal_ProjectDao.GetAllPersonal_Project(baseUri);
            if (players != null)
            {
                return Ok(players);
            }
            return NotFound();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<int>> UploadFile([FromForm] InsertData personal)
        {
            if (personal != null)
            {
                string imageName = new UploadHandler().Upload(personal.ImageFile);
                Console.Write(imageName);
                int res = await _Personal_ProjectDao.InsertPersonalDetails(personal, imageName);
                if (res > 0)
                {
                    return Ok(res);
                }
                return BadRequest("Failed to add player");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<ActionResult<int>> DeleteUser(int id)
        {
            bool res = await _Personal_ProjectDao.DeleteUserById(id);
            if (res)
            {
                return Ok($"User with ID {id} deleted successfully.");
            }
            return NotFound($"User with ID {id} not found.");
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<int>> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            if (request != null)
            {
                int res = await _Personal_ProjectDao.UpdateUserDetails(id, request.PhoneNumber, request.PermanentAddress);
                if (res > 0)
                {
                    return Ok($"User with ID {id} updated successfully.");
                }
                return NotFound($"User with ID {id} not found or no changes were made.");
            }
            return BadRequest("Invalid data provided.");
        }

    }
}