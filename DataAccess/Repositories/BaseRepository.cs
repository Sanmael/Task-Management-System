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
        private readonly DapperSession _dapperSession;

        public BaseRepository(DapperSession dapperSession)
        {
            _dapperSession = dapperSession;
        }

        public async Task DeleteAsync(BaseEntity entity)
        {
            try
            {
                string sql = $"DELETE FROM {typeof(BaseEntity).Name} WHERE Id = @Id";

                object id = typeof(BaseEntity).GetProperty("Id")!.GetValue(entity, null)!;

                await _dapperSession.DbConnection.ExecuteAsync(sql, id, _dapperSession.Transaction);
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

                Guid id = await _dapperSession.DbConnection.QuerySingleAsync<Guid>(sql, entity, null);

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
                await _dapperSession.DbConnection.UpdateAsync(entity, _dapperSession.Transaction);
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
