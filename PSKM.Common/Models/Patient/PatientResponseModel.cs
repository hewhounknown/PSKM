﻿namespace PSKM.Common.Models.Patient;

public class PatientResponseModel
{
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
}
