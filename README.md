# Documentação da Solução

## Estrutura da Solução

- **auth**: Projeto responsável pela autenticação e autorização dos usuários. Implementa Identity simplificado e geração de JWT.
- **Bff-app**: Backend for Frontend para o aplicativo mobile.
- **Bff-web**: Backend for Frontend para a aplicação web.
- **Core-api**: API central com regras de negócio, exposta para os BFFs.

## Tecnologias Utilizadas

- **.NET Core 8.0**
- **Entity Framework Core**
- **Docker** (ambiente de desenvolvimento)
- **PostgreSQL** (banco de dados)
- **JWT** (autenticação stateless)
- **Identity** (modelo simplificado)
- **Migrations** organizadas por projeto

## Como rodar o ambiente de desenvolvimento

1. **Pré-requisitos**:
   - Docker instalado
   - .NET 8 SDK

2. **Subir o banco de dados com Docker**:
   ```bash
   docker compose up -d
   ```
   > O arquivo `docker-compose.yml` já inclui a configuração do PostgreSQL.

3. **Executar as migrations** (Exemplo para `auth`):
   ```bash
   dotnet ef database update --project src/auth
   ```

4. **Rodar os projetos**:
   ```bash
   dotnet run --project src/auth
   dotnet run --project src/Bff-app
   dotnet run --project src/Bff-web
   dotnet run --project src/Core-api
   ```

## Organização das Migrations

- Cada projeto que utiliza o Entity Framework deve manter suas próprias migrations na pasta `Migrations`.
- As migrations devem ser versionadas e nomeadas de forma descritiva.

## Segurança & Autenticação

- **Autenticação via JWT**: O usuário faz login, recebe um token JWT, e o inclui no header `Authorization` das requisições.
- **Identity**: Usado de forma simplificada para cadastro e autenticação de usuários.
- **Firebase (a confirmar)**: Caso implementado, será utilizado apenas para envio de notificações.

## Fluxo de Autenticação

1. Usuário faz login (rota `/auth/login`) enviando usuário e senha.
2. Backend valida credenciais e gera um token JWT.
3. Token retornado deve ser enviado no header `Authorization: Bearer {token}` nas próximas requisições.
4. Os BFFs consomem a Core-api sempre autenticando as requisições.

## Docker Compose (Exemplo)

```yaml
version: '3.9'
services:
  postgres:
    image: postgres:16
    container_name: db_postgres
    restart: always
    environment:
      POSTGRES_USER: devuser
      POSTGRES_PASSWORD: devpassword
      POSTGRES_DB: devdb
    ports:
      - "5432:5432"
    volumes:
      - pgdata:/var/lib/postgresql/data
volumes:
  pgdata:
```

## Observações

- Todos os tokens JWT devem ser validados nos BFFs e na Core-api.
- As migrations devem ser aplicadas sempre que houver alteração de modelo.
- Definir se o Firebase será utilizado apenas para notificações.

---

*Para dúvidas ou sugestões, abrir uma issue ou falar com o time responsável.*
