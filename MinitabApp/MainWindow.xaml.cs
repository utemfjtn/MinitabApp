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
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //SampleRun();
            ClsMtbHelper clsMtbHelper = new ClsMtbHelper(true);
            clsMtbHelper.CreateColumn("Test", new double[] { 22, 123, 45, 76 });
            clsMtbHelper.ExecCapabilityAnalysis("Test", 2, 5);
        }
        private void SampleRun() {
            Mtb.Application application = new Mtb.Application();
            Mtb.Project project = application.ActiveProject;
            Mtb.Worksheet worksheet = project.ActiveWorksheet;
            Mtb.Columns columns = worksheet.Columns;
            Mtb.Column column;
            Mtb.Command command;

            double[] arraryData = new double[] { 25, 12, 53, 25 };

            application.UserInterface.Visible = true;
            columns.Add(null, null, 2).Name = "Sales";
            column = columns.Item(1);
            column.SetData(arraryData);

            project.ExecuteCommand("Capa 'Sales' 1;Lspec 2;Uspec 5;Pooled;AMR;UnBiased;OBiased;Toler 6;Within;Overall;NoCI;PPM;CStat.");

            command = project.Commands.Item(1);            
        }
    }
}
