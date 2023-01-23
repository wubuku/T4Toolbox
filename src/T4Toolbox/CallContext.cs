using System;
using System.Collections.Concurrent;

namespace T4Toolbox
{
    public static class CallContext
    {
        static ConcurrentDictionary<string, AsyncLocal<object>> state = new ConcurrentDictionary<string, AsyncLocal<object>>();

        public static void SetData(string name, object data) =>
            state.GetOrAdd(name, _ => new AsyncLocal<object>()).Value = data;

        public static object GetData(string name) =>
            state.TryGetValue(name, out AsyncLocal<object> data) ? data.Value : null;

        private const string __HOST_CONTEXT__ = "__HOST_CONTEXT__";

        public static object HostContext
        {
            get
            {
                return GetData(__HOST_CONTEXT__);
            }
            set
            {
                SetData(__HOST_CONTEXT__, value);
            }
        }
    }

}

