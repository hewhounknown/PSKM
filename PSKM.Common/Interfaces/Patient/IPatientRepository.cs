using PSKM.Common.Enums;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Interfaces.Patient;

public interface IPatientRepository
{
        Task<EnumResult> Add(PatientRequestModel patient);
        Task<List<PatientModel>> GetAll();
        Task<PatientResponseModel> GetById(int id);
        Task<EnumResult> Update(PatientRequestModel patient);
        Task<EnumResult> Delete(int id);
}
