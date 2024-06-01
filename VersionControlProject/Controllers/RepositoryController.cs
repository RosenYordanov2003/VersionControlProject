namespace VersionControlProject.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using VersionControlProject.Core.Contracts;
    using VersionControlProject.Core.Models.Repository;
    using VersionControlProject.Models;

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
            var user = await _useerManager.FindByIdAsync(model.UserId.ToString());

            if(user == null)
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
    }
}
