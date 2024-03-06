using Lab1_4.Entities;

namespace Lab1_4.Services
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>?> GetRates(DateTime date);
    }
}
