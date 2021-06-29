using C__ASP_.Net_Core_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace C__ASP_.Net_Core_API.Services
{
    public static class SampleWebApiServices
    {
        static List<TaskModel> _models { get; }
        static int nextId = 4;
        static SampleWebApiServices()
        {
            _models = new List<TaskModel>
            {
                new TaskModel { Id = 1, Title = "Dam Tuan Dat", IsCompleted = false },
                new TaskModel { Id = 2, Title = "Nguyen Viet Duy", IsCompleted = true },
                new TaskModel { Id = 3, Title = "Nguyen Van Cong", IsCompleted = true }
            };
        }

        public static List<TaskModel> GetAll()
        {
            return _models;
        }

        public static TaskModel Get(int id) 
        {
             var item =_models.FirstOrDefault(p => p.Id == id);
             return item;
        }

        public static void Add(TaskModel model)
        {
            model.Id = nextId++;
            _models.Add(model);
        }

        public static void AddListTasks(List<TaskModel> model)
        {
            for (var i = 0; i < model.Count; i++)
            {
                model[i].Id = nextId++;
                _models.Add(model[i]);
            }
        }

        public static void Delete(int id)
        {
            var temp = Get(id);
            if(temp is null)
                return;

            _models.Remove(temp);
        }



        public static void Update(TaskModel model)
        {
            var index = _models.FindIndex(p => p.Id == model.Id);
            if(index == -1)
                return;

            _models[index] = model;
        }

        public static void Remove(TaskModel model)
        {
            _models.Remove(model);
        }
    }
}