using HabrWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HabrWebApi.Controllers
{
   [Route("api")]
   public class HomeController : Controller
   {
      private const string onlineMessage = "online";

      private readonly IAuthorService authorService;

      public HomeController(IAuthorService authorService)
      {
         ArgumentNullException.ThrowIfNull(authorService, nameof(authorService));

         this.authorService = authorService;
      }

      [HttpGet]
      public string Ping()
      {
         return JsonConvert.SerializeObject(new { status = onlineMessage } );
      }

      [HttpGet("authors")]
      public string GetAuthors()
      {
         return JsonConvert.SerializeObject(new { result = authorService.GetAuthors() });
      }
   }
}