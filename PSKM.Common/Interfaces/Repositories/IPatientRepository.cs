using PSKM.Common.Models;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Interfaces.Repositories;

public interface IPatientRepository
{
        Task<ResponseModel<object>> Add(PatientRequestModel patient);
        Task<ResponseModel<List<PatientResponseModel>>> GetAll();
        Task<ResponseModel<PatientResponseModel>> GetById(int id);
        Task<ResponseModel<object>> Update(int id, PatientRequestModel patient);
        Task<ResponseModel<object>> Delete(int id);
}
