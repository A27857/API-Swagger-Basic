using API29v6v21.Models;
using System.Collections.Generic;
using System.Linq;

namespace API29v6v21.Services
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
            var item = _models.FirstOrDefault(p => p.Id == id);
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

        public static bool Delete(int id)
        {
            var temp = Get(id);
            if (temp is null)
            {
                return false;
            }
            _models.Remove(temp);
            return true;
        }

        public static void Update(TaskModel model)
        {
            var index = _models.FindIndex(p => p.Id == model.Id);
            if (index == -1)
                return;

            _models[index] = model;
        }

        public static void Remove(TaskModel model)
        {
            _models.Remove(model);
        }
    }
}