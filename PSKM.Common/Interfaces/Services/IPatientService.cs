using PSKM.Common.Enums;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Interfaces.Services;

public interface IPatientService
{
        Task<EnumResult> RegisterPatient(PatientRequestModel patient);
        Task<List<PatientModel>> ViewAllPatients();
        Task<PatientResponseModel> ViewPatient(int patientId);
}
