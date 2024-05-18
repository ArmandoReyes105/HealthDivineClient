using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDivineSysClient.Helpers
{
    public class SessionManager
    {
        public static SessionManager _instance = new();

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
            return 1; 
        }
    }
}
