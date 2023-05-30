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
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;
        private readonly IMapper mapper;

        /// <summary>
        /// class controller
        /// </summary>
        public ClassController(IClassService  classService,IMapper mapper)
        {
            this.classService=classService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get class by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetClasses([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =classService.GetClasses(limit,offset);

            return Ok(mapper.Map<PageResponse<ClassResponse>>(pageModel));
        }
        /// <summary>
        /// Delete class
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteClass([FromRoute] Guid id)
        {
            try
            {
                classService.DeleteClass(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get class
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetClass([FromRoute] Guid id)
        {
            try
            {
                var classModel =classService.GetClass(id);
                return Ok(mapper.Map<ClassResponse>(classModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update class
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateClass([FromRoute] Guid id, [FromBody] UpdateClassRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =classService.UpdateClass(id,mapper.Map<UpdateClassModel>(model));
            return Ok(mapper.Map<ClassResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create class
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateClass([FromBody] ClassModel clas, [FromQuery] Guid SchoolId)
        {
            var response = classService.CreateClass(clas, SchoolId);
            return Ok(response);
        }


    }

}