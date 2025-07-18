using PSKM.Common.Enums;
using PSKM.Common.Models.Doctor;

namespace PSKM.Common.Interfaces.Doctor;

public interface IDoctorRepository
{
        Task<EnumResult> Add(DoctorRequestModel doctor);
        Task<List<DoctorModel>> GetAll();
        Task<DoctorResponseModel> GetById(int id);
        Task<EnumResult> Update(DoctorRequestModel doctor);
        Task<EnumResult> Delete(int id);
}
