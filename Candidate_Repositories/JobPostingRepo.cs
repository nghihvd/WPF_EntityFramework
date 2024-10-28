using Candidate_BusinessObject;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPosting();

        public JobPosting GetJobPostingByID(string id) => JobPostingDAO.Instance.GetJobPostingByID(id);


        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);


        public bool UpdateJobposting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobposting(jobPosting);


        public bool DeleteJobPosting(string id) => JobPostingDAO.Instance.DeleteJobPosting(id);
    }
}
