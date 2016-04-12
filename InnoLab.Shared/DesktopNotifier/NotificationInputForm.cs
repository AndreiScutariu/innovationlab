using System;
using System.Windows.Forms;

namespace DesktopNotifier
{
    public partial class NotificationInputForm : Form
    {
        private NotificationWorker _worker;

        public NotificationInputForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var exitMenuItem = new MenuItem("Exit", Exit);
            notifyIcon.ContextMenu = new ContextMenu(new[] { exitMenuItem });
            notifyIcon.Visible = true;

            Hide();

            var userName = userNameInput.Text;
            _worker = new NotificationWorker(userName, notifyIcon);
            _worker.Start();
        }

        void Exit(object sender, EventArgs e)
        {
            _worker.Stop();
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}