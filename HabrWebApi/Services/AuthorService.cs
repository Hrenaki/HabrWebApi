namespace HabrWebApi.Services
{
   public interface IAuthorService
   {
      public string[] GetAuthors();
   }

   public class AuthorService : IAuthorService
   {
      private static readonly string[] authors = new string[]
      {
         "Hrenaki Hrenaki"
      };

      public string[] GetAuthors()
      {
         return authors.ToArray();
      }
   }
}