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
    public class PresenceController : ControllerBase
    {
        private readonly IPresenceService presenceService;
        private readonly IMapper mapper;

        /// <summary>
        /// presence controller
        /// </summary>
        public PresenceController(IPresenceService  presenceService,IMapper mapper)
        {
            this.presenceService=presenceService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get presence by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetPresences([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =presenceService.GetPresences(limit,offset);

            return Ok(mapper.Map<PageResponse<PresenceResponse>>(pageModel));
        }
        /// <summary>
        /// Delete presence
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePresence([FromRoute] Guid id)
        {
            try
            {
                presenceService.DeletePresence(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get presence
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPresence([FromRoute] Guid id)
        {
            try
            {
                var presenceModel =presenceService.GetPresence(id);
                return Ok(mapper.Map<PresenceResponse>(presenceModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update presence
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePresence([FromRoute] Guid id, [FromBody] UpdatePresenceRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =presenceService.UpdatePresence(id,mapper.Map<UpdatePresenceModel>(model));
            return Ok(mapper.Map<PresenceResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create presence
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreatePresence([FromBody] PresenceModel presence, [FromQuery] Guid StudentId, [FromQuery] Guid ScheduleId)
        {
            var response = presenceService.CreatePresence(presence, StudentId, ScheduleId);
            return Ok(response);
        }
          
    }

}