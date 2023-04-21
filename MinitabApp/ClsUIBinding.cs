using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinitabApp {
    public class ClsUIBinding : INotifyPropertyChanged {
        private string logsField;
        public string Logs {
            get {
                return logsField;
            }
            set {
                logsField = value;
                OnPropertyChanged();
            }
        }
        private string excelFilePathField;
        public string ExcelFilePath {
            get {
                return excelFilePathField;
            }
            set {
                excelFilePathField = value;
                OnPropertyChanged();
            }
        }
        private string exportFilePathField;
        public string ExportFilePath {
            get {
                return exportFilePathField;
            }
            set {
                exportFilePathField = value;
                OnPropertyChanged();
            }
        }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyname = null) {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            } catch (Exception ex) {
                //log4net.LogManager.GetLogger(GetType()).Error("Error", ex);
            }
        }
    }
}
