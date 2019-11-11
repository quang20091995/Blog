namespace Blog.Controller
{
    using Model.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    public class HomeController: Controller
    {
        private readonly BlogDbContext db;
        public HomeController(BlogDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult getList()
            => Ok(db.Articles.ToList());
    }
}
