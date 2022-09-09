using System;
using BTG.Models.ClientModels;
using Models.ClientModels;

namespace BTG.Services.ClientServices
{
    public interface IClientService
    {
        Task<bool> CreateClientAsync(ClientCreate model);
        
        Task<IEnumerable<ClientListItem>> GetClients();

        Task<bool> EditClientAsync(string id, ClientEdit model);

        //Task<bool> DeleteClientAsync (ClientCreate model);

        Task<ClientDetail> GetClientDetailByIDAsync(string id);

    }
}

