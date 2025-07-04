# ✈️ AOCC Flight Delay AI System

This project predicts flight delays for Airline Operations Control Centers (AOCC) using Machine Learning, .NET 9 APIs, and real-time SignalR dashboards. It is fully containerized with Docker and orchestratable using Docker Compose.

---

## 🧱 Project Structure

```
AOCC_FlightDelayAI/
├── src/
│   ├── Airlines_Services_ML_Approachs/      # .NET 9 API with Swagger, SignalR, Controllers
│   └── Training/                            # Console project to train and export ML model
├── MLModels/
│   └── FlightDelayModel.zip                 # Trained ML.NET model file
├── docker/
│   ├── api.Dockerfile                       # Dockerfile for the API project
│   ├── training.Dockerfile                  # Dockerfile for the training project
│   └── docker-compose.yml                   # Compose setup for API and training
├── .dockerignore                            # Docker cleanup
└── README.md
```

---

## 🚀 How to Run with Docker

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)
- (Optional) [Docker Compose](https://docs.docker.com/compose/)

### 🧪 Build and Start (via Compose)

From the solution root:

```bash
docker compose -f docker/docker-compose.yml up --build
```

This will:
- Build and run the **API container** on `http://localhost:8080`
- Run the **Training container** to regenerate `FlightDelayModel.zip`

---

## 🌐 API Endpoints

Once running, visit:

- **Swagger UI:** [http://localhost:8080/swagger](http://localhost:8080/swagger)
- **Prediction Endpoint:** `POST /api/delayprediction/predict`

```json
{
  "origin": "BLR",
  "destination": "DEL",
  "temperatureC": 27.5,
  "windSpeedKph": 14,
  "scheduledDepartureHour": 9
}
```

---

## ⚙️ Build Manually Without Docker

```bash
# Train model
dotnet run --project src/Training

# Run API
dotnet run --project src/Airlines_Services_ML_Approachs
```

---

## 🛠 Technologies Used

- .NET 9 (API & Training)
- ML.NET (Model training & inference)
- SignalR (real-time prediction feed)
- Swagger (API docs)
- Docker & Docker Compose
- Power BI (optional visualization)

---

## 📈 Future Enhancements

- Power BI dashboard integration
- Kafka/Event Hub ingestion
- Azure DevOps CI/CD pipeline
- KEDA scaling & model registry