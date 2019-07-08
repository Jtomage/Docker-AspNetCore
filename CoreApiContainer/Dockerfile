#Modified to build this project
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

#
# copy csproj and restore as distinct layers
# according to this document dotnet restore is no longer needed
# https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21
# -- Starting with .NET Core 2.0, you don't have to run dotnet restore because it's run implicitly by all commands
#COPY *.csproj ./
#RUN dotnet restore

# copy everything else and build app
COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
#EXPOSE 55910
#EXPOSE 44363
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CoreApiContainer.dll"]


#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
#WORKDIR /app
#EXPOSE 55910
#EXPOSE 44363
#
#FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
#WORKDIR /src
#COPY ["CoreApiContainer/CoreApiContainer.csproj", "CoreApiContainer/"]
#RUN dotnet restore "CoreApiContainer/CoreApiContainer.csproj"
#COPY . .
#WORKDIR "/src/CoreApiContainer"
#RUN dotnet build "CoreApiContainer.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "CoreApiContainer.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "CoreApiContainer.dll"]