using HackerRank1.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerRank1.Services
{
    public interface IFraudService
    {
        // Consultar todos los reportes
        Task<IEnumerable<Fraud>> GetAllFraudsAsync();

        // Insertar un nuevo reporte
        Task<Fraud> CreateFraudAsync(Fraud fraud);
    }
}
