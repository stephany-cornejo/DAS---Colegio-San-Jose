# Colegio San Jose

Esta es una aplicación web de control de datos estudiantiles para el colegio San Jose.

Esta aplicación está conectada a una base de datos SQL Server que contiene 3 tablas: Estudiantes, Materias y Expedientes. Y permite realizar acciones CRUD para cada una de ellas.

## Instalación


1. **Clonar el repositorio:**
   ```
   git clone https://github.com/stephany-cornejo/DAS---Colegio-San-Jose.git
   cd ColegioSanJose
   ```

2. **Restaurar las dependencias:**
   ```
   dotnet restore
   ```

3. **Configurar la base de datos:**
   - Abrir `appsettings.json` y configurar la cadena de conexión a SQL Server
   - Ejecutar las migraciones para crear la base de datos:
   ```
   dotnet ef database update
   ```

4. **Compilar el proyecto:**
   ```
   dotnet build
   ```

## Despliegue

1. **Publicar el proyecto:**
   ```
   dotnet publish -c Release -o ./publish
   ```

2. **Configurar variables de entorno:**
   - Configurar `appsettings.json` con la cadena de conexión de producción

3. **Ejecutar la aplicación:**
   ```
   dotnet ColegioSanJose.dll
   ```

# Tecnologías

ASP.NET MVC. Bootstrap, Javascript, SQL Server.

# Desarrollo

Desarrollado por Stephany Cornejo

# Licencia

Este proyecto es licenciado bajo la Licencia MIT.