using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Patient;

namespace PSKM.Core.Services;

public class PatientService : IPatientService
{
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
                _patientRepository = patientRepository;
        }

        public async Task<ResponseModel<object>> RegisterPatient(PatientRequestModel patient)
        {
                return await _patientRepository.Add(patient);
        }

        public async Task<ResponseModel<List<PatientModel>>> ViewAllPatients()
        {
                return await _patientRepository.GetAll();
        }

        public async Task<ResponseModel<PatientModel>> ViewPatient(int patientId)
        {
                return await _patientRepository.GetById(patientId);
        }
}
