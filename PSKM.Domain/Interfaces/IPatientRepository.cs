using PSKM.Domain.Models.Patient;

namespace PSKM.Domain.Interfaces;

public interface IPatientRepository
{
        Task<Boolean> Add(PatientRequestModel patient);
        Task<List<PatientModel>> GetAll();
        Task<PatientModel> GetById(int id);
        Task<Boolean> Update(PatientRequestModel patient);
        Task<Boolean> Delete(int id);
}
