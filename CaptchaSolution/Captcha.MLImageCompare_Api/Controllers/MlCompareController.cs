using Microsoft.AspNetCore.Mvc;
using Captcha.Shared;
using System.Threading.Tasks;
using Captcha.MLImageCompare_Api.MLInterfaces;

namespace Captcha.MLImageCompare_Api.Controllers
{

  [ApiController]
  public class MlCompareController : Controller
  {
    public readonly IMLImage _mLImage;

    public MlCompareController(IMLImage mLImage)
    {
      _mLImage = mLImage;
    }

    [HttpGet(Route.Predict)]
    public async Task<ModelOutputDTO> PredictImage(ModelInputDTO input)
    {
      return await _mLImage.Predict(input);
    }
  }
}
