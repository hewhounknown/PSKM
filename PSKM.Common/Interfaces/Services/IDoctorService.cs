using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;

namespace PSKM.Common.Interfaces.Services;

public interface IDoctorService
{
        Task<EnumResult> AddDoctor(DoctorRequestModel model);
        Task<ResponseModel<List<DoctorResponseModel>>> GetAllDoctors();
        Task<ResponseModel<DoctorResponseModel>> GetDoctorById(int id);
        Task<EnumResult> UpdateDoctor(int id, DoctorRequestModel model);
        Task<EnumResult> DeleteDoctor(int id);

}
