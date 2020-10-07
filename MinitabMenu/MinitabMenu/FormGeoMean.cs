using System.Windows.Forms;

namespace MinitabMenu
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
