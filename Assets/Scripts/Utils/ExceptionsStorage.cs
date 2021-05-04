using System;

namespace Utils
{
    public static class ExceptionsStorage
    {
        public static void ThrowNoComponent<Component>()
        {
            throw new NullReferenceException($"{nameof(Component)} component not found.");
        }
    }
}
