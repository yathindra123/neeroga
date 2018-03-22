using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizObject
{
    public class Patient
    {
        private string _PatientID;
        private string _Username { get; set; }
        private string _Password { get; set; }
        private string _Email { get; set; }
        private string _Gender { get; set; }

        public string PatientID { get => _PatientID; set => _PatientID = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Gender { get => _Gender; set => _Gender = value; }

    }
}
