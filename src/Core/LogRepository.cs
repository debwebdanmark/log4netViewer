using MongoDB.Driver;

namespace Core
{
    public class LogRepository<T>
    {
        private readonly MongoCollection<T> _mongoCollection;

        public LogRepository(MongoCollection<T> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
    }
}
