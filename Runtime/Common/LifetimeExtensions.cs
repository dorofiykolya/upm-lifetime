using System;

namespace Common
{
    public static class LifetimeExtensions
    {
        public static IDisposable AsDisposable(this Lifetime.Definition definition)
        {
            return new Disposable(definition.Terminate);
        }

        class Disposable : IDisposable
        {
            private Action _action;

            public Disposable(Action action)
            {
                _action = action;
            }

            public void Dispose()
            {
                if (_action != null)
                {
                    var action = _action;
                    _action = null;
                    action();
                }
            }
        }
    }
}
