# ApiEstudo_JWT

Este é um projeto de estudo focado na implementação de autenticação com **JWT (JSON Web Tokens)** utilizando **ASP.NET Core Web API**. O objetivo principal é consolidar conhecimentos sobre autenticação segura, boas práticas com arquitetura em camadas e testes unitários.

## 🧠 Tecnologias Utilizadas

- ASP.NET Core 8
- JWT (System.IdentityModel.Tokens.Jwt)
- Entity Framework Core
- SQL Server
- Serilog (para logging)
- xUnit (testes unitários)
- AutoMapper
- FluentValidation (em progresso)

## 🔐 Funcionalidades

- Cadastro de usuários
- Autenticação com geração de JWT
- Proteção de endpoints com `[Authorize]`
- Custom `ExceptionFilter` para tratamento global de exceções
- Logging com Serilog
- Separação entre DTOs, entidades, serviços e repositórios

## ▶️ Como Rodar

1. Clone o repositório:
   ```bash
   git clone https://github.com/t-arievilo/ApiEstudo_JWT.git
   ```

2. Configure o `appsettings.json` com suas informações de conexão e chave JWT:

   ```json
   "JwtSettings": {
     "SecretKey": "sua-chave-super-secreta",
     "Issuer": "ApiEstudo",
     "Audience": "ApiEstudo",
     "ExpiresInMinutes": 60
   }
   ```

3. Execute as migrations (caso esteja usando EF Core):
   ```bash
   dotnet ef database update
   ```

4. Rode a aplicação:
   ```bash
   dotnet run
   ```

5. Use uma ferramenta como Postman ou Insomnia para testar os endpoints.

## 📂 Endpoints

| Método | Rota               | Descrição                 | Autenticação |
|--------|--------------------|---------------------------|--------------|
| POST   | /api/auth/login    | Login e geração de token  | ❌           |
| POST   | /api/auth/register | Cadastro de usuário       | ❌           |
| GET    | /api/users/me      | Dados do usuário logado   | ✅           |

## 🧪 Testes

Os testes estão localizados no projeto `ApiEstudoxUnitTests`. Para executar:

```bash
dotnet test
```

## 🚧 Próximos Passos

- Implementar refresh token
- Armazenar senhas com hash (ex: BCrypt)
- Criar uma camada de retorno genérico (`ApiResponse<T>`)
- Adicionar documentação com Swagger
- Aplicar Clean Architecture em projetos futuros

## 📚 Aprendizados

Esse projeto reforçou conceitos de:
- Autenticação e autorização em APIs
- Injeção de dependência
- Padrões de arquitetura em camadas
- Testes automatizados
- Boas práticas de segurança

---

Feito com 💻 por **Thiago Oliveira**  
[LinkedIn](https://www.linkedin.com/in/t-arievilo) | [GitHub](https://github.com/t-arievilo)
