using Captcha.Shared;
using System.Threading.Tasks;
using Refit;

namespace Captcha.MVC.Service
{
  public interface IAIService
  {
    [Get(Route.Predict)]
    Task<ModelOutputDTO> PredictImage(ModelInputDTO inputDTO);
  }
}
