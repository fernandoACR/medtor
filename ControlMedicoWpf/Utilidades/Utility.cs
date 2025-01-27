using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;

namespace ControlMedicoWpf.Utilidades
{
    public class Utility
    {
        public static ProgressBar _progressForm;
        public class LongJob
        {
            public event Progressed OnProgress;
            public delegate void Progressed(int percent);

            public void Spin(IProgress<int> progress)
            {
                for (var i = 1; i <= 100; i++)
                {
                    Thread.Sleep(20);
                    if (progress != null)
                    {
                        progress.Report(i);
                    }
                }
            }
        }

        public class Win32Window : IWin32Window
        {
            private readonly IntPtr _hwnd;
            public Win32Window(IntPtr handle)
            {
                _hwnd = handle;
            }
            public IntPtr Handle
            {
                get
                {
                    return _hwnd;
                }
            }
        }

        //public void GoAsync() //no longer async as it blocks on Appication.Run
        //{
        //    var owner = new Win32Window(Process.GetCurrentProcess().MainWindowHandle);
        //    _progressForm = new ProgressBar();

        //    var progress = new Progress<int>(value => _progressForm.UpdateProgress(value));

        //    _progressForm.Activated += async (sender, args) =>
        //    {
        //        await Go(progress);
        //        _progressForm.Close();
        //    };

        //    _progressForm.ShowDialog();
        //}

        //public Task<bool> Go(IProgress<int> progress)
        //{
        //    return Task.Run(() =>
        //    {
        //        var job = new LongJob();
        //        job.Spin(progress);
        //        return true;
        //    });
        //}

        //public void job_OnProgress(int percent)
        //{
        //    _progressForm.UpdateProgress(percent);
        //}

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //public void OnlyNumbers(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }*/
        //}

        public void WriteToErrorLog(string rootPath, Exception ex)
        {
            Directory.CreateDirectory(rootPath + "logs");
            string filePath = rootPath + "logs/Error.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
