using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BizObject;

namespace BizLayer
{
    public class PatientBL
    {
        Patient patient = new Patient();
        PatientDAL uDal = new PatientDAL();

        public Patient login(string uname, string password)
        {
            //TODO
            return null;
        }

        public Patient register(Patient patient)
        {
            // TODO
            return null;
        }
    }
}
