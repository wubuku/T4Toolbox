using System;

namespace T4Toolbox.EnvDteLites
{
    public class EnvDTEPropertiesLite : EnvDTE.Properties
    {
        private EnvDTE.Properties _properties;

        public EnvDTEPropertiesLite(EnvDTE.Properties properties)
        {
            if (properties == null) { throw new ArgumentNullException("properties"); }
            this._properties = properties;
        }

        public object Application
        {
            get { throw new NotImplementedException("EnvDTE.Properties.Application"); }
        }

        public int Count
        {
            get { throw new NotImplementedException("EnvDTE.Properties.Count"); }
        }

        public EnvDTE.DTE DTE
        {
            get { throw new NotImplementedException("EnvDTE.Properties.DTE"); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException("EnvDTE.Properties.GetEnumerator");
        }

        public EnvDTE.Property Item(object index)
        {
            //throw new NotImplementedException("EnvDTE.Properties.Item");
            var item = this._properties.Item(index);
            if (item == null)
            {
                return null;
            }
            return new EnvDTEPropertyLite(item);
        }

        public object Parent
        {
            get { throw new NotImplementedException("EnvDTE.Properties.Parent"); }
        }
    }
}
