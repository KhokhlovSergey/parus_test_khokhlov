using Microsoft.AspNetCore.Mvc;
using parus_test_khokhlov.Models;
using parus_test_khokhlov.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace parus_test_khokhlov.Controllers
{

    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public UserApiController(AppDbContext appDbContext)
        {
            _db = new DbHelper(appDbContext);
        }

        // GET: api/<UserApiController>
        [HttpGet]
        [Route("api/[controller]/GetUsers")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;

            try
            {
                IEnumerable<UserModel> data = _db.GetUsers();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));

            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        


    }
}
