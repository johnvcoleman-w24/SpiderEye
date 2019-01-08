﻿using Microsoft.Toolkit.Wpf.UI.Controls;

namespace SpiderEye.Windows
{
    internal class WpfApplication : ApplicationBase
    {
        public override IWindow MainWindow
        {
            get { return window; }
        }

        private readonly System.Windows.Application application;
        private readonly WpfWindow window;

        public WpfApplication(AppConfiguration config)
            : base(config)
        {
            // WebViewCompatible does not expose InvokeScript(string, string[])
            // as a workaround, do the same as WebViewCompatible with only the methods that are needed
            IWpfWebview webview;
            if (WebViewCompatible.IsLegacy) { webview = new WpfLegacyWebview(config); }
            else { webview = new WpfWebview(config); }

            window = new WpfWindow(config, webview);

            application = new System.Windows.Application();
            application.MainWindow = window;
        }

        public override void Run()
        {
            base.Run();
            application.Run();
        }

        public override void Exit()
        {
            application.Shutdown();
        }
    }
}