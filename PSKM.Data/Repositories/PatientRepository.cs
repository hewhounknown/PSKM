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

        public async Task<ResponseModel<object>> Delete(int id)
        {
                var patient = await _context.Patients.FindAsync(id);

                if (patient is null)
                      return ResponseModel<object>
                                .Fail(EnumResponseCode.Notfound, "No patient found.");

                _context.Patients.Remove(patient);
                int result = await _context.SaveChangesAsync();
                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.NoContent, "Deleted successfully")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "Fail to delete patient.");
        }

        public async Task<ResponseModel<object>> Update(int id, PatientRequestModel patient)
        {
                var existingPatient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);

                if (existingPatient is null)
                        return ResponseModel<object>
                                .Fail(EnumResponseCode.Notfound, "No patient found.");

                existingPatient.PatientName = patient.PatientName;
                existingPatient.DOB = patient.DOB;
                existingPatient.Phone = patient.Phone;
                existingPatient.Gender = patient.Gender;
                existingPatient.Address = patient.Address;

                _context.Patients.Update(existingPatient);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.NoContent, "Updated success.") 
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "Fail to update patient.");
        }
}
