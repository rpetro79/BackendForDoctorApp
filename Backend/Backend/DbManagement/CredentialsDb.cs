using Backend.DbModel;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class CredentialsDb
    {
       

        private readonly Context context;
        public CredentialsDb(Context context)
        {
            this.context = context;
        }

        public async Task<DbCredentials> getCredentialsAsync(string SSN)
        {
            DbCredentials dbCredentials = await context.credentials.FindAsync(SSN);
            
            return dbCredentials;
        }

        public async Task<bool> putCredentialsAsync(Credentials credentials)
        {
            DbCredentials dbCredentials = await context.credentials.FindAsync(credentials.SSN);
            if (dbCredentials == null)
                return false;

            dbCredentials.password = credentials.password;
            context.Entry(dbCredentials).State = EntityState.Modified;
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

        public async Task<bool> postCredentialsAsync(Credentials credentials, int id)
        {
            DbCredentials dbCredentials = new DbCredentials();
            dbCredentials.fromCredentials(credentials, id);

            context.credentials.Add(dbCredentials);

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

        public async Task deleteCredentialsAsync(int personId)
        {
            var credentials = await context.credentials.FindAsync(personId);

            if (credentials == null)
            {
                return;
            }

            context.credentials.Remove(credentials);
            await context.SaveChangesAsync();

        }
    }
}
