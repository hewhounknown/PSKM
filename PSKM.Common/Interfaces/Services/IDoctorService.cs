using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;

namespace PSKM.Common.Interfaces.Services;

public interface IDoctorService
{
        Task<ResponseModel<object>> AddDoctor(DoctorRequestModel doctor);
        Task<ResponseModel<List<DoctorResponseModel>>> GetAllDoctors();
        Task<ResponseModel<DoctorResponseModel>> GetDoctorById(int id);
        Task<ResponseModel<object>> UpdateDoctor(int id, DoctorRequestModel doctor);
        Task<ResponseModel<object>> DeleteDoctor(int id);

}
