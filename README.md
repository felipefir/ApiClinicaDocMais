# API Clínica Doc+

![.NET](https://img.shields.io/badge/.NET-7.0-blue)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![License](https://img.shields.io/badge/license-MIT-green)
![API](https://img.shields.io/badge/API-RESTful-orange)

---

## 📌 Visão Geral

A **API Clínica Doc+** é uma solução desenvolvida para otimizar a gestão de atendimentos em clínicas médicas, oferecendo controle eficiente dos processos por meio de uma arquitetura RESTful.

A aplicação foi projetada para operar em ambientes conectados à internet, garantindo integração, organização e agilidade no fluxo de atendimento ao paciente.

---

## ⚙️ Tecnologias Utilizadas

* **.NET 7**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **Swagger (OpenAPI)**
* **C#**

---

## ⚙️ Funcionalidades

* Cadastro de pacientes
* Cadastro de médicos
* Gestão de agendamentos
* Controle de fila de atendimento (chamada)
* Direcionamento de pacientes por sala

---

## 🔗 Estrutura de Endpoints

### 📍 Pacientes

#### ➤ Criar paciente

`POST /api/pacientes`

**Request:**

```json
{
  "nome": "João Silva",
  "cpf": "12345678900",
  "telefone": "81999999999"
}
```

**Response:**

```json
{
  "id": 1,
  "nome": "João Silva",
  "cpf": "12345678900",
  "telefone": "81999999999"
}
```

---

#### ➤ Listar pacientes

`GET /api/pacientes`

**Response:**

```json
[
  {
    "id": 1,
    "nome": "João Silva",
    "cpf": "12345678900",
    "telefone": "81999999999"
  }
]
```

---

### 📍 Médicos

#### ➤ Criar médico

`POST /api/medicos`

**Request:**

```json
{
  "nome": "Dr. Carlos",
  "crm": "12345"
}
```

**Response:**

```json
{
  "id": 1,
  "nome": "Dr. Carlos",
  "crm": "12345"
}
```

---

#### ➤ Listar médicos

`GET /api/medicos`

**Response:**

```json
[
  {
    "id": 1,
    "nome": "Dr. Carlos",
    "crm": "12345"
  }
]
```

---

### 📍 Agendamentos

#### ➤ Criar agendamento

`POST /api/agendamentos`

**Request:**

```json
{
  "pacienteId": 1,
  "medicoId": 1,
  "dataHoraAtendimento": "2026-04-20T10:00:00"
}
```

**Response:**

```json
{
  "id": 1,
  "pacienteId": 1,
  "medicoId": 1,
  "dataHoraAtendimento": "2026-04-20T10:00:00",
  "presencaConfirmada": false
}
```

---

### 📍 Chamadas (Fila)

#### ➤ Chamar próximo paciente

`POST /api/chamadas`

**Request:**

```json
{
  "agendamentoId": 1,
  "salaMedico": "Sala 01"
}
```

**Response:**

```json
{
  "ordemChamada": 1,
  "pacienteNome": "João Silva",
  "salaMedico": "Sala 01",
  "status": "Chamado",
  "horaChamada": "2026-04-20T10:05:00"
}
```

---

#### ➤ Listar fila de chamadas

`GET /api/chamadas`

**Response:**

```json
[
  {
    "ordemChamada": 1,
    "pacienteNome": "João Silva",
    "salaMedico": "Sala 01",
    "status": "Chamado",
    "horaChamada": "2026-04-20T10:05:00"
  }
]
```

---

## 🎯 Objetivo

Fornecer uma API robusta e escalável para clínicas médicas que desejam digitalizar e organizar seus processos de atendimento, melhorando a eficiência operacional e a experiência dos usuários.

---

## 👨‍💻 Autor

**Felipe Souza**
