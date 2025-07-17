using PSKM.Common.Enums;

namespace PSKM.Common.Models.Appointment;

public class AppointmentModel
{
        public int AppointmentId { get; set; }
        public string Token { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public EnumAppointmentStatus status { get; set; } = EnumAppointmentStatus.Pending;
}
