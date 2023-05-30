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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        private readonly IMapper mapper;

        /// <summary>
        /// subject controller
        /// </summary>
        public SubjectController(ISubjectService  subjectService,IMapper mapper)
        {
            this.subjectService=subjectService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get subject by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetSubjects([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =subjectService.GetSubjects(limit,offset);

            return Ok(mapper.Map<PageResponse<SubjectResponse>>(pageModel));
        }
        /// <summary>
        /// Delete subject
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSubject([FromRoute] Guid id)
        {
            try
            {
                subjectService.DeleteSubject(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get subject
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSubject([FromRoute] Guid id)
        {
            try
            {
                var subjectModel =subjectService.GetSubject(id);
                return Ok(mapper.Map<AdminResponse>(subjectModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update subject
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateSubject([FromRoute] Guid id, [FromBody] UpdateSubjectRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =subjectService.UpdateSubject(id,mapper.Map<UpdateSubjectModel>(model));
            return Ok(mapper.Map<SubjectResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create subject
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSubject([FromBody] SubjectModel subject)
        {
            var response =subjectService.CreateSubject(subject);
            return Ok(response);
        }
          
    }

}