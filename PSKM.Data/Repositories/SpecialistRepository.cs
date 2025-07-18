
using Microsoft.EntityFrameworkCore;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Specialist;
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

        public async Task<EnumResult> Add(SpecialistRequestModel specialist)
        {
                
                var newSpecialist = new SpecialistModel()
                {
                        Name = specialist.Name,
                        Description = specialist.Description
                };

                await _context.AddAsync(newSpecialist);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Created : EnumResult.Fail;
        }

        public async Task<EnumResult> Delete(int id)
        {
                await _context.Specialists
                    .Where(s => s.SpecialistId == id).ExecuteDeleteAsync();
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Success : EnumResult.Fail;
        }

        public async Task<ResponseModel<List<SpecialistModel>>> GetAll()
        {
                var specialists = await _context.Specialists.ToListAsync();

                if (specialists == null || specialists.Count == 0)
                {
                        return ResponseModel<List<SpecialistModel>>.Fail(EnumResult.Notfound.ToString());
                }

                return ResponseModel<List<SpecialistModel>>.Success(specialists, EnumResult.Success.ToString());
        }

        public async Task<EnumResult> Update(int id, SpecialistRequestModel specialist)
        {
                var existingSpecialist = await _context.Specialists
                    .FirstOrDefaultAsync(s => s.SpecialistId == id);

                if (existingSpecialist == null)
                {
                        return EnumResult.Notfound;
                }

                existingSpecialist.Name = specialist.Name;
                existingSpecialist.Description = specialist.Description;

                _context.Specialists.Update(existingSpecialist);
                int result = await _context.SaveChangesAsync();

                return result > 0 ? EnumResult.Success : EnumResult.Fail;
        }
}
