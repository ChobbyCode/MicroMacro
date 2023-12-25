using Slide;

namespace MicroCacheManager
{
    public class CacheInitilizer
    {
        public CacheInitilizer()
        {
            Cache cache = new Cache("NewCache", "Bob", "MicroMacro", "C");
            cache.WriteCache();
        }
    }
}
