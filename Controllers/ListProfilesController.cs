using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using ctaskmaster.Models;
using ctaskmaster.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ctaskmaster.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ListProfilesController : ControllerBase
  {
    private readonly ListProfilesService _service;
    public ListProfilesController(ListProfilesService service)
    {
      _service = service;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<string>> Create([FromBody] ListProfile lp)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.Create(lp, userInfo.Id);
        return Ok("success");
      }
      catch (NotAuthorized e)
      {
        return Forbid(e.Message);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
         return BadRequest (e.Message);
      }
    }
  }
}