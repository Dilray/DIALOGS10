using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using NUnit.Framework;
using FlaUI.TestUtilities;
using FlaUI.Core;
using FlaUI.UIA2;
using UITests.TestFramework;
using System.Threading;
using FlaUI.Core.Tools;
using FlaUI.Core.Input;
using WPFTestApp;

[assembly: Property("Task", "DIALOGS10")]

namespace UITests
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms), Property("Score", 4)]
    [Property("Job", "DIALOGS10_WF")]
    public class WFTests : SomeTests
    {

        public WFTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test, Property("ScorePercentage", 20)]
        public override void OpenCloseTest()
        {
            base.OpenCloseTest();
        }


        [Test, Property("ScorePercentage", 20)]
        public override void SetColorTest()
        {
            base.SetColorTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void SetColorKeyTest()
        {
            base.SetColorKeyTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void WrongInputTest()
        {
            base.WrongInputTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void CancelTest()
        {
            base.CancelTest();
        }

    }

    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf), Property("Score", 5)]
    [Property("Job", "DIALOGS10_WPF")]
    public class WPFTests : SomeTests
    {

        public WPFTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test, Property("ScorePercentage", 20)]
        public override void OpenCloseTest()
        {
            base.OpenCloseTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void SetColorTest()
        {
            base.SetColorTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void SetColorKeyTest()
        {
            base.SetColorKeyTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void WrongInputTest()
        {
            base.WrongInputTest();
        }

        [Test, Property("ScorePercentage", 20)]
        public override void CancelTest()
        {
            base.CancelTest();
        }

    }


    //[TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    //[TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class SomeTests: UITestBase
    {
        private Window _mainWindow;
        private Window _secondWindow;

        public SomeTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }


        //[OneTimeSetUp]
        //public void TestOneTimeSetup()
        //{
        //    _mainWindow = Retry.WhileNull(() => Application.GetMainWindow(Automation), TimeSpan.FromSeconds(1)).Result;
        //    Assert.That(_mainWindow, Is.Not.Null);
        //}

        protected override string GetTestApplicationPath()
        {
            switch (ApplicationType)
            {
                case TestApplicationType.WinForms:
                    return Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\WinFormsTestApp\bin\Debug\WinFormsTestApp.exe");
                    break;
                case TestApplicationType.Wpf:
                    return Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\WPFTestApp\bin\Debug\WPFTestApp.exe");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override ApplicationStartMode ApplicationStartMode => ApplicationStartMode.OncePerTest;

        //[Test, Property("ScorePercentage", 50)]
        public virtual void OpenCloseTest()
        {
            var window = Application.GetMainWindow(Automation);
            var btn = window.FindFirstDescendant(cf => cf.ByName("Изменить фон"));
            Assert.That(btn, Is.Not.Null, "Не найдена кнопка с именем 'Изменить фон'");
            var mainBtn = btn.AsButton();
            Assert.That(mainBtn.IsEnabled, Is.True, "Почему кнопка не активна?");
            var allButtons = window.FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            Assert.That(allButtons.Length, Is.EqualTo(4), "Найдены лишние кнопки!");
            mainBtn.Click();
            var windows = Application.GetAllTopLevelWindows(Automation);
            Assert.That(windows.Length, Is.EqualTo(1), "Второе окно открылось неправильно (не модальное окно)!");
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");
            window.ModalWindows[0].Close();

            mainBtn.Click();
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");
            window.ModalWindows[0].Close();

            mainBtn.Click();
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");
            window.ModalWindows[0].Close();

            window.Close();

        }

        //[Test, Property("ScorePercentage", 50)]
        public virtual void SetColorTest()
        {

            var window = Application.GetMainWindow(Automation);
            var startWidth = window.ActualWidth;
            var startHeight = window.ActualHeight;

            var btn = window.FindFirstDescendant(cf => cf.ByName("Изменить фон"));
            Assert.That(btn, Is.Not.Null, "Не найдена кнопка с именем 'Изменить фон'");
            var mainBtn = btn.AsButton();

            var startButtonWidth = mainBtn.ActualWidth;
            var startButtonHeight = mainBtn.ActualHeight;

            var allButtons = window.FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            Assert.That(allButtons.Length, Is.EqualTo(4), "Найдены лишние кнопки!");
            mainBtn.Click();
            var windows = Application.GetAllTopLevelWindows(Automation);
            Assert.That(windows.Length, Is.EqualTo(1), "Второе окно открылось неправильно (не модальное окно)!");
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");

            var secondWnd = window.ModalWindows[0];
            var b = secondWnd.FindFirstDescendant(cf => cf.ByName("OK"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'OK'");
            var OKBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Применить"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Применить'");
            var applyBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Отмена"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Отмена'");
            var cancelBtn = b.AsButton();
            var texts = secondWnd.FindAllDescendants(cf => cf.ByControlType(ControlType.Edit)).ToList();
            Assert.That(texts.Count(), Is.EqualTo(3), "Найдены не те поля ввода!");
            texts.Sort((l, r) => { return l.BoundingRectangle.Top - r.BoundingRectangle.Top; });

            var rInput = texts[0].AsTextBox(); var gInput = texts[1].AsTextBox(); var bInput = texts[2].AsTextBox();
            rInput.Text = "0";
            gInput.Text = "0";
            bInput.Text = "200";

            applyBtn.Click();

            OKBtn.Click();
            Thread.Sleep(500);
            var bitmap = window.Capture();
            var somePixel = bitmap.GetPixel(200,100);
            Assert.That(somePixel.B, Is.InRange(180, 220));
            Assert.That(somePixel.G, Is.InRange(0, 20));
            Assert.That(somePixel.R, Is.InRange(0, 20));

            Assert.That(window.ModalWindows.Length, Is.EqualTo(0), "Второе окно не закрылось!");

            mainBtn.Click();
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");

            secondWnd = window.ModalWindows[0];
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("OK"));
            OKBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Применить"));
            applyBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Отмена"));
            cancelBtn = b.AsButton();
            texts = secondWnd.FindAllDescendants(cf => cf.ByControlType(ControlType.Edit)).ToList();
            texts.Sort((l, r) => { return l.BoundingRectangle.Top - r.BoundingRectangle.Top; });

            rInput = texts[0].AsTextBox(); gInput = texts[1].AsTextBox(); bInput = texts[2].AsTextBox();
            rInput.Text = "0";
            gInput.Text = "180";
            bInput.Text = "0";

            applyBtn.Click();

            OKBtn.Click();
            Thread.Sleep(500);
            bitmap = window.Capture();
            somePixel = bitmap.GetPixel(200, 100);
            Assert.That(somePixel.B, Is.InRange(0, 20));
            Assert.That(somePixel.G, Is.InRange(160, 200));
            Assert.That(somePixel.R, Is.InRange(0, 20));

            window.Close();

        }

        //[Test, Property("ScorePercentage", 50)]
        public virtual void SetColorKeyTest()
        {

            var window = Application.GetMainWindow(Automation);
            var startWidth = window.ActualWidth;
            var startHeight = window.ActualHeight;

            var btn = window.FindFirstDescendant(cf => cf.ByName("Изменить фон"));
            Assert.That(btn, Is.Not.Null, "Не найдена кнопка с именем 'Изменить фон'");
            var mainBtn = btn.AsButton();

            var startButtonWidth = mainBtn.ActualWidth;
            var startButtonHeight = mainBtn.ActualHeight;

            var allButtons = window.FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            Assert.That(allButtons.Length, Is.EqualTo(4), "Найдены лишние кнопки!");
            mainBtn.Click();
            var windows = Application.GetAllTopLevelWindows(Automation);
            Assert.That(windows.Length, Is.EqualTo(1), "Второе окно открылось неправильно (не модальное окно)!");
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");

            var secondWnd = window.ModalWindows[0];
            var b = secondWnd.FindFirstDescendant(cf => cf.ByName("OK"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'OK'");
            var OKBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Применить"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Применить'");
            var applyBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Отмена"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Отмена'");
            var cancelBtn = b.AsButton();
            var texts = secondWnd.FindAllDescendants(cf => cf.ByControlType(ControlType.Edit)).ToList();
            Assert.That(texts.Count(), Is.EqualTo(3), "Найдены не те поля ввода!");
            texts.Sort((l, r) => { return l.BoundingRectangle.Top - r.BoundingRectangle.Top; });

            var rInput = texts[0].AsTextBox(); var gInput = texts[1].AsTextBox(); var bInput = texts[2].AsTextBox();
            rInput.Text = "0";
            gInput.Text = "0";
            bInput.Text = "200";

            //OKBtn.Click();
            Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
            Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);

            Thread.Sleep(500);
            var bitmap = window.Capture();
            var somePixel = bitmap.GetPixel(200, 100);
            Assert.That(somePixel.B, Is.InRange(180, 220));
            Assert.That(somePixel.G, Is.InRange(0, 20));
            Assert.That(somePixel.R, Is.InRange(0, 20));

            Assert.That(window.ModalWindows.Length, Is.EqualTo(0), "Второе окно не закрылось!");

            mainBtn.Click();
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");

            secondWnd = window.ModalWindows[0];
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("OK"));
            OKBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Применить"));
            applyBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Отмена"));
            cancelBtn = b.AsButton();
            texts = secondWnd.FindAllDescendants(cf => cf.ByControlType(ControlType.Edit)).ToList();
            texts.Sort((l, r) => { return l.BoundingRectangle.Top - r.BoundingRectangle.Top; });

            rInput = texts[0].AsTextBox(); gInput = texts[1].AsTextBox(); bInput = texts[2].AsTextBox();
            rInput.Text = "0";
            gInput.Text = "180";
            bInput.Text = "0";

            //cancelBtn.Click();
            Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ESC);
            Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.ESC);
            Thread.Sleep(500);
            bitmap = window.Capture();
            somePixel = bitmap.GetPixel(200, 100);
            Assert.That(somePixel.B, Is.InRange(180, 220));
            Assert.That(somePixel.G, Is.InRange(0, 20));
            Assert.That(somePixel.R, Is.InRange(0, 20));

            window.Close();

        }


        //[Test, Property("ScorePercentage", 50)]
        public virtual void WrongInputTest()
        {

            var window = Application.GetMainWindow(Automation);
            var startWidth = window.ActualWidth;
            var startHeight = window.ActualHeight;

            var btn = window.FindFirstDescendant(cf => cf.ByName("Изменить фон"));
            Assert.That(btn, Is.Not.Null, "Не найдена кнопка с именем 'Изменить фон'");
            var mainBtn = btn.AsButton();

            var startButtonWidth = mainBtn.ActualWidth;
            var startButtonHeight = mainBtn.ActualHeight;

            var allButtons = window.FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            Assert.That(allButtons.Length, Is.EqualTo(4), "Найдены лишние кнопки!");
            mainBtn.Click();
            var windows = Application.GetAllTopLevelWindows(Automation);
            Assert.That(windows.Length, Is.EqualTo(1), "Второе окно открылось неправильно (не модальное окно)!");
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");

            var secondWnd = window.ModalWindows[0];
            var b = secondWnd.FindFirstDescendant(cf => cf.ByName("OK"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'OK'");
            var OKBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Применить"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Применить'");
            var applyBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Отмена"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Отмена'");
            var cancelBtn = b.AsButton();
            var texts = secondWnd.FindAllDescendants(cf => cf.ByControlType(ControlType.Edit)).ToList();
            Assert.That(texts.Count(), Is.EqualTo(3), "Найдены не те поля ввода!");
            texts.Sort((l, r) => { return l.BoundingRectangle.Top - r.BoundingRectangle.Top; });

            var rInput = texts[0].AsTextBox(); var gInput = texts[1].AsTextBox(); var bInput = texts[2].AsTextBox();
            rInput.Text = "0sdasdf";
            gInput.Text = "0";
            bInput.Text = "200";
            Assert.That(OKBtn.IsEnabled, Is.False); Assert.That(applyBtn.IsEnabled, Is.False);
            rInput.Text = "0";
            gInput.Text = "33330";
            bInput.Text = "200";
            Assert.That(OKBtn.IsEnabled, Is.False); Assert.That(applyBtn.IsEnabled, Is.False);
            rInput.Text = "0";
            gInput.Text = "2";
            bInput.Text = "djo3s";
            Assert.That(OKBtn.IsEnabled, Is.False); Assert.That(applyBtn.IsEnabled, Is.False);
            rInput.Text = "256";
            gInput.Text = "2";
            bInput.Text = "123";
            Assert.That(OKBtn.IsEnabled, Is.False); Assert.That(applyBtn.IsEnabled, Is.False);
            rInput.Text = "255";
            gInput.Text = "255";
            bInput.Text = "0";
            Assert.That(OKBtn.IsEnabled, Is.True); Assert.That(applyBtn.IsEnabled, Is.True);


            OKBtn.Click();
            Thread.Sleep(500);
            var bitmap = window.Capture();
            var somePixel = bitmap.GetPixel(200, 100);
            Assert.That(somePixel.B, Is.InRange(0, 20));
            Assert.That(somePixel.G, Is.InRange(235, 255));
            Assert.That(somePixel.R, Is.InRange(235, 255));

            Assert.That(window.ModalWindows.Length, Is.EqualTo(0), "Второе окно не закрылось!");


            window.Close();

        }

        //[Test, Property("ScorePercentage", 50)]
        public virtual void CancelTest()
        {

            var window = Application.GetMainWindow(Automation);
            var startWidth = window.ActualWidth;
            var startHeight = window.ActualHeight;

            var btn = window.FindFirstDescendant(cf => cf.ByName("Изменить фон"));
            Assert.That(btn, Is.Not.Null, "Не найдена кнопка с именем 'Изменить фон'");
            var mainBtn = btn.AsButton();
            var bitmap = window.Capture();
            var somePixel = bitmap.GetPixel(200, 100);


            var allButtons = window.FindAllDescendants(cf => cf.ByControlType(ControlType.Button));
            Assert.That(allButtons.Length, Is.EqualTo(4), "Найдены лишние кнопки!");
            mainBtn.Click();
            var windows = Application.GetAllTopLevelWindows(Automation);
            Assert.That(windows.Length, Is.EqualTo(1), "Второе окно открылось неправильно (не модальное окно)!");
            Assert.That(window.ModalWindows.Length, Is.EqualTo(1), "Втоое окно не открылось!");

            var secondWnd = window.ModalWindows[0];
            var b = secondWnd.FindFirstDescendant(cf => cf.ByName("OK"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'OK'");
            var OKBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Применить"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Применить'");
            var applyBtn = b.AsButton();
            b = secondWnd.FindFirstDescendant(cf => cf.ByName("Отмена"));
            Assert.That(b, Is.Not.Null, "Не найдена кнопка с именем 'Отмена'");
            var cancelBtn = b.AsButton();
            var texts = secondWnd.FindAllDescendants(cf => cf.ByControlType(ControlType.Edit)).ToList();
            Assert.That(texts.Count(), Is.EqualTo(3), "Найдены не те поля ввода!");
            texts.Sort((l, r) => { return l.BoundingRectangle.Top - r.BoundingRectangle.Top; });

            var rInput = texts[0].AsTextBox(); var gInput = texts[1].AsTextBox(); var bInput = texts[2].AsTextBox();
            rInput.Text = "0";
            gInput.Text = "150";
            bInput.Text = "200";

            cancelBtn.Click();
            Thread.Sleep(500);
            Assert.That(window.ModalWindows.Length, Is.EqualTo(0), "Второе окно не закрылось!");

            var newBitmap = window.Capture();
            var newPixel = bitmap.GetPixel(200, 100);
            Assert.That(newPixel, Is.EqualTo(somePixel));

            window.Close();

        }

    }
}
