using Candidate_Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidatemanagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private ICandidateProfileService profileService;
        public CandidateController()
        {
            profileService = new CandidateProfileService();
        }
        [HttpGet(Name = "GetCandidate")]
        public IActionResult GetAllCandidate()
        {
            return Ok(profileService.cadidateList().ToList());
        }
    }
}
