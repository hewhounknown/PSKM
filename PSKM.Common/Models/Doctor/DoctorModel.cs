
using PSKM.Common.Models.Specialist;

namespace PSKM.Common.Models.Doctor;

public class DoctorModel
{
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int? SpecialistId {  get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }

        public SpecialistModel? Specialist { get; set; } // Navigation for Specialist
}
