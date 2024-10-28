using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;

        private static HRAccountDAO instance = null; // biến tĩnh và không đổi trong quá trình đang run

        public HRAccountDAO() { 
            context = new CandidateManagementContext();
        }
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(String email) {

            return context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
            // lấy 1 dòng nếu có còn không thì trả ra mặc định null
        }

        public List<Hraccount> GetHrAll()
        {
            return context.Hraccounts.ToList();
        }



    }
}