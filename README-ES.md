# AppParkingSys-Back

## Descripci&#243;n general

Este proyecto es una API REST desarrollada con ASP.NET Core 8 que implementa una arquitectura limpia (Clean Architecture) para asegurar la mantenibilidad, escalabilidad y separaci&#243;n de preocupaciones en el c&#243;digo. La soluci&#243;n est&#225; organizada en cuatro capas principales: Web, Core, Infrastructure, y Services, cada una con responsabilidades espec&#237;ficas.

### Nombre del Proyecto: API que simula un sistema de estacionamiento

### Tecnolog&#237;as Utilizadas:

- **ASP.NET Core 8:** Framework principal utilizado para desarrollar la API REST.

- **EntityFramework Core:** ORM (Object-Relational Mapping) utilizado para manejar la persistencia de las entidades en una base de datos SQL Server.

- **JWT (JSON Web Tokens):** Implementado para la autenticaci&#243;n y autorizaci&#243;n de usuarios.

- **BCrypt.Net:** Utilizado para cifrar y verificar los passwords de los usuarios.

- **UnitOfWork Pattern:** Patr&#243;n de dise&#241;o implementado para coordinar la ejecuci&#243;n de m&#250;ltiples repositorios y asegurar las transacciones.

- **FluentValidation:** Utilizado para definir reglas de validaci&#243;n de las entidades del dominio.

- **AutoMapper:** Utilizado para mapear objetos entre diferentes capas de la aplicaci&#243;n.

- **Serilog:** Librer&#237;a de logging utilizada para generar logs detallados y configurables.

## Funcionalidades Principales

### Capas del Proyecto

**Web**

- Esta capa contiene los controladores de la API REST y la configuraci&#243;n del pipeline de solicitudes HTTP.

- Aqu&#237; se implementa la autenticaci&#243;n JWT (JSON Web Tokens) para asegurar las comunicaciones entre el cliente y la API.

- Utiliza Serilog para el logging y la generaci&#243;n de logs detallados.

- Utiliza AutoMapper para mapear las entidades del dominio a los modelos de DTOs (Data Transfer Objects) y viceversa.

- Utiliza BCrypt.Net para cifrar los passwords de los usuarios antes de almacenarlos en la base de datos.

**Core**

- Contiene las entidades del dominio, interfaces de repositorios y servicios, as&#237; como la l&#243;gica de negocio.

- Define las interfaces para la implementaci&#243;n del patr&#243;n de dise&#241;o UnitOfWork y los repositorios.

**Infrastructure**

- Implementa los repositorios y la unidad de trabajo (UnitOfWork) usando EntityFramework Core para manejar la persistencia de las entidades en una base de datos Microsoft SQL Server.

**Services**

- Contiene la implementaci&#243;n de los servicios de aplicaci&#243;n que interact&#250;an con la capa de infraestructura para ejecutar las operaciones de negocio definidas en la capa Core.

- Incluye las reglas de validaci&#243;n definidas con FluentValidation para garantizar la integridad de los datos.


> Este proyecto backend con ASP.NET Core 8 est&#225; dise&#241;ado para ser robusto, escalable y mantenible. La implementaci&#243;n de una arquitectura limpia (Clean Architecture) y el uso de tecnolog&#237;as modernas como JWT, BCrypt.Net, EntityFramework Core, FluentValidation, AutoMapper y Serilog garantizan un desarrollo eficiente y una operaci&#243;n segura del sistema.

> Este sistema simula lo que ser&#237;a un sistema de control de un estacionamiento, una dispensadora de tickets, solamente tiene implementado una peque&#241;a parte para simular la dispensadora de tickets no tiene desarrollado por completo los m&#243;dulos administrativos de facturaci&#243;n, etc., estos se podr&#237;an incluir a futuro.


# Screenshots
![page1](docs/images/entitys.svg)

![page1](docs/images/usecase.svg)