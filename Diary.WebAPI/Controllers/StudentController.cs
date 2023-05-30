using AutoMapper;
using Diary.Services.Abstract;
using Diary.Services.Models;
using Diary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IStudentService userServise;
        private readonly IMapper mapper;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IStudentService userService,IMapper mapper)
        {
            this.userServise=userService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get users by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =userServise.GetStudents(limit,offset);

            return Ok(mapper.Map<PageResponse<StudentResponse>>(pageModel));
        }
        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="users"></param>
        [HttpDelete]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                userServise.DeleteStudent(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var userModel =userServise.GetStudent(id);
                return Ok(mapper.Map<StudentResponse>(userModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update users
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateStudentRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel = userServise.UpdateStudent(id,mapper.Map<UpdateStudentModel>(model));
            return Ok(mapper.Map<StudentResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}