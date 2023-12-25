using Microsoft.AspNetCore.Mvc;
using myTask.Models;
using myTask.Services;

namespace myTask.Controllers;

[ApiController]
[Route("[controller]")]
public class myTaskController : ControllerBase
{
 [HttpGet]
    public ActionResult<List<theTask>> Get()
    {
        return theTaskService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<theTask> Get(int id)
    {
        var task = theTaskService.GetById(id);
        if (task == null)
            return NotFound();
        return task;
    }

    [HttpPost]
    public ActionResult Post(theTask newTask)
    {
        var newId = theTaskService.Add(newTask);

        return CreatedAtAction("Post", 
            new {id = newId}, theTaskService.GetById(newId));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id,theTask newTask)
    {
        var result = theTaskService.Update(id, newTask);
        if (!result)
        {
            return BadRequest();
        }
        return NoContent();
    }
    
}
