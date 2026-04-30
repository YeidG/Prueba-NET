Product API - Prueba Técnica Backend

Descripción

📌 API REST desarrollada en .NET 10 para la gestión de productos y control de inventario.
Permite crear, consultar y actualizar productos, incluyendo manejo de stock con validaciones de negocio.

⚙️ Tecnologías utilizadas
.NET 8
ASP.NET Core Web API
Entity Framework Core
SQLite
Swagger (OpenAPI)


🚀 Cómo ejecutar el proyecto
1. Clonar repositorio
2. Ejecutar la API
cd Api
dotnet run
3. Acceder a Swagger
Abrir en navegador:
https://localhost:xxxx/swagger
Abrir en navegador https://prueba-net.onrender.com/index.html(version publicada)
📦 Funcionalidades
🔹 Productos
Crear producto
Listar productos (con paginación)
Obtener producto por ID
Buscar producto por código
🔹 Stock
Incrementar o disminuir stock 

🧪 Ejemplos
Crear producto
{
  "code": "P001",
  "name": "Laptop",
  "price": 2500000,
  "stock": 10
}
