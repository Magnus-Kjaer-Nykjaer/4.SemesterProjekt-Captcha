using Microsoft.AspNetCore.Mvc;
using Captcha.Shared;
using System.Threading.Tasks;

namespace Captcha.MLImageCompare_Api.Controllers
{

  [ApiController]
  public class MlCompareController : Controller
  {
    private readonly MLImage _mLImage;

    public MlCompareController(MLImage mLImage)
    {
      _mLImage = mLImage;
    }
    //[HttpGet(Route.Predict)]
    //public async Task<ModelOutputDTO> PredictImage(ModelInputDTO input)
    //{
    //  return await _mLImage.
    //}
  }
}
