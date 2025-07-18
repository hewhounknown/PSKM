using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Interfaces.Specialist;
using PSKM.Common.Models.Specialist;

namespace PSKM.API.Controllers;

[Route("api/v1/specialists")]
[ApiController]
public class SpecialistController : Controller
{
        private readonly ISpecialistService _specialistService;

        public SpecialistController(ISpecialistService specialistService)
        {
                _specialistService = specialistService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpecialistRequestModel request)
        {
                try
                {
                        var result = await _specialistService.AddSpecialist(request);
                        return Ok(result);
                }
                catch (Exception)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                try
                {
                        var result = await _specialistService.GetAllSpecialists();
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, SpecialistRequestModel request)
        {
                try
                {
                        var result = await _specialistService.EditSpecialist(id, request);
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                try
                {
                        var result = await _specialistService.DeleteSpecialist(id);
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }
}
