# Using the base dotnet image for building the entire project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copying the needed solution files into their respective directory in the container.
COPY ./*.sln ./
COPY ./API/*.csproj ./API/
COPY ./BL/*.csproj ./BL/
COPY ./DAL/*.csproj ./DAL/
COPY ./Domain/*.csproj ./Domain/

# Restoring project dependencies
RUN dotnet restore ./API/API.csproj

# Copying the entire solution except the files in the .dockerignore file.
COPY . .
WORKDIR /app/API

# Handle conditional builds for development or production
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/API/out ./

# Set environment variable and expose port
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "API.dll"]