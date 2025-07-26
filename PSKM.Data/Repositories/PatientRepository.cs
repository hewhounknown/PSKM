using Microsoft.EntityFrameworkCore;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Mappings;
using PSKM.Common.Models;
using PSKM.Common.Models.Patient;

namespace PSKM.Data.Repositories;

public class PatientRepository : IPatientRepository
{
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task<ResponseModel<object>> Add(PatientRequestModel patient)
        {
                var newPatient = new PatientModel
                {
                        PatientName = patient.PatientName,
                        DOB = patient.DOB,
                        Phone = patient.Phone,
                        Gender = patient.Gender,
                        Address = patient.Address,
                };

                await _context.AddAsync(newPatient);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.OK, "New patient added")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "Fail to add patient");
        }

        public async Task<ResponseModel<List<PatientResponseModel>>> GetAll()
        {
                var patients = await _context.Patients
                        .Select(d => d.Map()) // change PatientModel to PatientResponseModel
                        .ToListAsync();

                if (patients is null || patients.Count == 0)
                        return ResponseModel<List<PatientResponseModel>>
                                .Fail(EnumResponseCode.Notfound, "No patients found.");

                return ResponseModel<List<PatientResponseModel>>
                        .Success(patients, EnumResponseCode.OK);
        }

        public async Task<ResponseModel<PatientResponseModel>> GetById(int id)
        {
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);

                if (patient is null)
                        return ResponseModel<PatientResponseModel>
                                .Fail(EnumResponseCode.Notfound, "No patient found.");

                return ResponseModel<PatientResponseModel>
                        .Success(patient.Map(), EnumResponseCode.OK);
        }

        Task<ResponseModel<object>> IPatientRepository.Delete(int id)
        {
                throw new NotImplementedException();
        }

        Task<ResponseModel<object>> IPatientRepository.Update(PatientRequestModel patient)
        {
                throw new NotImplementedException();
        }
}
