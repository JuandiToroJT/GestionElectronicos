# Gestión de Inventario de Electrónicos

## Descripción del proyecto

El sistema de gestión de inventario permite el correcto manejo de los productos
en una tienda de electrónicos, incluye un login con la posibilidad de registrarse como
empleado, luego desde el rol de empleado se tiene la posibilidad de ingresar productos, con sus
caracteristicas y cantidad de cada uno, tambien se puede registrar ventas, elegir la cantidad de 
productos a vender y se modificara la cantidad actual dependiendo de los productos que se vendan,
tambien desde el rol de administrador se podra ver un historial de ventas, el manejo de productos y el 
manejo de ventas fue realizado con árboles binarios.

### Tecnologías usadas

```
Lenguaje de programación: C#
Frameworks: .NET 8, Bootstrap
```

## Requisitos

.NET 8
> Enlace de descarga: **https://dotnet.microsoft.com/es-es/download/dotnet/8.0**

Visual Studio 2022
> Enlace de descarga: **https://visualstudio.microsoft.com/es/vs/**

## Instrucciones

Abrir el proyecto con Visual Studio 2022, luego ejecutarlo mediante el botón verde en la 
parte superior, o presionar **CTRL+F5**

## Funcionalidades

### Gestión de usuarios: 

Permite registrar empleados e iniciar sesión como empleado o como administrador.

### Registro de productos: 

Permitir a los empleados registrar nuevos productos 
electrónicos en el inventario, incluyendo información como nombre, descripción, 
precio, cantidad inicial en stock, marca, modelo, y características técnicas.

### Busqueda de productos: 

Permitir a los empleados buscar productos por nombre, marca o modelo.

### Gestión de ventas: 

Proporcionar una interfaz de usuario para que los empleados 
puedan registrar ventas de los productos electrónicos y al registrar la
venta, que se vea reflejado en la cantidad de productos disponibles, si se vende la
cantidad total del producto, este se eliminara del listado de productos. Tambien se tiene
un control para que no se vendan mas productos de los que hay.

### Historial de ventas: 

El administrador podrá visualizar el historial de ventas realizadas por los empleados

## Prueba del código

> Enlace: **https://drive.google.com/file/d/1bPsA4Zkf1ZNno379JrzYtMAoj-AdbOsh/view**