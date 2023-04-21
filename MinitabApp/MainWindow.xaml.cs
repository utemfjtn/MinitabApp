using System;
using System.Windows;

namespace MinitabApp {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        /// <summary>
        /// Use WPF is expect to use load data or load project files.
        /// Add Some UI interactions.
        /// </summary>
        public MainWindow() {
            InitializeComponent();
        }

        private ClsMtbHelper clsMtbHelper;
        private ClsUIBinding binding;
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //SampleRun();
            clsMtbHelper = new ClsMtbHelper(true);
            binding = new ClsUIBinding();
            binding.Logs = "Start Program";
            binding.ExcelFilePath = @"D:\Repos\MinitabApp\MinitabApp\Resources\Test.mpx";
            binding.ExportFilePath = @"D:\Repos\MinitabApp\MinitabApp\bin\x86\Debug\Report\";
            DataContext = binding;
        }
        //private void SampleRun() {
        //    Mtb.Application application = new Mtb.Application();
        //    Mtb.Project project = application.ActiveProject;
        //    Mtb.Worksheet worksheet = project.ActiveWorksheet;
        //    Mtb.Columns columns = worksheet.Columns;
        //    Mtb.Column column;
        //    Mtb.Command command;

        //    double[] arraryData = new double[] { 25, 12, 53, 25 };

        //    application.UserInterface.Visible = true;
        //    columns.Add(null, null, 2).Name = "Sales";
        //    column = columns.Item(1);
        //    column.SetData(arraryData);

        //    project.ExecuteCommand("Capa 'Sales' 1;Lspec 2;Uspec 5;Pooled;AMR;UnBiased;OBiased;Toler 6;Within;Overall;NoCI;PPM;CStat.");

        //    command = project.Commands.Item(1);            
        //}

        private void Button_OpenExcel_Click(object sender, RoutedEventArgs e) {
            binding.Logs = "";
            binding.Logs = clsMtbHelper.OpenProject(binding.ExcelFilePath);
            binding.Logs += clsMtbHelper.ExecCapabilityAnalysis("EC7_1", 350, 450);
            binding.Logs += clsMtbHelper.ExecCgkAnalysis("EC7_1", 420, 50);
            binding.Logs += clsMtbHelper.ExecGRRAnalysis("SN_1", "Operator", "EC7_1");
            binding.Logs += clsMtbHelper.Generate_OutputReport(binding.ExportFilePath + DateTime.Today.ToFileTime());
        }
    }
}
