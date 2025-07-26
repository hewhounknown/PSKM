using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Interfaces.Services;

public interface IPatientService
{
        Task<ResponseModel<object>> RegisterPatient(PatientRequestModel patient);
        Task<ResponseModel<List<PatientModel>>> ViewAllPatients();
        Task<ResponseModel<PatientModel>> ViewPatient(int patientId);

        Task<ResponseModel<List<AppointmentResponseModel>>> GetAppointmentsByPatientId(int patientId);
}
