using PSKM.Common.Models.Doctor;
using PSKM.Common.Models.Patient;

namespace PSKM.Common.Mappings;


// This class is responsible for mapping between Models.
public static class Mapper
{
        //PatientRequestModel to PatientModel
        public static PatientModel Map(this PatientRequestModel request)
        {
                return new PatientModel
                {
                        PatientName = request.PatientName,
                        DOB = request.DOB,
                        Phone = request.Phone,
                        Gender = request.Gender,
                        Address = request.Address,
                };
        }

        //DoctorRequestModel to DoctorModel
        public static DoctorModel Map(this DoctorRequestModel request)
        {
                return new DoctorModel
                {
                        DoctorName = request.DoctorName,
                        SpecialistId = request.SpecialistId,
                        Email = request.Email,
                        Phone = request.Phone,
                };
        }
}