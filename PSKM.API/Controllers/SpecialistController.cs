using Microsoft.AspNetCore.Mvc;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Specialist;

namespace PSKM.API.Controllers;

[Route("api/v1/specialists")]
[ApiController]
public class SpecialistController : BaseController
{
        private readonly ISpecialistService _specialistService;

        public SpecialistController(ISpecialistService specialistService)
        {
                _specialistService = specialistService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpecialistRequestModel request)
        {
                return await HandleRequest(() => _specialistService.AddSpecialist(request));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                return await HandleRequest(() => _specialistService.GetAllSpecialists());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, SpecialistRequestModel request)
        {
                return await HandleRequest(() => _specialistService.EditSpecialist(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                return await HandleRequest(() => _specialistService.DeleteSpecialist(id));
        }
}
