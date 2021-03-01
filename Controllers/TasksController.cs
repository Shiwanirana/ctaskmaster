using System;
using ctaskmaster.Models;
using ctaskmaster.Services;
using Microsoft.AspNetCore.Mvc;
namespace ctaskmaster.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TasksController : ControllerBase
  {
    private readonly TasksService _ts;
    public TasksController(TasksService ts)
    {
      _ts = ts;
    }
    [HttpGet("{id}")]
    public ActionResult<Tasky> Get(int id)
    {
      try
      {
      return Ok(_ts.GetById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Tasky> Create([FromBody] Tasky newTask)
    {
      try
      {
        return Ok(_ts.Create(newTask));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Tasky> Edit(int id, [FromBody] Tasky editTask)
    {
       try
      {
        return Ok(_ts.Edit(editTask));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Tasky> Delete(int id)
    {
      try
      {
        return(_ts.Delete(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}