#Modified to build this project only
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy everything else and build app
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CoreWebContainer.dll"]

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM microsoft/dotnet:2.2-nanoserver-1903 AS base
#WORKDIR /app
#EXPOSE 55447
#EXPOSE 44328

#FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
#WORKDIR /src
#COPY ["CoreWebContainer/CoreWebContainer.csproj", "CoreWebContainer/"]
#RUN dotnet restore "CoreWebContainer/CoreWebContainer.csproj"
#COPY . .
#WORKDIR "/src/CoreWebContainer"
#RUN dotnet build "CoreWebContainer.csproj" -c Release -o /app

#FROM build AS publish
#RUN dotnet publish "CoreWebContainer.csproj" -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "CoreWebContainer.dll"]