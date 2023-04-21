using Mtb;
using Application = Mtb.Application;

namespace MinitabApp {
    /// <summary>
    /// 
    /// </summary>
    public class ClsMtbHelper {

        private Application mtbApp;
        private Project mtbProject;
        private Worksheet mtbWorkSheet;
        private Columns mtbColumns;

        /// <summary>
        /// Used for Single Project,WorkSheet.
        /// </summary>
        /// <param name="visible"></param>
        public ClsMtbHelper(bool visible = false) {
            mtbApp = new Application();
            mtbApp.UserInterface.Visible = visible;
            EnableProjects();
        }
        ~ClsMtbHelper() {
            Quit();
        }
        private void EnableProjects() {
            mtbProject = mtbApp.ActiveProject;
            mtbWorkSheet = mtbProject.ActiveWorksheet;
            mtbColumns = mtbWorkSheet.Columns;
        }
        public string OpenProject(string filepath) {
            try {
                mtbApp.Open(filepath);
                EnableProjects();
                return "Load Succes：" + filepath;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        public void Quit() {
            try {
                if (mtbApp != null) {
                    mtbApp.Quit();
                }
            } catch (System.Exception) {
            } finally {
                mtbApp = null;
            }
        }
        public string CreateColumn(string columnName, double[] data) {
            try {
                mtbColumns.Add();
                Column column = mtbColumns.Item(mtbColumns.Count);
                column.Name = columnName;
                column.SetData(data);
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        public double GetData(int columnNo, int rowNo) {
            try {
                Column column = mtbColumns.Item(columnNo);
                double data = column.GetData(rowNo, 1);
                return data;
            } catch (System.Exception ex) {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">C1,C2,C3,C4 or Customize Header inside minitab like:Data1</param>
        /// <param name="lspec"></param>
        /// <param name="uspec"></param>
        /// <param name="subSize"></param>
        /// <returns></returns>
        public string ExecCapabilityAnalysis(string columnName, double lspec, double uspec, double subSize = 1) {
            try {
                mtbProject.ExecuteCommand("Capa '" + columnName + "' " + subSize.ToString() + ";Lspec " + lspec.ToString() + ";Uspec " + uspec.ToString() + ";Pooled;AMR;UnBiased;OBiased;Toler 6;Within;Overall;NoCI;PPM;CStat.");
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName">C1,C2,C3,C4 or Customize Header inside minitab like:Data1</param>
        /// <param name="reference"></param>
        /// <param name="tolerance"></param>
        /// <param name="cgConstant"></param>
        /// <param name="studyVar"></param>
        /// <returns></returns>
        public string ExecCgkAnalysis(string columnName, double reference, double tolerance, double cgConstant = 20.0, double studyVar = 6) {
            try {
                mtbProject.ExecuteCommand("TOGage '" + columnName + "' ;Reference " + reference.ToString() + ";Tolerance " + tolerance.ToString() + ";CgConstant " + cgConstant.ToString() + ";Studyvar " + tolerance.ToString());
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnNameParts">C1,C2,C3,C4 or Customize Header inside minitab like:SN</param>
        /// <param name="columnNameOpers">C1,C2,C3,C4 or Customize Header inside minitab like:OP</param>
        /// <param name="columnNameData">C1,C2,C3,C4 or Customize Header inside minitab like:Data1</param>
        /// <param name="studyvar"></param>
        /// <returns></returns>
        public string ExecGRRAnalysis(string columnNameParts, string columnNameOpers, string columnNameData, double studyvar = 6) {
            try {
                mtbProject.ExecuteCommand("GageRR; Parts '" + columnNameParts + "';Opers '" + columnNameOpers + "';Response '" + columnNameData + "';Studyvar " + studyvar.ToString() + ".");
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">without file extension,extension always : html</param>
        /// <returns></returns>
        public string Generate_OutputReport(string fileName) {
            try {
                //Mtb.Command mtbCmnd;
                //Mtb.Output mtbOutObj;
                ////Loop through outputs from commands, identify type of each, and display message
                //for (int i = 1; i <= mtbProject.Commands.Count; i++) {
                //    mtbCmnd = mtbProject.Commands.Item(i);
                //    for (int j = 1; j <= mtbCmnd.Outputs.Count; j++) {
                //        mtbOutObj = mtbCmnd.Outputs.Item(j);
                //        int caseSwitch = mtbOutObj.OutputType.GetHashCode();                    
                //        Console.WriteLine("Command #" + i + ", " + "Output #" + j + " is OutputType " + caseSwitch.ToString() + mtbOutObj.Text);
                //        switch (caseSwitch) {
                //            case 0: //Graph
                //            case 1: //Table
                //                break;
                //            case 3: //Title
                //            case 4: //Message
                //            case 6: //Formula
                //                break;
                //        }
                //    }
                //}

                //Save OutputDocument as an HTM file named mtb_out.htm
                mtbProject.Commands.OutputDocument.SaveAs(fileName, true);
            } catch (System.Exception ex) {
                return ex.ToString();
            }
            return string.Empty;
        }
    }
}
