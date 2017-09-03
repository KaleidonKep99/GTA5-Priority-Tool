using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GTAVPriorityTool
{
    public partial class Main : Form
    {
        [DllImport("user32")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32")]
        public static extern bool EnableMenuItem(IntPtr hMenu, uint itemId, uint uEnable);

        ProcessPriorityClass[] Priorities = new ProcessPriorityClass[6]
        {
            ProcessPriorityClass.Idle,
            ProcessPriorityClass.BelowNormal,
            ProcessPriorityClass.Normal,
            ProcessPriorityClass.AboveNormal,
            ProcessPriorityClass.High,
            ProcessPriorityClass.RealTime
        };
        Int32 IndexOfPriority = 3;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Priority.SelectedIndex = IndexOfPriority;
        }

        private void Priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexOfPriority = Priority.SelectedIndex;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Priority.Enabled = false;
            ConfirmBtn.Enabled = false;
            DisableCloseButton();
            SetGTAVPriority.RunWorkerAsync();
        }

        private void SetGTAVPriority_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("GTA5");

                while (true)
                {
                    if (processes.Length == 0)
                    {
                        this.Invoke((MethodInvoker)delegate { Status.Text = "Status:\nWaiting for GTA V to start..."; });

                        processes = Process.GetProcessesByName("GTA5");
                        System.Threading.Thread.Sleep(10);
                    }
                    else
                    {
                        foreach (Process proc in processes) proc.PriorityClass = Priorities[IndexOfPriority];

                        this.Invoke((MethodInvoker)delegate { Status.Text = String.Format("Status:\nGTA V has been set to {0} priority.", Priority.Text); });
                        System.Threading.Thread.Sleep(500);
                        this.Invoke((MethodInvoker)delegate { Status.Text = "Status:\nClosing..."; });
                        System.Threading.Thread.Sleep(100);

                        Environment.Exit(0);
                    }
                }
            }
            catch { Environment.Exit(-1); }
        }

        private void DisableCloseButton()
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), 0xF060, 1);
        }

        private void EnableCloseButton()
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), 0xF060, 0);
        }
    }
}
