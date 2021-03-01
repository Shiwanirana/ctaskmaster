using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using ctaskmaster.Models;

namespace ctaskmaster.Repositories
{
  public class TasksRepository
  {
    private readonly IDbConnection _db;

    public TasksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Tasky> GetAll()
    {
      string sql = @"
      SELECT * FROM tasks";
      return _db.Query<Tasky>(sql);
    }


    // REVIEW[epic=Populate] add the creator to the object
    internal Tasky GetById(int id)
    {
      string sql = "SELECT * FROM tasks WHERE Id=@id";
       return _db.QueryFirstOrDefault<Tasky>(sql, new { id });

    }

    internal Tasky Create(Tasky newTask)
    {
      string sql = @"
      INSERT INTO tasks 
      (body) 
      VALUES 
      (@CreatorId, @Title);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newTask);
      newTask.Id = id;
      return newTask;
    }

    internal Tasky Edit(Tasky updated)
    {
      string sql = @"
        UPDATE tasks
        SET
         body = @Body
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    // REVIEW[epic=many-to-many] This sql will add the relationship id to a Tasky, as the PartyPartyMemberViewModel
    // REVIEW[epic=Populate] and get the creator
    // internal IEnumerable<TaskProfileViewModel> GetTasksByProfileId(string id)
    // {
    //   string sql = @"
    //   SELECT
    //   lis.*,
    //   lp.id as TaskProfileId,
    //   pr.*
    //   FROM Taskprofiles lp
    //   JOIN Tasks lis ON lp.TaskId == lis.id
    //   JOIN profiles pr ON lis.creatorId = pr.id
    //   WHERE profileId = @id
    //   ";
    //   return _db.Query<TaskProfileViewModel, Profile, TaskProfileViewModel>(sql, (Task, profile) =>
    //   {
    //     Task.Creator = profile;
    //     return Task;
    //   }
    //     , new { id }, splitOn: "id");
    // }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM tasks WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}