using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using OnlineBookstore.Services.Services.Interfaces;

namespace OnlineBookstore.Services.Services.Interfaces
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public void Add(Publisher publisher)
        {
            _publisherRepository.Add(publisher);
        }

        public void Delete(int publisherID)
        {
            _publisherRepository.Delete(publisherID);
        }

        public void Edit(Publisher publisher)
        {
            _publisherRepository.Edit(publisher);
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _publisherRepository.GetAllPublishers();
            return result;
        }

        public Publisher GetPublishersById(int id)
        {
            var result = _publisherRepository.GetPublishersById(id);
            return result;
        }
    }
}
