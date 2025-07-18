using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKM.Common.Models.Doctor;

public class DoctorRequestModel
{
        public string DoctorName { get; set; }
        public int? SpecialistId {  get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
}
