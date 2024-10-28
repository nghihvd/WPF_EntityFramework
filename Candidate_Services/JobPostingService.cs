using Candidate_BusinessObject;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }
        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }
        public JobPosting GetJobPostingByID(string id)
        {
            return jobPostingRepo.GetJobPostingByID(id);
        }


        public bool AddJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.AddJobPosting(jobPosting);
        }


        public bool UpdateJobposting(JobPosting jobPosting)
        {
            return jobPostingRepo.UpdateJobposting(jobPosting);
        }


        public bool DeleteJobPosting(string id)
        {
            return jobPostingRepo.DeleteJobPosting(id);
        }
    }
}
