using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ControlMedicoWinForms.Reportes
{
    public partial class WebViewer : Form
    {
        //Stream file;
        string url;
        public WebViewer(string u)
        {
            url = u;
            //file = f;
            InitializeComponent();
        }

        private void WebViewer_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(url);
            //using (StreamReader sr = new StreamReader(file))

            //{

            //    using (Stream s = sr.BaseStream)

            //    {

            //        webBrowser1.DocumentStream = s;

            //        //ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("hello");

            //        Application.DoEvents();

            //    }
            //}
                //webBrowser1.DocumentStream = file;
        }
    }
}
