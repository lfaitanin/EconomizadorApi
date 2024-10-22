﻿using EconomizadorApi.Application.Financeiro.Queries;
using EconomizadorApi.Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EconomizadorApi.Application.Financeiro.Handlers
{
    public class SomarReceitasPorCategoriaHandler : IRequestHandler<SomarReceitasPorCategoriaQuery, List<ReceitaCategoriaDTO>>
    {
        private readonly ApplicationDbContext _context;

        public SomarReceitasPorCategoriaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReceitaCategoriaDTO>> Handle(SomarReceitasPorCategoriaQuery request, CancellationToken cancellationToken)
        {
            var dataInicioUtc = DateTime.SpecifyKind(request.DataInicio, DateTimeKind.Utc);
            var dataFimUtc = DateTime.SpecifyKind(request.DataFim, DateTimeKind.Utc);

            var receitas = await _context.Receitas
                .Where(r => r.Data >= dataInicioUtc && r.Data <= dataFimUtc)
                .GroupBy(r => r.Categoria.Nome)
                .Select(group => new ReceitaCategoriaDTO
                {
                    Categoria = group.Key,
                    ValorTotal = group.Sum(r => r.Valor)
                })
                .ToListAsync(cancellationToken);

            return receitas;
        }
    }
}