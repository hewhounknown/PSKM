using FluentValidation;
using FluentValidation.Results;
using PSKM.Common.Enums;
using PSKM.Common.Models;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Utils;

public class PatientValidator : AbstractValidator<PatientRequestModel>
{
        public PatientValidator()
        {
                RuleFor(x => x.PatientName)
                        .NotEmpty().WithMessage("Patient name is required.")
                        .MaximumLength(100).WithMessage("Patient name must not exceed 100 characters.");

                RuleFor(x => x.DOB)
                        .NotEmpty().WithMessage("Date of birth is required.")
                        .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

                RuleFor(x => x.Phone)
                        .NotEmpty().WithMessage("Phone number is required.")
                        .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits.");

                //TODO: create EnumGender and replace it here.
                RuleFor(x => x.Gender)
                        .NotEmpty().WithMessage("Gender is required.")
                        .IsInEnum().WithMessage("Gender must be Male, Female or Other.");
        }
}

public class DoctorValidator : AbstractValidator<DoctorRequestModel>
{
        public DoctorValidator()
        {
                RuleFor(x => x.DoctorName)
                        .NotEmpty().WithMessage("Doctor name is required.")
                        .MaximumLength(100).WithMessage("Doctor name must not exceed 100 characters.");

                RuleFor(x => x.Email)
                        .NotEmpty().WithMessage("Email is required.")
                        .EmailAddress().WithMessage("Invalid email format.");

                RuleFor(x => x.Phone)
                        .NotEmpty().WithMessage("Phone number is required.")
                        .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits.");
        }
}

public class AppointmentValidator : AbstractValidator<AppointmentRequestModel>
{
        public AppointmentValidator()
        {
                RuleFor(x => x.PatientId)
                        .NotEmpty().WithMessage("Patient ID is required.");

                RuleFor(x => x.DoctorId)
                        .NotEmpty().WithMessage("Doctor ID is required.");

                RuleFor(x => x.AppointmentDate)
                        .NotEmpty().WithMessage("Appointment date is required.")
                        .Must(date => date >DateTime.Now).WithMessage("Appointment date must be in the future.");
        }
}

public class AppointmentUpdateValidator : AbstractValidator<AppointmentUpdateRequestModel>
{
        public AppointmentUpdateValidator()
        {
                RuleFor(x => x.PatientId)
                        .NotEmpty().WithMessage("Patient ID is required.");

                RuleFor(x => x.DoctorId)
                        .NotEmpty().WithMessage("Doctor ID is required.");

                //TODO: allow for unchanged the original date and changing to the future time
                //TODO: disallow for change to the past time from now
                RuleFor(x => x.AppointmentDate)
                        .NotEmpty().WithMessage("Appointment date is required.");

                RuleFor(x => x.Status)
                        .NotEmpty().WithMessage("Status is required.")
                        .IsInEnum().WithMessage("Status must be pending, completed or cancelled.");
        }
}

public static class ValidationHelper
{
        public static ResponseModel<object> FormatErrors(List<ValidationFailure> err)
        {
                 var errors = err.Select(e => e.ErrorMessage).ToList();
                        return ResponseModel<object>.Fail(EnumResponseCode.BadRequest, string.Join(" | ", errors));
        }
}
