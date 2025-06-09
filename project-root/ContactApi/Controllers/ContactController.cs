using Microsoft.AspNetCore.Mvc;
using ContactApi.Models;
using ContactApi.Data;
using System.Threading.Tasks;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}