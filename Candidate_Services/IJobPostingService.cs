using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobPostings();

        public JobPosting GetJobPostingByID(string id);


        public bool AddJobPosting(JobPosting jobPosting);


        public bool UpdateJobposting(JobPosting jobPosting);


        public bool DeleteJobPosting(string id);
    }
}
