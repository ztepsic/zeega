using Microsoft.AspNetCore.Mvc;
using Zed.Transaction;
using Zeega.Domain;

namespace Zeega.Web.Controllers.Api {
    [ApiController]
    [Route("api/[controller]")]
    public class AppTenantsController : ControllerBase {

        private readonly IUnitOfWorkManager unitOfWorkManager;
        private readonly IAppTenantsRepository _appTenantsRepository;

        public AppTenantsController(IUnitOfWorkManager unitOfWorkManager, IAppTenantsRepository appTenantsRepository) {
            _appTenantsRepository = appTenantsRepository;
            this.unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Gets a list of all application tenants
        /// </summary>
        /// <returns>List of app tenants</returns>
        [HttpGet]
        public IActionResult GetAppTenants() {
            using var unitOfWorkRootScope = unitOfWorkManager.Start();
            try {
                var appTenants = _appTenantsRepository.GetAll();
                return Ok(appTenants);
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while retrieving app tenants", error = ex.Message });
            }

        }
    }
}
