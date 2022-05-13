using Captcha.Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.MVC.Service
{
  public class AIService : IAIService
  {
    public async Task<ModelOutputDTO> PredictImage (ModelInputDTO inputDTO)
    {
      return await PredictImage(inputDTO);
    }
  }
}
