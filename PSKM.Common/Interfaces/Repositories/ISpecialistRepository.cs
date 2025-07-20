using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Specialist;

namespace PSKM.Common.Interfaces.Repositories;

public interface ISpecialistRepository
{
        Task<ResponseModel<object>> Add(SpecialistRequestModel specialist);
        Task<ResponseModel<List<SpecialistModel>>> GetAll();
        Task<ResponseModel<object>> Update(int id, SpecialistRequestModel specialist);
        Task<ResponseModel<object>> Delete(int id);
}
