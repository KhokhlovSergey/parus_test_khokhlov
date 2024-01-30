using Microsoft.AspNetCore.Mvc;
using parus_test_khokhlov.Models;
using parus_test_khokhlov.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace parus_test_khokhlov.Controllers
{
 
    [ApiController]
    public class CommentApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public CommentApiController(AppDbContext appDbContext)
        {
            _db = new DbHelper(appDbContext);
        }

        // GET api/<CommentApiController> получение комментов к задаче
        //Получение списка задач по проекту
        [Route("api/[controller]/GetCommentByTask/taskId/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                IEnumerable<CommentModel> data = _db.GetCommentsByTask(id);
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

        // POST api/<CommentApiController> сохранение коммента
        [HttpPost]
        [Route("api/[controller]/SaveComment")]
        public IActionResult Post([FromBody] CommentModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveComment(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<CommentApiController>/5 редактирование коммента
        [HttpPut]
        [Route("api/[controller]/UpdateTask")]
        public IActionResult Put([FromBody] CommentModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveComment(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<CommentApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteComment/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteComment(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete success"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }
    }
}
