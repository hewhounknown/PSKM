using PSKM.Common.Enums;

namespace PSKM.Common.Models.Appointment;

public class AppointmentRequestModel
{
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
}

// This model is used for updating an appointment.
public class  AppointmentUpdateRequestModel
{
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public EnumAppointmentStatus Status { get; set; }
}
