using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models.Patient;

namespace PSKM.Core.Services;

public class PatientService : IPatientService
{
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
                _patientRepository = patientRepository;
        }

        public async Task<EnumResult> RegisterPatient(PatientRequestModel patient)
        {
                return await _patientRepository.Add(patient);
        }

        public async Task<List<PatientModel>> ViewAllPatients()
        {
                return await _patientRepository.GetAll();
        }

        public async Task<PatientResponseModel> ViewPatient(int patientId)
        {
                return await _patientRepository.GetById(patientId);
        }
}
