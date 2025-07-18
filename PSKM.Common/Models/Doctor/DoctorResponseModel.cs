
namespace PSKM.Common.Models.Doctor;

public class DoctorResponseModel
{
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DoctorModel Doctor { get; set; }
}
