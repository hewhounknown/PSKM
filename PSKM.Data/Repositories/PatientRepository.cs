using Microsoft.EntityFrameworkCore;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Patient;
using PSKM.Common.Models.Patient;

namespace PSKM.Data.Repositories;

public class PatientRepository : IPatientRepository
{
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task<EnumResult> Add(PatientRequestModel patient)
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
                return result > 0? EnumResult.C : EnumResult.Fail;
        }

        public async Task<List<PatientModel>> GetAll()
        {
                return await _context.Patients.ToListAsync();
        }

        public async Task<PatientResponseModel> GetById(int id)
        {
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);

                if (patient == null) return new PatientResponseModel 
                { 
                        IsSuccess = false,
                        Message = EnumResult.Notfound.ToString(),
                        Patient = null
                };

                var p = new PatientResponseModel
                {
                        IsSuccess = true,
                        Message = EnumResult.Success.ToString(),
                        Patient = patient
                };

                return p;
        }

        Task<EnumResult> IPatientRepository.Delete(int id)
        {
                throw new NotImplementedException();
        }

        Task<EnumResult> IPatientRepository.Update(PatientRequestModel patient)
        {
                throw new NotImplementedException();
        }
}
