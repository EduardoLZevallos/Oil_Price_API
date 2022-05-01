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
    public class OilPriceController : ControllerBase
    {
        private readonly OilPriceAPIDBContext _context;

        public OilPriceController(OilPriceAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/OilPrice
        [HttpGet]
        public async Task<ActionResult<Response>> GetConventionalGasoline()
        {
            var conventionalGasoline = await _context.ConventionalGasoline.ToListAsync();
            var response = new Response();

            response.StatusCode = 400;
            response.StatusDescription = "You did not find the IDs";

            if (conventionalGasoline != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "You found the IDs";
                response.ConventionalGasolines = conventionalGasoline;
            }

            return response; 
        }


        // GET: api/OilPrice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetConventionalGasoline(int id)
        {
            var conventionalGasoline = await _context.ConventionalGasoline.FindAsync(id);

            var response =new Response();

            response.StatusCode = 400;
            response.StatusDescription = " That ID does not exist";

            if (conventionalGasoline != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "You found the ID";
                response.ConventionalGasolines = new();
                response.ConventionalGasolines.Add(conventionalGasoline);
            }

            return response;
        }

        // POST: api/OilPrice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostConventionalGasoline(ConventionalGasoline conventionalGasoline)
        {
            _context.ConventionalGasoline.Add(conventionalGasoline);
            await _context.SaveChangesAsync();

            var response = new Response();
            response.StatusCode = 400;
            response.StatusDescription = "You did not add the conventional gasoline";

            var CG = CreatedAtAction("GetConventionalGasoline", new { id = conventionalGasoline.ConventionalGasID }, conventionalGasoline);
            if(CG != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "You added the conventional gasoline!";
            }
            //return CreatedAtAction("GetConventionalGasoline", new { id = conventionalGasoline.ConventionalGasID }, conventionalGasoline);
            return response;
        }

        // DELETE: api/OilPrice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteConventionalGasoline(int id)
        {
            var conventionalGasoline = await _context.ConventionalGasoline.FindAsync(id);
            var response = new Response();

            response.StatusCode = 400;
            response.StatusDescription = "You did not delete the gasoline";

            if (conventionalGasoline != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = " You successfully deleted the gasoline";
                _context.ConventionalGasoline.Remove(conventionalGasoline);
                await _context.SaveChangesAsync();
            }



            return response;
        }


        private bool ConventionalGasolineExists(int id)
        {
            return _context.ConventionalGasoline.Any(e => e.ConventionalGasID == id);
        }
    }
}
