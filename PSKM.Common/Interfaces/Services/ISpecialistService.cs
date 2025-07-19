using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Specialist;

namespace PSKM.Common.Interfaces.Specialist;

public interface ISpecialistService
{
        Task<EnumResult> AddSpecialist(SpecialistRequestModel specialist);
        Task<ResponseModel<List<SpecialistModel>>> GetAllSpecialists();
        Task<EnumResult> EditSpecialist(int id, SpecialistRequestModel specialist);
        Task<EnumResult> DeleteSpecialist(int id);
}
