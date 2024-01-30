using Microsoft.AspNetCore.Mvc;
using parus_test_khokhlov.Models;
using parus_test_khokhlov.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace parus_test_khokhlov.Controllers
{
   
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public ProjectApiController(AppDbContext appDbContext)
        {
            _db = new DbHelper(appDbContext);
        }

        // GET: api/<ProjectApiController>
        [HttpGet]
        [Route("api/[controller]/GetProjects")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;

            try
            {
                IEnumerable<ProjectModel> data = _db.GetProjects();
                if(!data.Any())
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

        // GET api/<ProjectApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProjectById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                ProjectModel data = _db.GetProjectById(id);
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
        



        // POST api/<ProjectApiController>
        [HttpPost]
        [Route("api/[controller]/SaveProject")]
        public IActionResult Post([FromBody] ProjectModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveProgect(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ProjectApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateProject")]
        public IActionResult Put([FromBody] ProjectModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveProgect(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        //Добавление и удаление пользователя к проекту
        [HttpPut]
        [Route("api/[controller]/UserByProject/{_type}/projectId/{pId}/userId/{uId}")]
        public IActionResult Put(string _type, int pId, int uId)
        {
           
            try
            {
                ResponseType type = ResponseType.Success;
                ProjectModel projectData = _db.GetProjectById(pId);
                UserModel userData = _db.GetUserById(uId);
                if (_type == "add")                {

                    if (projectData == null || userData == null)
                    {
                        type = ResponseType.NotFound;
                    }
                    _db.ProjectAddUser(pId, uId);
                    return Ok(ResponseHandler.GetAppResponse(type, projectData));
                }
                else if (_type == "del")
                {
                    if (projectData == null || userData == null)
                    {
                        type = ResponseType.NotFound;
                    }
                    _db.ProjectDelUser(pId, uId);
                    return Ok(ResponseHandler.GetAppResponse(type, projectData));
                }
                else
                {
                    type = ResponseType.NotFound;
                    return Ok(ResponseHandler.GetAppResponse(type, projectData));
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        //Добавление и удаление задачи к проекту
        [HttpPut]
        [Route("api/[controller]/TaskByProject/{_type}/projectId/{pId}/taskId/{tId}/string/{_task}")]
        public IActionResult Put(string _type, int pId, int tId, string _task)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                ProjectModel projectData = _db.GetProjectById(pId);
                ProjectTaskModel taskData = _db.GetTaskById(tId);
                if (_type == "add")
                {

                    if (projectData == null || taskData == null)
                    {
                        type = ResponseType.NotFound;
                    }
                    _db.ProjectAddTask(pId, tId);
                    return Ok(ResponseHandler.GetAppResponse(type, projectData));
                }
                else if (_type == "del")
                {
                    if (projectData == null || taskData == null)
                    {
                        type = ResponseType.NotFound;
                    }
                    _db.ProjectDelTask(pId, tId);
                    return Ok(ResponseHandler.GetAppResponse(type, projectData));
                }
                else
                {
                    type = ResponseType.NotFound;
                    return Ok(ResponseHandler.GetAppResponse(type, projectData));
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ProjectApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteProject/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteProject(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete success"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
            
        }
    }
}
