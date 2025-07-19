namespace PSKM.Common.Utils;

internal class Generator
{
        private readonly string _date;
        private readonly string _random;

        public Generator()
        {
                _date = DateTime.Now.ToString("yyMMdd");
                _random = new Guid().ToString("N")[..4].ToUpper();
        }

        // Generates a unique appointment token based on the current date and a random GUID segment.
        public string getAppointmentToken()
        {
                return $"APPT{_date}{_random}";
        }
}
