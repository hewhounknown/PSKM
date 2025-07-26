using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Interfaces.Services;

public interface IPatientService
{
        Task<ResponseModel<object>> RegisterPatient(PatientRequestModel patient);
        Task<ResponseModel<List<PatientResponseModel>>> ViewAllPatients();
        Task<ResponseModel<PatientResponseModel>> ViewPatient(int patientId);
        Task<ResponseModel<object>> EditPatient(int id, PatientRequestModel patient);
        Task<ResponseModel<object>> DeletePatient(int id);

        Task<ResponseModel<List<AppointmentResponseModel>>> GetAppointmentsByPatientId(int patientId);
}
