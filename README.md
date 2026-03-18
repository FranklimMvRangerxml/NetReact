# 🛒 Login Net

Sistema de gestión de usuarios, sedes y planes construido con **ASP.NET Core 8** + **React** + **PostgreSQL (Neon)**.

---

## 🧰 Tecnologías

| Capa | Tecnología |
|------|-----------|
| Backend | ASP.NET Core 8 (C#) |
| Frontend | React 18 |
| Base de datos | PostgreSQL (Neon) |
| ORM | Entity Framework Core |
| Autenticación | JWT Bearer |
| Hash contraseñas | BCrypt.Net |
| Documentación | Swagger / OpenAPI |

---

## 📁 Estructura del proyecto

```
carritonet/
├── Controllers/
│   ├── AuthController.cs       # Login y autenticación
│   ├── UsuarioController.cs    # CRUD de usuarios
│   └── SedeController.cs       # CRUD de sedes
├── Models/
│   ├── Usuario.cs
│   ├── LoginDto.cs
│   ├── LoginResponseDto.cs
│   ├── Sede.cs
│   └── Plan.cs
├── Services/
│   ├── IAuthService.cs
│   └── AuthService.cs
├── Data/
│   └── AppDbContext.cs
├── ClientApp/                  # React frontend
│   └── src/
│       ├── components/
│       ├── http/
│       │   ├── solicitud.js    # Llamadas Axios
│       │   └── Datosenpoints.js
│       └── setupProxy.js       # Proxy desarrollo
├── Program.cs
└── appsettings.json
```

---

## ⚙️ Configuración local

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- Cuenta en [Neon](https://neon.tech/) (PostgreSQL)

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/carritonet.git
cd carritonet
```

### 2. Configurar `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=...;Database=...;Username=...;Password=..."
  },
  "Jwt": {
    "Key": "TuClaveSecretaMuyLargaMinimo32Caracteres!",
    "Issuer": "carritonet",
    "Audience": "carritonet"
  }
}
```

### 3. Instalar dependencias y correr

```bash
# Restaurar paquetes .NET
dotnet restore

# Instalar dependencias React
cd ClientApp && npm install && cd ..

# Correr el proyecto
dotnet run
```

La app estará disponible en `https://localhost:7237`  
Swagger UI en `https://localhost:7237/swagger`

---

## 🔌 Endpoints API

### Auth

| Método | Ruta | Descripción |
|--------|------|-------------|
| `POST` | `/api/auth/login` | Iniciar sesión, retorna JWT |

**Body login:**
```json
{
  "correo": "usuario@correo.com",
  "contrasenaHash": "contraseña123"
}
```

**Respuesta exitosa:**
```json
{
  "token": "eyJhbGci...",
  "expiracion": "2026-04-17T..."
}
```

---

### Usuarios

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/usuario` | Listar todos los usuarios |
| `GET` | `/api/usuario/{id}` | Obtener usuario por ID |
| `POST` | `/api/usuario` | Crear usuario |
| `PUT` | `/api/usuario/{id}` | Actualizar usuario |
| `DELETE` | `/api/usuario/{id}` | Eliminar usuario |

**Body crear usuario:**
```json
{
  "cedula": "123456789",
  "nombre": "Juan Pérez",
  "correo": "juan@correo.com",
  "telefono": "3001234567",
  "contrasenaHash": "123456",
  "rol": "empleado",
  "codigo": "USR001",
  "planId": 1,
  "sedeId": 1,
  "activo": false
}
```

---

### Sedes

| Método | Ruta | Descripción |
|--------|------|-------------|
| `POST` | `/api/sede` | Crear sede |

**Body crear sede:**
```json
{
  "usuarioSede": 2,
  "img": "https://ejemplo.com/imagen.jpg",
  "nombre": "Sede Secundaria",
  "ubicacion": "Calle 1d # 52-125, Cali",
  "estado": "activo"
}
```

---

## 🚀 Deploy en Railway

### 1. Agregar `Dockerfile` en la raíz

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
RUN apt-get update && apt-get install -y nodejs npm
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "carritonet.dll"]
```

### 2. Variables de entorno en Railway

```
ConnectionStrings__DefaultConnection  =  tu_url_neon_postgres
Jwt__Key                              =  tu_clave_secreta
Jwt__Issuer                           =  carritonet
Jwt__Audience                         =  carritonet
ASPNETCORE_ENVIRONMENT                =  Production
```

### 3. Pasos

1. Sube el proyecto a GitHub
2. Entra a [railway.app](https://railway.app)
3. **New Project → Deploy from GitHub**
4. Selecciona el repositorio
5. Agrega las variables de entorno
6. Railway hace el deploy automáticamente en cada `git push`

---

## 🔐 Uso del token JWT

Después del login, incluye el token en cada petición protegida:

```javascript
axios.get('/api/usuario', {
  headers: {
    Authorization: `Bearer ${token}`
  }
});
```

O configura un interceptor global en `solicitud.js`:

```javascript
axios.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});
```

---

## 👤 Autor

Desarrollado con ASP.NET Core 8 + React — Cali, Colombia 🇨🇴
