# ReWord API

Backend desarrollado con **ASP.NET Core Web API**, **Entity Framework Core** y **PostgreSQL** para la aplicación ReWord.

## 🚀 Tecnologías utilizadas

- ASP.NET Core Web API
- C#
- Entity Framework Core
- PostgreSQL
- Npgsql
- OpenAPI / Swagger
- Git

## 📁 Estructura del proyecto

```text
ReWord/
│
├── Controllers/
├── Data/
│   └── AppDbContext.cs
├── Entities/
│   └── User.cs
├── Migrations/
├── Properties/
├── appsettings.json
├── Program.cs
└── ReWord.csproj
```

## ⚙️ Requisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- .NET SDK 10
- PostgreSQL
- Git
- Docker

## 🔧 Configuración

Clona el repositorio:

```bash
git clone https://github.com/Jossdel/ReWord.git
cd ReWord
```

Instala las dependencias:

```bash
dotnet restore
```

Configura la cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "************************************************"
}
```

## 🗄️ Crear la base de datos

Crear una migración:

```bash
dotnet ef migrations add InitialCreate
```

Aplicar las migraciones:

```bash
dotnet ef database update
```

## ▶️ Ejecutar el proyecto

```bash
dotnet run
```

O utilizando Hot Reload:

```bash
dotnet watch
```

## 📄 Documentación de la API

Una vez iniciada la aplicación, la documentación estará disponible en Swagger/OpenAPI.

## 🐳 Docker Compose

Levanta los servicios definidos en `docker-compose.yml`:

```bash
docker compose up -d
```

Detén los servicios:

```bash
docker compose down
```

## 📌 Comandos útiles

Restaurar paquetes:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Ejecutar:

```bash
dotnet run
```

Crear una migración:

```bash
dotnet ef migrations add NombreMigracion
```

Actualizar la base de datos:

```bash
dotnet ef database update
```

Eliminar la última migración:

```bash
dotnet ef migrations remove
```
