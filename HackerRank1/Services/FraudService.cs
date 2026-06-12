using HackerRank1.Entities;
using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerRank1.Services
{
    public class FraudService : IFraudService
    {
        private readonly LibraryContext _context;

        // Inyectar la base de datos
        public FraudService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fraud>> GetAllFraudsAsync()
        {
            // Devuelve todos los fraudes registrados
            return await _context.Frauds.ToListAsync();
        }

        public async Task<Fraud> CreateFraudAsync(Fraud fraud)
        {
            // Agrega el nuevo reporte y guarda los cambios en la BD
            _context.Frauds.Add(fraud);
            await _context.SaveChangesAsync();
            return fraud;
        }
    }
}