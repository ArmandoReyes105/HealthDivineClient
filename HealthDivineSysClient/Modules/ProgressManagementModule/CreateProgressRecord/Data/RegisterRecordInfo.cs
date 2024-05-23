using HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.Data;
using ProgressManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.Data
{
    class RegisterRecordInfo
    {

        //Fields
        private static RegisterRecordInfo? _instance;
        private Diagnosis _diagnosis;

        //Properties
        public Diagnosis Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        //Constructor
        private RegisterRecordInfo()
        {
            Diagnosis = new Diagnosis();
            Diagnosis.Image = null; 
        }

        public static RegisterRecordInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RegisterRecordInfo();
                }
                return _instance;
            }
        }
    }
}
