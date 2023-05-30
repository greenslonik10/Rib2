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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService scheduleService;
        private readonly IMapper mapper;

        /// <summary>
        /// schedule controller
        /// </summary>
        public ScheduleController(IScheduleService  scheduleService,IMapper mapper)
        {
            this.scheduleService=scheduleService;
            this.mapper=mapper;
        }

        
        /// <summary>
        /// Get schedule by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetSchedules([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =scheduleService.GetSchedules(limit,offset);

            return Ok(mapper.Map<PageResponse<ScheduleResponse>>(pageModel));
        }
        /// <summary>
        /// Delete schedule
        /// </summary>
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSchedule([FromRoute] Guid id)
        {
            try
            {
                scheduleService.DeleteSchedule(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get schedule
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSchedule([FromRoute] Guid id)
        {
            try
            {
                var scheduleModel =scheduleService.GetSchedule(id);
                return Ok(mapper.Map<SchoolResponse>(scheduleModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update schedule
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateSchool([FromRoute] Guid id, [FromBody] UpdateScheduleRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =scheduleService.UpdateSchedule(id,mapper.Map<UpdateScheduleModel>(model));
            return Ok(mapper.Map<ScheduleResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }

        /// <summary>
        /// create schedule
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSchedule([FromBody] ScheduleModel schedule, [FromQuery] Guid SubjectId, [FromQuery] Guid ClassId, [FromQuery] Guid TeacherId)
        {
            var response = scheduleService.CreateSchedule(schedule, SubjectId, ClassId, TeacherId);
            return Ok(response);
        }
    }

}