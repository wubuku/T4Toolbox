using System;
using EnvDTE;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class PropertyLite : EnvDTE.Property
    {
        private ProjectPropertyElement _projectPropertyElement;

        private DTE _dte;

        public PropertyLite(ProjectPropertyElement projectPropertyElement, DTE dte)
        {
            if (projectPropertyElement == null) { throw new ArgumentNullException("projectPropertyElement"); }
            this._projectPropertyElement = projectPropertyElement;
            this._dte = dte;
        }

        public object Application
        {
            get { throw new NotImplementedException("EnvDTE.Property.Application"); }
        }

        public EnvDTE.Properties Collection
        {
            get { throw new NotImplementedException("EnvDTE.Property.Collection"); }
        }

        public EnvDTE.DTE DTE
        {
            //get { throw new NotImplementedException("EnvDTE.Property.DTE"); }
            get { return this._dte; }
        }

        public string Name
        {
            //get { throw new NotImplementedException("EnvDTE.Property.Name"); }
            get { return this._projectPropertyElement.Name; }
        }

        public short NumIndices
        {
            get { throw new NotImplementedException("EnvDTE.Property.NumIndices"); }
        }

        public new object Object
        {
            get
            {
                throw new NotImplementedException("EnvDTE.Property.Object");
            }
            set
            {
                throw new NotImplementedException("set EnvDTE.Property.Object");
            }
        }

        public EnvDTE.Properties Parent
        {
            get { throw new NotImplementedException("EnvDTE.Property.Parent"); }
        }

        public object Value
        {
            get
            {
                //throw new NotImplementedException("EnvDTE.Property.Value");
                return this._projectPropertyElement.Value;
            }
            set
            {
                throw new NotImplementedException("set EnvDTE.Property.Value");
            }
        }

        public object get_IndexedValue(object Index1, [System.Runtime.InteropServices.OptionalAttribute]object Index2, [System.Runtime.InteropServices.OptionalAttribute]object Index3, [System.Runtime.InteropServices.OptionalAttribute]object Index4)
        {
            throw new NotImplementedException("EnvDTE.Property.get_IndexedValue");
        }

        public void let_Value(object lppvReturn)
        {
            throw new NotImplementedException("EnvDTE.Property.let_Value");
        }

        public void set_IndexedValue(object Index1, [System.Runtime.InteropServices.OptionalAttribute]object Index2, [System.Runtime.InteropServices.OptionalAttribute]object Index3, [System.Runtime.InteropServices.OptionalAttribute]object Index4, object Val)
        {
            throw new NotImplementedException("EnvDTE.Property.set_IndexedValue");
        }
    }
}
