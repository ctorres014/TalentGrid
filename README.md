# 🌐 TalentGrid: Dynamic Internal Talent Management

**TalentGrid** es una plataforma SaaS de vanguardia diseñada para mapear, validar y potenciar el talento interno de las organizaciones. A diferencia de los sistemas tradicionales, TalentGrid utiliza **IA Local** y **Validación Social** para crear un ecosistema vivo donde las habilidades no solo se declaran, sino que evolucionan.

---

## 🚀 Visión General

En el mercado laboral actual, el conocimiento es el activo más valioso. TalentGrid permite a las empresas:
* **Visualizar** el inventario de habilidades en tiempo real.
* **Validar** capacidades mediante el reconocimiento entre pares (**Endorsements**).
* **Guiar** el crecimiento profesional con un mentor de carrera basado en IA que respeta al 100% la privacidad de los datos.

---

## 🛠️ El Stack Tecnológico (The Power Stack)

Hemos construido TalentGrid utilizando las herramientas más potentes del ecosistema .NET y Web actual:

| Capa | Tecnología | Propósito |
| :--- | :--- | :--- |
| **Orquestación** | **.NET Aspire** | Gestión de microservicios, telemetría y orquestación de contenedores. |
| **Backend** | **ASP.NET Core 10** | API robusta con arquitectura limpia y alto rendimiento. |
| **Frontend** | **Next.js 15** | Interfaz "Antigravity" ultra rápida con TypeScript y Tailwind CSS. |
| **Identidad (IdP)** | **Keycloak** | Gestión de usuarios y seguridad de grado empresarial. |
| **Persistencia SQL** | **PostgreSQL** | Almacenamiento relacional para la matriz de talento y empleados. |
| **Persistencia NoSQL** | **MongoDB** | Almacenamiento de documentos flexibles para el historial de la IA. |
| **Abstracción** | **Dapr** | State Store para desacoplar el acceso a datos y mejorar la resiliencia. |
| **IA Local** | **Ollama (Llama 3)** | Mentoría de carrera privada sin salida de datos a la nube. |

---

## 🔌 Referencia de la API (Endpoints Principales)

### 1. Gestión de Talento
* **`POST /api/Talent/add-skill`**
    * **Función:** Permite a los colaboradores declarar una nueva habilidad o actualizar su nivel de maestría (1-5).
    * **Valor:** Fomenta la autogestión y mantiene el inventario de habilidades siempre actualizado.

* **`GET /api/Talent/search`**
    * **Función:** Motor de búsqueda avanzado. Filtra expertos por habilidad, nivel mínimo y reputación social.
    * **Valor:** Encuentra al experto ideal para cada proyecto en segundos.

### 2. Validación y Confianza
* **`POST /api/Endorsement/validate-skill`**
    * **Función:** Permite que un compañero avale la habilidad de otro mediante un comentario técnico.
    * **Valor:** Convierte las habilidades "autodeclaradas" en habilidades "verificadas" por la comunidad.

### 3. Inteligencia Artificial (PathFinder)
* **`GET /api/Mentor/advice`**
    * **Función:** Genera una hoja de ruta personalizada de carrera basada en el perfil actual vs. el rol objetivo.
    * **Lógica:** La respuesta se procesa localmente y se persiste en **MongoDB a través de Dapr** para mantener un historial coherente.
    * **Valor:** Mentoría personalizada 24/7 sin comprometer la privacidad corporativa.

---

## 🧠 Arquitectura de Datos y Persistencia Políglota

TalentGrid utiliza una arquitectura moderna donde cada dato reside en el lugar más eficiente:
1.  **Datos Core (SQL):** Empleados, habilidades y relaciones se gestionan en **PostgreSQL** para garantizar integridad referencial.
2.  **Memoria de IA (NoSQL):** Los consejos y análisis de carrera se guardan en **MongoDB**.
3.  **Capa Dapr:** Utilizamos **Dapr State Store** como mediador. Esto permite que la API sea agnóstica a la base de datos documental, facilitando la escalabilidad y el mantenimiento.

---

## 🎨 Frontend: Experiencia "Antigravity"

La interfaz de usuario está diseñada siguiendo principios de minimalismo y ligereza:
* **Diseño Minimalista:** Foco en la claridad de los datos y la reducción de la fatiga visual.
* **Componentes React:** Uso intensivo de componentes funcionales y Server Components de Next.js.
* **Visualización:** Gráficos de radar y barras de progreso dinámicas para mostrar el "gap" de habilidades.

---

## 🏁 Cómo empezar (Desarrollo)

Gracias a **.NET Aspire**, levantar todo el entorno de desarrollo es sumamente sencillo:

1.  Instala [Docker Desktop](https://www.docker.com/), [Ollama](https://ollama.com/) y el SDK de .NET 9.
2.  Clona este repositorio.
3.  Ejecuta el proyecto **TalentGrid.AppHost**.
4.  El panel de Aspire se abrirá automáticamente, levantando PostgreSQL, MongoDB, Ollama, la API y el Frontend por ti.

---

> **TalentGrid** — *Elevando el potencial humano a través de la conexión y la inteligencia.*
