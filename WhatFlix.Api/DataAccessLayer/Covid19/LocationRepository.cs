using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Covid19.Domain;
using Covid19.Repository;
using Microsoft.Azure.Cosmos;


namespace DataAccessLayer.Covid19
{
    public class LocationRepository : ILocationRepository
    {
        private Container container;
        public LocationRepository(Covid19DbContext context)
        {
            this.container = context.Locations;
        }
        public async void Add(Location entity)
        {

            try
            {
                // Read the item to see if it exists.  
                ItemResponse<Location> res = await this.container.ReadItemAsync<Location>(entity.id, new PartitionKey(entity.country));
                Console.WriteLine("Item in database with id: {0} already exists\n", res.Resource.zipcode);
            }
            catch(CosmosException) 
            {
                // Create an item in the container representing the Andersen family. Note we provide the value of the partition key for this item, which is "Andersen"
                var res = await this.container.CreateItemAsync<Location>(entity, new PartitionKey(entity.country));
                //Console.WriteLine(ex);
                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                //Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", andersenFamilyResponse.Resource.Id, andersenFamilyResponse.RequestCharge);
            }
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await GetAllLocation();
        }

        private async Task<List<Location>> GetAllLocation()
        {
            var sqlQueryText = "SELECT * FROM c ";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Location> queryResultSetIterator = this.container.GetItemQueryIterator<Location>(queryDefinition);

            var families = new List<Location>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (var location in currentResultSet)
                {
                    families.Add(location);
                    //Console.WriteLine("\tRead {0}\n", family);
                }
            }
            return families;
        }

        
       
    }
}