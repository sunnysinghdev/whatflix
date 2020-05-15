using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Covid19.Domain;
using Covid19.Repository;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
namespace DataAccessLayer.Covid19
{
    public class Covid19DbContext //: ILocationRepository
    {
        
        // Equivalent to DbSet in EF
        public Container Locations;
        private readonly string databaseId = "covid19";
        private readonly string locationId = "location";
        public Covid19DbContext(string EndpointUri, string PrimaryKey)
        {
            CosmosClient cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "Covid19Monitor" });
            Database database = cosmosClient.GetDatabase(databaseId);
            this.Locations = database.GetContainer(locationId);
        }
    }
}