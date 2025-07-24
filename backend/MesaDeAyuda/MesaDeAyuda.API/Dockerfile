# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solo el archivo .csproj (asegurate de estar en la carpeta correcta)
COPY MesaDeAyuda.API.csproj ./
RUN dotnet restore

# Copiar todo el código fuente
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar lo publicado desde el build
COPY --from=build /app/out ./

# 🔧 Expone el puerto 80 dentro del contenedor
EXPOSE 80

# 🔧 Configura la aplicación para que escuche en el puerto 80
ENV ASPNETCORE_URLS=http://+:80

# Comando de arranque
ENTRYPOINT ["dotnet", "MesaDeAyuda.API.dll"]


