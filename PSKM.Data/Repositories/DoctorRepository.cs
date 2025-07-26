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
        public async Task<ResponseModel<object>> Add(DoctorRequestModel doctor)
        {
                var newDoctor = doctor.Map();

                await _context.AddAsync(newDoctor);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.OK, "new doctor added.")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "fail to add doctor.");
        }

        public async Task<ResponseModel<object>> Delete(int id)
        {
                var doctor = await _context.Doctors.FindAsync(id);

                if (doctor is null) 
                        return ResponseModel<object>
                                .Fail(EnumResponseCode.Notfound, "No doctor found.");
         

                _context.Doctors.Remove(doctor);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.NoContent, "deleted success")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "fail to delete doctor.");
        }

        public async Task<ResponseModel<List<DoctorResponseModel>>> GetAll()
        {
                var doctors = await _context.Doctors
                        .Include(d => d.Specialist)
                        .Select(d => d.Map()) // change DoctorModel to DoctorResponseModel
                        .ToListAsync();

                if (doctors is null || doctors.Count is 0)
                {
                      return ResponseModel<List<DoctorResponseModel>>.Fail(EnumResponseCode.Notfound.ToString());
                }
                
                return ResponseModel<List<DoctorResponseModel>>.Success(doctors, EnumResponseCode.OK);
        }

        public async Task<ResponseModel<DoctorResponseModel>> GetById(int id)
        {
                var doctor = await _context.Doctors
                        .Include(d => d.Specialist)
                        .FirstOrDefaultAsync(d => d.DoctorId == id);

                if (doctor is null) return ResponseModel<DoctorResponseModel>.Fail(EnumResponseCode.Notfound.ToString());

                return ResponseModel<DoctorResponseModel>.Success(doctor.Map(), EnumResponseCode.OK);
        }

        public async Task<ResponseModel<object>> Update(int id, DoctorRequestModel doctor)
        {
                var existingDoctor = await _context.Doctors
                        .FirstOrDefaultAsync(d =>d.DoctorId == id);

                if(existingDoctor is null) 
                       return ResponseModel<object>
                                .Fail(EnumResponseCode.Notfound, "No doctor found.");

                existingDoctor.DoctorName = doctor.DoctorName;
                existingDoctor.SpecialistId = doctor.SpecialistId;
                existingDoctor.Email = doctor.Email;
                existingDoctor.Phone = doctor.Phone;

                _context.Doctors.Update(existingDoctor);
                var result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.NoContent, "updated success")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "fail to update doctor.");
        }

        public async Task<ResponseModel<List<DoctorResponseModel>>> GetAllBySpecialistId(int specialistId)
        {
                var doctors = await _context.Doctors
                        .Where(d => d.SpecialistId == specialistId)
                        .Include(d => d.Specialist)
                        .Select(d => d.Map())
                        .ToListAsync();

                if (doctors is null || doctors.Count is 0)
                        return ResponseModel<List<DoctorResponseModel>>
                                .Fail(EnumResponseCode.Notfound, "no doctor found.");

                return ResponseModel<List<DoctorResponseModel>>
                        .Success(doctors, EnumResponseCode.OK);
        }
}
