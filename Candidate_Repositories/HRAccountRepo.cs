using Candidate_BusinessObject;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);
        

        public List<Hraccount> GetHrAll() => HRAccountDAO.Instance.GetHrAll();
        
    }
}
