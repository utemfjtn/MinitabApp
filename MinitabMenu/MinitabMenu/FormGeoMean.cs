using System.Windows.Forms;

namespace YAN_MinitabMenu
{
    internal partial class FormGeoMean : Form
    {
        internal FormGeoMean()
        {
            InitializeComponent();
        }

        internal FormGeoMean(ref Mtb.Application pApp)
        {
            InitializeComponent();
            AddIn.gMtbApp = pApp;
        }
    }
}
