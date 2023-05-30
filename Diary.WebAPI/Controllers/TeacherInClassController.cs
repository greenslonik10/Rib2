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
    public class TeacherInClassController : ControllerBase
    {
        private readonly ITeacherInClassService teacherInClassService;
        private readonly IMapper mapper;

        /// <summary>
        /// teacher in class controller
        /// </summary>
        public TeacherInClassController(ITeacherInClassService  teacherInClassService,IMapper mapper)
        {
            this.teacherInClassService=teacherInClassService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get teacher in class by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetTeachersInClasses([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =teacherInClassService.GetTeachersInClasses(limit,offset);

            return Ok(mapper.Map<PageResponse<TeacherInClassResponse>>(pageModel));
        }
        /// <summary>
        /// Delete teacher in class
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTeacherInClass([FromRoute] Guid id)
        {
            try
            {
                teacherInClassService.DeleteTeacherInClass(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get teacher in class
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTeacherInClass([FromRoute] Guid id)
        {
            try
            {
                var teacherInClassModel =teacherInClassService.GetTeacherInClass(id);
                return Ok(mapper.Map<SchoolResponse>(teacherInClassModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update teacher in class
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTeacherInClass([FromRoute] Guid id, [FromBody] TeacherInClassResponse model)
        {
           try
           {
            var resultModel =teacherInClassService.UpdateTeacherInClass(id,mapper.Map<TeacherInClassModel>(model));
            return Ok(mapper.Map<TeacherInClassResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}