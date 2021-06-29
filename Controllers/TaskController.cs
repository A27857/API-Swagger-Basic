using System.Collections.Generic;
using C__ASP_.Net_Core_API.Models;
using Microsoft.AspNetCore.Mvc;
using C__ASP_.Net_Core_API.Services;

namespace C__ASP_.Net_Core_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TaskController : ControllerBase
    {
        private SampleWebApiContext _context;
        public TaskController(SampleWebApiContext contex)
        {
            _context = contex;
        }

        [HttpGet("GetAllTask")]
        public ActionResult<List<TaskModel>> GetAllTask()
        {
            var item = SampleWebApiServices.GetAll();
            return item;
        }

        [HttpGet("GetTask/{id}")]
        public ActionResult<TaskModel> GetTask(int id)
        {
            var model = SampleWebApiServices.Get(id);

            if (model == null)
                return NotFound();

            return model;
        }

        [HttpPost("CreateTask")]
        public IActionResult CreateTask(TaskModel model)
        {
            SampleWebApiServices.Add(model);
            return CreatedAtAction(nameof(CreateTask), new { id = model.Id }, model);
        }

        [HttpPost("CreateTasks")]
        public IActionResult CreateTasks(List<TaskModel> model)
        {
            SampleWebApiServices.AddListTasks(model);
            return Ok("Successfully!");
            // var modelTemp = new List<TaskModel>();
            // for(int i=0; i< model.Count;i++)
            // {
            //     SampleWebApiServices.Add(model[i]);
            //     CreatedAtAction(nameof(CreateTasks), new { id = model[i].Id }, model);
            // }
            // return Ok();
        }


        [HttpPut("Edit/{id}")]
        public IActionResult Update(int id, TaskModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var modeled = SampleWebApiServices.Get(id);
            if (modeled is null)
            {
                return NotFound();
            }

            SampleWebApiServices.Update(model);

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var model = SampleWebApiServices.Get(id);

            if (model is null)
                return NotFound();

            SampleWebApiServices.Delete(id);

            return NoContent();
        }

        [HttpDelete("DeleteTasks")]
        public IActionResult DeleteTasks(List<int> ids)
        {
            for (var i = 0; i < ids.Count; i++)
            {
                var model = SampleWebApiServices.Get(ids[i]);
                if (model is null)
                    return NotFound();

                SampleWebApiServices.Remove(model);
            }
            return NoContent();
        }
    }
}