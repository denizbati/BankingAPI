using System.Diagnostics.CodeAnalysis;

namespace platform.empty.Domain.Extentions
{
    public static class ValidationExtentions
    {
        /// <summary>
        /// Validate object, throw ArgumentNullException when object is null, Else return object
        /// </summary>
        public static T ValidateNotNull<T>([NotNull] this T obj)
        {
            if(obj is null)
            {
                Type type = typeof(T);
                throw new ArgumentNullException(type.Name);
            }
            return obj;
        }

        /// <summary>
        /// Validate object, throw ArgumentNullException when object is null, Else return object
        /// </summary>
        public static T ValidateNotNull<T>([NotNull] this T obj, string name)
        {
            if (obj is null)
                throw new ArgumentNullException(name);
            return obj;
        }
    }
}
