﻿/*
The MIT License (MIT)

Copyright (c) 2015 Objectivity Bespoke Software Specialists

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/


namespace Objectivity.Test.Automation.Tests.NUnit.Tests
{
    using System.Drawing.Imaging;

    using global::NUnit.Framework;

    using Objectivity.Test.Automation.Common.Helpers;
    using Objectivity.Test.Automation.Tests.PageObjects.PageObjects.TheInternet;

    [TestFixture]
    class SaveScreenShotsOageSourceTestsNUnit : ProjectTestBase
    {
        [Test]
        public void SaveFullScreenShotTest()
        {
            var downloadPage = new InternetPage(this.DriverContext).OpenHomePage().GoToFileDownloader();
            var screenShotNumber = FilesHelper.CountFiles(this.DriverContext.ScreenShotFolder, FileType.Png);
            TakeScreenShot.Save(TakeScreenShot.DoIt(), ImageFormat.Png, this.DriverContext.ScreenShotFolder, this.DriverContext.TestTitle);
            downloadPage.CheckIfScreenShotIsSaved(screenShotNumber, "SaveFullScreenShotTest.png");
        }

        [Test]
        public void SaveWebDriverScreenShotTest()
        {
            var downloadPage = new InternetPage(this.DriverContext).OpenHomePage().GoToFileDownloader();
            var screenShotNumber = FilesHelper.CountFiles(this.DriverContext.ScreenShotFolder, FileType.Png);
            downloadPage.SaveWebDriverScreenShot();
            downloadPage.CheckIfScreenShotIsSaved(screenShotNumber, "SaveWebDriverScreenShotTest.png");
        }

        [Test]
        public void SaveSourcePageTest()
        {
            var downloadPage = new InternetPage(this.DriverContext).OpenHomePage().GoToFileDownloader();
            var pageSourceNumber = FilesHelper.CountFiles(this.DriverContext.PageSourceFolder, FileType.Html);
            downloadPage.SaveSourcePage();
            downloadPage.CheckIfScreenShotIsSaved(pageSourceNumber, "SaveSourcePageTest.html");
        }
    }
}
