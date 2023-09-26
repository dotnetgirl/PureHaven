using System.Reflection;
namespace PureHaven.Service.Mapper;
public static class Mapper<TOutput>
{
    public static TOutput Map<TInput>(TInput dtoIn, TOutput dtoOut)
    {
        PropertyInfo[] inputProperties = typeof(TInput).GetProperties();
        PropertyInfo[] outputProperties = typeof(TOutput).GetProperties();
        foreach (var inProperty in inputProperties)
            foreach (var outProperty in outputProperties)
                if (inProperty.Name == outProperty.Name)
                    outProperty.SetValue(dtoOut, inProperty.GetValue(dtoIn));

        return dtoOut;
    }
}