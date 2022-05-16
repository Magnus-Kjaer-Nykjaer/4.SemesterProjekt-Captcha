using System.IO;
using Microsoft.AspNetCore.Mvc;
using Captcha.Shared;
using System.Threading.Tasks;
using Captcha.MLImageCompare_Api.MLInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

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

    [HttpPost(Route.Predict)]
    public async Task<ModelOutputDTO> PredictImage([FromForm] ModelInputDTO inputDto)
    {

      return await _mLImage.Predict(inputDto);
    }
  }
}
