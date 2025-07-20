using FluentValidation;
using PSKM.Common.Enums;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Utils;
using System.Numerics;

namespace PSKM.Core.Services;

public class DoctorService : IDoctorService
{
        private readonly IDoctorRepository _doctorRepository;
        private readonly IValidator<DoctorRequestModel> _docValidator;

        public DoctorService(
                IDoctorRepository doctorRepository, 
                IValidator<DoctorRequestModel> docValidator
                )
        {
                _doctorRepository = doctorRepository;
                _docValidator = docValidator;
        }

        public async Task<ResponseModel<object>> AddDoctor(DoctorRequestModel doctor)
        {
                var validator = await _docValidator.ValidateAsync(doctor);
                if (!validator.IsValid)
                        return ValidationHelper.FormatErrors(validator.Errors);
                
                return await _doctorRepository.Add(doctor);
        }

        public async Task<ResponseModel<object>> DeleteDoctor(int id)
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

        public async Task<ResponseModel<object>> UpdateDoctor(int id, DoctorRequestModel doctor)
        {
                var validator = await _docValidator.ValidateAsync(doctor);
                if (!validator.IsValid)
                        return ValidationHelper.FormatErrors(validator.Errors);
                return await _doctorRepository.Update(id, doctor);
        }
}
