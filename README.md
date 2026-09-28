# TccApi

API RESTful em ASP.NET Core para cadastro de Trabalhos de Conclusão de Curso (TCC), com Entity Framework Core (Code First), migrations automáticas, SQL Server e documentação Swagger.

> Projeto acadêmico desenvolvido para a disciplina de **Microsserviços**.

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/84753d07-704a-4463-8511-07c9ccf418d2" />

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/61cb2537-93bb-441e-8340-b9d96d2ea9c1" />

## Sobre o projeto

Este projeto é um trabalho da disciplina de Microsserviços da faculdade. O objetivo é construir uma API em ASP.NET com C# para o cadastro de TCC, seguindo os requisitos abaixo:

- API RESTful, com os verbos GET, POST, PUT e DELETE
- Gravação dos dados em banco de dados
- Automatic migration (Code First)
- Swagger para documentação
- Campos: Id, TituloTCC, Autores, Orientador e DataDeConclusao

A API funciona como um serviço independente, com responsabilidade única (gerenciar TCCs), banco de dados próprio e contrato exposto via HTTP e documentado pelo Swagger, o que a deixa pronta para ser consumida por outros serviços ou aplicações.

## Tecnologias

- C# e ASP.NET Core Web API (controllers)
- Entity Framework Core (Code First)
- SQL Server (LocalDB)
- Swagger (Swashbuckle.AspNetCore)
- Visual Studio 2026

## Funcionalidades

- CRUD completo de TCC (GET, POST, PUT e DELETE)
- Persistência em banco de dados SQL Server
- Migrations aplicadas automaticamente ao iniciar a aplicação
- Validação dos dados de entrada com Data Annotations
- DTOs de entrada e saída, sem expor a entidade do banco
- Documentação interativa com Swagger

## Modelo de dados

Entidade `Tcc`:

| Campo | Tipo | Regras |
|---|---|---|
| Id | int | Chave primária, gerada automaticamente |
| TituloTCC | string | Obrigatório, até 300 caracteres |
| Autores | string | Obrigatório, até 500 caracteres |
| Orientador | string | Obrigatório, até 200 caracteres |
| DataDeConclusao | datetime | Obrigatório |

## Endpoints

Rota base: `/api/Tcc`

| Verbo | Rota | Descrição | Retornos |
|---|---|---|---|
| GET | `/api/Tcc` | Lista todos os TCCs | 200 |
| GET | `/api/Tcc/{id}` | Busca um TCC pelo Id | 200, 404 |
| POST | `/api/Tcc` | Cadastra um novo TCC | 201, 400 |
| PUT | `/api/Tcc/{id}` | Atualiza um TCC existente | 204, 400, 404 |
| DELETE | `/api/Tcc/{id}` | Remove um TCC | 204, 404 |

### Exemplo de corpo (POST e PUT)

```json
{
  "tituloTCC": "Sistema de Gestão Escolar",
  "autores": "Maria Silva, João Souza",
  "orientador": "Prof. Carlos Lima",
  "dataDeConclusao": "2026-12-15T00:00:00"
}
```

O `id` não é enviado no corpo. Ele é gerado pelo banco no POST e informado pela rota no PUT e no DELETE.

### Exemplo de resposta

```json
{
  "id": 1,
  "tituloTCC": "Sistema de Gestão Escolar",
  "autores": "Maria Silva, João Souza",
  "orientador": "Prof. Carlos Lima",
  "dataDeConclusao": "2026-12-15T00:00:00"
}
```

## Estrutura do projeto

```
TccApi/
├── .gitattributes
├── .gitignore
├── README.md
├── TccApi.slnx
└── TccApi/
    ├── Controllers/
    │   └── TccController.cs
    ├── Data/
    │   └── AppDbContext.cs
    ├── Dtos/
    │   ├── TccRequest.cs
    │   └── TccResponse.cs
    ├── Migrations/
    ├── Models/
    │   └── Tcc.cs
    ├── Properties/
    │   └── launchSettings.json
    ├── appsettings.json
    ├── Program.cs
    └── TccApi.csproj
```

## Pacotes NuGet

| Pacote | Finalidade |
|---|---|
| Microsoft.EntityFrameworkCore.SqlServer | Provider do SQL Server |
| Microsoft.EntityFrameworkCore.Tools | Comandos de migration |
| Swashbuckle.AspNetCore | Documentação Swagger |

## Como executar

### Requisitos

- Visual Studio 2026 com a carga de trabalho **ASP.NET e desenvolvimento Web**
- SQL Server LocalDB (instalado junto com o Visual Studio)
- SDK do .NET compatível com o projeto

### Passos

1. Clone o repositório:

```
git clone https://github.com/JuanLopesDev/TccApi.git
```

2. Abra o arquivo `TccApi.slnx` no Visual Studio.
3. Confira a connection string em `TccApi/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TccDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

4. Selecione o perfil **https** e pressione **F5**.
5. O Swagger abre em `https://localhost:7007/swagger`.

Para usar outro SQL Server, altere o valor de `Server=` na connection string.

## Banco de dados e migrations

O projeto usa Code First com migration automática. Ao iniciar, o `Program.cs` executa `Database.Migrate()`, que cria o banco `TccDb` e a tabela `Tccs` caso não existam e aplica as migrations pendentes.

Para criar uma nova migration após alterar o model, use o Console do Gerenciador de Pacotes:

```
Add-Migration NomeDaMigration
```

Para aplicar manualmente, se preferir:

```
Update-Database
```

## Documentação

O Swagger fica disponível em `/swagger` e permite testar todos os endpoints direto pelo navegador.

## Autor

**Juan Lopes**
Trabalho da disciplina de Microsserviços
[github.com/JuanLopesDev](https://github.com/JuanLopesDev)
