using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;

namespace OnlineBookstore.Services.Services.Interfaces
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();
        void Add(Publisher publisher);
        void Edit(Publisher publisher);
        void Delete(int publisherID);
        Publisher GetPublishersById(int id);
    }
}
