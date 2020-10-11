using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using MinitabAddinTLB;
using Mtb;
using RGiesecke.DllExport;
using Application = Mtb.Application;

namespace YAN_MinitabMenu {
    [ComVisible(true)]
    //计算机\HKEY_USERS\S-1-5-21-45146399-3246480850-3154560146-1001\SOFTWARE\Minitab\Minitab19.1SimplifiedChinese\Addins\{ED8C3AEB-6980-7927-38C0-5C01AEA512F6}
    [Guid("DDBB881E-1C5F-DF0F-BEEC-0E707A4C241F")]//make sure each new menu dll has unique GUID!it will show in the upper register.    
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("YAN_MinitabMenu.AddIn")]//提供表示 Windows 注册表中的根项的 Microsoft.Win32.RegistryKey 对象，并提供访问项/值对的 static 方法。Should be same as your project name.
    public class AddIn : IMinitabAddin
    {
        #region system
        internal static Application gMtbApp;
        internal static int Flags = 0; //Set Flags to 1 for dynamic menus and 0 for static. 1 mainly used for debug. 0 for release.

        [DllExport("DllRegisterServer", CallingConvention.StdCall)]
        public static int DllRegisterServer()
        {
            try
            {
                SetUpCLSID(Registry.ClassesRoot);
                SetUpCLSID(Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // Probably didn't have permissions to modify the registry
            }

            return 0;
        }
        /// <summary>
        /// No need to change. used for register.
        /// </summary>
        /// <param name="root"></param>
        private static void SetUpCLSID(RegistryKey root)
        {
            Type type = typeof(AddIn);
            string guid = type.GUID.ToString("B");
            string runtimeVersion = Environment.Version.ToString();
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;

            RegistryKey typeRoot = root.CreateSubKey(type.FullName);
            typeRoot.SetValue("", type.FullName);
            typeRoot.CreateSubKey("CLSID").SetValue("", guid);

            RegistryKey clsidGuid = root.OpenSubKey("CLSID", true).CreateSubKey(guid);
            clsidGuid.SetValue("", type.FullName);

            clsidGuid.CreateSubKey("Implemented Categories").CreateSubKey("{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}");
            RegistryKey server = clsidGuid.CreateSubKey("InprocServer32");
            server.SetValue("", "mscoree.dll");
            server.SetValue("ThreadingModel", "Both");
            server.SetValue("Class", type.FullName);
            server.SetValue("Assembly", type.Assembly.FullName);
            server.SetValue("RuntimeVersion", runtimeVersion);
            server.SetValue("CodeBase", codeBase);

            RegistryKey serverVersion = server.CreateSubKey("1.0.0.3");
            serverVersion.SetValue("Class", type.FullName);
            serverVersion.SetValue("Assembly", type.Assembly.FullName);
            serverVersion.SetValue("RuntimeVersion", runtimeVersion);
            serverVersion.SetValue("CodeBase", codeBase);

            clsidGuid.CreateSubKey("ProdId").SetValue("", type.FullName);
        }

        public void OnConnect(IntPtr iHwnd, object pApp, ref int iFlags)
        {
            // This method is called as Minitab is initializing your add-in.
            // The “iHwnd” parameter is the handle to the main Minitab window.
            // The “pApp” parameter is a reference to the “Minitab Automation object.”
            // You can hold onto either of these for use in your add-in.
            // “iFlags” is used to tell Minitab if your add-in has dynamic menus (i.e. should be reloaded each time
            // Minitab starts up).  Set Flags to 1 for dynamic menus and 0 for static.
            //MessageBox.Show("start OnConnect!");
            gMtbApp = pApp as Application;
            iFlags = Flags;
            return;
        }

        public void OnDisconnect()
        {
            // This method is called as Minitab is closing your add-in.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            try
            {
                Marshal.ReleaseComObject(gMtbApp);
                gMtbApp = null;
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            return;
        }

        public string GetName()
        {
            // This method returns the friendly name of your add-in:
            // Both the name and the description of the add-in are stored in the registry.
            return "Example C♯ Minitab Add-In!";
        }

        public string GetDescription()
        {
            // This method returns the description of your add-in:
            return "An example Minitab add-in written in C♯ using the “Minitab Menu” functionality. Updated by YAN";
        }
        #endregion
        #region Menuitems
        private const string Menuitems_cgk_Description = "C&gk"; private const int Menuitems_cgk_id = 0;
        private const string Menuitems_grr_Description = "Gauge &R and R (Cross)"; private const int Menuitems_grr_id = 1;
        private const string Menuitems_splitter1_Description = "|"; private const int Menuitems_splitter1_id = 2;
        private const string Menuitems_cpk_Description = "C&pk"; private const int Menuitems_cpk_id = 3;
        private const string Menuitems_splitter2_Description = "|"; private const int Menuitems_splitter2_id = 4;
        private const string Menuitems_about_Description = "&About Minitab"; private const int Menuitems_about_id = 5;
        private int totalSubMenuItems = 6;
        public void GetMenuItems(ref string sMainMenu, ref Array saMenuItems, ref int iFlags)
        {
            // This method returns the text for the main menu and each menu item.
            // You can return "|" to create a menu separator in your menu items.
            sMainMenu = "&Six Sigma (S)";  // This string is the name of the menu.

            saMenuItems = new string[totalSubMenuItems];  // The strings in this array are the names of the items on the aforementioned menu.
            
            saMenuItems.SetValue(Menuitems_cgk_Description, Menuitems_cgk_id);
            saMenuItems.SetValue(Menuitems_grr_Description, Menuitems_grr_id);
            saMenuItems.SetValue(Menuitems_splitter1_Description, Menuitems_splitter1_id);
            saMenuItems.SetValue(Menuitems_cpk_Description, Menuitems_cpk_id);
            saMenuItems.SetValue(Menuitems_splitter2_Description, Menuitems_splitter2_id);
            saMenuItems.SetValue(Menuitems_about_Description, Menuitems_about_id);

            iFlags = Flags;

            return;
        }

        public string OnDispatchCommand(int iMenu)
        {
            // This method is called whenever a user selects one of your menu items.
            // The iMenu variable should be equivalent to the menu item index set in “GetMenuItems.”
            string command = string.Empty;
            DialogResult dialogResult;
            switch (iMenu)
            {
                case Menuitems_cgk_id: 
                    break;
                case Menuitems_grr_id:                    
                    break;
                case Menuitems_splitter1_id:
                    break;
                case Menuitems_cpk_id:                   
                    break;
                case Menuitems_splitter2_id:                   
                    break;
                case Menuitems_about_id:
                    FormAbout formAbout = new FormAbout(ref gMtbApp);
                    // Show the dialog:
                    formAbout.ShowDialog();
                    break;
                default:
                    break;
            }
            return command;
        }
        #endregion
        #region notused
        public void OnNotify(AddinNotifyType eAddinNotifyType)
        {
            // This method is called when Minitab notifies your add-in that something has changed.
            // Use the “eAddinNotifyType” parameter to figure out what changed.
            // Minitab currently fires no events, so this method is not called.
            return;
        }
        #endregion
        #region CustomCommand
        public bool QueryCustomCommand(string sCommand)
        {
            // This method is called when Minitab asks your Addin if it supports a custom command.
            // The argument “sCommand” is the name of the custom command.  Return “true” if you support the command.
            return sCommand.ToUpper() == "EXPLORER" || sCommand.ToUpper() == "CLEAR";
        }

        public void ExecuteCustomCommand(string sCommand, ref Array saArgs)
        {
            // This method is called when Minitab asks your add-in to execute a custom command.
            // The argument “sCommand” is the name of the command, and “saArgs” is an array of arguments.
            if (sCommand.ToUpper() == "EXPLORER")
            {
                // Open Windows Explorer:
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo {
                    UseShellExecute = true,
                    FileName = "explorer.exe"
                };
                process.StartInfo = processStartInfo;
                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "My Menu");
                    MessageBox.Show("Apparently, Windows Explorer could not be started…", "My Menu");
                }
            }
            else if (sCommand.ToUpper() == "CLEAR")
            {
                // Clear indicated columns:
                int lColumnCount = gMtbApp.ActiveProject.ActiveWorksheet.Columns.Count;
                //int saArgsCardinality = saArgs.GetLength(saArgs.Rank - 1);
                IEnumerator myEnumerator = saArgs.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    for (int i = 1; i <= lColumnCount; i++)
                    {
                        int.TryParse(myEnumerator.Current.ToString(), out int myEnumeratorCurrent);
                        if (gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).Number == myEnumeratorCurrent)
                        {
                            gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).Clear();
                        }
                    }
                }
            }
        }
        #endregion
    }
}

