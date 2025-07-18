using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Doctor;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;

namespace PSKM.Core.Services;

public class DoctorService : IDoctorService
{
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
                _doctorRepository = doctorRepository;
        }

        public async Task<EnumResult> AddDoctor(DoctorRequestModel model)
        {
                return await _doctorRepository.Add(model);
        }

        public async Task<EnumResult> DeleteDoctor(int id)
        {
                return await _doctorRepository.Delete(id);
        }

        public async Task<ResponseModel<List<DoctorResponseModel>>> GetAllDoctors()
        {
                return await _doctorRepository.GetAll();
        }

        public async Task<ResponseModel<DoctorResponseModel>> GetDoctorById(int id)
        {
                return await _doctorRepository.GetById(id);
        }

        public async Task<EnumResult> UpdateDoctor(int id, DoctorRequestModel model)
        {
                return await _doctorRepository.Update(id, model);
        }
}
