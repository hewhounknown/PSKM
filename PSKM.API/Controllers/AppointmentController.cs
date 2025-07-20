using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Appointment;

namespace PSKM.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : Controller
{
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
                _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(AppointmentRequestModel appointment)
        {
                try
                {
                        var result = await _appointmentService.AddAppointment(appointment);
                        if (result == EnumResult.Created)
                                return StatusCode(201, new {message = "Appointment created successfully."});
                        else if (result == EnumResult.Fail)
                                return BadRequest(new {message = "Failed to create appointment."});
                        else
                                return NotFound(new {message = "Appointment not found."});
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
                try
                {
                        var result = await _appointmentService.GetAllAppointments();
                        if (result.Data is null || result.Data.Count == 0)
                                return NotFound(new {message = "No appointments found."});
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
                try
                {
                        var result = await _appointmentService.GetAppointmentById(id);
                        if (result.Data is null)
                                return NotFound(new {message = "Appointment not found."});
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateRequestModel appointment)
        {
                try
                {
                        var result = await _appointmentService.UpdateAppointment(id, appointment);
                        if (result == EnumResult.Success)
                                return Ok(new {message = "Appointment updated successfully."});
                        else if (result == EnumResult.Fail)
                                return BadRequest(new {message = "Failed to update appointment."});
                        else
                                return NotFound(new {message = "Appointment not found."});
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
                try
                {
                        var result = await _appointmentService.DeleteAppointment(id);
                        if (result == EnumResult.Success)
                                return Ok(new {message = "Appointment deleted successfully."});
                        else if (result == EnumResult.Fail)
                                return BadRequest(new {message = "Failed to delete appointment."});
                        else
                                return NotFound(new {message = "Appointment not found."});
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctorId(int doctorId)
        {
                try
                {
                        var result = await _appointmentService.GetAppointmentsByDoctorId(doctorId);
                        if (result.Data is null || result.Data.Count == 0)
                                return NotFound(new {message = "No appointments found for this doctor."});
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatientId(int patientId)
        {
                try
                {
                        var result = await _appointmentService.GetAppointmentsByPatientId(patientId);
                        if (result.Data is null || result.Data.Count == 0)
                                return NotFound(new {message = "No appointments found for this patient."});
                        return Ok(result);
                }
                catch (Exception ex)
                {
                        return StatusCode(500, new {message = ex.Message});
                }
        }
}
