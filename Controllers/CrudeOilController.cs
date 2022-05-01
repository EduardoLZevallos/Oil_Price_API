#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OilPrice.Models;

namespace OilPrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudeOilController : ControllerBase
    {
        private readonly OilPriceAPIDBContext _context;

        public CrudeOilController(OilPriceAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/CrudeOil
        [HttpGet]
        public async Task<ActionResult<Response>> GetCrudeOil_1()
        {
            var crudeOil = await _context.CrudeOil.ToListAsync();
            var response = new Response();

            response.StatusCode = 400;
            response.StatusDescription = "You did not find the IDs";

            if (crudeOil != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "You found the IDs";
                response.CrudeOils = crudeOil;
            }

            return response;
        }

        // GET: api/CrudeOil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetCrudeOil(int id)
        {
            var crudeOil = await _context.CrudeOil.FindAsync(id);

            var response = new Response();

            response.StatusCode = 400;
            response.StatusDescription = " That ID does not exist";

            if (crudeOil != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "You found the ID";
                response.CrudeOils = new();
                response.CrudeOils.Add(crudeOil);
            }

            return response;
        }


        // POST: api/CrudeOil
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostCrudeOil(CrudeOil crudeOil)
        {
            _context.CrudeOil.Add(crudeOil);
            await _context.SaveChangesAsync();

            var response = new Response();
            response.StatusCode = 400;
            response.StatusDescription = "You did not add the crude oil";

            var CO = CreatedAtAction("GetConventionalGasoline", new { id = crudeOil.CrudeOilID }, crudeOil);
            if (CO != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "You added the crude oil!";
            }
            //return CreatedAtAction("GetConventionalGasoline", new { id = conventionalGasoline.ConventionalGasID }, conventionalGasoline);
            return response;
        }


        // DELETE: api/CrudeOil/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteCrudeOil(int id)
        {
            var crudeOil = await _context.CrudeOil.FindAsync(id);
            var response = new Response();

            response.StatusCode = 400;
            response.StatusDescription = "You did not delete the crude oil";

            if (crudeOil != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = " You successfully deleted the crude oil";
                _context.CrudeOil.Remove(crudeOil);
                await _context.SaveChangesAsync();
            }
            return response;
        }

        private bool CrudeOilExists(int id)
        {
            return _context.CrudeOil.Any(e => e.CrudeOilID == id);
        }
    }
}
