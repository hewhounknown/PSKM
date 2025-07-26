using PSKM.Common.Models;
using PSKM.Common.Models.Specialist;

namespace PSKM.Common.Interfaces.Services;

public interface ISpecialistService
{
        Task<ResponseModel<object>> AddSpecialist(SpecialistRequestModel specialist);
        Task<ResponseModel<List<SpecialistModel>>> GetAllSpecialists();
        Task<ResponseModel<object>> EditSpecialist(int id, SpecialistRequestModel specialist);
        Task<ResponseModel<object>> DeleteSpecialist(int id);
}
