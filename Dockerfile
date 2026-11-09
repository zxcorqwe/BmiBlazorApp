# ЭТАП 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем оставшиеся файлы и публикуем релизную сборку
COPY . ./
RUN dotnet publish -c Release -o out

# ЭТАП 2: Запуск
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/out .

# Открываем порт
EXPOSE 8080

# Команда запуска (обязательно проверь имя dll! Если проект называется BmiBlazorApp, то тут BmiBlazorApp.dll)
ENTRYPOINT ["dotnet", "BmiBlazorApp.dll"]