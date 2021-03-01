using System;
using ctaskmaster.Models;
using ctaskmaster.Services;
using Microsoft.AspNetCore.Mvc;
namespace ctaskmaster.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ListsController : ControllerBase
  {
    private readonly ListsService _ls;
    private readonly TasksService _ts;
    public ListsController(ListsService ls, TasksService ts)
    {
      _ls = ls;
      _ts = ts;
    }
    [HttpGet("{id}")]
    public ActionResult<Listy> Get(int id)
    {
      try
      {
      return Ok(_ls.GetById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpGet("{id}/Tasks")]
    // public ActionResult<Tasky> GetTasksByListyId(int id)
    // {
    //   try
    //   {
    //     return Ok(_ts.GetTasksByListyId(id));
    //   }
    //   catch(Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    [HttpPost]
    public ActionResult<Listy> Create([FromBody] Listy newListy)
    {
      try
      {
        return Ok(_ls.Create(newListy));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Listy> Edit(int id, [FromBody] Listy editListy)
    {
       try
      {
        return Ok(_ls.Edit(editListy));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Listy> Delete(int id)
    {
      try
      {
        return(_ls.Delete(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}