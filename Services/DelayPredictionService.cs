
using Microsoft.ML;
using Airlines_Services_ML_Approachs.Models;

namespace Airlines_Services_ML_Approachs.Services
{
    public class DelayPredictionService
    {
        private readonly PredictionEngine<FlightData, FlightPrediction> _predictionEngine;

        public DelayPredictionService()
        {
            var mlContext = new MLContext();
            DataViewSchema modelSchema;
            ITransformer mlModel = mlContext.Model.Load("MLModels/FlightDelayModel.zip", out modelSchema);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<FlightData, FlightPrediction>(mlModel);
        }

        public FlightPrediction Predict(FlightData input)
        {
            return _predictionEngine.Predict(input);
        }
    }
}
