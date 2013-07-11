using System;

namespace PrivateZone.Core.Exceptions
{
    public static class Check
    {
        public static void Require<T>(bool assertion, string message) where T : Exception
        {
            if (!assertion)
            {
                throw (T)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new object[] { message });
            }
        }
    }
}
