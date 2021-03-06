﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedTheCrowd.Models;
using Microsoft.EntityFrameworkCore;
using FeedTheCrowd.Data;
using FeedTheCrowd.Services.Interfaces;
using FeedTheCrowd.Dtos.User;

namespace FeedTheCrowd.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller

    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var success = await _userService.Delete(id);
            if (success == null)
                return BadRequest("Cannot delete user");

            return Ok("deletion is succesful");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, [FromBody] UserDto newUser)
        {
            try
            {
                var user = await _userService.Update(id, newUser);
                return Ok(user);
            }
            catch(Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}