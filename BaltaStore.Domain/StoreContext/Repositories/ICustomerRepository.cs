

using BaltaStore.Domain.StoreContext.Queries;

namespace BaltaStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckEmail(string email);
        bool CheckDocument(string document);

        void Save(Entities.Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}