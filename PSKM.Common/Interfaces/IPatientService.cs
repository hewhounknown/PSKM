using PSKM.Common.Enums;
using PSKM.Common.Models.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKM.Common.Interfaces;

public interface IPatientService
{
        Task<EnumResult> RegisterPatient(PatientRequestModel patient);
        Task<List<PatientModel>> ViewAllPatients();
        Task<PatientResponseModel> ViewPatient(int patientId);
}
