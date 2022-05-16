﻿using System.Net.Http;
using Captcha.Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Captcha.MVC.Service
{
  public interface IAIService
  {
    [Multipart]
    [Post(Route.Predict)]
    Task<ModelOutputDTO> PredictImage([AliasAs("file")]StreamPart content);
  }
}
