using System;
using System.Net;

namespace functional_programming
{
    public static class Extensions
    {
        public static T WithRetry<T>(this Func<T> action)
        {
            var result = default(T);
            int retryCount = 0;
            bool successful = false;

            do
            {
                try
                {
                    result = action();
                    successful = true;
                }
                catch (WebException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    retryCount++;
                }
            } while (retryCount < 3 && !successful);

            return result;
        }

        public static Func<TResult> Partial<TParam1, TResult>(this Func<TParam1, TResult> func, TParam1 param)
        {
            return () => func(param);
        }

        public static Func<TParam1, Func<TResult>> Curry<TParam1, TResult>(this Func<TParam1, TResult> func)
        {
            return param => () => func(param);
        }
    }
}