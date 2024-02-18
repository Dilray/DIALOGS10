using System;
using System.IO;
using FlaUI.TestUtilities;
using NUnit.Framework;
using FlaUI.Core;
using FlaUI.UIA2;
using WPFTestApp;
using FlaUI.Core.Capturing;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace UITests.TestFramework
{
    /// <summary>
    /// Base class for UI Tests with FlaUI test applications.
    /// </summary>
    public class UITestBase : FlaUITestBase
    {
        protected UITestBase(AutomationType automationType, TestApplicationType appType)
        {
            AutomationType = automationType;
            ApplicationType = appType;
        }

        [SetUp]
        public override async Task UITestBaseSetUp()
        {
            string allVideoPath = Environment.GetEnvironmentVariable("FLAUI_VIDEO_FOLDER");
            if (Directory.Exists(allVideoPath))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(allVideoPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            await base.UITestBaseSetUp();
        }

        
        [TearDown]
        public override void UITestBaseTearDown()
        {
            base.UITestBaseTearDown();
            string allVideoPath = Environment.GetEnvironmentVariable("FLAUI_VIDEO_FOLDER");
            if (allVideoPath is null || allVideoPath == "") return;
            if (!Directory.Exists(allVideoPath))
            {
                Directory.CreateDirectory(allVideoPath);
            }
            if (Directory.Exists(TestsMediaPath))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(TestsMediaPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.CopyTo(Path.Combine(allVideoPath, file.Name));
                }
            }
        }

        protected virtual string GetTestApplicationPath()
        {
            switch (ApplicationType)
            {
                case TestApplicationType.WinForms:
                    return Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\TestApplications\WinFormsApplication\bin\WinFormsApplication.exe");
                    break;
                case TestApplicationType.Wpf:
                    return Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\TestApplications\WpfApplication\bin\WpfApplication.exe");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        //protected virtual VideoRecordingMode VideoRecordingMode => VideoRecordingMode.NoVideo;
        protected override async Task AdjustRecorderSettings(VideoRecorderSettings videoRecorderSettings)
        {
            videoRecorderSettings.ffmpegPath = "ffmpeg";
        }

        protected AutomationType AutomationType { get; }

        protected TestApplicationType ApplicationType { get; }

        protected override ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerFixture;

        protected override FlaUI.Core.AutomationBase GetAutomation()
        {
            return UtilityMethods.GetAutomation(AutomationType);
        }

        protected override Application StartApplication()
        {
            Application app;
            app = Application.Launch(this.GetTestApplicationPath());
            app.WaitWhileMainHandleIsMissing();
            return app;
        }
    }
}
