using Newtonsoft.Json;
using PureHaven.Data.IRepositories;
using PureHaven.Domain.Commons;
using PureHaven.Domain.Configurations;
using PureHaven.Domain.Entities;

namespace PureHaven.Data.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly string databaseFilePath;

    public Repository()
    {
        if (typeof(User) == typeof(TEntity))
        {
            this.databaseFilePath = DataBasePath.UserDb;
        }
        else if (typeof(User) == typeof(TEntity))
        {
            this.databaseFilePath = DataBasePath.UserDb;
        }
        else if (typeof(Schedule) == typeof(TEntity))
        {
            this.databaseFilePath = DataBasePath.ScheduleDb;
        }
        else if (typeof(CleaningService) == typeof(TEntity))
        {
            this.databaseFilePath = DataBasePath.CleaningServiceDb;
        }

        var str = File.ReadAllText(databaseFilePath);
        if (string.IsNullOrEmpty(str))
            File.WriteAllText(databaseFilePath, "[]");
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entities = await SelectAllAsync();
        var entity = entities.FirstOrDefault(e => e.Id == id);
        entities.Remove(entity);
        var str = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
        await File.WriteAllTextAsync(databaseFilePath, str);
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        string str = await File.ReadAllTextAsync(databaseFilePath);
        List<TEntity> entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
        entities.Add(entity);
        string result = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
        await File.WriteAllTextAsync(databaseFilePath, result);
        return entity;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        return (await SelectAllAsync()).FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entities = await SelectAllAsync();
        await File.WriteAllTextAsync(databaseFilePath, "[]");

        foreach (var data in entities)
        {
            if (data.Id == entity.Id)
            {
                await InsertAsync(entity);
                continue;
            }
            await InsertAsync(data);
        }
        return entity;
    }

    public async Task<List<TEntity>> SelectAllAsync()
    {
        var str = await File.ReadAllTextAsync(databaseFilePath);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
        return entities;
    }
}

