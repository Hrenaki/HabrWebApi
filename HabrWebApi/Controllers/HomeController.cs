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
      private readonly IEnvironmentInfoService environmentInfoService;

      public HomeController(IAuthorService authorService, IEnvironmentInfoService infoService)
      {
         ArgumentNullException.ThrowIfNull(authorService, nameof(authorService));
         ArgumentNullException.ThrowIfNull(infoService, nameof(infoService));

         this.authorService = authorService;
         environmentInfoService = infoService;
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

      [HttpGet("info")]
      public string GetInfo()
      {
         return JsonConvert.SerializeObject(environmentInfoService.GetInfo());
      }
   }
}