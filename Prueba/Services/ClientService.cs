using Microsoft.AspNetCore.Http.HttpResults;
using Prueba.Models;

namespace Prueba.Services
{
    public class ClientService
    {
        private readonly List<Client> _clients = new List<Client>
    {
        new Client { id = 1, name = "Alex", age = "22" },
        new Client { id = 2, name = "Ulises", age = "25" }
    };

        public IEnumerable<Client> GetAll()
        {
            return _clients;
        }

        public Client GetById(int ID)
        {
            return _clients.FirstOrDefault(p => p.id == ID);

        }

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Update(Client client)
        {
            var existingClient = GetById(client.id);
            if (existingClient != null)
            {
                existingClient.name = client.name;
                existingClient.age = client.age;
            }
        }

        public void Delete(int id)
        {
            var client = GetById(id);
            if (client != null)
            {
                _clients.Remove(client);
            }
        }
    }
}
