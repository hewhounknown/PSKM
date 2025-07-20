using Microsoft.EntityFrameworkCore;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Models;
using PSKM.Common.Models.Specialist;


namespace PSKM.Data.Repositories;

public class SpecialistRepository : ISpecialistRepository
{
        private readonly AppDbContext _context;

        public SpecialistRepository(AppDbContext context)
        {
                _context = context;
        }      

        public async Task<ResponseModel<object>> Add(SpecialistRequestModel specialist)
        {
                
                var newSpecialist = new SpecialistModel()
                {
                        Name = specialist.Name,
                        Description = specialist.Description
                };

                await _context.AddAsync(newSpecialist);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.Created, "new specialist added.")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "fail to add new specialist.");
        }

        public async Task<ResponseModel<object>> Delete(int id)
        {
                var specialist = await _context.Specialists.FirstOrDefaultAsync(s => s.SpecialistId == id);

                if (specialist is null) 
                        return ResponseModel<object>
                                .Fail(EnumResponseCode.Notfound, "no specialist found");
                
                _context.Specialists.Remove(specialist);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.NoContent, "deleted success.")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "Fail to delete specialist.");
        }

        public async Task<ResponseModel<List<SpecialistModel>>> GetAll()
        {
                var specialists = await _context.Specialists.ToListAsync();

                if (specialists is null || specialists.Count is 0)
                        return ResponseModel<List<SpecialistModel>>
                                .Fail(EnumResponseCode.Notfound.ToString());
                

                return ResponseModel<List<SpecialistModel>>
                        .Success(specialists, EnumResponseCode.OK);
        }

        public async Task<ResponseModel<object>> Update(int id, SpecialistRequestModel specialist)
        {
                var existingSpecialist = await _context.Specialists
                        .FirstOrDefaultAsync(s => s.SpecialistId == id);

                if (existingSpecialist is null) 
                        return ResponseModel<object>.Fail(EnumResponseCode.Notfound, "no specialist found");
               
                existingSpecialist.Name = specialist.Name;
                existingSpecialist.Description = specialist.Description;

                _context.Specialists.Update(existingSpecialist);
                int result = await _context.SaveChangesAsync();

               return result > 0 ? ResponseModel<object>
                        .Success(EnumResponseCode.NoContent, "update success.")
                        : ResponseModel<object>
                        .Fail(EnumResponseCode.ServerError, "Fail to update specialist.");
        }
}
