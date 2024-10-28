using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> cadidateList();

        public bool AddCandidate(CandidateProfile candidate);

        public bool RemoveCandidate(String candidateID);

        public CandidateProfile SearchCandidateByID(String id);

        public bool updateProfile(CandidateProfile candidate);
    }
}
