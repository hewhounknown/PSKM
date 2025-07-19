using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;

namespace PSKM.Common.Interfaces.Repositories;

public interface IDoctorRepository
{
        Task<EnumResult> Add(DoctorRequestModel doctor);
        Task<ResponseModel<List<DoctorResponseModel>>> GetAll();
        Task<ResponseModel<DoctorResponseModel>> GetById(int id);
        Task<EnumResult> Update(int id, DoctorRequestModel doctor);
        Task<EnumResult> Delete(int id);
}
