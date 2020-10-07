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

namespace MinitabMenu
{
    [ComVisible(true)]
    [Guid("ED8C3AEB-6980-7927-38C0-5C01AEA512F6")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MinitabMenu.AddIn")]
    public class AddIn : IMinitabAddin
    {
        internal static Application gMtbApp;

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

            RegistryKey serverVersion = server.CreateSubKey("1.0.0.0");
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
            gMtbApp = pApp as Application;
            // Static menus:
            iFlags = 0;
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
            return "Example C♯ Minitab Add-In";
        }

        public string GetDescription()
        {
            // This method returns the description of your add-in:
            return "An example Minitab add-in written in C♯ using the “My Menu” functionality.";
        }

        public void GetMenuItems(ref string sMainMenu, ref Array saMenuItems, ref int iFlags)
        {
            // This method returns the text for the main menu and each menu item.
            // You can return "|" to create a menu separator in your menu items.
            sMainMenu = "&Release (R)";  // This string is the name of the menu.

            saMenuItems = new string[7];  // The strings in this array are the names of the items on the aforementioned menu.

            saMenuItems.SetValue("Describe &column(s)…", 0);
            saMenuItems.SetValue("Rename active &worksheet…", 1);
            saMenuItems.SetValue("|", 2);
            saMenuItems.SetValue("&DOS window", 3);
            saMenuItems.SetValue("&Geometric Mean and Mean Absolute Difference…", 4);
            saMenuItems.SetValue("|", 5);
            saMenuItems.SetValue("&NotePad+", 6);

            // Flags is not currently used:
            iFlags = 0;

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
                case 0:
                    // Describe column(s):
                    FormDescribe formDescribe = new FormDescribe(ref gMtbApp);
                    // Fill up list box in dialog with numeric columns in worksheet:
                    formDescribe.checkedListBoxOfColumns.ClearSelected();
                    int lColumnCount = gMtbApp.ActiveProject.ActiveWorksheet.Columns.Count;
                    for (int i = 1; i <= lColumnCount; i += 1)
                    {
                        // Select only the numeric columns:
                        if (gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).DataType == MtbDataTypes.Numeric)
                        {
                            formDescribe.checkedListBoxOfColumns.Items.Add(gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).SynthesizedName);
                        }
                    }
                    // Show the dialog:
                    dialogResult = formDescribe.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        StringBuilder cmnd = new StringBuilder("Describe ");

