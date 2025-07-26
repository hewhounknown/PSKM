using PSKM.Common.Enums;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Models.Patient;
using PSKM.Common.Utils;

namespace PSKM.Common.Mappings;


// This class is responsible for mapping between Models.
public static class Mapper
{
        //PatientRequestModel to PatientModel
        public static PatientModel Map(this PatientRequestModel request)
        {
                return new PatientModel
                {
                        PatientName = request.PatientName,
                        DOB = request.DOB,
                        Phone = request.Phone,
                        Gender = request.Gender,
                        Address = request.Address,
                };
        }

        //PatientModel to PatientResponseModel
        public static PatientResponseModel Map(this PatientModel patient)
        {
                return new PatientResponseModel
                {
                        PatientId = patient.PatientId,
                        PatientName = patient.PatientName,
                        DOB = patient.DOB,
                        Phone = patient.Phone,
                        Gender = patient.Gender.ToString(),
                        Address = patient.Address
                };
        }

        //DoctorRequestModel to DoctorModel
        public static DoctorModel Map(this DoctorRequestModel request)
        {
                return new DoctorModel
                {
                        DoctorName = request.DoctorName,
                        SpecialistId = request.SpecialistId,
                        Email = request.Email,
                        Phone = request.Phone,
                };
        }

        //DoctorModel to DoctorResponseModel
        public static DoctorResponseModel Map(this DoctorModel doctor)
        {
                return new DoctorResponseModel
                {
                        DoctorId = doctor.DoctorId,
                        DoctorName = doctor.DoctorName,
                        Specialist = doctor.Specialist?.Name,
                        Email = doctor.Email,
                        Phone = doctor.Phone
                };
        }

        //AppointmentRequestModel to AppointmentModel with Token generation
        public static AppointmentModel Map(this AppointmentRequestModel request)
        {
                // to generate appt token
                var generator = new Generator();

                return new AppointmentModel
                {
                        PatientId = request.PatientId,
                        DoctorId = request.DoctorId,
                        CreatedAt = DateTime.UtcNow,
                        AppointmentDate = request.AppointmentDate,
                        Token = generator.getAppointmentToken(),
                        Status = EnumAppointmentStatus.Pending
                };
        }

        //AppointmentModel to AppointmentResponseModel
        public static AppointmentResponseModel Map(this AppointmentModel appointment)
        {
                return new AppointmentResponseModel
                {
                        AppointmentId = appointment.AppointmentId,
                        Token = appointment.Token,
                        AppointmentDate = appointment.AppointmentDate,
                        PatientName = appointment.Patient.PatientName,
                        DoctorName = appointment.Doctor.DoctorName,
                        Status = appointment.Status.ToString(), // Convert Enum to string
                        CreatedAt = appointment.CreatedAt
                };
        }
}