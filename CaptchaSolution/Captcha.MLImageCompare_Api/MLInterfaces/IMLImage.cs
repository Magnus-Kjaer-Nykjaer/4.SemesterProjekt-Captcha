using Captcha.Shared;
using System.Threading.Tasks;

namespace Captcha.MLImageCompare_Api.MLInterfaces
{
  public interface IMLImage
  {
    Task<ModelOutputDTO> Predict(ModelInputDTO input, byte[] file);
  }
}
