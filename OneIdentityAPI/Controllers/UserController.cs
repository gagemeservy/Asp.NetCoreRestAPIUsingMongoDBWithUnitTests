using Microsoft.AspNetCore.Mvc;
using OneIdentityAPI.Services;
using OneIdentityAPI.Models;

namespace OneIdentityAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    public UserController(MongoDBService mongoDBService) =>
        _mongoDBService = mongoDBService;

    [HttpGet]
    public async Task<List<User>> Get()=>
        await _mongoDBService.GetAsync();

    [HttpGet("{DB_ID:length(24)}")]
    public async Task<ActionResult<User>> Get(string DB_ID)
    {
        var user = await _mongoDBService.GetDBIDAsync(DB_ID);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpGet("{User_ID}")]
    public async Task<ActionResult<User>> GetByUserID(int User_ID)
    {
        var user = await _mongoDBService.GetUserIDAsync(User_ID);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _mongoDBService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.DbId }, newUser);
    }

    [HttpPut("{DB_ID:length(24)}")]
    public async Task<IActionResult> Update(string DB_ID, User updatedUser)
    {
        var user = await _mongoDBService.GetDBIDAsync(DB_ID);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.DbId = user.DbId;

        await _mongoDBService.UpdateAsync(DB_ID, updatedUser);

        return NoContent();
    }

    [HttpPut("{User_ID}")]
    public async Task<IActionResult> UpdateByUserID(int User_ID, User updatedUser)
    {
        var user = await _mongoDBService.GetUserIDAsync(User_ID);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.DbId = user.DbId;

        await _mongoDBService.UpdateByUserIDAsync(User_ID, updatedUser);

        return NoContent();
    }

    [HttpDelete("{DB_ID:length(24)}")]
    public async Task<IActionResult> Delete(string DB_ID)
    {
        var user = await _mongoDBService.GetDBIDAsync(DB_ID);

        if (user is null)
        {
            return NotFound();
        }

        await _mongoDBService.RemoveAsync(DB_ID);

        return NoContent();
    }

    [HttpDelete("{User_ID}")]
    public async Task<IActionResult> DeleteByUserID(int User_ID)
    {
        var user = await _mongoDBService.GetUserIDAsync(User_ID);

        if (user is null)
        {
            return NotFound();
        }

        await _mongoDBService.RemoveUserIDAsync(User_ID);

        return NoContent();
    }
}