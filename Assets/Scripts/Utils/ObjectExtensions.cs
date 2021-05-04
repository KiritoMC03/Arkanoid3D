namespace Utils
{
    public static class ObjectExtensions
    {
        public static bool NotEquals(this object thisObj, object targetObj)
        {
            return !thisObj.Equals(targetObj);
        }
    }
}
