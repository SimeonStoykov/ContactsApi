using ContactsApi.Models;
using ContactsApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        public IContactsRepository ContactsRepo { get; set; }

        public ContactsController(IContactsRepository _repo)
        {
            ContactsRepo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactList = await ContactsRepo.GetAll();
            return Ok(contactList);
        }

        [HttpGet("{id}", Name = "GetContacts")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await ContactsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await ContactsRepo.Add(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contact newContact)
        {
            if (newContact == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldContact = await ContactsRepo.Find(id);

            if (oldContact == null)
            {
                return NotFound($"Contact with id {id} is not found!");
            }

            await ContactsRepo.Update(oldContact, newContact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contactObj = await ContactsRepo.Find(id);

            if (contactObj == null)
            {
                return NotFound();
            }

            await ContactsRepo.Remove(contactObj);
            return Ok();
        }
    }
}