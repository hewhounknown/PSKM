using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Specialist;

namespace PSKM.Core.Services;

public class SpecialistService : ISpecialistService
{
        private readonly ISpecialistRepository _specialistRepository;

        public SpecialistService(ISpecialistRepository specialistRepository)
        {
                _specialistRepository = specialistRepository;
        }       

        public async Task<ResponseModel<object>> AddSpecialist(SpecialistRequestModel specialist)
        {
                return await _specialistRepository.Add(specialist);
        }

        public async Task<ResponseModel<object>> DeleteSpecialist(int id)
        {
                return await _specialistRepository.Delete(id);
        }

        public async Task<ResponseModel<object>> EditSpecialist(int id, SpecialistRequestModel specialist)
        {
                return await _specialistRepository.Update(id, specialist);
        }

        public async Task<ResponseModel<List<SpecialistModel>>> GetAllSpecialists()
        {
                return await _specialistRepository.GetAll();
        }
}
