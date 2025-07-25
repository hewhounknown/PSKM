
using PSKM.Common.Models.Appointment;

namespace PSKM.Common.Models.Doctor;

public class DoctorResponseModel
{
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialist {  get; set; }  // used for specialist name in API return
        public string Email { get; set; }
        public string Phone {  get; set; }
}
