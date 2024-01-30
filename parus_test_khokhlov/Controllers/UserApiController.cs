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

        //Получение пользователей в разбивке по проектам

        [HttpGet]
        [Route("api/[controller]/GetUsersByProject/projectId/{id}/{_temp}")]
        public IActionResult Get(int id, string _temp)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                IEnumerable<UserModel> data = _db.GetUsersByProject(id);
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

        //Получение пользователя по айдишнику
        [HttpGet]
        [Route("api/[controller]/GetUserById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                UserModel data = _db.GetUserById(id);
                if (data == null)
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

        // POST api/<UserApiController>
        [HttpPost]
        [Route("api/[controller]/SaveUser")]
        public IActionResult Post([FromBody] UserModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUser(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<UserApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public IActionResult Put([FromBody] UserModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUser(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteUser(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete success"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }



    }
}
