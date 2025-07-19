using Microsoft.EntityFrameworkCore;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Mappings;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;

namespace PSKM.Data.Repositories;

public class DoctorRepository : IDoctorRepository
{
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
                _context = context;
        }
        public async Task<EnumResult> Add(DoctorRequestModel doctor)
        {
                var newDoctor = doctor.Map();

                await _context.AddAsync(newDoctor);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Created : EnumResult.Fail;
        }

        public async Task<EnumResult> Delete(int id)
        {
                var doctor = await _context.Doctors.FindAsync(id);

                if (doctor == null) return EnumResult.Notfound;
         

                _context.Doctors.Remove(doctor);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Success : EnumResult.Fail;
        }

        public async Task<ResponseModel<List<DoctorResponseModel>>> GetAll()
        {
                var doctors = await _context.Doctors
                        .Include(d => d.Specialist)
                        .Select(d => d.Map()) // change DoctorModel to DoctorResponseModel
                        .ToListAsync();

                if (doctors is null || doctors.Count is 0)
                {
                      return ResponseModel<List<DoctorResponseModel>>.Fail(EnumResult.Notfound.ToString());
                }
                
                return ResponseModel<List<DoctorResponseModel>>.Success(doctors, EnumResult.Success.ToString());
        }

        public async Task<ResponseModel<DoctorResponseModel>> GetById(int id)
        {
                var doctor = await _context.Doctors
                        .Include(d => d.Specialist)
                        .Select(d => d.Map()) // change DoctorModel to DoctorResponseModel
                        .FirstOrDefaultAsync(d => d.DoctorId == id);

                if (doctor == null) return ResponseModel<DoctorResponseModel>.Fail(EnumResult.Notfound.ToString());

                return ResponseModel<DoctorResponseModel>.Success(doctor);
        }

        public async Task<EnumResult> Update(int id, DoctorRequestModel doctor)
        {
                var existingDoctor = await _context.Doctors
                        .FirstOrDefaultAsync(d =>d.DoctorId == id);

                if(existingDoctor == null) return EnumResult.Notfound;

                existingDoctor.DoctorName = doctor.DoctorName;
                existingDoctor.SpecialistId = doctor.SpecialistId;
                existingDoctor.Email = doctor.Email;
                existingDoctor.Phone = doctor.Phone;

                _context.Doctors.Update(existingDoctor);
                var result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Success : EnumResult.Notfound;
        }
}
