FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
RUN dotnet ef database update --connection $PSQL_CONNECTION

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT PSQL_CONNECTION=$PSQL_CONNECTION JWT_KEY=$JWT_KEY dotnet meistrelis.dll