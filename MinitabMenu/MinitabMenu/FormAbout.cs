using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YAN_MinitabMenu {
    public partial class FormAbout : Form {
        internal FormAbout() {
            InitializeComponent();
        }

        internal FormAbout(ref Mtb.Application pApp) {
            InitializeComponent();
            AddIn.gMtbApp = pApp;
        }

        private void FormAbout_Load(object sender, EventArgs e) {
            try {
                foreach(string item in Enum.GetNames(typeof(Mtb.MtbOutputFileTypes))) {
                    cB_DefaultOutputFileType.Items.Add(item);
                }
                tB_AddInPath.Text = AddIn.gMtbApp.AddInPath;
                tB_AppPath.Text = AddIn.gMtbApp.AppPath;
                tB_Handle.Text = AddIn.gMtbApp.Handle.ToString();
                tB_LastError.Text = AddIn.gMtbApp.LastError;
                tB_Version.Text = AddIn.gMtbApp.Version.ToString();
                tB_Status.Text = AddIn.gMtbApp.Status.ToString();
                cB_DisplayAlerts.Checked = AddIn.gMtbApp.UserInterface.DisplayAlerts;
                cB_Interactive.Checked = AddIn.gMtbApp.UserInterface.Interactive;
                cB_UserControl.Checked = AddIn.gMtbApp.UserInterface.UserControl;
                cB_Visible.Checked = AddIn.gMtbApp.UserInterface.Visible;
                tB_ClientMissingValueDateTime.Text = AddIn.gMtbApp.Options.ClientMissingValueDateTime.ToString();
                tB_ClientMissingValueNumeric.Text = AddIn.gMtbApp.Options.ClientMissingValueNumeric.ToString();
                tB_DefaultFilePath.Text = AddIn.gMtbApp.Options.DefaultFilePath;
                cB_DefaultOutputFileType.SelectedItem = AddIn.gMtbApp.Options.DefaultOutputFileType.ToString();
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_OK_Click(object sender, EventArgs e) {
            try {
                AddIn.gMtbApp.UserInterface.DisplayAlerts = cB_DisplayAlerts.Checked;
                AddIn.gMtbApp.UserInterface.Interactive = cB_Interactive.Checked;
                AddIn.gMtbApp.UserInterface.UserControl = cB_UserControl.Checked;
                AddIn.gMtbApp.UserInterface.Visible = cB_Visible.Checked;
                AddIn.gMtbApp.Options.ClientMissingValueDateTime = Convert.ToDateTime(tB_ClientMissingValueDateTime.Text);
                AddIn.gMtbApp.Options.ClientMissingValueNumeric = Convert.ToDouble(tB_ClientMissingValueNumeric.Text);
                AddIn.gMtbApp.Options.DefaultFilePath = tB_DefaultFilePath.Text;
                AddIn.gMtbApp.Options.DefaultOutputFileType = (Mtb.MtbOutputFileTypes)Enum.Parse(typeof(Mtb.MtbOutputFileTypes), cB_DefaultOutputFileType.SelectedItem.ToString());                
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void FormAbout_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Escape) {
                bt_Cancel_Click(null,null);
            } else if(e.KeyCode == Keys.Enter) {
                bt_OK_Click(null, null);
            }
        }
    }
}
