using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP02.Context;
using WebAPI.Models;

//Marcelo Modesto de Lima Junior CB3015823
//Bruna Helena Silva Santos      CB3016111

namespace WebAPI.Repositories
{
    public class AtividadesRepository
    {
        private readonly TpContext _context;

        public AtividadesRepository(TpContext context)
        {
            _context = context;
        }

        public async Task<List<Atividade>> GetAll()
        {
            return await _context.Atividades.ToListAsync();
        }

        public async Task<Atividade> GetById(int id)
        {
            return await _context.Atividades.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async void Create(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            await _context.SaveChangesAsync();
        }

        public async void Update(int id, Atividade atividade)
        {
            var atividadeFind = await GetById(id);

            atividadeFind.Titulo = atividade.Titulo;
            atividadeFind.Descricao = atividade.Descricao;
            atividadeFind.Prioridade = atividade.Prioridade;
            atividadeFind.DataEntrega = atividade.DataEntrega;

            _context.Atividades.Update(atividadeFind);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var atividade = await GetById(id);
            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();
        }
    }
}
