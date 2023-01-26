﻿using System;
using EnvDTE;
using Microsoft.Build.Construction;

namespace T4Toolbox.EnvDteLites
{
    public class PropertiesLite : EnvDTE.Properties
    {
        private IList<ProjectPropertyElement> _projectPropertyElements;

        private DTE _dte;

        public PropertiesLite(IList<ProjectPropertyElement> projectPropertyElements, DTE dte)
        {
            if (projectPropertyElements == null) { throw new ArgumentNullException("projectPropertyElements"); }
            this._projectPropertyElements = projectPropertyElements;
            this._dte = dte;
        }

        public object Application
        {
            get { throw new NotImplementedException("EnvDTE.Properties.Application"); }
        }

        public int Count
        {
            //get { throw new NotImplementedException("EnvDTE.Properties.Count"); }
            get { return this._projectPropertyElements.Count; }
        }

        public EnvDTE.DTE DTE
        {
            //get { throw new NotImplementedException("EnvDTE.Properties.DTE"); }
            get { return _dte; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException("EnvDTE.Properties.GetEnumerator");
            foreach(var e in this._projectPropertyElements)
            {
                yield return new PropertyLite(e, _dte);
            }
        }

        public EnvDTE.Property Item(object index)
        {
            //throw new NotImplementedException("EnvDTE.Properties.Item");
            var item = this._projectPropertyElements[Convert.ToInt32(index)];
            if (item == null)
            {
                return null;
            }
            return new PropertyLite(item, _dte);
        }

        public object Parent
        {
            get { throw new NotImplementedException("EnvDTE.Properties.Parent"); }
        }
    }
}
