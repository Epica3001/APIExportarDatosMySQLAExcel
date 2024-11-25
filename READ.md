#### ExportarDatosAExcelAPI ####

## **DESCRIPCIÓN**
`ExportarDatosAExcelAPI` es una API REST desarrollada en C# y .NET 8 que permite exportar datos desde una base de datos MySQL a un archivo Excel. Este proyecto está diseñado para ser seguro, modular y fácilmente configurable, utilizando variables de entorno para manejar credenciales sensibles.

------------------

## **CARACTERÍSTICAS**
- Exporta datos desde MySQL a Excel con un solo endpoint.
- Utiliza variables de entorno para proteger credenciales.
- Permite configurar dinámicamente la conexión a la base de datos si las variables de entorno no están    
  disponibles.
- Diseñado para ser extensible y fácil de mantener.

------------------

## **ESTRUCTURA DEL PROYECTO**
```plaintext
ExportarDatosAExcelAPI
│ 
├── Controllers
│   └── ExportarController.cs  #Controlador principal para manejar endpoints
│
├── Helpers
│   └── DatabaseConnection.cs  #Clase para gestionar la conexión a la base de datos
│
├── Services
│   ├── DatabaseService.cs     #Clase para ejecutar consultas SQL
│   └── ExcelExportService.cs  #Clase para exportar datos a Excel
│
├── appsettings.json           #Configuración general del proyecto (sin datos sensibles)
├── Program.cs                 #Punto de entrada del programa
└── .env                       #Variables de entorno (excluidas del control de versiones)
```
------------------

## **REQUISITOS PREVIOS**
- Visual Studio Code (o cualquier IDE compatible con .NET 8).
- MySQL instalado y configurado.
- Postman para realizar pruebas de la API.
- Archivo .env configurado con las credenciales de conexión.

## **INSTALACIÓN Y CONFIGURACIÓN**
# Paso 1: Clonar el repositorio (Clona el proyecto desde GitHub)
*bash:*
 git clone https://github.com/usuario/ExportarDatosAExcelAPI.git
 cd ExportarDatosAExcelAPI

# Paso 2: Configurar el archivo .env
- Crear un archivo .env en la carpeta raíz con el siguiente contenido:
DB_CONNECTION_STRING=Server="Nombre_Servidor";Database="Nombre_Base_Datos";Port="Número_Puerto";UserId="Mi_Usuario_MySQL";Password="Mi_Contraseña_MySQL"

# Paso 3: Restaurar las dependencias
- Ejecutar el siguiente comando para instalar las dependencias del proyecto:
*bash:*
 dotnet restore

# Paso 4: Ejecutar el proyecto
- Iniciar el servidor:
*bash:*
 dotnet run

# Paso 5: Probar la API con Postman
- Abrir Postman y crear una nueva solicitud GET.
- Usar el siguiente formato de URL:
http://localhost:5000/api/Exportar/{nombreTabla}
- Reemplazar {nombreTabla} con el nombre de la tabla que se desea exportar.
- Si todo está configurado correctamente, el archivo Excel se generará en la carpeta raíz del proyecto.

------------------

## **CÓMO FUNCIONA**
# 1.- Conexión a la base de datos:
- La clase DatabaseConnection busca la cadena de conexión en las variables de entorno.
- Si no la encuentra, solicita los datos al usuario a través de la consola.

# 2.- Consulta a la base de datos:
- La clase DatabaseService ejecuta consultas SQL utilizando la cadena de conexión configurada.

# 3.- Generación de archivos Excel:
La clase ExcelExportService transforma los datos obtenidos en un archivo Excel.

# 4.- Controlador de la API:
El controlador ExportarController expone un endpoint que coordina las acciones anteriores.

------------------

## **ARCHIVO .gitignore**
# 1.- El archivo .gitignore excluye:
    - Archivos de compilación: bin/, obj/.
    - Configuraciones locales: .vs/.
    - Variables de entorno: .env.
    - Archivos temporales o de sistema: *.log, *.tmp, Thumbs.db, .DS_Store.

# 2.- Contenido actual del .gitignore:
#Archivos y carpetas de compilación
bin/
obj/
*.exe
*.dll

#Configuración específica de usuario
.vs/
*.user
*.suo

#Archivos temporales
*.log
*.tmp

#Configuración del sistema operativo
Thumbs.db
.DS_Store

------------------

## **PREGUNTAS FRECUENTES (FAQ)**
# ¿Qué ocurre si la API no encuentra la cadena de conexión en las variables de entorno?
El programa solicita al usuario la información necesaria para configurar manualmente la conexión a la base de datos.

## ¿Se puede usar otra base de datos diferente a MySQL?
El código está diseñado para MySQL, pero puede adaptarse a otros gestores de base de datos modificando las consultas SQL y la configuración de conexión.

## ¿Es seguro subir este proyecto a GitHub?
Sí, siempre que el archivo .env no esté incluido en el control de versiones.

------------------

## **CONTRIBUCIONES**
# 1.- Las contribuciones son bienvenidas.

# 2.- Por favor, seguir los siguientes pasos:
- Hacer un fork del repositorio.
- Crear una nueva rama para tu funcionalidad:
    *bash:*
     git checkout -b nueva-funcionalidad

- Realizar tus cambios y hacer un commit.
- Enviar un pull request.

------------------

## **AUTOR**
`Nombre:`   Rafael José Rivas Romero
`Contacto:` epica3001.csharp@gmail.com

------------------

## **DOCUMRNTACIÓN ADICIONAL**
- El archivo Documentacion_Codigo.pdf contiene una descripción detallada del código fuente y su lógica.
- Este archivo está disponible en la raíz del proyecto.
