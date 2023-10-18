using Dapper;
using DapperExtensions;
using DataAccess.Session;
using Domain.Entitys;
using Domain.Interfaces;
using System.Reflection;

namespace DataAccess.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ISession _session;
        public BaseRepository(ISession session)
        {
            _session = session;
        }
        public async Task DeleteAsync(BaseEntity entity)
        {
            try
            {
                string sql = $"DELETE FROM {typeof(BaseEntity).Name} WHERE Id = @Id";

                object id = typeof(BaseEntity).GetProperty("Id")!.GetValue(entity, null)!;

                await _session.Connection.ExecuteAsync(sql, id, _session.DbTransaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task InsertAsync(BaseEntity entity)
        {
            try
            {
                string sql = $"INSERT INTO [{typeof(BaseEntity).Name}] ({GetColumns<BaseEntity>()}) OUTPUT INSERTED.Id VALUES ({GetParameters<BaseEntity>()})";

                Guid id = await _session.Connection.QuerySingleAsync<Guid>(sql, entity, null);

                typeof(BaseEntity).GetProperty("Id")!.SetValue(entity, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(BaseEntity entity)
        {
            try
            {
                await _session.Connection.UpdateAsync(entity, _session.DbTransaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetColumns<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties().Where(x => x.Name != "Id").ToArray();
            return string.Join(", ", properties.Select(p => p.Name));
        }

        private static string GetParameters<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties().Where(x => x.Name != "Id").ToArray();
            return string.Join(", ", properties.Select(p => $"@{p.Name}"));
        }
    }
}
