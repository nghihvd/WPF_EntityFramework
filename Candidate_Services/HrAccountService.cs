using Candidate_BusinessObject;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class HrAccountService : IHrAccountService
    {
        private IHRAccountRepo iAccountRepo;
        public HrAccountService() {
            iAccountRepo =  new HRAccountRepo();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHrAll()
        {
            return iAccountRepo.GetHrAll();
        }
    }
}
