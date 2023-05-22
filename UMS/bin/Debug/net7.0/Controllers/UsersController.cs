using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using UMS.Entities;
using UMS.Entities.Data;
using UMS.Models;

namespace UMS.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UsersController : ControllerBase
    {
        
        private readonly UMSContext _context;
        private static Logger logger = LogManager.GetCurrentClassLogger();


        public UsersController(UMSContext context)
		{
            _context = context;
		}

        [HttpGet(Name = "getUsers")]
        ///to use custom route name
        //[Route("getUsers")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Users> users = _context.Users.AsEnumerable().Where(x => x.RecordStatus == 1).OrderBy(x => x.UserName);

                ///for returning custom response message
                //return Ok(new ResponseMsg("201", "User created", userList));

                return Ok(users);
            }
            catch (Exception ex) {
                logger.Error(ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("getByUserId")]
        public IActionResult GetByUserId(Guid userId)
        {
            try
            {
                var result = _context.Users.FirstOrDefault(x => x.ID == userId && x.RecordStatus == 1);

                if (result != null)
                {
                    return Ok(result);
                }
                else {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost(Name = "addUsers")]
        public IActionResult Add(Users user)
        {
            try
            {
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.IsActive = true;

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(user);
            }
            catch(Exception ex)
            {
                logger.Error(ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }

        [HttpPut(Name = "editUsers")]
        public IActionResult Edit(Users user)
        {
            try
            {
                var result = _context.Users.SingleOrDefault(x=> x.ID == user.ID && x.RecordStatus == 1);
                if (result != null)
                {
                    result.UserName = user.UserName;
                    result.Email = user.Email;
                    result.IsActive = user.IsActive;
                    result.RecordStatus = user.RecordStatus;
                    result.LoginID = user.LoginID;
                    result.Password = user.Password;                    
                    result.ModifiedDate = DateTime.Now;

                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();

                    return Ok(user);
                }
                else {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete(Name = "deleteUsers")]
        public IActionResult Delete(Guid userID)
        {
            try
            {
                var result = _context.Users.SingleOrDefault(x => x.ID == userID);
                if (result != null)
                {
                    _context.Remove(result);
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.InnerException);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

