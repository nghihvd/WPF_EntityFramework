using Candidate_BusinessObject;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo profileRepo;

        public CandidateProfileService()
        {
            profileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidate(CandidateProfile candidate)
        {
            return profileRepo.AddCandidate(candidate);
        }

        public List<CandidateProfile> cadidateList()
        {
            return profileRepo.cadidateList();
        }

        public bool RemoveCandidate(string candidateID)
        {
            return profileRepo.RemoveCandidate(candidateID);
        }

        public CandidateProfile SearchCandidateByID(string id)
        {
            return profileRepo.SearchCandidateByID(id);
        }

        public bool updateProfile(CandidateProfile candidate)
        {
            return profileRepo.updateProfile(candidate);
        }
    }
}
