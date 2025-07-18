using PSKM.Common.Models.Patient;

namespace PSKM.Common.Mappings;


// This class is responsible for mapping between Patient Models.
public static class Mapper
{
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

}