﻿using FluentValidation;
using PSKM.Common.Interfaces.Repositories;
using PSKM.Common.Interfaces.Services;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Utils;

namespace PSKM.Core.Services;

public class DoctorService : IDoctorService
{
        private readonly IDoctorRepository _doctorRepository;
        private readonly IValidator<DoctorRequestModel> _docValidator;

        private readonly IAppointmentRepository _apptRepository;

        public DoctorService(
                IDoctorRepository doctorRepository,
                IAppointmentRepository appointmentRepository,
                IValidator<DoctorRequestModel> docValidator
                )
        {
                _doctorRepository = doctorRepository;
                _docValidator = docValidator;
                _apptRepository = appointmentRepository;
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

        public async Task<ResponseModel<List<AppointmentResponseModel>>> GetAppointmentsByDoctorId(int doctorId)
        {
                return await _apptRepository.GetByDoctorId(doctorId);
        }
}
