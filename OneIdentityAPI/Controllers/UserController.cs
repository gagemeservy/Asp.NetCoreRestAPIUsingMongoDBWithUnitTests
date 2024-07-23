using Microsoft.AspNetCore.Mvc;
using OneIdentityAPI.Services;
using OneIdentityAPI.Models;

namespace OneIdentityAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    public UsersController(MongoDBService mongoDBService) =>
        _mongoDBService = mongoDBService;

    [HttpGet]
    public async Task<List<Users>> Get()=>
        await _mongoDBService.GetAsync();

    /*[HttpGet("{DB_ID:length(24)}")]
    public async Task<ActionResult<Users>> Get(string DB_ID)
    {
        var user = await _mongoDBService.GetDBIDAsync(DB_ID);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }*/

    [HttpGet("{User_ID}")]
    public async Task<ActionResult<Users>> GetByUserID(int User_ID)
    {
        var user = await _mongoDBService.GetUserIDAsync(User_ID);

        if (user is null)
        {
            return NotFound("User does not exist.");
        }

        return user;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Users newUser)
    {
        var user = await _mongoDBService.GetUserIDAsync(newUser.id);

        if (user is null)
        {
            await _mongoDBService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.DbId }, newUser);
        }
        else
        {
            return BadRequest("User ID already exists.");
        }       
    }

    /*[HttpPut("{DB_ID:length(24)}")]
    public async Task<IActionResult> Update(string DB_ID, Users updatedUser)
    {
        var user = await _mongoDBService.GetDBIDAsync(DB_ID);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.DbId = user.DbId;

        await _mongoDBService.UpdateAsync(DB_ID, updatedUser);

        return NoContent();
    }*/

    [HttpPut("{User_ID}")]
    public async Task<IActionResult> UpdateByUserID(int User_ID, Users updatedUser)
    {
        var user = await _mongoDBService.GetUserIDAsync(User_ID);

        if (user is null)
        {
            return NotFound("User does not exist.");
        }

        updatedUser.DbId = user.DbId;

        await _mongoDBService.UpdateByUserIDAsync(User_ID, updatedUser);

        return NoContent();
    }

    /*[HttpDelete("{DB_ID:length(24)}")]
    public async Task<IActionResult> Delete(string DB_ID)
    {
        var user = await _mongoDBService.GetDBIDAsync(DB_ID);

        if (user is null)
        {
            return NotFound();
        }

        await _mongoDBService.RemoveAsync(DB_ID);

        return NoContent();
    }*/

    [HttpDelete("{User_ID}")]
    public async Task<IActionResult> DeleteByUserID(int User_ID)
    {
        var user = await _mongoDBService.GetUserIDAsync(User_ID);

        if (user is null)
        {
            return NotFound("User does not exist.");
        }

        await _mongoDBService.RemoveUserIDAsync(User_ID);

        return NoContent();
    }
}