using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramework.Nort.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable] // nedir öğren
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheByMinue=60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinue;
        }

        // Gelen Cachemanagerın instance sini üretmek icin RuntimeInitialize kullanıyoruz
        public override void RuntimeInitialize(MethodBase method)
        {
            // gelen cachemanegerin dogru typr da oldugunu kontrol ediyoruz.
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }

            //Cache managerin instancesını üretmek için kullandık Bakılacak.
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }
        // Metodu çalıştırmadan önce aspectin çalışması için oninvoke
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,//metodun class ismi
                args.Method.Name);
            var arguments = args.Arguments.ToList();

            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cacheManager.Add(key,args.ReturnValue,_cacheByMinute);
        }
    }
}
