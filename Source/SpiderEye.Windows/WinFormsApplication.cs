﻿using System;
using System.Threading;
using System.Windows.Forms;
using App = System.Windows.Forms.Application;

namespace SpiderEye.Windows
{
    internal class WinFormsApplication : IApplication
    {
        public IUiFactory Factory { get; }

        public SynchronizationContext SynchronizationContext { get; }

        public WinFormsApplication()
        {
            App.EnableVisualStyles();
            App.SetCompatibleTextRenderingDefault(false);

            Factory = new WinFormsUiFactory();
            SynchronizationContext = new WindowsFormsSynchronizationContext();

            WinFormsWindow.LastWindowClosed += WinFormsWindow_LastWindowClosed;
        }

        public void Run()
        {
            App.Run();
        }

        public void Exit()
        {
            App.Exit();
        }

        private void WinFormsWindow_LastWindowClosed(object sender, EventArgs e)
        {
            if (Application.ExitWithLastWindow) { Exit(); }
        }
    }
}
