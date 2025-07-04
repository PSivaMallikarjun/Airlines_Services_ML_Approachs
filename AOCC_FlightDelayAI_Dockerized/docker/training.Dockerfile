FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app

COPY ./src/Training/*.csproj ./
RUN dotnet restore

COPY ./src/Training/ ./
COPY ./src/Training/data ./data

RUN dotnet publish -c Release -o /out
WORKDIR /out

CMD ["dotnet", "Training.dll"]