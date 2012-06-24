using System;

namespace CqrsIntroduction
{
    public interface IAtomicWriter<in TKey, TView>
    {
        TView AddOrUpdate(TKey key, Func<TView> addFactory, Func<TView, TView> updateFunction);
    }
}
