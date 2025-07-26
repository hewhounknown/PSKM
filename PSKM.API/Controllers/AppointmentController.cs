using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Appointment;

namespace PSKM.API.Controllers;

[Route("api/v1/appointments")]
[ApiController]
public class AppointmentController : BaseController
{
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
                _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(AppointmentRequestModel appointment)
        {
                return await HandleRequest(() => _appointmentService.AddAppointment(appointment));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
                return await HandleRequest(() => _appointmentService.GetAllAppointments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
                return await HandleRequest(() => _appointmentService.GetAppointmentById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateRequestModel appointment)
        {
                return await HandleRequest(() => _appointmentService.UpdateAppointment(id, appointment));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
                return await HandleRequest(() => _appointmentService.DeleteAppointment(id));
        }
}
