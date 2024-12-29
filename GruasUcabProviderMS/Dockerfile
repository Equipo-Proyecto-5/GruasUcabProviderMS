# Usa una imagen base de .NET 8 SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto de todas las capas y restaurar dependencias
COPY GruasUcabProviderMS/GruasUcabProviderMS.csproj ./GruasUcabProviderMS/
COPY ProviderMS.Application/ProviderMS.Application.csproj ./ProviderMS.Application/
COPY ProviderMS.Commons/ProviderMS.Commons.csproj ./ProviderMS.Commons/
COPY ProviderMS.Core/ProviderMS.Core.csproj ./ProviderMS.Core/
COPY ProviderMS.Domain/ProviderMS.Domain.csproj ./ProviderMS.Domain/
COPY ProviderMS.Infrastructure/ProviderMS.Infrastructure.csproj ./ProviderMS.Infrastructure/

# Restaurar dependencias
RUN dotnet restore ./GruasUcabProviderMS/GruasUcabProviderMS.csproj

# Copiar el resto de los archivos del proyecto
COPY . .

# Establecer el directorio de trabajo al proyecto principal
WORKDIR "/src/GruasUcabProviderMS"

# Publicar la aplicación en modo Release
RUN dotnet publish "GruasUcabProviderMS.csproj" -c Release -o /app/out

# Usa una imagen base de .NET 8 Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de construcción
COPY --from=build /app/out .

# Exponer los puertos que la aplicación usará
EXPOSE 7255
EXPOSE 5039

# Configurar el punto de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "GruasUcabProviderMS.dll"]
