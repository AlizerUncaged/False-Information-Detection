﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace False_Information_Detection
{
    public partial class FakeNewsConfiguration
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Text.FeaturizeText(@"title", @"title")      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"text", @"text"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"title",@"text"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"label", @"label"))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(l1Regularization:12.162208522053F,l2Regularization:0.03125F,labelColumnName:@"label",featureColumnName:@"Features"), labelColumnName: @"label"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"));

            return pipeline;
        }
    }
}