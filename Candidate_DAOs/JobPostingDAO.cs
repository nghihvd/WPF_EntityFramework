using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;
        private static JobPostingDAO instance = null;

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public List<JobPosting> GetJobPosting()
        {
            return dbContext.JobPostings.ToList();
        }
        public JobPosting GetJobPostingByID(string id)
        {
            return dbContext.JobPostings.SingleOrDefault(a => a.PostingId.Equals(id));
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {

            bool result = false;
            JobPosting job = GetJobPostingByID(jobPosting.PostingId);
            if (job == null)
            {
                dbContext.Add(jobPosting);
                dbContext.SaveChanges();
                result = true;
             }

            return result;
        }

        public bool UpdateJobposting(JobPosting jobPosting)
        {
            dbContext = new CandidateManagementContext();
            bool result = false;
            JobPosting job = GetJobPostingByID(jobPosting.PostingId);
            if (job != null)
            {
                job.JobPostingTitle = jobPosting.JobPostingTitle;
                job.Description = jobPosting.Description;
                job.PostedDate = jobPosting.PostedDate;
                job.PostingId = jobPosting.PostingId;
                dbContext.Entry(job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public bool DeleteJobPosting(string id)
        {
            dbContext = new CandidateManagementContext();
            bool result = false;
            JobPosting job = GetJobPostingByID(id);
            if (job != null)
            {
                dbContext.Remove(job);
                dbContext.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
