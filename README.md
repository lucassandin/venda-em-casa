# Documenta��o da Solu��o

## Estrutura da Solu��o

- **auth**: Projeto respons�vel pela autentica��o e autoriza��o dos usu�rios. Implementa Identity simplificado e gera��o de JWT.
- **Bff-app**: Backend for Frontend para o aplicativo mobile.
- **Bff-web**: Backend for Frontend para a aplica��o web.
- **Core-api**: API central com regras de neg�cio, exposta para os BFFs.

## Tecnologias Utilizadas

- **.NET Core 8.0**
- **Entity Framework Core**
- **Docker** (ambiente de desenvolvimento)
- **PostgreSQL** (banco de dados)
- **JWT** (autentica��o stateless)
- **Identity** (modelo simplificado)
- **Migrations** organizadas por projeto

## Como rodar o ambiente de desenvolvimento

1. **Pr�-requisitos**:
   - Docker instalado
   - .NET 8 SDK

2. **Subir o banco de dados com Docker**:
   ```bash
   docker compose up -d
   ```
   > O arquivo `docker-compose.yml` j� inclui a configura��o do PostgreSQL.

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

## Organiza��o das Migrations

- Cada projeto que utiliza o Entity Framework deve manter suas pr�prias migrations na pasta `Migrations`.
- As migrations devem ser versionadas e nomeadas de forma descritiva.

## Seguran�a & Autentica��o

- **Autentica��o via JWT**: O usu�rio faz login, recebe um token JWT, e o inclui no header `Authorization` das requisi��es.
- **Identity**: Usado de forma simplificada para cadastro e autentica��o de usu�rios.
- **Firebase (a confirmar)**: Caso implementado, ser� utilizado apenas para envio de notifica��es.

## Fluxo de Autentica��o

1. Usu�rio faz login (rota `/auth/login`) enviando usu�rio e senha.
2. Backend valida credenciais e gera um token JWT.
3. Token retornado deve ser enviado no header `Authorization: Bearer {token}` nas pr�ximas requisi��es.
4. Os BFFs consomem a Core-api sempre autenticando as requisi��es.

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

## Observa��es

- Todos os tokens JWT devem ser validados nos BFFs e na Core-api.
- As migrations devem ser aplicadas sempre que houver altera��o de modelo.
- Definir se o Firebase ser� utilizado apenas para notifica��es.

---

*Para d�vidas ou sugest�es, abrir uma issue ou falar com o time respons�vel.*
