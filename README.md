# 🧠 Anexa.Domain

Repositório que representa a camada de Domínio da aplicação **Anexa**, responsável por encapsular regras de negócio, entidades ricas, eventos de domínio e suas interações.

---

## 📚 Índice

1. [📖 Visão Geral](#-visão-geral)
2. [⚙️ Tecnologias & Padrões Utilizados](#️-tecnologias--padrões-utilizados)
3. [🏛️ Estrutura de Domínio](#️-estrutura-de-domínio)
4. [🧩 Entidades Modeladas](#-entidades-modeladas)
5. [📡 Eventos e Handlers](#-eventos-e-handlers)
6. [📦 Repositórios](#-repositórios)
7. [📐 Arquitetura Adotada](#-arquitetura-adotada)
8. [🚧 Próximos Passos](#-próximos-passos)

---

## 📖 Visão Geral

Este projeto define o núcleo do domínio da aplicação Anexa, uma plataforma educacional voltada à gestão de cursos online, pagamentos e interações entre instrutores e alunos.

---

## ⚙️ Tecnologias & Padrões Utilizados

- **.NET 8 / C#**
- **Domain-Driven Design (DDD)**
- **Arquitetura Limpa**
- **Eventos de Domínio**
- **Validações com Exceptions customizadas**
- **Value Objects**

---

## 🏛️ Estrutura de Domínio

```bash
Anexa.Domain/
├── Entities/
├── Events/
├── Exceptions/
├── Handlers/
├── Interfaces/
├── ValueObjects/
