using Microsoft.Extensions.DependencyInjection;
using Infranstracture.Interface;

namespace Database.Delivery;

public static class DatabaseExtensions
{
    public static IServiceCollection AddTestDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IDatabase>(x => new TestDatabase());
        return services;
    }

    readonly struct TestDatabase : IDatabase
    {
        public string ConnectionString => throw new NotImplementedException();

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> DeleteManyAsync(string[] id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResult>> QueryAllAsync<TResult>()
        {
            throw new NotImplementedException();
        }

        public Task<string> QueryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> QueryAsync<TResult>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> UpdateAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
