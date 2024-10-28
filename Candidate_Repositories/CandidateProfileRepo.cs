using Candidate_BusinessObject;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidate(CandidateProfile candidate) => CandidateProfileDAO.Instance.AddCandidate(candidate);
        

        public List<CandidateProfile> cadidateList() => CandidateProfileDAO.Instance.cadidateList();
        

        public bool RemoveCandidate(string candidateID) => CandidateProfileDAO.Instance.RemoveCandidate(candidateID);
       

        public CandidateProfile SearchCandidateByID(string id) => CandidateProfileDAO.Instance.SearchCandidateByID(id);
        

        public bool updateProfile(CandidateProfile candidate) => CandidateProfileDAO.Instance.updateProfile(candidate);
        
    }
}
