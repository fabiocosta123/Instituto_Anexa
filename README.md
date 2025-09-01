# 🧠 Anexa.Domain

Repositório que representa a camada de Domínio da aplicação **Anexa**, responsável por encapsular regras de negócio, entidades ricas, eventos de domínio e suas interações.

---
## Images
![Pagina Home](../Plataforma_Anexa/frontend/public/home.png)
![Pagina Home modo escuro](../Plataforma_Anexa/frontend/public/homeDark.png)
![Pagina Login](../Plataforma_Anexa/frontend/public/login.png)
![Pagina login modo escuro](../Plataforma_Anexa/frontend/public/loginDark.png)

## 📚 Índice

1. [📖 Visão Geral](#-visão-geral)
2. [⚙️ Tecnologias & Padrões Utilizados](#️-tecnologias--padrões-utilizados)
3. [🏛️ Estrutura de Domínio](#️-estrutura-de-domínio)
4. [🧩 Entidades Modeladas](#-entidades-modeladas)
5. [📡 Eventos e Handlers](#-eventos-e-handlers)
6. [📦 Repositórios](#-repositórios)
7. [📐 Arquitetura Adotada](#-arquitetura-adotada)
8. [🧾 Value Objects](#-value-objects)
9. [🚧 Próximos Passos](#-próximos-passos)

---

## 📖 Visão Geral

Este projeto define o núcleo do domínio da aplicação Anexa, uma plataforma educacional voltada à gestão de cursos online, pagamentos e interações entre instrutores e alunos.

---

## ⚙️ Tecnologias & Padrões Utilizados

- .NET 8 / C#
- Domain-Driven Design (DDD)
- Arquitetura Limpa
- Eventos de Domínio
- Validações com Exceptions customizadas
- Value Objects

---

## 🏛️ Estrutura de Domínio
Anexa.Domain/
├── Entities/
├── Events/
├── Exceptions/
├── Handlers/
├── Interfaces/
├── ValueObjects/

---

## 🧩 Entidades Modeladas

| Entidade    | Descrição                                                |
|-------------|------------------------------------------------------------|
| `Usuario`   | Representa usuários da plataforma (aluno/instrutor)        |
| `Curso`     | Modelo principal de um curso online                        |
| `Modulo`    | Módulo de um curso contendo lições                         |
| `Pagamento` | Registro de transações com suporte a múltiplos métodos     |
| `Pergunta`  | Dúvida enviada por alunos em cursos                        |
| `Resposta`  | Respostas ligadas a perguntas feitas                       |
| `Notificacao` | Mensagens geradas por eventos do sistema                |

---

## 📡 Eventos e Handlers

| Evento                      | Handler                            | Responsabilidade                                       |
|----------------------------|------------------------------------|--------------------------------------------------------|
| `CursoCriadoEvent`         | `CursoCriadoEventHandler`          | Notificar instrutor sobre criação de curso            |
| `PagamentoConfirmadoEvent` | `PagamentoConfirmadoEventHandler`  | Notificar aluno e instrutor sobre matrícula concluída |
| `RespostaAdicionadaEvent`  | `RespostaAdicionadaEventHandler`   | Notificar autor da pergunta sobre nova resposta       |

---

## 📦 Repositórios

Interfaces já definidas para persistência de entidades:

- `INotificacaoRepository`
- *(Em construção)*: `ICursoRepository`, `IPagamentoRepository`, `IUsuarioRepository`, etc.

---

## 📐 Arquitetura Adotada

- Domínio isolado com regras puras (sem dependências de infraestrutura)
- Eventos de domínio com dispatch manual
- Handlers desacoplados que reagem a eventos do núcleo
- Value Objects reforçando consistência dos dados (em desenvolvimento)

---

## 🧾 Value Objects

Objetos de valor encapsulam regras e validações de dados imutáveis no domínio.

### 🧾 `Cpf`

Representa um CPF válido no formato brasileiro.

- ✅ Validação:
  - Deve conter 11 dígitos numéricos
  - Não pode ser uma sequência inválida (ex: `00000000000`)
  - Validação dos dígitos verificadores
- 🧼 Normalização:
  - Remove pontuação
  - Armazena formatado: `000.000.000-00`
- 🧪 Exemplo:
  ```csharp
  var cpf = new Cpf("12345678909");
  Console.WriteLine(cpf); // 123.456.789-09

   Email
Representa um endereço de e-mail válido.
- ✅ Validação:
- Deve conter @ e domínio com ponto
- Sem espaços ou caracteres inválidos
- 🧼 Normalização:
- Aplica Trim() e ToLowerInvariant()
- 🧪 Exemplo:
var email = new Email("  USUARIO@EMAIL.com ");
Console.WriteLine(email); // usuario@email.com



🏠 Endereco
Representa um endereço físico completo.
- ✅ Validação:
- Todos os campos obrigatórios
- CEP com 8 dígitos numéricos
- 🧼 Normalização:
- Remove traços e espaços do CEP
- Estado em letras maiúsculas
- 🧪 Exemplo:
var endereco = new Endereco("Rua das Flores", "55", "Centro", "Registro", "SP", "11900000");
Console.WriteLine(endereco);
// Rua das Flores, 55 - Centro, Registro - SP, 11900-000



🚧 Próximos Passos
- [ X ] Criar ValueObjects (Email, Cpf, MetodoPagamento, etc)
- [ X ] Adicionar testes unitários para validar regras de negócio
- [ ] Criar repositórios restantes
- [ ] Iniciar camada de aplicação (Anexa.Application)
- [ ] Orquestrar casos de uso com Application Services

Projeto mantido por Fábio 💻✨



