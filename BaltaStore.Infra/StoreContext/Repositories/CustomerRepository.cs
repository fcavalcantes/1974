using System;
using System.Data;
using System.Linq;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.DataContexts;
using Dapper;

namespace BaltaStore.Infra.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _baltaDataContext;
        public CustomerRepository(BaltaDataContext baltaDataContext)
        {
            _baltaDataContext = baltaDataContext;
        }
        public bool CheckDocument(string document)
        {
            return _baltaDataContext.Connection.Query<bool>("spCheckDocument", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _baltaDataContext.Connection.Query<bool>("spCheckEmail", new { Email = email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _baltaDataContext.Connection.Query<CustomerOrdersCountResult>("spGetCustomerOrdersCount", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _baltaDataContext.Connection.Execute("spCreateCustomer", 
            new { 
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.EmailAddress
             }, commandType: CommandType.StoredProcedure);
        }
    }
}