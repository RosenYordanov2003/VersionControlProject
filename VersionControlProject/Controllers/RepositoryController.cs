namespace VersionControlProject.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Repository;
    using Models;

    [Route("api/repository")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;
        private readonly UserManager<User> _useerManager;
        public RepositoryController(IRepositoryService repositoryService, UserManager<User> userManager)
        {
            _repositoryService = repositoryService;
            _useerManager = userManager;
        }

        //[Authorize]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateRepositoryModel model)
        {

            if (!await CheckIfUserExistsAsync(model.UserId))
            {
                return BadRequest();
            }

            try
            {
                await _repositoryService.CreateRepositoryAsync(model.UserId, model);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Route("addContributor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddContributor([FromQuery] Guid repositoryId, [FromQuery] Guid userId)
        {
            if (!await CheckIfUserExistsAsync(userId) ||  ! await _repositoryService.CheckIfRepositoryExistsAsync(repositoryId) )
            {
                return BadRequest();
            }
            try
            {
                await _repositoryService.AddContributorToRepository(userId, repositoryId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private async Task<bool> CheckIfUserExistsAsync(Guid userId)
        {
            var user = await _useerManager.FindByIdAsync(userId.ToString());

            return user == null ? false : true;
        }
    }
}
