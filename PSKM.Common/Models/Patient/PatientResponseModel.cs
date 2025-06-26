namespace PSKM.Common.Models.Patient;

public class PatientResponseModel
{
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public PatientModel Patient { get; set; }
}
