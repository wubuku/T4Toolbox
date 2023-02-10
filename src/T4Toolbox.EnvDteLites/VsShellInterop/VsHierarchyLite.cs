﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace T4Toolbox.EnvDteLites.VsShellInterop
{

    public class VsHierarchyLite : IVsHierarchy, IVsBuildPropertyStorage
    {
        private ProjectLite _project;

        public VsHierarchyLite(Project project)
        {
            _project = (ProjectLite)project;
        }

        public int AdviseHierarchyEvents(IVsHierarchyEvents pEventSink, out uint pdwCookie)
        {
            throw new NotImplementedException();
        }

        public int Close()
        {
            throw new NotImplementedException();
        }

        public int GetCanonicalName(uint itemid, out string pbstrName)
        {
            throw new NotImplementedException();
        }

        public int GetGuidProperty(uint itemid, int propid, out Guid pguid)
        {
            throw new NotImplementedException();
        }

        public int GetNestedHierarchy(uint itemid, ref Guid iidHierarchyNested, out IntPtr ppHierarchyNested, out uint pitemidNested)
        {
            throw new NotImplementedException();
        }

        public int GetProperty(uint itemid, int propid, out object pvar)
        {
            throw new NotImplementedException();
        }

        public int GetSite(out Microsoft.VisualStudio.OLE.Interop.IServiceProvider ppSP)
        {
            throw new NotImplementedException();
        }

        private static IDictionary<string, uint> _canonicalNameMap = new Dictionary<string, uint>();

        public int ParseCanonicalName(string pszName, out uint pitemid)
        {
            uint itemIdFrom = 100;
            if (!_canonicalNameMap.ContainsKey(pszName))
            {
                _canonicalNameMap[pszName] = (uint)(itemIdFrom + _canonicalNameMap.Count);
            }
            pitemid = _canonicalNameMap[pszName];
            return 0;
        }

        public int QueryClose(out int pfCanClose)
        {
            throw new NotImplementedException();
        }

        public int SetGuidProperty(uint itemid, int propid, ref Guid rguid)
        {
            throw new NotImplementedException();
        }

        public int SetProperty(uint itemid, int propid, object var)
        {
            throw new NotImplementedException();
        }

        public int SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
        {
            throw new NotImplementedException();
        }

        public int UnadviseHierarchyEvents(uint dwCookie)
        {
            throw new NotImplementedException();
        }

        public int Unused0()
        {
            throw new NotImplementedException();
        }

        public int Unused1()
        {
            throw new NotImplementedException();
        }

        public int Unused2()
        {
            throw new NotImplementedException();
        }

        public int Unused3()
        {
            throw new NotImplementedException();
        }

        public int Unused4()
        {
            throw new NotImplementedException();
        }

        protected virtual int GetPropertyValue(string pszPropName, string pszConfigName, uint storage, out string pbstrPropValue)
        {
            throw new NotImplementedException();
        }

        protected virtual int GetItemAttribute(uint item, string pszAttributeName, out string pbstrAttributeValue)
        {
            //todo just return null now?
            // string relativeInputFilePath = this.Context.GetMetadataValue("Link");
            pbstrAttributeValue = null;
            return 0;
        }

        #region Implements IVsBuildPropertyStorage

        int IVsBuildPropertyStorage.GetItemAttribute(uint item, string pszAttributeName, out string pbstrAttributeValue)
        {
            return this.GetItemAttribute(item, pszAttributeName, out pbstrAttributeValue);
        }

        int IVsBuildPropertyStorage.GetPropertyValue(string pszPropName, string pszConfigName, uint storage, out string pbstrPropValue)
        {
            return this.GetPropertyValue(pszPropName, pszConfigName, storage, out pbstrPropValue);
        }

        int IVsBuildPropertyStorage.RemoveProperty(string pszPropName, string pszConfigName, uint storage)
        {
            throw new NotImplementedException();
        }

        int IVsBuildPropertyStorage.SetItemAttribute(uint item, string pszAttributeName, string pszAttributeValue)
        {
            throw new NotImplementedException(); //todo
        }

        int IVsBuildPropertyStorage.SetPropertyValue(string pszPropName, string pszConfigName, uint storage, string pszPropValue)
        {
            throw new NotImplementedException();
        }

        #endregion

    }

}

