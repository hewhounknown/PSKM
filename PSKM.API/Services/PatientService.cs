using PSKM.Domain.Interfaces;
using PSKM.Domain.Models.Patient;

namespace PSKM.API.Services;

public class PatientService : IPatientService
{
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
                _patientRepository = patientRepository;
        }

        public async Task<bool> RegisterPatient(PatientRequestModel patient)
        {
                return await _patientRepository.Add(patient);
        }

        public async Task<List<PatientModel>> ViewAllPatients()
        {
                return await _patientRepository.GetAll();
        }

        public async Task<PatientModel> ViewPatient(int patientId)
        {
                return await _patientRepository.GetById(patientId);
        }
}
