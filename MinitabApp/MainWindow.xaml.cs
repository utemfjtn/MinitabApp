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
            binding.ExcelFilePath = @"D:\Repos\MinitabApp\MinitabApp\Resources\Cpk_CgkTemplate.mpx";
            binding.ExportFilePath = @"D:\Repos\MinitabApp\MinitabApp\bin\x86\Debug\Report\";
            binding.GRR_SN = 1;
            binding.GRR_OP = 2;
            binding.GRR_DataStart = 3;
            binding.GRR_DataEnd = 5;
            binding.Cgkenable = true;
            binding.CpkCgk_DataStart = 3;
            binding.CpkCgk_DataEnd = 5;
            DataContext = binding;
        }

        private void Button_StartCpkCgk_Click(object sender, RoutedEventArgs e) {
            binding.Logs = "";
            if (!clsMtbHelper.ProjectOpened) Button_OpenProject_Click(null, null);
            for (int i = (int)binding.CpkCgk_DataStart; i < binding.CpkCgk_DataEnd + 1; i++) {
                double lsl = clsMtbHelper.GetData(1, i - 2); //Must get from column 1;
                double usl = clsMtbHelper.GetData(2, i - 2);//Must get from column 2;
                if (binding.Cgkenable) {
                    binding.Logs += clsMtbHelper.ExecCgkAnalysis("C" + i, lsl, usl);
                } else {
                    binding.Logs += clsMtbHelper.ExecCapabilityAnalysis("C" + i, lsl, usl);
                }
            }
            if (System.IO.Directory.Exists(binding.ExportFilePath)) {
                System.IO.Directory.CreateDirectory(binding.ExportFilePath);
            }
            binding.Logs += clsMtbHelper.Generate_OutputReport(binding.ExportFilePath + DateTime.Now.ToFileTime());
            binding.Logs += "StartCpkCgk Finished";
        }
        private void Button_StartGRR_Click(object sender, RoutedEventArgs e) {
            binding.Logs = "";
            if (!clsMtbHelper.ProjectOpened) Button_OpenProject_Click(null, null);
            for (int i = (int)binding.GRR_DataStart; i < binding.GRR_DataEnd + 1; i++) {
                binding.Logs += clsMtbHelper.ExecGRRAnalysis("C" + binding.GRR_SN, "C" + binding.GRR_OP, "C" + i);
            }
            if (System.IO.Directory.Exists(binding.ExportFilePath)) {
                System.IO.Directory.CreateDirectory(binding.ExportFilePath);
            }
            binding.Logs += clsMtbHelper.Generate_OutputReport(binding.ExportFilePath + DateTime.Now.ToFileTime());
            binding.Logs += "StartGRR Finished";
        }
        private void Button_OpenProject_Click(object sender, RoutedEventArgs e) {
            binding.Logs = "";
            binding.Logs = clsMtbHelper.OpenProject(binding.ExcelFilePath);
            binding.Logs += "OpenProject Finished";
        }
    }
}
