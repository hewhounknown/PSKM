using Microsoft.EntityFrameworkCore;
using PSKM.Common.Interfaces;
using PSKM.Common.Models.Patient;

namespace PSKM.Data.Repositories;

public class PatientRepository : IPatientRepository
{
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task<bool> Add(PatientRequestModel patient)
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
                return result > 0? true: false;
        }

        public Task<bool> Delete(int id)
        {
                throw new NotImplementedException();
        }

        public async Task<List<PatientModel>> GetAll()
        {
                return await _context.Patients.ToListAsync();
        }

        public async Task<PatientModel> GetById(int id)
        {
                return await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
        }

        public Task<bool> Update(PatientRequestModel patient)
        {
                throw new NotImplementedException();
        }
}