                        bool bPrev = false;
                        for (int i = 0; i < formDescribe.checkedListBoxOfColumns.CheckedItems.Count; i += 1)
                        {
                            if (bPrev)
                            {
                                cmnd.Append(" ");
                            }
                            cmnd.Append(formDescribe.checkedListBoxOfColumns.CheckedItems[i].ToString());
                            bPrev = true;
                        }
                        if (formDescribe.chkMean.Checked)
                        {
                            cmnd.Append("; Mean");
                        }
                        if (formDescribe.chkVariance.Checked)
                        {
                            cmnd.Append("; Variance");
                        }
                        if (formDescribe.chkSum.Checked)
                        {
                            cmnd.Append("; Sums");
                        }
                        if (formDescribe.chkNnonmissing.Checked)
                        {
                            cmnd.Append("; N");
                        }
                        if (formDescribe.chkHistogram.Checked)
                        {
                            cmnd.Append("; GHist");
                        }
                        if (formDescribe.chkBoxplot.Checked)
                        {
                            cmnd.Append("; GBoxplot");
                        }
                        cmnd.Append(".");
                        command = cmnd.ToString();
                    }
                    formDescribe.Close();
                    break;
                case 1:
                    // Rename active worksheet:
                    FormRename formRename = new FormRename(ref gMtbApp);
                    string sCurrent = gMtbApp.ActiveProject.ActiveWorksheet.Name;
                    formRename.textBoxCurrent.Enabled = true;
                    formRename.textBoxCurrent.Text = sCurrent;
                    formRename.textBoxCurrent.Enabled = false;
                    // Show the dialog:
                    dialogResult = formRename.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        gMtbApp.ActiveProject.ActiveWorksheet.Name = formRename.textBoxNew.Text;
                    }
                    formRename.Close();
                    break;
                case 2:
                    break;
                case 3:
                    // Open a DOS Window:
                    MessageBox.Show("Test!");
                    string[] fileNamePossibilities = { "cmd.exe", "command.com" };
                    Process process;
                    ProcessStartInfo processStartInfo;
                    foreach (string fileNamePossibility in fileNamePossibilities)
                    {
                        process = new Process();
                        processStartInfo = new ProcessStartInfo {
                            UseShellExecute = true,
                            FileName = fileNamePossibility
                        };
                        process.StartInfo = processStartInfo;
                        try
                        {
                            process.Start();
                            break;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "My Menu");
                            MessageBox.Show("Cannot locate DOS executable or otherwise start a command prompt…", "My Menu");
                            continue;
                        }
                    }
                    break;
                case 4:
                    // “Geometric Mean” and “Mean Absolute Difference” (stored in the worksheet):
                    FormGeoMean formGeoMean = new FormGeoMean(ref gMtbApp);
                    // Fill up list box in dialog with numeric columns in worksheet:
                    lColumnCount = gMtbApp.ActiveProject.ActiveWorksheet.Columns.Count;
                    Hashtable hashtableOfNumericColumns = new Hashtable();
                    for (int i = 1; i <= lColumnCount; i += 1)
                    {
                        if (gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).DataType == MtbDataTypes.Numeric)
                        {
                            string sSynthesizedColumnName = gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).SynthesizedName;
                            string sColumnName = gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i).Name;
                            // Add column name (if it exists):
                            if (sColumnName != sSynthesizedColumnName)
                            {
                                sSynthesizedColumnName += string.Concat("  ", sColumnName);
                            }
                            formGeoMean.comboBox.Items.Add(sSynthesizedColumnName);
                            hashtableOfNumericColumns.Add(sSynthesizedColumnName, gMtbApp.ActiveProject.ActiveWorksheet.Columns.Item(i));
                        }
                    }
                    // Show the dialog:
                    dialogResult = formGeoMean.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        // Get data from the column and pass it to the function to do calculations:
                        object selectedItem = formGeoMean.comboBox.SelectedItem;
                        Column mtbDataColumn = (Column)hashtableOfNumericColumns[selectedItem];
                        // “FindGeoMean” takes an array of doubles and returns the geometric mean.
                        // “bSuccess” indicates if the calculations were completed.
                        Array daData = (Array)mtbDataColumn.GetData();
                        object dGeoMean = FindGeoMean(ref daData, out bool bSuccess);
                        if (bSuccess)
                        {
                            // Find the “Mean Absolute Difference”:
                            object dMAD = FindMAD(ref daData);
                            // Store both values in the first available column:
                            Column mtbStorageColumn = gMtbApp.ActiveProject.ActiveWorksheet.Columns.Add();
                            mtbStorageColumn.SetData(ref dGeoMean, 1, 1);
                            mtbStorageColumn.SetData(ref dMAD, 2, 1);
                            mtbStorageColumn.Name = "MyResults";
                        }
                        else
                        {
                            // An error occurred:
                            gMtbApp.ActiveProject.ExecuteCommand("NOTE ** Error ** Cannot compute statistics…");
                        }
                        formGeoMean.Close();
                    }
                    break;
                case 5:
                    break;
                case 6:
                    // Open a NotePad+
                    string[] NotePadNamePossibilities = { @"C:\Program Files\Notepad++\notepad++.exe"};
                    foreach(string fileNamePossibility in NotePadNamePossibilities) {
                        process = new Process();
                        processStartInfo = new ProcessStartInfo {
                            UseShellExecute = true,
                            FileName = fileNamePossibility
                        };
                        process.StartInfo = processStartInfo;
                        try {
                            process.Start();
                            break;
                        } catch(Exception e) {
                            MessageBox.Show(e.Message, "My Menu");
                            MessageBox.Show("Cannot locate DOS executable or otherwise start a command prompt…", "My Menu");
                            continue;
                        }
                    }
                    break;
                default:
                    break;
            }
            return command;
        }

        public void OnNotify(AddinNotifyType eAddinNotifyType)
        {
            // This method is called when Minitab notifies your add-in that something has changed.
            // Use the “eAddinNotifyType” parameter to figure out what changed.
            // Minitab currently fires no events, so this method is not called.
            return;
        }

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

        public double FindGeoMean(ref Array saData, out bool bSuccess)
        {
            // Find geometric mean:
            double dSum = 0.0;
            int iCount = 0;
            bSuccess = true;
            foreach (double dValue in saData)
            {
                if (dValue <= 0)
                {
                    bSuccess = false;
                    MessageBox.Show("All values must be strictly positive!", "My Menu");
                    break;
                }
                dSum += Math.Log(dValue);
                iCount += 1;
            }

            return Math.Exp(dSum / iCount);
        }

        public double FindMAD(ref Array daData)
        {
            // Find M(ean) A(bsolute) D(ifference):
            double dSum = 0.0;
            int iCount = 0;

            foreach (double dValue in daData)
            {
                dSum += dValue;
                iCount += 1;
            }

            double dMAD = 0.0;
            double dMean = dSum / iCount;

            foreach (double dValue in daData)
            {
                dMAD += Math.Abs(dValue - dMean);
            }

            dMAD /= iCount;

            return dMAD;
        }
    }
}

