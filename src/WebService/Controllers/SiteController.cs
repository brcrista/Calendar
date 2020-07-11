using System;

using Microsoft.AspNetCore.Mvc;

namespace Calendar.WebService.Controllers
{
    /// <summary>
    /// Provides access to information about the site.
    /// </summary>
    [Route("_site")]
    [ApiController]
    public sealed class SiteController : ControllerBase
    {
        /// <summary>
        /// Tells whether the site is online.
        /// </summary>
        [HttpGet("live")]
        public IActionResult Live() => Ok();

        /// <summary>
        /// Tells the UTC time of when the site was deployed.
        /// </summary>
        [HttpGet("version")]
        public DateTime Version() => deployedAt;

        private static readonly DateTime deployedAt = DateTime.UtcNow;
    }
}
