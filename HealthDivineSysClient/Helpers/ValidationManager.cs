using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace HealthDivineSysClient.Helpers
{
    public static class ValidationManager
    {
        public static bool IsEmailCorrect(string email)
        {
            return email.EndsWith("@gmail.com"); 
        }

        public static bool IsOfLegalAge(DateTime birthday)
        {
            DateTime actualdate = DateTime.Today;
            int edad = actualdate.Year - birthday.Year;
            if (birthday.Date > actualdate.AddYears(-edad))
            {
                edad--;
            }
            return edad >= 18;
        }

        public static bool AreAllFieldsComplete(List<string> fields)
        {
            bool result = true;

            foreach (string field in fields)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    result = false;
                    break; 
                }
            }

            return result; 
        }

        public static bool IsHourCorrect(string hour)
        {
            bool result = true; 

            string regex = @"^\d{2}:\d{2}$";
            string regex2 = @"^\d{1}:\d{2}$"; 

            if(!Regex.IsMatch(hour, regex) && !Regex.IsMatch(hour, regex2))
            {
                result = false;
            }
            else
            {
                string hours;
                string minutes; 

                if(hour.Length == 5)
                {
                    hours = hour.Substring(0, 2);
                    minutes = hour.Substring(3, 2);
                }
                else
                {
                    hours = hour.Substring(0, 1);
                    minutes = hour.Substring(2,2); 
                }

                if(int.Parse(hours) > 23 || int.Parse(minutes) > 59)
                {
                    result = false; 
                }
            }

            return result;
        }
    }
}
