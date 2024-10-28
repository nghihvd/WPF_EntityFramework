using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO 
    {
        private static CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance = null;
        

        public CandidateProfileDAO() 
        {
            dbContext = new CandidateManagementContext();
            
        }

        public static CandidateProfileDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public List<CandidateProfile> cadidateList()
        {
            return dbContext.CandidateProfiles.Include(a => a.Posting).OrderBy(a => a.CandidateId).ToList();
        }

        public bool AddCandidate(CandidateProfile candidate)
        {
            dbContext = new CandidateManagementContext();
            bool isSuccess = false;
            CandidateProfile candidateProfile = SearchCandidateByID(candidate.CandidateId);
            if (candidateProfile == null)
            {
                dbContext.Add(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public bool RemoveCandidate(String candidateID)
        {
            dbContext = new CandidateManagementContext();
            bool isSuccess = false;             
            CandidateProfile  candidate = SearchCandidateByID(candidateID);
            if (candidate != null) {
                dbContext.Remove(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }

            return isSuccess;
        }

        public CandidateProfile SearchCandidateByID(string id)
        {
            return dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool updateProfile (CandidateProfile candidate)
        {
            dbContext = new CandidateManagementContext();
            bool isSuccess = false;
            dbContext.Update(candidate);
            CandidateProfile searchCandi = SearchCandidateByID(candidate.CandidateId);
            if (searchCandi != null)
            {
                //only update field which isn't key
                dbContext.Update(candidate);
                dbContext.SaveChanges() ;
                isSuccess = true;

            }
            return isSuccess;
        }
    }
}
