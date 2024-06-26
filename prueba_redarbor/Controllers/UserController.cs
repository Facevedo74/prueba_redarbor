﻿using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using prueba_redarbor.Models;
using prueba_redarbor.Service;

namespace prueba_redarbor.Controllers
{
    [Route("api/redarbor")]
    public class UserController : Controller
    {
        private IUserService userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this._logger = logger;
        }

        /// <summary>
        /// Gets the state of the helper.
        /// </summary>
        /// <remarks>
        /// This method returns the state of the helper.
        /// </remarks>
        /// <returns>1 if exist elements</returns>
        [Authorize]
        [HttpGet("HelperStatus")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public ActionResult HelperStatus()
        {
            try
            {
                return Ok(userService.HelperStatus());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Get All Employees.
        /// </summary>
        /// <remarks>
        /// This method returns the list of all employees
        /// </remarks>
        /// <returns>This method returns the list of all employees</returns>
        [Authorize]
        [HttpGet()]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                return Ok(userService.GetAllUser());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }



        /// <summary>
        /// Get employee by Id.
        /// </summary>
        /// <remarks>
        /// This method returns the employee item.
        /// </remarks>
        /// <returns>This method returns the employee item</returns>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                return Ok(userService.GetUser(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }


        /// <summary>
        /// Insert new employee
        /// </summary>
        /// <remarks>
        /// This method add new employee.
        /// </remarks>
        /// <returns>This method returns the employee item</returns>
        [Authorize]
        [HttpPost()]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                return Ok(userService.AddUser(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <remarks>
        /// This method update the data to the employee.
        /// </remarks>
        /// <returns>This method returns void</returns>
        [Authorize]
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete employere
        /// </summary>
        /// <remarks>
        /// This method delete the data to the employee.
        /// </remarks>
        /// <returns>This method returns void</returns>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}

