using System;
using BeyondTheGym_WebApp.Data.Data;
using BTG.Data;
using BTG.Models.ClientModels;
using Microsoft.EntityFrameworkCore;
using Models.ClientModels;

namespace BTG.Services.ClientServices
{
    public class ClientService :IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientListItem>> GetClients()
        {
            var clients = await _context.Clients.Select(c => new ClientListItem
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                ID = c.Id,
            }).ToListAsync();


            return clients;
        }

        public async Task<bool> CreateClientAsync(ClientCreate model)
        {
            if (model is null) return false;

            var entity = new Client
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                DateOfBirth = model.DateOfBirth,
                Injuries = model.Injuries,
            
            };

            _context.Clients.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ClientDetail> GetClientDetailByIDAsync(string lastName)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.LastName == lastName);

            if (client is null) return null;

            return new ClientDetail
            {
                FirstName=client.FirstName,
                LastName=client.LastName,
                //Email=client.Email,
                DateOfBirth=client.DateOfBirth,
                Injuries=client.Injuries,
                ExercisePlans=client.ExercisePlans
            };
        }

        public async Task<bool> EditClientAsync(string lastName, ClientEdit model)
        {
            if (lastName == null) return false;

            var entity = await _context.Clients.SingleOrDefaultAsync(x=>x.LastName==lastName);
            if (entity is null) return false;

            //entity.Id = model.ID;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.DateOfBirth = model.DateOfBirth;
            entity.Injuries = model.Injuries;

            //_context.Clients.Update(entity);
            //await _context.SaveChangesAsync();
            //return true;
            return await _context.SaveChangesAsync() == 1;

        }
    }
}

