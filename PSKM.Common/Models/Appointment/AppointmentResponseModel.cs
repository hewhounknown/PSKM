using PSKM.Common.Enums;

namespace PSKM.Common.Models.Appointment;

public class AppointmentResponseModel
{
        public int AppointmentId { get; set; }
        public string Token { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public EnumAppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
}
