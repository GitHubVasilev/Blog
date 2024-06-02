using System.ComponentModel;
using System.Security.Claims;

namespace Blog.WebApi.Identity;

public class ClaimsHelper
{
    public static IEnumerable<Claim> CreateClaims<T>(T entity, IEnumerable<Claim> additionalClaims = null) where T : class
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        List<Claim> list = new List<Claim>();
        if (additionalClaims != null)
        {
            list.AddRange(additionalClaims);
        }

        IEnumerable<Claim> collection = from t in typeof(T).GetProperties()
                                        where t.PropertyType.IsPrimitive || t.PropertyType.IsValueType || t.PropertyType == typeof(string)
                                        select t into property
                                        let value = property.GetValue(entity)
                                        where value != null
                                        select new Claim(property.Name, value?.ToString());
        list.AddRange(collection);
        return list;
    }

    public static T GetValue<T>(ClaimsIdentity identity, string claimName)
    {
        Claim claim = identity.FindFirst((Claim x) => x.Type == claimName);
        if (claim == null)
        {
            return default(T);
        }

        if (string.IsNullOrWhiteSpace(claim.Value))
        {
            return default(T);
        }

        try
        {
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(claim.Value);
        }
        catch (Exception exception)
        {
            throw new Exception($"{claim.Value} from {claim.Value} to {typeof(T)}", exception);
        }
    }

    public static List<T> GetValues<T>(ClaimsIdentity items, string claimName)
    {
        List<T> result = new List<T>();
        List<Claim> source = items.FindAll((Claim x) => x.Type == claimName).ToList();
        if (!source.Any())
        {
            return result;
        }

        source.ToList().ForEach(delegate (Claim x)
        {
            if (string.IsNullOrWhiteSpace(x.Value))
            {
                return;
            }

            try
            {
                T item = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(x.Value);
                result.Add(item);
            }
            catch (Exception exception)
            {
                throw new Exception($"{x.Value} from {x.Value} to {typeof(T)}", exception);
            }
        });
        return result;
    }

    private static Claim FindFirstOrEmpty(IEnumerable<Claim> claims, string claimType)
    {
        return claims.FirstOrDefault((Claim x) => x.Value == claimType);
    }
}
