# PruebasHexagonal

Este proyecto implementa una arquitectura **hexagonal (Ports and Adapters)**, también conocida como **Arquitectura Limpia**, orientada a separar claramente las responsabilidades de cada capa del sistema. Este enfoque promueve una solución mantenible, testeable, extensible y desacoplada.

---

## 🧱 Estructura del Proyecto

La solución está organizada en cuatro carpetas principales:

---

### 📁 Domain

Contiene la lógica de negocio pura, sin dependencias hacia otras capas. Esta capa se divide en:

- **Core**: Incluye las entidades del dominio y sus comportamientos.
- **Abstractions**: Define las interfaces (puertos) que deben ser implementadas por otras capas, tales como repositorios, servicios externos o contratos de validación.

El dominio es el núcleo del sistema y permanece inmutable frente a cambios en tecnología, frameworks o infraestructura.

---

### 📁 Application

Define la lógica de aplicación, orquestando el flujo de datos entre el dominio y los adaptadores. Se compone de:

- **Communication**: Contiene los objetos que se utilizan para transportar datos, como DTOs, ViewModels, Requests y Responses.
- **UseCases**: Son los puertos de entrada a la lógica de la aplicación, definiendo las operaciones disponibles.
- **Handlers**: Implementan la lógica para coordinar los casos de uso y los servicios.
- **Services**: Incluyen lógica de negocio específica de aplicación que utiliza entidades del dominio y abstractions.

Esta capa depende únicamente del `Domain` y está completamente aislada de la infraestructura o detalles de implementación.

---

### 📁 Infrastructure & Adapters

Contiene las implementaciones concretas de los puertos definidos en `Domain.Abstractions` y la lógica que conecta con el mundo exterior. Se organiza de la siguiente manera:

- **Repositories**: Implementaciones concretas de acceso a datos.
- **Validators** (versionados): Validaciones específicas para cada versión o endpoint.
- **Presenters** (versionados): Transforman los datos para ser devueltos desde los entrypoints.
- **MappingProfiles**: Configuraciones de AutoMapper.
- **IoC (Inversión de Control)**: Contiene extensiones para `ServiceCollection`, facilitando la inyección de dependencias desde cualquier punto del sistema.

---

### 📁 Integrations

Contiene un proyecto de integración de ejemplo: `PruebaHexagonal.API`, que expone un API REST utilizando Swagger. Incluye:

- Un controlador de ejemplo (`UserGet`)
- Inyección de dependencias a través del proyecto `IoC`
- Un formato de respuesta uniforme con `AppResponse<T>`, que encapsula:
  - `Success (bool)`
  - `Data (T)`
  - `Message (string)`

---

## 🚀 Ventajas Clave

Este proyecto demuestra cómo con unas pocas líneas y sin necesidad de acceder directamente a la lógica interna, se puede:

- Inyectar todos los servicios necesarios utilizando únicamente el proyecto `IoC`
- Invocar entrypoints definidos en los `UseCases` sin acoplarse a detalles de infraestructura
- Obtener una respuesta estructurada de forma coherente y reutilizable

Esto hace que la solución sea altamente reutilizable, fácil de testear, y lista para escalar o migrar tecnologías sin tocar la lógica central.

---

## 📦 Recomendación: Externalizar Abstracciones

Para lograr una verdadera arquitectura limpia, se recomienda que las abstracciones de:

- Handlers  
- Presenters  
- UseCases  
- Validators  

...se ubiquen en un paquete NuGet separado. Esto evita "ensuciar" la solución con archivos que cumplen únicamente funciones utilitarias o de contrato, permitiendo mantener la aplicación enfocada en su lógica de negocio.

---

## 🧩 Separación por Capas

Mantener la separación entre las capas de:

1. **Dominio** (entidades y reglas de negocio)
2. **Aplicación** (casos de uso y lógica de orquestación)
3. **Infraestructura/Adaptadores** (implementaciones concretas)

...es fundamental para:

- Asegurar un sistema desacoplado
- Facilitar pruebas unitarias y de integración
- Permitir el reemplazo de tecnología sin impacto en la lógica
- Reutilizar casos de uso desde distintos entornos (API, Worker, CLI, etc.)

---

> ✅ Este enfoque permite construir software robusto, evolutivo y enfocado en el negocio, sin quedar atado a detalles técnicos o decisiones tempranas de infraestructura.
