using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;

namespace PSKM.Common.Interfaces.Services
{
        public interface IAppointmentService
        {
                Task<EnumResult> AddAppointment(AppointmentRequestModel appointment);
                Task<ResponseModel<List<AppointmentResponseModel>>> GetAllAppointments();
                Task<ResponseModel<AppointmentResponseModel>> GetAppointmentById(int id);
                Task<EnumResult> UpdateAppointment(int id, AppointmentUpdateRequestModel appointment);
                Task<EnumResult> DeleteAppointment(int id);
        }
}
