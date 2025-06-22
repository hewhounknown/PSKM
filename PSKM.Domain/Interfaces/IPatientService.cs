using PSKM.Domain.Models.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKM.Domain.Interfaces;

public interface IPatientService
{
        Task<Boolean> RegisterPatient(PatientRequestModel patient);
        Task<List<PatientModel>> ViewAllPatients();
        Task<PatientModel> ViewPatient(int patientId);
}
