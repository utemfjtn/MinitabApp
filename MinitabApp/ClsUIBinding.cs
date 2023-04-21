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


        private bool cgkenableField;
        public bool Cgkenable {
            get {
                return cgkenableField;
            }
            set {
                cgkenableField = value;
                OnPropertyChanged();
            }
        }
        private uint cpkCgk_DataStartField;
        public uint CpkCgk_DataStart {
            get {
                return cpkCgk_DataStartField;
            }
            set {
                cpkCgk_DataStartField = value;
                OnPropertyChanged();
            }
        }
        private uint cpkCgk_DataEndField;
        public uint CpkCgk_DataEnd {
            get {
                return cpkCgk_DataEndField;
            }
            set {
                cpkCgk_DataEndField = value;
                OnPropertyChanged();
            }
        }

        private uint gRR_OPField;
        public uint GRR_OP {
            get {
                return gRR_OPField;
            }
            set {
                gRR_OPField = value;
                OnPropertyChanged();
            }
        }
        private uint gRR_SNField;
        public uint GRR_SN {
            get {
                return gRR_SNField;
            }
            set {
                gRR_SNField = value;
                OnPropertyChanged();
            }
        }
        private uint gRR_DataStartField;
        public uint GRR_DataStart {
            get {
                return gRR_DataStartField;
            }
            set {
                gRR_DataStartField = value;
                OnPropertyChanged();
            }
        }
        private uint gRR_DataEndField;
        public uint GRR_DataEnd {
            get {
                return gRR_DataEndField;
            }
            set {
                gRR_DataEndField = value;
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
