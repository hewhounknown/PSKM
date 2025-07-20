using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Doctor;

namespace PSKM.API.Controllers;

[Route("api/v1/doctors")]
[ApiController]
public class DoctorController : BaseController
{
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
                _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorRequestModel request)
        {
                return await HandleRequest(() => _doctorService.AddDoctor(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
                return await HandleRequest(() => _doctorService.GetAllDoctors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
                return await HandleRequest(() => _doctorService.GetDoctorById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorRequestModel request)
        {
                return await HandleRequest(() => _doctorService.UpdateDoctor(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
                return await HandleRequest(() => _doctorService.DeleteDoctor(id));
        }
}
