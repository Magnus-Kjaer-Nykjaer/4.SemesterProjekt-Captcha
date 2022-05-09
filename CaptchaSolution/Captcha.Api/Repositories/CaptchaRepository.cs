using Captcha.Shared;
using Raven.Client.Documents;
using System.Linq;
using System.Threading.Tasks;

namespace Captcha.Api.Repositories
{
  public class CaptchaRepository
  {
    public Task<CaptchaModel> GetASelectedCaptcha(string captchaName)
    {
      using var documentStore = CreateStore();
      using var session = documentStore.OpenSession();
      var captcha = session.Load<CaptchaModel>(captchaName);
      return Task.FromResult(captcha);
    }

    public Task UpdateCaptchaName(string captchaName, string change) // ændre navn og begræns output
    {
      using var documentStore = CreateStore();
      using var session = documentStore.OpenSession();
      var captcha = session.Load<CaptchaModel>(captchaName);
      var emp = session.Query<CaptchaModel>().Where(z => z.Name == captchaName).ToList();
      captcha.Name = change;
      session.SaveChanges();
      return Task.CompletedTask;
    }

    public Task PostCaptcha(string captchaName) // Opret medarbejder 
    {
      using var documentStore = CreateStore();
      using var session = documentStore.OpenSession();

      var newEmployee = new CaptchaModel
      {
        Name = captchaName
      };
      session.Store(newEmployee);
      session.SaveChanges();
      return Task.CompletedTask;
    }

    private IDocumentStore CreateStore()
    {
      var store = new DocumentStore()
      {
        // Define the cluster node URLs (required)
        Urls = new[] { "http://localhost:8080", },

        // Set conventions as necessary (optional)
        Conventions =
                {
                    MaxNumberOfRequestsPerSession = 10,
                    UseOptimisticConcurrency = true
                },
        // Define a default database (optional)
        Database = "CaptchaReader",
      }.Initialize();

      return store;
    }
  }
}
