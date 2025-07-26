using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Patient;

namespace PSKM.API.Controllers;

[Route("api/v1/patients")]
[ApiController]
public class PatientController : BaseController
{
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
                _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(PatientRequestModel patient)
        {
                return await HandleRequest(() => _patientService.RegisterPatient(patient));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
               return await HandleRequest(() => _patientService.ViewAllPatients());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
                return await HandleRequest(() => _patientService.ViewPatient(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientRequestModel patient)
                => await HandleRequest(() => _patientService.EditPatient(id, patient));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
                => await HandleRequest(() => _patientService.DeletePatient(id));


        [HttpGet("{id}/appointments")]
        public async Task<IActionResult> GetAppointmentsByPatientId(int id)
                => await HandleRequest(() => _patientService.GetAppointmentsByPatientId(id));
}
