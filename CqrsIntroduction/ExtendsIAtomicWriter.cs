using System;

namespace CqrsIntroduction
{
    public static class ExtendsIAtomicWriter
    {
        public static TView Add<TKey, TView>(this IAtomicWriter<TKey, TView> self, TKey key, TView newView)
        {
            return self.AddOrUpdate(key, () => newView, view =>
            {
                var txt = String.Format("View '{0}' with key '{1}' should not exist.", typeof(TView).Name, key);
                throw new InvalidOperationException(txt);
            });
        }

        public static TView UpdateOrThrow<TKey, TView>(this IAtomicWriter<TKey, TView> self, TKey key, Func<TView, TView> change)
        {
            return self.AddOrUpdate(key, () =>
            {
                var txt = String.Format("Failed to load '{0}' with key '{1}'.", typeof(TView).Name, key);
                throw new InvalidOperationException(txt);
            }, change);
        }

        public static TView UpdateOrThrow<TKey, TView>(this IAtomicWriter<TKey, TView> self, TKey key, Action<TView> update)
        {
            return self.UpdateOrThrow(key, view =>
            {
                update(view);
                return view;
            });
        }
    }
}