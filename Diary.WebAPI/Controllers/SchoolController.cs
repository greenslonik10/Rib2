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
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService schoolService;
        private readonly IMapper mapper;

        /// <summary>
        /// school controller
        /// </summary>
        public SchoolController(ISchoolService  schoolService,IMapper mapper)
        {
            this.schoolService=schoolService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get school by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetSchools([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =schoolService.GetSchools(limit,offset);

            return Ok(mapper.Map<PageResponse<SchoolResponse>>(pageModel));
        }
        /// <summary>
        /// Delete school
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSchool([FromRoute] Guid id)
        {
            try
            {
                schoolService.DeleteSchool(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get school
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSchool([FromRoute] Guid id)
        {
            try
            {
                var schoolModel =schoolService.GetSchool(id);
                return Ok(mapper.Map<SchoolResponse>(schoolModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update school
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateSchool([FromRoute] Guid id, [FromBody] UpdateSchoolRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =schoolService.UpdateSchool(id,mapper.Map<UpdateSchoolModel>(model));
            return Ok(mapper.Map<SchoolResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create school
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSchool([FromBody] SchoolModel school)
        {
            var response =schoolService.CreateSchool(school);
            return Ok(response);
        }
          
    }

}