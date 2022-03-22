using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAPI.jwtAut;
using DotNetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetAPI.Repository;

namespace DotNetAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAuthController : ControllerBase
    {
        // GET: api/ApiAuth
        private readonly IJWTusers jwtAuth;
        private readonly IProductsRepository _prodrepo;

        private readonly List<User> lstMember = new List<User>()
        {
            new User {Id=1, Name="Kirtesh" },
            new User {Id=2, Name="Nitya" },
            new User {Id=3, Name="pankaj"}
        };
        public ApiAuthController(IJWTusers jwtAuth, IProductsRepository prodrepo)
        {
            this.jwtAuth = jwtAuth;
            _prodrepo = prodrepo;
        }


        [HttpGet("allusers")]
        public IEnumerable<User> Get()
        {
            return lstMember;
        }
        [HttpGet("allProducts")]
        public IActionResult AllProducts()
        {
            var products = _prodrepo.GetAll();
            return Ok(products);
        }
        [HttpPost("AddProducts")]
        public IActionResult SaveProducts([FromBody]Products prod)
        {
            
                // TODO: Add insert logic here
                _prodrepo.Insert(prod);
                return Ok();
            
        }


        // GET: api/ApiAuth/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return lstMember.Find(x => x.Id == id);
        }
        
        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody]UserCredential userCredential)
        {
            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }



        // POST: api/ApiAuth
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpGet("singleProduct/{id}")]
        public IActionResult GetProductByID(int id)
        {
            return Ok(_prodrepo.GetById(id));
        }


        // PUT: api/ApiAuth/5
        [HttpPut("updateProduct")]
        public void Put([FromBody] Products model )
        {
            _prodrepo.Update(model);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public OkResult Delete(int id)
        {
            _prodrepo.Delete(id);
            return Ok();
        }


    }
}
