using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;

namespace PSKM.Common.Interfaces.Repositories;

public interface IDoctorRepository
{
        Task<ResponseModel<object>> Add(DoctorRequestModel doctor);
        Task<ResponseModel<List<DoctorResponseModel>>> GetAll();
        Task<ResponseModel<DoctorResponseModel>> GetById(int id);
        Task<ResponseModel<object>> Update(int id, DoctorRequestModel doctor);
        Task<ResponseModel<object>> Delete(int id);

        Task<ResponseModel<List<DoctorResponseModel>>> GetAllBySpecialistId(int specialistId);
}
