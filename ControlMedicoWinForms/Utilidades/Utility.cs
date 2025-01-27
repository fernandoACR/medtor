using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Utilidades
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

        public void GoAsync() //no longer async as it blocks on Appication.Run
        {
            var owner = new Win32Window(Process.GetCurrentProcess().MainWindowHandle);
            _progressForm = new ProgressBar();

            var progress = new Progress<int>(value => _progressForm.UpdateProgress(value));

            _progressForm.Activated += async (sender, args) =>
            {
                await Go(progress);
                _progressForm.Close();
            };

            _progressForm.ShowDialog();
        }

        public Task<bool> Go(IProgress<int> progress)
        {
            return Task.Run(() =>
            {
                var job = new LongJob();
                job.Spin(progress);
                return true;
            });
        }

        public void job_OnProgress(int percent)
        {
            _progressForm.UpdateProgress(percent);
        }

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

        public void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        public void OnlyLetters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;

            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }

        public static DateTime GetLastDayOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = GetFirstDayOfWeek(dayInWeek, firstDay);
            return firstDayInWeek.AddDays(5);
        }

        public static string GetRandomAlphaNumString()
        {
            char[] charactersAvailable = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                             'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                             '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            StringBuilder randomString = new StringBuilder();

            Random randomCharacter = new Random();

            for (uint i = 0; i < 6; i++)
            {
                int randomCharSelected = randomCharacter.Next(0, (charactersAvailable.Length - 1));

                randomString.Append(charactersAvailable[randomCharSelected]);
            }

            randomString.Append(".1");
            return randomString.ToString();
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void SetRowStyle(DataGridViewRow row, DataGridViewCellStyle style)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style = style;
            }
        }

        public static Font GetMedtorFont(FontControlEnum controlEnum)
        {
            switch (controlEnum)
            {
                case FontControlEnum.General:
                    return new Font("Segoe UI", 10, FontStyle.Regular);
                case FontControlEnum.GridTitle:
                    return new Font("Segoe UI", 9, FontStyle.Bold); 
                case FontControlEnum.GridRows:
                    return new Font("Segoe UI", 9, FontStyle.Regular);
                case FontControlEnum.HeaderGroupBoxTitle:
                    return new Font("Segoe UI", 12, FontStyle.Bold);
                default:
                    return new Font("Segoe UI", 10, FontStyle.Regular);
            }
            
        }
    }
}
