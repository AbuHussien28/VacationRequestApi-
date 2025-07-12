using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacationRequestAPIApp.DTOs.OfficialHolidays;
using VacationRequestAPIApp.Interfaces;

namespace VacationRequestAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialHolidayController : ControllerBase
    {
        private readonly IOfficialHolidayService officialHolidayService;

        public OfficialHolidayController(IOfficialHolidayService officialHolidayService)
        {
            this.officialHolidayService = officialHolidayService;
        }
        [HttpGet]
        [EndpointSummary("Get all official holidays")]
        [EndpointDescription("Retrieves a list of all official holidays in the system.")]
        public async Task<IActionResult> GetAllHolidayDays()
        {
            var holidays = await officialHolidayService.GetAllHolidayDays();
            return Ok(holidays);
        }
        [HttpPost]
        [EndpointSummary("Create a new official holiday")]
        [EndpointDescription("Creates a new official holiday in the system with validation for required fields.")]
        public async Task<IActionResult> Create([FromBody] OfficialHolidayCreateDto officialHolidayCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await officialHolidayService.AddHolidayToSystem(officialHolidayCreateDto);
            return Ok("Holiday created successfully");
        }
        [HttpDelete("{id}")]
        [EndpointSummary("Delete an official holiday")]
        [EndpointDescription("Deletes an official holiday from the system by its ID with validation for valid ID.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid holiday ID");
            await officialHolidayService.DeleteHoliday(id);
            return Ok("Holiday deleted successfully");
        }
    }
}
