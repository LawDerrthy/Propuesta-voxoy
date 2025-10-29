# Sistema de Inventarios

Una aplicación de escritorio desarrollada en WPF (Windows Presentation Foundation) para la gestión de inventarios.

## Características Implementadas

### ✅ Sistema de Autenticación
- **Registro de usuarios**: Crear nuevas cuentas con validación de datos
- **Inicio de sesión**: Autenticación segura de usuarios
- **Validación de formularios**: Verificación de campos obligatorios y formato de email
- **Interfaz moderna**: Diseño limpio y profesional con efectos interactivos

### ✅ Diseño Interactivo y Moderno
- **Controles de ventana personalizados**: Minimizar, maximizar y cerrar
- **Efectos visuales**: Sombras, bordes redondeados y transiciones suaves
- **Botones interactivos**: Efectos hover y animaciones de escala
- **Campos de texto mejorados**: Focus states y validación visual
- **Diseño responsivo**: Adaptable a diferentes tamaños de ventana
- **Paleta de colores moderna**: Esquema de colores profesional y consistente

### 🔄 Funcionalidades Pendientes
- Gestión de productos
- Control de stock
- Reportes de inventario
- Historial de movimientos
- Gestión de proveedores

## Requisitos del Sistema

- Windows 10 o superior
- .NET 6.0 Runtime

## Instalación y Ejecución

1. **Clonar o descargar el proyecto**
2. **Abrir la terminal en la carpeta del proyecto**
3. **Ejecutar el siguiente comando:**
   ```bash
   dotnet run
   ```

## Uso de la Aplicación

### Registro de Usuario
1. Al ejecutar la aplicación, aparecerá la ventana de inicio de sesión
2. Hacer clic en "Registrarse" para crear una nueva cuenta
3. Completar todos los campos del formulario:
   - Nombre Completo
   - Nombre de Usuario (único)
   - Correo Electrónico (válido)
   - Contraseña (mínimo 6 caracteres)
   - Confirmar Contraseña
4. Hacer clic en "Registrarse"

### Inicio de Sesión
1. En la ventana de inicio de sesión, ingresar:
   - Nombre de Usuario
   - Contraseña
2. Hacer clic en "Iniciar Sesión"

### Ventana Principal
- Después del login exitoso, se abrirá la ventana principal
- Muestra información del usuario logueado
- Incluye opción para cerrar sesión

## Estructura del Proyecto

```
InventarioApp/
├── Models/
│   └── Usuario.cs              # Modelo de datos del usuario
├── Services/
│   └── AuthService.cs          # Servicio de autenticación
├── Views/
│   ├── LoginWindow.xaml        # Ventana de inicio de sesión
│   ├── LoginWindow.xaml.cs     # Lógica de inicio de sesión
│   ├── RegistroWindow.xaml     # Ventana de registro
│   ├── RegistroWindow.xaml.cs  # Lógica de registro
│   ├── MainWindow.xaml         # Ventana principal
│   └── MainWindow.xaml.cs      # Lógica de ventana principal
├── App.xaml                    # Configuración de la aplicación
├── App.xaml.cs                 # Punto de entrada de la aplicación
├── InventarioApp.csproj        # Archivo de proyecto
└── README.md                   # Este archivo
```

## Tecnologías Utilizadas

- **WPF (Windows Presentation Foundation)**: Framework de UI para Windows
- **C#**: Lenguaje de programación
- **.NET 6.0**: Plataforma de desarrollo
- **XAML**: Lenguaje de marcado para interfaces de usuario

## Notas de Desarrollo

- Los datos de usuario se almacenan temporalmente en memoria (se perderán al cerrar la aplicación)
- En una versión de producción, se recomienda implementar una base de datos real
- Las contraseñas no están encriptadas (implementar encriptación para producción)
- La aplicación está diseñada para ser escalable y fácil de mantener

## Próximos Pasos

1. Implementar persistencia de datos con base de datos
2. Agregar encriptación de contraseñas
3. Desarrollar módulos de gestión de inventario
4. Implementar sistema de reportes
5. Agregar validaciones adicionales de seguridad

