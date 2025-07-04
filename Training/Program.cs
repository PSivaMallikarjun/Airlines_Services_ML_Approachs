using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace Training;
public class FlightData
{
    [LoadColumn(0)] public string ? Origin;
    [LoadColumn(1)] public string  ? Destination;
    [LoadColumn(2)] public float TemperatureC;
    [LoadColumn(3)] public float WindSpeedKph;
    [LoadColumn(4)] public float ScheduledDepartureHour;
    [LoadColumn(5)] public float DelayMinutes;
}

public class FlightPrediction
{
    public float Score;
}

class Program
{
    static void Main()
    {
        var mlContext = new MLContext();

        if (!File.Exists("Training/data/flight_delay_100k.csv"))
        {
            Console.WriteLine("⚠️  Missing training data: data/flight_delay_100k.csv");
            return;
        }

        var data = mlContext.Data.LoadFromTextFile<FlightData>(
            path: "data/flight_delay.csv", hasHeader: true, separatorChar: ',');

        var pipeline = mlContext.Transforms.Concatenate("Features",
                nameof(FlightData.TemperatureC),
                nameof(FlightData.WindSpeedKph),
                nameof(FlightData.ScheduledDepartureHour))
            .Append(mlContext.Regression.Trainers.FastTree());

        var model = pipeline.Fit(data);

        Directory.CreateDirectory("MLModels");
        mlContext.Model.Save(model, data.Schema, "MLModels/FlightDelayModel.zip");

        Console.WriteLine("✅ Model trained and saved to MLModels/FlightDelayModel.zip");
    }
}