using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;

namespace HealthDivineSysClient.Helpers
{
    public class SessionManager
    {
        public static SessionManager _instance = new();
        private static Nutritionist nutritionist; 

        private SessionManager() { }

        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionManager();
                }
                return _instance;
            }
        }

        public int GetNutritionistId()
        {
            return nutritionist.IdNutritionist; 
        }

        public void SetNutritionist(Nutritionist LoginNutritionist)
        {
            nutritionist = LoginNutritionist;
        }

        public void CloseSession()
        {
            nutritionist = null; 
        }
    }
}
