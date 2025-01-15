FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.20 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

USER root
# Install curl, sudo, and bash RUN 
RUN apk update && apk add --no-cache curl sudo bash git yq

RUN sudo apk add dotnet8-sdk

RUN sudo dotnet tool install --global dotnet-ef

# Set the PATH to include the dotnet tools 
ENV PATH="$PATH:/root/.dotnet/tools"

# Download and install multi-gitter using sudo
RUN sudo curl -s https://raw.githubusercontent.com/lindell/multi-gitter/master/install.sh | sudo sh

USER $APP_UID

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.20 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MuNeMo/MuNeMo.csproj", "MuNeMo/"]
RUN dotnet restore "MuNeMo/MuNeMo.csproj"
COPY . .
WORKDIR "/src/MuNeMo"
RUN dotnet build "MuNeMo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MuNeMo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MuNeMo.dll"]
