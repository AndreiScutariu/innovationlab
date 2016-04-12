using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DesktopNotifier
{
    public class NotificationWorker
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly string _userName;
        private IDisposable _timer;

        public NotificationWorker(string userName, NotifyIcon notifyIcon)
        {
            _userName = userName;
            _notifyIcon = notifyIcon;
        }

        public void Start()
        {
            _timer = EasyTimer.SetInterval(GetLastNotification, 5000);
        }

        private void GetLastNotification()
        {
            var http = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:8890/users/get?userName={0}", _userName));
            var message = "";

            var responseStream = http.GetResponse().GetResponseStream();
            if (responseStream == null) return;

            var objReader = new StreamReader(responseStream);
            var sLine = "";

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    message += sLine;
            }

            _notifyIcon.ShowBalloonTip(1000, message, message, ToolTipIcon.Info);
        }

        public void Stop()
        {
            _timer.Dispose();
        }

    }
}