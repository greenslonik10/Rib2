FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Diary.WebAPI/Diary.WebAPI.csproj", "Diary.WebAPI/"]
COPY ["Diary.Entity/Diary.Entity.csproj", "Diary.Entity/"]
COPY ["Diary.Shared/Diary.Shared.csproj", "Diary.Shared/"]
COPY ["Diary.Repository/Diary.Repository.csproj", "Diary.Repository/"]
COPY ["Diary.Services/Diary.Services.csproj", "Diary.Services/"]
RUN dotnet restore "Diary.WebAPI/Diary.WebAPI.csproj"
COPY . .
WORKDIR "/src/Diary.WebAPI"
RUN dotnet build "Diary.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diary.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diary.WebAPI.dll"]
