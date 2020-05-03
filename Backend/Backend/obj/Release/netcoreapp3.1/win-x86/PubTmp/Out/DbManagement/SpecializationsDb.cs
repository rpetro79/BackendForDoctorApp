using Backend.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class SpecializationsDb : ISpecializationsDb
    {
        private readonly Context context;

        public SpecializationsDb(Context context)
        {
            this.context = context;
        }

        public async Task<List<string>> getSpecializationsAsync()
        {
            List<Specialization> specs = await context.specializations.ToListAsync<Specialization>();
            List<string> toReturn = new List<string>();
            foreach (Specialization s in specs)
            {
                toReturn.Add(s.name);
            }
            return toReturn;
        }

        public async Task<bool> postSpecializationAsync(string specialization)
        {
            context.specializations.Add(new Specialization(specialization));
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public async Task deleteSpecializationAsync(string specialization)
        {
            context.specializations.Remove(new Specialization(specialization));
            await context.SaveChangesAsync();
        }
    }
}
