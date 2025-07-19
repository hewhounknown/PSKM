using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Specialist;

namespace PSKM.Common.Interfaces.Repositories;

public interface ISpecialistRepository
{
        Task<EnumResult> Add(SpecialistRequestModel specialist);
        Task<ResponseModel<List<SpecialistModel>>> GetAll();
        Task<EnumResult> Update(int id, SpecialistRequestModel specialist);
        Task<EnumResult> Delete(int id);
}
