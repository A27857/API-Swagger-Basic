using System.Collections.Generic;
using API29v6v21.Models;
using Microsoft.AspNetCore.Mvc;
using API29v6v21.Services;

namespace API29v6v21.Controllers
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

        [HttpGet("Tasks")]
        public ActionResult<List<TaskModel>> GetAllTask()
        {
            var item = SampleWebApiServices.GetAll();
            return item;
        }

        [HttpGet("Task/{id}")]
        public ActionResult<TaskModel> GetTask(int id)
        {
            var model = SampleWebApiServices.Get(id);

            if (model == null)
                return null;

            return model;
        }

        [HttpPost("Task")]
        public IActionResult CreateTask(TaskModel model)
        {
            SampleWebApiServices.Add(model);
            return CreatedAtAction(nameof(CreateTask), new { id = model.Id }, model);
        }

        [HttpPost("Tasks")]
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

        [HttpPut("Task/{id}")]
        public IActionResult Update(int id, TaskModel model)
        {
            if (id != model.Id)
            {
                return null;
            }
            var modeled = SampleWebApiServices.Get(id);
            if (modeled is null)
            {
                return null;
            }

            SampleWebApiServices.Update(model);

            return Ok("Update Successfully!");
        }

        [HttpDelete("Task/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var model = SampleWebApiServices.Get(id);

            if (model is null)
                return false;

            SampleWebApiServices.Delete(id);

            return true;
        }

        [HttpDelete("Tasks")]
        public ActionResult<bool> DeleteTasks(List<int> ids)
        {
            for (var i = 0; i < ids.Count; i++)
            {
                var model = SampleWebApiServices.Get(ids[i]);
                if (model is null)
                    return false;

                SampleWebApiServices.Remove(model);
            }
            return true;
        }
    }
}