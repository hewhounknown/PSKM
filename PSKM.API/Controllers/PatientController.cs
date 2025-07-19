using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Patient;

namespace PSKM.API.Controllers;

[Route("api/v1/patients")]
[ApiController]
public class PatientController : Controller
{
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
                _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(PatientRequestModel patient)
        {
                try
                {
                        var result = await _patientService.RegisterPatient(patient);
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new { message = ex.Message });
                }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                try
                {
                        var patientList = await _patientService.ViewAllPatients();
                        return Ok(patientList);
                }
                catch (Exception ex)
                {

                        return StatusCode(500, new { message = ex.Message });
                }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
                try
                {
                        var patient = await _patientService.ViewPatient(id);
                        return Ok(patient);
                }
                catch (Exception ex)
                {

                        return StatusCode(500, new { message = ex.Message });
                }
        }
}
