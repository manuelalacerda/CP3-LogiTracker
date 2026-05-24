# 🚚 LogiTracker - Sistema de Gestão Logística

Este projeto faz parte da avaliação **CP2 (Check Point 2)** do curso de **Análise e Desenvolvimento de Sistemas - FIAP**.
O objetivo é aplicar conceitos de:

* Clean Architecture
* Entity Framework Core
* Persistência de dados com banco relacional
* Migrações versionadas

---

## 👥 Integrantes

* **Nome:** Felipe Monte de Sousa **RM:** 562019
* **Nome:** Manuela de Lacerda Soares **RM:** 564887
---

## 🔗 Link Swagger

http://localhost:5138/swagger/index.html

## 🏗️ Domínio Escolhido

O sistema **LogiTracker** atua no domínio de **Logística e Transportes**, permitindo:

* Gerenciamento de transportadoras
* Controle de veículos e motoristas
* Rastreamento de entregas
* Associação entre carga, veículo e motorista

---

## 🧩 Entidades Modeladas

O modelo foi implementado em C# seguindo princípios de encapsulamento e separação de responsabilidades:

* **Carrier (Transportadora):** entidade central que gerencia veículos e motoristas
* **Vehicle (Veículo):** representa os veículos da frota
* **Driver (Motorista):** profissionais vinculados à transportadora
* **Cargo (Carga):** informações da carga transportada
* **Delivery (Entrega):** operação logística que conecta veículo, motorista e carga

---

## 🔄 Relacionamentos (MER)

| Relacionamento     | Cardinalidade | Descrição                                   |
| ------------------ | ------------- | ------------------------------------------- |
| Carrier → Vehicle  | 1:N           | Uma transportadora possui vários veículos   |
| Carrier → Driver   | 1:N           | Uma transportadora possui vários motoristas |
| Vehicle → Delivery | 1:N           | Um veículo pode realizar várias entregas    |
| Driver → Delivery  | 1:N           | Um motorista pode realizar várias entregas  |
| Cargo → Delivery   | 1:1           | Uma carga gera exatamente uma entrega       |

📌 O modelo foi implementado fielmente no **Entity Framework Core**, incluindo:

* Chaves primárias (PK)
* Chaves estrangeiras (FK)
* Controle de nulidade
* Relacionamentos explícitos via Fluent API

## Modelo Relacional
![Diagrama MER do Projeto](/docs/MER.jpg)

## Print Swagger
![Swagger](/docs/swaggerum.png)
![Swagger](/docs/swaggerdois.png)

## Print de ProblemDetails
![ProblemDetails](/docs/problem.jpg)
---

## 🗄️ Banco de Dados

* **SGBD utilizado:** Oracle
* Configuração via **Entity Framework Core Provider para Oracle**

📌 O banco pode ser recriado localmente utilizando as migrações.

---

## ⚙️ Persistência com EF Core

✔ `DbContext` localizado na camada **Infrastructure**
✔ Configuração via **Fluent API (`IEntityTypeConfiguration`)**
✔ Separação por entidade
✔ Relacionamentos explícitos e fiéis ao MER

---

## 🧬 Migrações

O projeto utiliza migrações versionadas do EF Core:

* Migration inicial criada
* Snapshot do modelo incluído

### ▶️ Comandos para executar:

```bash
dotnet ef database update --project LogiTracker.Infrastructure --startup-project LogiTracker.API
```

---

## 🧱 Arquitetura

O projeto segue o padrão **Clean Architecture**:

* **Domain:** Entidades e regras básicas
* **Application:** Interfaces de repositório
* **Infrastructure:** EF Core, DbContext e implementações
* **API:** Controllers e configuração de DI

---

## 🧠 Padrão de Repositório

✔ Interfaces definidas na camada **Application**
✔ Implementações na camada **Infrastructure**
✔ Injeção de dependência configurada no `Program.cs`:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
```

---

## 🔐 Configuração

A string de conexão está em:

```json
appsettings.json
```

📌 Dados sensíveis não são versionados (recomendado uso de User Secrets ou variáveis de ambiente).

---

## 🌐 Execução da API

### ▶️ Rodar o projeto:

Restaurar dependências
```bash
dotnet restore
```

Compilar
```bash
dotnet build
```

Executar a API
```bash
dotnet run --project LogiTracker.API
```
## Swagger
* Após executar a aplicação:
http://localhost:5138/swagger

### Endpoints disponíveis:
# Cargo
* GET /api/Cargo
* GET /api/Cargo/{id}
* POST /api/Cargo
* DELETE /api/Cargo/{id}
* 
# Carrier
* GET /api/Carrier
* GET /api/Carrier/{id}
* POST /api/Carrier
* DELETE /api/Carrier/{id}
* 
# Delivery
* GET /api/Delivery
* GET /api/Delivery/{id}
* POST /api/Delivery
* DELETE /api/Delivery/{id}

# Driver
* GET /api/Driver
* GET /api/Driver/{id}
* POST /api/Driver
* DELETE /api/Driver/{id}

# Vehicle
* GET /api/Vehicle
* GET /api/Vehicle/{id}
* POST /api/Vehicle
* DELETE /api/Vehicle/{id}

---

## 📁 Evidências

A pasta `/docs` contém:

* Print do banco de dados gerado
* Estrutura das tabelas
* Modelo MER atualizado
* Print Swagger
* Print ProblemDetails 

---

## 📌 Observações

* O projeto não contém regras de negócio complexas na camada de infraestrutura (conforme requisito da CP2)
* O foco está na persistência, mapeamento e organização em camadas
* O modelo foi ajustado para garantir consistência entre domínio e banco de dados

---

## 🌟 Propósito

> “Faça o seu melhor, na condição que você tem, enquanto você não tem condições melhores, para fazer melhor ainda”
> — Mario Sergio Cortella

---

## 🔗 Relação com o CP1

| CP1              | CP2                      |
| ---------------- | ------------------------ |
| MER conceitual   | Esquema físico no banco  |
| Entidades em C#  | Persistência com EF Core |
| Sem banco        | Banco configurado        |
| Sem repositórios | Repositórios + DI        |

---
