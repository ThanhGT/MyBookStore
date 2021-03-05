using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBookStore.Infrastructure
{
    public static class SessionExtensions
    {
        //checks if session has been established
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));

        }

        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionDate = session.GetString(key);
            return sessionDate == null ? default(T) : JsonSerializer.Deserialize<T>(sessionDate);

                    
        }
    }
}
