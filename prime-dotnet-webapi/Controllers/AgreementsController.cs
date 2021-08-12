using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Prime.Auth;
using Prime.Models.Api;
using Prime.Services;
using Prime.ViewModels;

namespace Prime.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementsController : PrimeControllerBase
    {
        private readonly IAgreementService _agreementService;

        public AgreementsController(IAgreementService agreementService)
        {
            _agreementService = agreementService;
        }

        /// <summary>
        /// Get a list of the Agreement Versions, with filters
        /// </summary>
        [HttpGet(Name = nameof(GetAgreementVersions))]
        [Authorize(Roles = Roles.ViewEnrollee)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResultResponse<IEnumerable<AgreementVersionListViewModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAgreementVersions([FromQuery] AgreementVersionFilters filters)
        {
            var agreements = await _agreementService.GetAgreementVersionsAsync(filters);
            return Ok(agreements);
        }

        // api/agreements/2
        /// <summary>
        /// Get an Agreement Version by id
        /// </summary>
        /// <param name="agreementVersionId"></param>
        [HttpGet("{agreementVersionId}", Name = nameof(GetAgreementVersionById))]
        [Authorize(Roles = Roles.ViewEnrollee)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResultResponse<AgreementVersionViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAgreementVersionById(int agreementVersionId)
        {
            var agreement = await _agreementService.GetAgreementVersionAsync(agreementVersionId);
            return Ok(agreement);
        }

        // api/agreements/compare/11..13
        [HttpGet("compare/{compareString}", Name = nameof(CompareAgreements))]
        [Authorize(Roles = Roles.ViewEnrollee)]
        [ProducesResponseType(typeof(ApiMessageResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResultResponse<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CompareAgreements(string compareString)
        {
            var vm = AgreementCompareViewModel.ParseCompareString(compareString);
            if (vm == null)
            {
                return BadRequest("Could not determine Agreement Versions to compare.");
            }

            var diff = await _agreementService.CompareAgreementsAsync(vm);
            return Ok(diff);
        }
    }
}
