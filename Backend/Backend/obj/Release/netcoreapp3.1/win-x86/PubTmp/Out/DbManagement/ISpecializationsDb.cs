using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface ISpecializationsDb
    {
        Task<List<string>> getSpecializationsAsync();

        Task<bool> postSpecializationAsync(string specialization);

        Task deleteSpecializationAsync(string specialization);
    }
}
