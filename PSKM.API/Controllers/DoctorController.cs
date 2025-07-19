using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Doctor;

namespace PSKM.API.Controllers;

[Route("api/v1/doctors")]
[ApiController]
public class DoctorController : Controller
{
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
                _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorRequestModel request)
        {
                try
                {
                        var result = await _doctorService.AddDoctor(request);
                        return Ok(result.ToString());
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
                try
                {
                        var result = await _doctorService.GetAllDoctors();
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
                try
                {
                        var result = await _doctorService.GetDoctorById(id);
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorRequestModel request)
        {
                try
                {
                        var result = await _doctorService.UpdateDoctor(id, request);
                        return Ok(result.ToString());
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
                try
                {
                        var result = await _doctorService.DeleteDoctor(id);
                        return Ok(result.ToString());
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }
        }
}
