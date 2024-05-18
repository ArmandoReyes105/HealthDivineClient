using UserManagementService;

namespace HealthDivineSysClient.Modules.UserManagementModule.RegisterPatient.Data
{
    public class RegisterPatientInfo
    {
        //Fields
        private static RegisterPatientInfo? _instance;
        private Patient _newPatient;
        private MedicalInformation _medicalInfo;
        private GeneralInformation _nutritionalInfo;
        private HabitsAndGoals _habitsAndGoalsInfo;

        //Properties
        public Patient NewPatient
        {
            get { return _newPatient; }
            set { _newPatient = value; }
        }

        public MedicalInformation MedicalInfo
        {
            get { return _medicalInfo; }
            set { _medicalInfo = value; }
        }

        public GeneralInformation NutritionalInfo
        {
            get { return _nutritionalInfo; }
            set { _nutritionalInfo = value; }
        }

        public HabitsAndGoals HabitsAndGoalsInfo
        {
            get { return _habitsAndGoalsInfo; }
            set { _habitsAndGoalsInfo = value; }
        }

        //Constructor
        private RegisterPatientInfo()
        {
            _newPatient = new Patient();
            _medicalInfo = new MedicalInformation();
            _nutritionalInfo = new GeneralInformation();
            _habitsAndGoalsInfo = new HabitsAndGoals();
        }

        public static RegisterPatientInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RegisterPatientInfo();
                }
                return _instance;
            }
        }

    }
}
