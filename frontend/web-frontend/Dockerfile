# Stage 1: Build Angular app
FROM node:22 AS build
WORKDIR /app

# Copiar solo los archivos necesarios para instalar dependencias
COPY package*.json ./
RUN npm install

# Copiar el resto del código fuente
COPY . .

# Compilar la app para producción
RUN npm run build -- --output-path=dist --configuration=production

# Stage 2: Servir la app con nginx
FROM nginx:stable-alpine
COPY --from=build /app/dist/browser /usr/share/nginx/html

# Exponer el puerto por donde servirá Nginx
EXPOSE 80
