using Microsoft.EntityFrameworkCore;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Mappings;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;

namespace PSKM.Data.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task<EnumResult> Add(AppointmentRequestModel appointment)
        {
                var newAppointment = appointment.Map();

                await _context.AddAsync(newAppointment);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Created : EnumResult.Fail;
        }

        public async Task<EnumResult> Delete(int id)
        {
                var appointment = await _context.Appointments.FindAsync(id);

                if (appointment == null) return EnumResult.Notfound;

                _context.Appointments.Remove(appointment);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Success : EnumResult.Fail;
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetAll()
        {
                var appointments = await _context.Appointments
                        .Include(a => a.Doctor)
                        .Include(a => a.Patient)
                        .Select(a => a.Map()) // change AppointmentModel to AppointmentResponseModel
                        .ToListAsync();

                return GenerateListResponse(appointments);
        }

        public async Task<ResponseModel<AppointmentResponseModel>> GetById(int id)
        {
                var appointment = await _context.Appointments
                        .Include(a => a.Doctor)
                        .Include(a => a.Patient)
                        .Select(a => a.Map()) // change AppointmentModel to AppointmentResponseModel
                        .FirstOrDefaultAsync(a => a.AppointmentId == id);
                if (appointment == null)
                        return ResponseModel<AppointmentResponseModel>
                                .Fail(EnumResult.Notfound.ToString());

                return ResponseModel<AppointmentResponseModel>
                        .Success(appointment, EnumResult.Success.ToString());
        }

        public async Task<EnumResult> Update(int id, AppointmentUpdateRequestModel appointment)
        {
                var existingAppointment = await _context.Appointments
                        .FirstOrDefaultAsync(a => a.AppointmentId == id);

                if (existingAppointment is null) return EnumResult.Notfound;

                existingAppointment.AppointmentDate = appointment.AppointmentDate;
                existingAppointment.DoctorId = appointment.DoctorId;
                existingAppointment.PatientId = appointment.PatientId;
                existingAppointment.Status = appointment.Status;

                _context.Appointments.Update(existingAppointment);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Success : EnumResult.Fail;
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetByDoctorId(int doctorId)
        {
                var appointments = await _context.Appointments
                        .Include(a => a.Doctor)
                        .Include(a => a.Patient)
                        .Where(a => a.DoctorId == doctorId)
                        .Select(a => a.Map()).ToListAsync();

                return GenerateListResponse(appointments);
        }

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetByPatientId(int patientId)
        {
                var appointments = await _context.Appointments
                        .Include(a => a.Doctor)
                        .Include(a => a.Patient)
                        .Where(a => a.PatientId == patientId)
                        .Select(a => a.Map()).ToListAsync();

                return GenerateListResponse(appointments);
        }


        //help to generate response model for list of appointments
        private ResponseModel<List<AppointmentResponseModel>> GenerateListResponse(List<AppointmentResponseModel> appointments)
        {
                if (appointments is null || appointments.Count == 0)
                        return ResponseModel<List<AppointmentResponseModel>>
                                .Fail(EnumResult.Notfound.ToString());

                return ResponseModel<List<AppointmentResponseModel>>
                        .Success(appointments, EnumResult.Success.ToString());
        }
}
