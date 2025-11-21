# 📊 Investment Simulator API

API desenvolvida em **.NET 9**, seguindo **Clean Architecture**, com
autenticação via **Keycloak**, métricas e rastreamento via
**OpenTelemetry**, coleta por **Prometheus** e visualização em
**Grafana**.

O objetivo deste projeto é fornecer simuladores e serviços de
investimentos, bem como telemetria consolidada para análise.

---

## 🚀 Tecnologias Utilizadas

- **.NET 9 Web API**
- **Entity Framework Core 9**
- **SQL Server 2022 (Docker)**
- **Keycloak 26** (Autenticação & Autorização)
- **OpenTelemetry (.NET)**
- **Prometheus** (Coleta de Métricas)
- **Grafana** (Dashboards)
- **OpenTelemetry Collector**
- **Docker Compose**
- **MediatR**
- **Clean Architecture**

---

## 🧱 Estrutura da Arquitetura

```text
src/
 ├─ Application/          → Casos de uso, Handlers, DTOs, Interfaces
 ├─ Domain/               → Entidades, Regras de negócio e Interfaces de repositório
 ├─ Infrastructure/       → Implementações de repositórios e serviços externos
 └─ WebApi/               → Controllers, Middlewares, IoC e Telemetria
```

---

## 🐳 Como subir toda a stack com Docker

### 1. Build e subir containers

Execute no terminal:

```bash
docker-compose up -d --build
```

### 2. Serviços disponíveis

Serviço Porta

---

API (.NET 9) **8080**
SQL Server **1433**
Keycloak **18080**
Prometheus **9090**
Grafana **3000**
OTel Collector **4317** / **4318**

---

## 🔑 Keycloak

### Admin Console

Acessar em:

    http://localhost:18080/

Credenciais padrão:

    Usuário: admin
    Senha: admin

### Importação de realm

O projeto importa automaticamente o realm localizado em:

    ./realms

### Autenticação

- Utilize o client id _investment-simulator-api_
- Mantenha _openid_ e _profile_ marcados
- Clique em _Register_ para registrar um novo usuário e utilizar na autenticação
- ***

## 📡 Endpoints principais

### Health check

    GET /health

### Telemetria consolidada

    GET /telemetria

**Exemplo de resposta:**

```json
{
  "servicos": [
    {
      "nome": "simular-investimento",
      "quantidadeChamadas": 120,
      "mediaTempoRespostaMs": 250
    },
    {
      "nome": "perfil-risco",
      "quantidadeChamadas": 80,
      "mediaTempoRespostaMs": 180
    }
  ],
  "periodo": {
    "inicio": "2025-10-01",
    "fim": "2025-10-31"
  }
}
```

### Prometheus Scraping

    http://localhost:8080/metrics

---

## 📈 Observabilidade

### 🔷 OpenTelemetry (.NET)

A API usa: - Instrumentação ASP.NET Core - Instrumentação de HTTP
Client - Instrumentação de Runtime - Métricas customizadas
(`Investimentos.Metrics`) - Exportação OTLP → Collector - Exposição
Prometheus

### 🔶 Prometheus

UI acessível em:

    http://localhost:9090

### 🔷 Grafana

UI:

    http://localhost:3000

Credenciais padrão:

    Usuário: admin
    Senha: admin

---

## 💾 Configuração do Banco

### Connection string utilizada pela API:

    Server=sqlserver,1433;Database=InvestimentosDb;User Id=sa;Password=Password123!;TrustServerCertificate=True;

A aplicação sobe automaticamente com conexão para o container
`sqlserver`.

---

## 🔐 Autenticação

A API utiliza **JWT do Keycloak**, com: - OAuth2 - OpenID Connect -
Realm importado em `/realms`

A API está preparada para validar tokens emitidos pelo Keycloak.

---

## 🧪 Swagger

Disponível em:

    http://localhost:8080/swagger

Com suporte a autenticação via Bearer Token.

---

## 📦 Scripts úteis

### Buildar e Startar serviços e API

```bash
docker-compose up -d --build
```

### Parar containers

```bash
docker-compose down
```

### Parar e remover volumes

```bash
docker-compose down -v
```

### Logs da API

```bash
docker logs -f investment_api
```
