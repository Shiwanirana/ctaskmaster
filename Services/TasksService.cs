using System;
using System.Collections.Generic;
using ctaskmaster.Models;
using ctaskmaster.Repositories;

namespace ctaskmaster.Services
{
  public class TasksService
  {
    private readonly TasksRepository _repo;
    public TasksService(TasksRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Tasky> GetAll()
    {
      // FIXME Should not be able to get any and all Taskys
      return _repo.GetAll();
    }

    internal Tasky GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Tasky Create(Tasky newTask)
    {
      return _repo.Create(newTask);
    }

    internal Tasky Edit(Tasky editTask)
    {
      var data = GetById(editTask.Id);
      editTask.Body = editTask.Body != null ? editTask.Body : data.Body;
      return _repo.Edit(editTask);
    }

    internal Tasky Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return data;
    }
    // internal IEnumerable<Tasky> Get 
  }
}