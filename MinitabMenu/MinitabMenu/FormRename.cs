using System.Windows.Forms;

namespace YAN_MinitabMenu
{
    internal partial class FormRename : Form
    {
        internal FormRename()
        {
            InitializeComponent();
        }

        internal FormRename(ref Mtb.Application pApp)
        {
            InitializeComponent();
            AddIn.gMtbApp = pApp;
        }
    }
}
