using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace DataMixer.Managers
{
    public class AuthModel
    {
        
    }
    
    public class ModelSetter
    {

        public static IEnumerable<Claim> SetClaims<T>(T model)
        {
            yield return new Claim("TName", typeof(T).Name);
            
            foreach (var prop in typeof(T).GetProperties().Where(e => e.DeclaringType!.IsPublic))
            {
                yield return new Claim(prop.Name, prop.GetValue(model)!.ToString()!);
            }
        }

        public static T GetModelFromClaims<T>(IEnumerable<Claim> claims)
        {
            T item = Activator.CreateInstance<T>();

            Type t = typeof(T);
            
            foreach (var claim in claims)
            {
                PropertyInfo? prop;
                if ((prop = t.GetProperty(claim.Type)) != null)
                    prop.SetValue(item, claim.Value);
            }

            return item;
        }
        
    }
}