﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web_053504_Belko.Extensions
{
    
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session,
        string key, T item)
        {
            var serializedItem = JsonSerializer.Serialize(item);
            session.SetString(key, serializedItem);
        }
        public static T Get<T>(this ISession session, string key)
        {
            var item = session.GetString(key);
            return item == null
            ? Activator.CreateInstance<T>() // или default(T)
            : JsonSerializer.Deserialize<T>(item);
        }
    }
}
