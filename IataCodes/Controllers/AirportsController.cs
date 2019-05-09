using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace IataCodes.Controllers
{
    /// <summary>
    /// Endpoint to manage the Airport resource.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        #region Class Fields

        private readonly AirportsContext _dbContext;

        #endregion

        #region Class Constructors

        public AirportsController(AirportsContext dbContext)
        {
            #region Preconditions
            if (null == dbContext) { throw new ArgumentNullException(nameof(dbContext)); }
            #endregion

            _dbContext = dbContext;
        }

        #endregion

        /// <summary>
        /// Gets the airport with the specified IATA code.
        /// </summary>
        /// <param name="iataCode">The IATA code of the airport to retrieve.</param>
        /// <returns>The airport's information.</returns>
        /// <response code="200">The airport was successfully found.</response>
        /// <response code="404">The airport with the specified IATA code was not found.</response>
        [HttpGet]
        [Route("{iataCode}")]
        [ProducesResponseType(200, Type=typeof(Airports))]
        public IActionResult Get(string iataCode)
        {
            #region Preconditions
            if (null == iataCode) { return BadRequest(); }
            #endregion

            try
            {
                var airport = _dbContext.Airports
                    .Where(a => a.Iatacode == iataCode)
                    .SingleOrDefault<Airports>();

                if (null != airport)
                {
                    return Ok(airport);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }    
    }
}
