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
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect // Nedir öğren
    {
        private string _pattern;
        private Type _cacheType;

        private ICacheManager _cacheManager;

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }

        public CacheRemoveAspect(string pattern, Type cacheType)
        {
            _pattern = pattern;
            _cacheType = cacheType;
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

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
                ? string.Format("{0}.{1}.*", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name)
                : _pattern);
        }
    }
}