using Loxodon.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reflection;
using Tais.Extensions;

namespace Tais.Models
{
    public class Entity : IDisposable
    {
        public static Dictionary<Type, List<MethodInfo>> dict = new Dictionary<Type, List<MethodInfo>>();
        public static IMessenger messenger { get; set; }

        protected CompositeDisposable disposables = new CompositeDisposable();

        public Entity()
        {
            var type = GetType();
            if(!dict.ContainsKey(type))
            {
                var methods = new List<MethodInfo>();
                methods.AddRange(type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(method => method.GetCustomAttribute<MessageProcesser>() != null));

                dict.Add(type, methods);
            }

            foreach(var method in dict[type])
            {
                messenger.Subscribe(method.GetParameters()[0].ParameterType, (obj) => method.Invoke(this, new object[] { obj })).AddTo(disposables);
            }
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}
