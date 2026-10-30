<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:0f766e,100:2563eb&height=220&section=header&text=GestionTurnos&fontSize=64&fontColor=ffffff&animation=fadeIn&fontAlignY=38&desc=Sistema%20de%20gesti%C3%B3n%20de%20turnos%20para%20cl%C3%ADnicas&descAlignY=60&descSize=20" alt="GestionTurnos" />

<a href="https://git.io/typing-svg">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&weight=600&size=22&pause=1200&color=2563EB&center=true&vCenter=true&width=640&lines=Pacientes+y+profesionales+%F0%9F%A9%BA;Turnos+validados+en+tiempo+real+%F0%9F%93%85;Control+de+feriados+con+API+de+Argentina+%F0%9F%87%A6%F0%9F%87%B7;Hecho+en+C%23+con+POO+%F0%9F%92%BB" alt="Typing SVG" />
</a>

<br/>

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
![Estado](https://img.shields.io/badge/estado-en%20desarrollo-f59e0b?style=for-the-badge)

</div>

---

## 📋 Descripción

**GestionTurnos** es una aplicación de consola desarrollada en **C#** que simula el sistema de turnos de una clínica o consultorio médico. Permite registrar pacientes y profesionales, definir los horarios de atención de cada profesional y asignar turnos validando que el horario esté libre, que el profesional atienda ese día y que la fecha **no sea feriado**.

El proyecto está diseñado con **programación orientada a objetos** a partir de un diagrama UML, aplicando clases, relaciones, encapsulamiento y manejo de excepciones.

---

## ✨ Funcionalidades

| | Funcionalidad | Descripción |
|---|---|---|
| 🧑‍⚕️ | **Registro de pacientes** | Nombre, apellido, fecha de nacimiento, teléfono y tipo de cobertura, con validación de cada dato ingresado |
| 👨‍⚕️ | **Registro de profesionales** | Matrícula, especialidad, valor de consulta y horarios de atención |
| 🔎 | **Búsqueda de pacientes** | Por nombre y apellido, con su historial de turnos |
| 📅 | **Sacar turno** | Asigna un turno y genera un comprobante con el costo estimado según la cobertura |
| 🗓️ | **Agenda del profesional** | Muestra los turnos de un profesional en un día determinado |
| 🇦🇷 | **Control de feriados** | Consulta una API de feriados de Argentina para impedir turnos en días no laborables |
| 💰 | **Cálculo de costos** | El monto de la consulta varía según el paciente sea Particular u Obra social |

---

## ✅ Validaciones al sacar un turno

```text
 ✔ El paciente existe
 ✔ El profesional existe
 ✔ La fecha no es anterior a la actual
 ✔ El día no es feriado (API de feriados de Argentina)
 ✔ El profesional atiende ese día y a esa hora
 ✔ El horario está libre (sin dos turnos a la misma hora)
```

---

## 🧱 Diagrama de clases

```mermaid
classDiagram
    class SistemaClinica {
        +List~Paciente~ Pacientes
        +List~Profesional~ Profesionales
        +List~Turno~ Turnos
        +RegistrarPaciente()
        +RegistrarProfesional()
        +BuscarPaciente()
        +VerAgendaProfesional()
        +SacarTurno()
    }
    class Paciente {
        +string Nombre
        +string Apellido
        +DateTime FechaNacimiento
        +string Telefono
        +string TipoCobertura
    }
    class Profesional {
        +string Matricula
        +string Especialidad
        +decimal ValorConsulta
        +List~HorarioAtencion~ Horarios
    }
    class HorarioAtencion {
        +DayOfWeek Dia
        +TimeSpan HoraInicio
        +TimeSpan HoraFin
        +int DuracionTurnoMinutos
    }
    class Turno {
        +int Numero
        +DateTime Fecha
        +string MotivoPaciente
        +string Diagnostico
        +string MotivoCancelacion
        +decimal Monto
        +string ObraSocial
    }
    class Feriado {
        +string fecha
        +string nombre
    }

    SistemaClinica "1" --> "*" Paciente
    SistemaClinica "1" --> "*" Profesional
    SistemaClinica "1" --> "*" Turno
    Profesional "1" --> "*" HorarioAtencion
    Turno "*" --> "1" Paciente
    Turno "*" --> "1" Profesional
```

> La lista de turnos se centraliza en `SistemaClinica`, de modo que cada turno existe **una sola vez** y se filtra con LINQ según el paciente o el profesional.

---

## 🛠️ Tecnologías

- **C#** y **.NET**
- **LINQ** para filtrar y consultar colecciones
- **System.Text.Json** para leer la respuesta de la API de feriados
- **HttpClient** y **async/await** para las consultas web
- **[ArgentinaDatos API](https://argentinadatos.com/)** para los feriados nacionales

---

## 🚀 Cómo ejecutarlo

1. Cloná el repositorio:

   ```bash
   git clone https://github.com/TU_USUARIO/GestionTurnos.git
   ```

2. Abrí la solución `GestionTurnos.sln` con **Visual Studio**.
3. Presioná **F5** para compilar y ejecutar.

> Para el control de feriados se necesita conexión a internet. Si la consulta falla, el programa informa el error y no se cierra.

---

## 🗺️ Estado del proyecto

- [x] Registro y listado de pacientes
- [x] Registro y listado de profesionales
- [x] Horarios de atención por profesional
- [x] Control de feriados con API
- [x] Comprobante de turno con costo según cobertura
- [ ] Validación completa de horarios y duración de turnos
- [ ] Persistencia de turnos en archivo JSON
- [ ] Cancelación de turnos con motivo
- [ ] Carga de diagnóstico al atender
- [ ] Manejo de excepciones en todas las operaciones

---

## 👤 Autor

Proyecto desarrollado por **TU NOMBRE** como parte de la tecnicatura.

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/TU_USUARIO)

<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:2563eb,100:0f766e&height=100&section=footer" alt="footer" />

</div>
