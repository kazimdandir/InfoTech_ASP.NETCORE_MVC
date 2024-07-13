using IA_WebAPIEmpty_06072024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IA_WebAPIEmpty_06072024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        public IActionResult Get()
        {
            var users = _users.ToList();

            return Ok(users); // 200 + data
        }

        /// <summary>
        /// Verilen ID'ye sahip personel bilgisini getirir
        /// </summary>
        /// <param name="id">
        /// Tam sayı türünde bir ID verilmedilir. 0'dan büyük olmalıdır.
        /// </param>
        /// <returns>
        /// Çalışan tipinde geriye değer döndürür.
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                return Ok(user); // 200 + data
            }

            return NotFound(); //404
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _users.Add(user);
                return CreatedAtAction("Get", new { id = user.Id }, user);
            }

            return BadRequest(ModelState); // 400 + validation errors
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (user.Id != null)
            {
                var editUser = _users.FirstOrDefault(x => x.Id == user.Id);

                if (editUser != null)
                {
                    editUser.FirstName = user.FirstName;
                    editUser.LastName = user.LastName;
                    editUser.Address = user.Address;

                    return Ok(user); // 200 + data
                }
            }        
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                var getUser = _users.FirstOrDefault(x => x.Id == id);

                if (getUser != null)
                {
                    _users.Remove(getUser);

                    return Ok(getUser); // 200 + data
                }
            }
            return NotFound();
        }
    }
}
