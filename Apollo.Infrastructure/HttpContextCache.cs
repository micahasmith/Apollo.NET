using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Apollo.Infrastructure
{
    public class HttpContextCache 
    {
        public HttpContextCache()
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                throw new ArgumentNullException("HttpContext.Current");
            }
        }
        /// <summary>
        /// Gets an item, recreating it and adding it if its not there
        /// </summary>
        /// <param name="name">The name of the item, used as a key in the HttpContext.Current.Items cache</param>
        /// <param name="ifNotFoundRecreateFunc">A function that will create the item if its not in the Http.Context.Current.Items cache</param>
        /// <returns></returns>
        public T Proxy<T>(string key, Func<T> creationFunc)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");
            if (creationFunc == null)
                throw new ArgumentNullException("creationFunc");

            var context = HttpContext.Current;

            var items = context.Items;
            var item = items[key];
            if (item != null)
            {
                return (T)item;
            }
            else
            {
                item = creationFunc();
                items[key] = item;
                return (T)item;
            }


        }

        public T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("name");
            var context = HttpContext.Current;
            var items = context.Items;
            var item = items[key];
            if (item != null)
            {
                return (T)item;
            }
            return default(T);

        }

        public void Set(string key, object obj)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            var context = HttpContext.Current;
            context.Items[key] = obj;

        }

        public void Dispose()
        {
            CacheDispose();
        }
        public static void CacheDispose()
        {
            if (HttpContext.Current != null)
            {
                var items = HttpContext.Current.Items;
                //var count = items.Count;
                var e=items.Keys.GetEnumerator();
                while (e.MoveNext())
                {

                    var item = items[e.Current];
                    if (item is IDisposable)
                    {
                        (item as IDisposable).Dispose();
                    }
                }
            }
        }
    }
}
