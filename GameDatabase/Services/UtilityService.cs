using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class UtilityService: IUtilityService
    {
        public string EncodePassword(string password)
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        public string DecodePassword(string password)
        {
            return null;
        }
    }
}
