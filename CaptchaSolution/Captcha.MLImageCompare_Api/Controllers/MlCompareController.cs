using Microsoft.AspNetCore.Mvc;
using Captcha.Shared;
using System.Threading.Tasks;

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
    public async Task<global::MLImage.ModelOutput> PredictImage(global::MLImage.ModelInput input)
    {
      return await _mLImage.Predict(input);
    }
  }
}
