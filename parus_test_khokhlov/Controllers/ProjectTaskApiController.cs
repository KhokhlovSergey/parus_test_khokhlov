﻿using Microsoft.AspNetCore.Mvc;
using parus_test_khokhlov.Models;
using parus_test_khokhlov.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace parus_test_khokhlov.Controllers
{
    
    [ApiController]
    public class ProjectTaskApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public ProjectTaskApiController(AppDbContext appDbContext)
        {
            _db = new DbHelper(appDbContext);
        }

        //Получение списка задач по проекту
        [Route("api/[controller]/GetTaskByProject/projectId/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                IEnumerable<ProjectTaskModel> data = _db.GetTaskByProject(id);
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

        //Получение задач по статусу
        [Route("api/[controller]/GetTaskByStatus/status/{status}")]
        public IActionResult Get(string status)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                IEnumerable<ProjectTaskModel> data = _db.GetTaskByStatus(status);
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

        // POST api/<Project_taskApiController> сохранение задачи
        [HttpPost]
        [Route("api/[controller]/SaveTask")]
        public IActionResult Post([FromBody] ProjectTaskModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveTask(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ProjectApiController>/5 редактирование задачи
        [HttpPut]
        [Route("api/[controller]/UpdateTask")]
        public IActionResult Put([FromBody] ProjectTaskModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveTask(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ProjectApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteTask/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteTask(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete success"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }




    }
}
