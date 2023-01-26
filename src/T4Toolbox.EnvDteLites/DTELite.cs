using EnvDTE;
using EnvDTE80;
using System;

namespace T4Toolbox.EnvDteLites
{
    public class DTELite : DTE2, DTE
    {
        private Solution _solution;
      
        public DTELite()
        {
            //if (dte == null) { throw new ArgumentNullException("dte"); }
            //this._dte = dte;
            this._solution = new SolutionLite(this);
        }

        public Document ActiveDocument
        {
            get { throw new NotImplementedException("ActiveDocument"); }
        }

        public object ActiveSolutionProjects
        {
            get { throw new NotImplementedException("ActiveSolutionProjects"); }
        }

        public Window ActiveWindow
        {
            get { throw new NotImplementedException("ActiveWindow"); }
        }

        public AddIns AddIns
        {
            get { throw new NotImplementedException("AddIns"); }
        }

        public DTE Application
        {
            get { throw new NotImplementedException("Application"); }
        }

        public object CommandBars
        {
            get { throw new NotImplementedException("CommandBars"); }
        }

        public string CommandLineArguments
        {
            get { throw new NotImplementedException("CommandLineArguments"); }
        }

        public Commands Commands
        {
            get { throw new NotImplementedException("Commands"); }
        }

        public ContextAttributes ContextAttributes
        {
            get { throw new NotImplementedException("ContextAttributes"); }
        }

        public DTE DTE
        {
            get { throw new NotImplementedException("DTE"); }
        }

        public Debugger Debugger
        {
            get { throw new NotImplementedException("Debugger"); }
        }

        public vsDisplay DisplayMode
        {
            get
            {
                throw new NotImplementedException("DisplayMode");
            }
            set
            {
                throw new NotImplementedException("set DisplayMode");
            }
        }

        public Documents Documents
        {
            get { throw new NotImplementedException("Documents"); }
        }

        public string Edition
        {
            get { throw new NotImplementedException("Edition"); }
        }

        public Events Events
        {
            get { throw new NotImplementedException("Events"); }
        }

        public void ExecuteCommand(string CommandName, string CommandArgs = "")
        {
            throw new NotImplementedException("ExecuteCommand");
        }

        public string FileName
        {
            get { throw new NotImplementedException("FileName"); }
        }

        public Find Find
        {
            get { throw new NotImplementedException("Find"); }
        }

        public string FullName
        {
            get { throw new NotImplementedException("FullName"); }
        }

        public object GetObject(string Name)
        {
            throw new NotImplementedException("GetObject");
        }

        //public uint GetThemeColor(vsThemeColors Element)
        //{
        //    throw new NotImplementedException("GetThemeColor");
        //}

        public Globals Globals
        {
            get { throw new NotImplementedException("Globals"); }
        }

        public ItemOperations ItemOperations
        {
            get { throw new NotImplementedException("ItemOperations"); }
        }

        //public wizardResult LaunchWizard(string VSZFile, ref object[] ContextParams)
        //{
        //    throw new NotImplementedException("LaunchWizard");
        //}

        public int LocaleID
        {
            get { throw new NotImplementedException("LocaleID"); }
        }

        public Macros Macros
        {
            get { throw new NotImplementedException("Macros"); }
        }

        public DTE MacrosIDE
        {
            get { throw new NotImplementedException("MacrosIDE"); }
        }

        public Window MainWindow
        {
            get { throw new NotImplementedException("MainWindow"); }
        }

        public vsIDEMode Mode
        {
            get { throw new NotImplementedException("Mode"); }
        }

        public string Name
        {
            get { throw new NotImplementedException("Name"); }
        }

        public ObjectExtenders ObjectExtenders
        {
            get { throw new NotImplementedException("ObjectExtenders"); }
        }

        public Window OpenFile(string ViewKind, string FileName)
        {
            throw new NotImplementedException("OpenFile");
        }

        public void Quit()
        {
            throw new NotImplementedException("Quit");
        }

        public string RegistryRoot
        {
            get { throw new NotImplementedException("RegistryRoot"); }
        }

        public string SatelliteDllPath(string Path, string Name)
        {
            throw new NotImplementedException("SatelliteDllPath");
        }

        //public SelectedItems SelectedItems
        //{
        //    get { throw new NotImplementedException("SelectedItems"); }
        //}

        public Solution Solution
        {
            //get { throw new NotImplementedException("Solution"); }
            get
            {
                return this._solution;
            }
        }

        //public SourceControl SourceControl
        //{
        //    get { throw new NotImplementedException("SourceControl"); }
        //}

        //public StatusBar StatusBar
        //{
        //    get { throw new NotImplementedException("StatusBar "); }
        //}

        public bool SuppressUI
        {
            get
            {
                throw new NotImplementedException("SuppressUI");
            }
            set
            {
                throw new NotImplementedException("set SuppressUI");
            }
        }

        //public ToolWindows ToolWindows
        //{
        //    get { throw new NotImplementedException("ToolWindows"); }
        //}

        //public UndoContext UndoContext
        //{
        //    get { throw new NotImplementedException("UndoContext"); }
        //}

        public bool UserControl
        {
            get
            {
                throw new NotImplementedException("UserControl");
            }
            set
            {
                throw new NotImplementedException("set UserControl");
            }
        }

        public string Version
        {
            get { throw new NotImplementedException("Version"); }
        }

        //public WindowConfigurations WindowConfigurations
        //{
        //    get { throw new NotImplementedException("WindowConfigurations"); }
        //}

        //public Windows Windows
        //{
        //    get { throw new NotImplementedException("Windows"); }
        //}

        public bool get_IsOpenFile(string ViewKind, string FileName)
        {
            throw new NotImplementedException("get_IsOpenFile");
        }

        public EnvDTE.Properties get_Properties(string Category, string Page)
        {
            throw new NotImplementedException("get_Properties");
        }
    }
}
