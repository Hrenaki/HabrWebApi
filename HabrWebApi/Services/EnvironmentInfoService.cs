using System.Collections;
using System.Net;

namespace HabrWebApi.Services
{
   public class EnvironmentInfo
   {
      public IDictionary Variables { get; set; }
      public string MachineName { get; set; }
      public string UserName { get; set; }
      public string HostName { get; set; }
      public string[] IPAddresses { get; set; }
   }

   public interface IEnvironmentInfoService
   {
      public EnvironmentInfo GetInfo();
   }

   internal class EnvironmentInfoService : IEnvironmentInfoService
   {
      public EnvironmentInfo GetInfo()
      {
         var info = new EnvironmentInfo()
         {
            Variables = Environment.GetEnvironmentVariables(),
            MachineName = Environment.MachineName,
            UserName = Environment.UserName,
            HostName = Dns.GetHostName(),
            IPAddresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Select(addr => addr.ToString()).ToArray()
         };

         return info;
      }
   }
}
