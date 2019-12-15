using Mtb;

namespace MinitabApp {
    /// <summary>
    /// TODO, Add Output, picture and data.
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
            mtbProject = mtbApp.ActiveProject;
            mtbWorkSheet = mtbProject.ActiveWorksheet;
            mtbColumns = mtbWorkSheet.Columns;
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
        public string ExecCapabilityAnalysis(string columnName,double lspec,double uspec) {
            try {
                mtbProject.ExecuteCommand("Capa '" + columnName +"' 1;Lspec " + lspec.ToString() + ";Uspec " + uspec.ToString() + ";Pooled;AMR;UnBiased;OBiased;Toler 6;Within;Overall;NoCI;PPM;CStat.");
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        public string ExecCgkAnalysis(string columnName, double lspec, double uspec) {
            try {
                //mtbProject.ExecuteCommand("Capa '" + columnName + "' 1;Lspec " + lspec.ToString() + ";Uspec " + uspec.ToString() + ";Pooled;AMR;UnBiased;OBiased;Toler 6;Within;Overall;NoCI;PPM;CStat.");
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
        public string ExecGRRAnalysis(string columnName, double lspec, double uspec) {
            try {
                //mtbProject.ExecuteCommand("Capa '" + columnName + "' 1;Lspec " + lspec.ToString() + ";Uspec " + uspec.ToString() + ";Pooled;AMR;UnBiased;OBiased;Toler 6;Within;Overall;NoCI;PPM;CStat.");
                return string.Empty;
            } catch (System.Exception ex) {
                return ex.ToString();
            }
        }
    }
}
