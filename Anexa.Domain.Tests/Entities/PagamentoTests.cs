using Anexa.Domain.Entities;
using Anexa.Domain.Exceptions;
using Anexa.Domain.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Anexa.Domain.Entities.Pagamento;

namespace Anexa.Domain.Tests.Entities
{
    public class PagamentoTests
    {
        [Fact]
        public void Deve_criar_pagamento_valido()
        {
            var pagamento = new Pagamento(
                alunoId: Guid.NewGuid(),
                cursoId: Guid.NewGuid(),
                valor: VoFixture.Valor(199.90m),
                metodo: MetodoPagamento.Pix
            );

            Assert.NotEqual(Guid.Empty, pagamento.Id);
            Assert.NotEqual(Guid.Empty, pagamento.AlunoId);
            Assert.NotEqual(Guid.Empty, pagamento.CursoId);
            Assert.Equal(199.90m, pagamento.Valor.Valor);
            Assert.Equal(MetodoPagamento.Pix, pagamento.Metodo);
            Assert.True(pagamento.DataPagamento <= DateTime.UtcNow);
        }

        [Fact]
        public void Nao_deve_criar_pagamento_com_aluno_id_vazio()
        {
            var exception = Assert.Throws<DomainException>(() =>
            {
                new Pagamento(
                    alunoId: Guid.Empty,
                    cursoId: Guid.NewGuid(),
                    valor: VoFixture.Valor(),
                    metodo: MetodoPagamento.Dinheiro
                );
            });
            Assert.Equal("Aluno não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Nao_deve_criar_pagamento_com_curso_id_vazio()
        {
            var exception = Assert.Throws<DomainException>(() =>
            {
                new Pagamento(
                    alunoId: Guid.NewGuid(),
                    cursoId: Guid.Empty,
                    valor: VoFixture.Valor(),
                    metodo: MetodoPagamento.Dinheiro
                );
            });
            Assert.Equal("Curso não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void Nao_deve_criar_pagamento_com_valor_nulo()
        {
            var exception = Assert.Throws<DomainException>(() =>
            {
                new Pagamento(
                    alunoId: Guid.NewGuid(),
                    cursoId: Guid.NewGuid(),
                    valor: null,
                    metodo: MetodoPagamento.Credito
                );
            });
            Assert.Equal("Valor deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public void Nao_deve_criar_pagamento_com_metodo_invalido()
        {
            var exception = Assert.Throws<DomainException>(() =>
            {
                new Pagamento(
                    alunoId: Guid.NewGuid(),
                    cursoId: Guid.NewGuid(),
                    valor: VoFixture.Valor(),
                    metodo: MetodoPagamento.Nenhum
                );
            });
            Assert.Equal("Método de pagamento inválido.", exception.Message);
        }
    }
}
