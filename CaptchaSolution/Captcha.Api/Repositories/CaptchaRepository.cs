using Captcha.Shared;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Captcha.Api.Repositories
{
  public class CaptchaRepository : ICaptchaRepository
  {
    private readonly ILogger<CaptchaRepository> _logger;

    public CaptchaRepository(ILogger<CaptchaRepository> logger)
    {
      _logger = logger;
    }

    public async Task<CaptchaLabelDto> GetASelectedCaptcha(string captchaName)
    {
      using var documentStore = CreateStore();
      using var session = documentStore.OpenAsyncSession();
      var captcha = await session.LoadAsync<CaptchaLabelDto>(captchaName);
      return captcha;
    }

    public async Task UpdateCaptchaName(string captchaName, string change) // ændre navn og begræns output
    {
      using var documentStore = CreateStore();
      using var session = documentStore.OpenAsyncSession();
      var captcha = await session.LoadAsync<CaptchaLabelDto>(captchaName);
      var emp = session.Query<CaptchaLabelDto>().Where(z => z.Name == captchaName).ToList();
      captcha.Name = change;
      await session.SaveChangesAsync();
      await Task.CompletedTask;
    }

    public async Task PostCaptcha(CaptchaLabelDto captchaLabel) // Opret medarbejder 
    {
      try
      {
        var documentStore = CreateStore();
        var session = documentStore.OpenAsyncSession();

        var memoryStream = new MemoryStream();
        await captchaLabel.File.OpenReadStream().CopyToAsync(memoryStream);

        var newCaptcha = new CaptchaModel
        {
          Name = captchaLabel.Name,
          FileBytes = memoryStream.ToArray()
        };

        await session.StoreAsync(newCaptcha);
        await session.SaveChangesAsync();
      }
      catch (Exception e)
      {
        _logger.LogError("{e}", e);
      }
    }
    public async Task PostCaptchaResult(ModelOutputDTO captchaResult) // Opret medarbejder 
    {
      try
      {
        var documentStore = CreateStore();
        var session = documentStore.OpenAsyncSession();

        await session.StoreAsync(captchaResult);
        await session.SaveChangesAsync();
      }
      catch (Exception e)
      {
        _logger.LogError("{e}", e);
      }
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
