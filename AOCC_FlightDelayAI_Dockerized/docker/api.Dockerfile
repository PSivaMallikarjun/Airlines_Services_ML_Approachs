# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ./src/Airlines_Services_ML_Approachs/*.csproj ./
RUN dotnet restore

COPY ./src/Airlines_Services_ML_Approachs/ ./
RUN dotnet publish -c Release -o /out

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out /app
COPY ./MLModels/FlightDelayModel.zip ./MLModels/

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Airlines_Services_ML_Approachs.dll"]