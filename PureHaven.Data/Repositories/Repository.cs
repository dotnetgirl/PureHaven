using Newtonsoft.Json;
using PureHaven.Domain.Commons;
using PureHaven.Domain.Entities;
using PureHaven.Data.IRepositories;
using PureHaven.Domain.Configurations;
using PureHaven.Data.Databases.Snapshots;

namespace PureHaven.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly string databaseFilePath;
    private readonly string dbSnapshot = DataBasePath.DbSnapshot;

    public Repository()
    {
        if (typeof(User) == typeof(TEntity))
            this.databaseFilePath = DataBasePath.UserDb;
        else if (typeof(Order) == typeof(TEntity))
            this.databaseFilePath = DataBasePath.OrderDb;
        else if (typeof(Schedule) == typeof(TEntity))
            this.databaseFilePath = DataBasePath.ScheduleDb;
        else
            this.databaseFilePath = DataBasePath.CleaningServiceDb;

        var source = File.ReadAllText(databaseFilePath);
        if (string.IsNullOrEmpty(source))
            File.WriteAllText(databaseFilePath, "[]");

        source = File.ReadAllText(dbSnapshot);
        if (string.IsNullOrEmpty(source))
        {
            var snapshot = JsonConvert.SerializeObject(new Snapshot(), Formatting.Indented);
            File.WriteAllText(dbSnapshot, snapshot);
        }
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        string source = await File.ReadAllTextAsync(databaseFilePath);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(source);

        source = await File.ReadAllTextAsync(dbSnapshot);
        var snapshot = JsonConvert.DeserializeObject<Snapshot>(source);

        if (databaseFilePath.Contains("users"))
            entity.Id = ++snapshot.UserId;
        else if (databaseFilePath.Contains("orders"))
            entity.Id = ++snapshot.OrderId;
        else if (databaseFilePath.Contains("schedules"))
            entity.Id = ++snapshot.ScheduleId;
        else
            entity.Id = ++snapshot.CleaningServiceId;

        source = JsonConvert.SerializeObject(snapshot, Formatting.Indented);
        await File.WriteAllTextAsync(dbSnapshot, source);

        entities.Add(entity);
        source = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(databaseFilePath, source);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var source = await File.ReadAllTextAsync(databaseFilePath);
        var oldData = JsonConvert.DeserializeObject<List<TEntity>>(source);

        var newData = oldData.Where(e => e.Id != entity.Id).ToList();
        newData.Add(entity);

        newData = newData.OrderBy(e => e.Id).ToList();
        source = JsonConvert.SerializeObject(newData, Formatting.Indented);
        await File.WriteAllTextAsync(databaseFilePath, source);

        return entity;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var source = await File.ReadAllTextAsync(databaseFilePath);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(source);

        var entity = entities.FirstOrDefault(e => e.Id == id);
        entities.Remove(entity);

        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(databaseFilePath, str);
        return true;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var source = await File.ReadAllTextAsync(databaseFilePath);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(source);

        return entities.FirstOrDefault(entity => entity.Id == id);
    }

    public async Task<List<TEntity>> SelectAllAsync()
    {
        var source = await File.ReadAllTextAsync(databaseFilePath);
        return JsonConvert.DeserializeObject<List<TEntity>>(source);
    }
}