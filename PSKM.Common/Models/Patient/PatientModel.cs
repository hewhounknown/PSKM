using PSKM.Common.Enums;

namespace PSKM.Common.Models.Patient;

public class PatientModel
{
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime DOB { get; set; }
        public EnumGender Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

}
