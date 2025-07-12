using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VacationRequestAPIApp.DTOs.VacationRequests;
using VacationRequestAPIApp.Interfaces;

namespace VacationRequestAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationRequestController : ControllerBase
    {
        private readonly IVacationRequestService vacationRequestService;

        public VacationRequestController(IVacationRequestService vacationRequestService)
        {
            this.vacationRequestService = vacationRequestService;
        }
        [HttpGet]
        [EndpointSummary("Get all vacation requests")]
        [EndpointDescription("Returns a list of all submitted vacation requests with calculated days and return date.")]
        public async Task<IActionResult> GetAllVacationRequests()
        {
            var vacationRequests =await vacationRequestService.GetAllVacationRequests();
            return Ok(vacationRequests);
        }
        [HttpPost("NewRequest")]
        [EndpointSummary("Create a new vacation request")]
        [EndpointDescription("Creates a new vacation request with validation for dates and calculates total vacation days and return date.")]
        public async Task<IActionResult> CreateNewVacation(VacationRequestCreateDto vacationRequestCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (vacationRequestCreateDto.VacationDateTo < vacationRequestCreateDto.VacationDateFrom)
                return BadRequest("Vacation end date cannot be earlier than start date.");
            if (vacationRequestCreateDto.VacationDateFrom < DateTime.Now)
                return BadRequest("Vacation start date cannot be in the past.");
            await vacationRequestService.CreateNewVacationRequest(vacationRequestCreateDto);
            return Ok("Vacation request created successfully");
        }
        [HttpGet("{id}")]
        [EndpointSummary("Get vacation request by ID")]
        [EndpointDescription("Retrieves a specific vacation request by its ID, including calculated days and return date.")]
        public async Task<IActionResult> GetVacationRequestById(int id)
        {
            try
            {
                var vacation = await vacationRequestService.GetVacationRequestById(id);
                return Ok(vacation);
            }
            catch (Exception ex)
            {
                return  NotFound(ex.Message);
            }
        }
    }
}
