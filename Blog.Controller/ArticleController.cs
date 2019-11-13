namespace Blog.Controller
{
    using Model.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Service.Implements;
    using Models.Response;
    using Models.Request;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController: Controller
    {
        private IArticleService iarticle_service;
        public ArticleController(IArticleService iarticle_service)
        {
            this.iarticle_service = iarticle_service;
        }

        [HttpGet("[action]")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult GetArticles()
            => Ok(this.iarticle_service.GetArticles().Result);

        [HttpPost("[action]")]
        public IActionResult CreateArticle([FromBody] CreateArticleRequest request)
        {
            // Will hold all the errors related to registration
            List<string> errorList = new List<string>();

            if (ModelState.IsValid)
            {
                Article article = new Article();
                article.ArticleId = request.ArticleId;
                article.ArticleTitle = request.ArticleTitle;
                article.CreatedOn = DateTime.Now;
                article.Description = request.Description;

                var result = this.iarticle_service.CreateArticle(article);

                CreateArticleResponse response = new CreateArticleResponse
                {
                    Created_Article = article,
                    Message = "Tạo mới thành công"
                };
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("[action]")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult EditArticle([FromBody] CreateArticleRequest request)
        {
            // Will hold all the errors related to registration
            List<string> errorList = new List<string>();

            if (ModelState.IsValid)
            {
                Article article = new Article();
                article.ArticleId = request.ArticleId;
                article.ArticleTitle = request.ArticleTitle;
                article.CreatedOn = DateTime.Now;
                article.Description = request.Description;

                var result = this.iarticle_service.EditArticle(article);

                CreateArticleResponse response = new CreateArticleResponse
                {
                    Created_Article = article,
                    Message = "Sửa thành công"
                };
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("[action]/{param}")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int param)
        {
            var deleted_status = await iarticle_service.DeleteArticle(param);
            if (deleted_status)
            {
                DeleteArticleResponse response = new DeleteArticleResponse
                {
                    Deleted_Id = param,
                    Message = "Xóa thành công"
                };
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("[action]/{param}")]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> DetailArticle([FromRoute] int param)
        {
            var detail = await iarticle_service.GetDetail(param);

            DetailArticleResponse response = new DetailArticleResponse { 
                ArticleId = detail.ArticleId,
                ArticleTitle = detail.ArticleTitle,
                CreatedOn = detail.CreatedOn,
                Description = detail.Description
            };
            return Ok(response);
        }
    }
}
