using PSKM.Common.Enums;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Models.Appointment;

public class AppointmentModel
{
        public int AppointmentId { get; set; }
        public string Token { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public EnumAppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public PatientModel Patient { get; set; } // Navigation for Patient
        public DoctorModel Doctor { get; set; } // Navigation for Doctor
}
