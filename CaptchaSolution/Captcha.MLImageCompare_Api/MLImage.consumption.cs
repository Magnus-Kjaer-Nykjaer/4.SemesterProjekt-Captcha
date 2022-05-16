﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Captcha.Shared;
using Captcha.MLImageCompare_Api.MLInterfaces;
using Microsoft.AspNetCore.Http;
using Refit;

public class MLImage : IMLImage
{
  /// <summary>
  /// model input class for MLImage.
  /// </summary>
  #region model input class
  public class ModelInput
  {
    [ColumnName(@"Label")]
    public string Label { get; set; }

    [ColumnName(@"ImageSource")]
    public byte[] ImageSource { get; set; }

  }

  #endregion

  /// <summary>
  /// model output class for MLImage.
  /// </summary>
  #region model output class
  public class ModelOutput
  {
    [ColumnName(@"Label")]
    public uint Label { get; set; }

    [ColumnName(@"ImageSource")]
    public byte[] ImageSource { get; set; }

    [ColumnName(@"PredictedLabel")]
    public string PredictedLabel { get; set; }

    [ColumnName(@"Score")]
    public float[] Score { get; set; }

  }

  #endregion

  private static string MLNetModelPath = Path.GetFullPath("MLImage.zip");

  public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

  /// <summary>
  /// Use this method to predict on <see cref="ModelInput"/>.
  /// </summary>
  /// <param name="input">model input.</param>
  /// <returns><seealso cref=" ModelOutput"/></returns>
  public async Task<ModelOutputDTO> Predict(ModelInputDTO input)
  {
    var predEngine = PredictEngine.Value;
    return ConvertOutputToDto(predEngine.Predict(await ConvertInputFromDto(input)));
  }
  public ModelOutputDTO ConvertOutputToDto(ModelOutput modelOutput)
  {
    var output = new ModelOutputDTO();

    output.PredictedLabel = modelOutput.PredictedLabel;
    output.Label = modelOutput.Label;
    output.Score = modelOutput.Score;
    return output;
  }

  public async Task<ModelInput> ConvertInputFromDto(ModelInputDTO dto)
  {
    var memoryStream = new MemoryStream();
    await dto.File.OpenReadStream().CopyToAsync(memoryStream);
    var modelInput = new ModelInput()
    {
      Label = dto.Name,
      ImageSource = memoryStream.ToArray()
    };
    return modelInput;
  }

  private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
  {
    var mlContext = new MLContext();
    ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
    return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
  }
}

