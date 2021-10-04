using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Adjective> Adjective { get; }
        public IGenericRepository<Client> Client { get; }
        public IGenericRepository<Friend> Friend { get; }

        public IGenericRepository<ClientResponse> ClientResponse { get; }
        public IGenericRepository<FriendResponse> FriendResponse { get; }
        public IGenericRepository<ApplicationUser> ApplicationUser { get; }
        int Commit();


        Task<int> CommitAsync();
    }
}
