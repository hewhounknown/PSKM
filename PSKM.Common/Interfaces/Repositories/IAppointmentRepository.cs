using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;

namespace PSKM.Common.Interfaces.Repositories;

public interface IAppointmentRepository
{
        Task<EnumResult> Add(AppointmentRequestModel appointment);
        Task<ResponseModel<List<AppointmentResponseModel>>> GetAll();
        Task<ResponseModel<AppointmentResponseModel>> GetById(int id);
        Task<EnumResult> Update(int id, AppointmentUpdateRequestModel appointment);
        Task<EnumResult> Delete(int id);
}
