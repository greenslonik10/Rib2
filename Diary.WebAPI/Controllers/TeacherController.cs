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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        /// <summary>
        /// teacher controller
        /// </summary>
        public TeacherController(ITeacherService  teacherService,IMapper mapper)
        {
            this.teacherService=teacherService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get teacher by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetTeachers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =teacherService.GetTeachers(limit,offset);

            return Ok(mapper.Map<PageResponse<TeacherResponse>>(pageModel));
        }
        /// <summary>
        /// Delete teacher
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTeacher([FromRoute] Guid id)
        {
            try
            {
                teacherService.DeleteTeacher(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get teacher
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTeacher([FromRoute] Guid id)
        {
            try
            {
                var teacherModel =teacherService.GetTeacher(id);
                return Ok(mapper.Map<TeacherResponse>(teacherModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update teacher
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTeacher([FromRoute] Guid id, [FromBody] UpdateTeacherRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =teacherService.UpdateTeacher(id,mapper.Map<UpdateTeacherModel>(model));
            return Ok(mapper.Map<TeacherResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create teacher
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherModel teacher, [FromQuery] Guid SchoolId)
        {
            var response = teacherService.CreateTeacher(teacher, SchoolId);
            return Ok(response);
        }
          
    }

}