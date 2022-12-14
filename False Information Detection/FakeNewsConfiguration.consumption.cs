// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace False_Information_Detection
{
    public partial class FakeNewsConfiguration
    {
        /// <summary>
        /// model input class for FakeNewsConfiguration.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"id")]
            public float Id { get; set; }

            [ColumnName(@"title")]
            public string Title { get; set; }

            [ColumnName(@"author")]
            public string Author { get; set; }

            [ColumnName(@"text")]
            public string Text { get; set; }

            [ColumnName(@"label")]
            public float Label { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for FakeNewsConfiguration.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName("PredictedLabel")]
            public float Prediction { get; set; }

            public float[] Score { get; set; }
        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("FakeNewsConfiguration.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
