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
                Process[] processesGTA5 = Process.GetProcessesByName("GTA5");
                Process[] processesGTA5Launcher = Process.GetProcessesByName("GTAVLauncher");
                Process[] processesSPLauncher = Process.GetProcessesByName("subprocess");

                while (true)
                {
                    if (processesGTA5.Length == 0 || processesGTA5Launcher.Length == 0)
                    {
                        this.Invoke((MethodInvoker)delegate { Status.Text = "Status:\nWaiting for GTA V to start..."; });

                        processesGTA5 = Process.GetProcessesByName("GTA5");
                        processesGTA5Launcher = Process.GetProcessesByName("GTAVLauncher");
                        processesSPLauncher = Process.GetProcessesByName("subprocess");
                        System.Threading.Thread.Sleep(100);
                    }
                    else
                    {
                        foreach (Process proc in processesGTA5) proc.PriorityClass = Priorities[IndexOfPriority];
                        foreach (Process proc in processesGTA5Launcher) proc.PriorityClass = Priorities[0];
                        foreach (Process proc in processesSPLauncher) proc.PriorityClass = Priorities[0];

                        this.Invoke((MethodInvoker)delegate { Status.Text = String.Format("Status:\nGTA V's priority set to {0}. Launcher priority set to Low.", Priority.Text); });
                        System.Threading.Thread.Sleep(500);
                        this.Invoke((MethodInvoker)delegate { Status.Text = "Status:\nClosing..."; });
                        System.Threading.Thread.Sleep(10);

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
