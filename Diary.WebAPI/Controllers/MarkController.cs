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
    public class MarkController : ControllerBase
    {
        private readonly IMarkService markService;
        private readonly IMapper mapper;

        /// <summary>
        /// mark controller
        /// </summary>
        public MarkController(IMarkService  markService,IMapper mapper)
        {
            this.markService=markService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get mark by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetMarks([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =markService.GetMarks(limit,offset);

            return Ok(mapper.Map<PageResponse<MarkResponse>>(pageModel));
        }
        /// <summary>
        /// Delete mark
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMark([FromRoute] Guid id)
        {
            try
            {
                markService.DeleteMark(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get mark
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMark([FromRoute] Guid id)
        {
            try
            {
                var markModel =markService.GetMark(id);
                return Ok(mapper.Map<MarkResponse>(markModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update mark
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMark([FromRoute] Guid id, [FromBody] UpdateMarkRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =markService.UpdateMark(id,mapper.Map<UpdateMarkModel>(model));
            return Ok(mapper.Map<MarkResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create mark
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateMark([FromBody] MarkModel mark, [FromQuery] Guid StudentId, [FromQuery] Guid ScheduleId)
        {
            var response = markService.CreateMark(mark, StudentId, ScheduleId);
            return Ok(response);
        }
          
    }

}