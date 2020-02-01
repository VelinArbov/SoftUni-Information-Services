using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SIS.MVCFramework.Tests
{
    public class ViewEngineTests
    {
        [Theory]
        [InlineData("OnlyHtmlView")]
        [InlineData("ForForeachIfView")]
        [InlineData("ViewModelView")]
        public void GetHtmlTest(string testName)
        {

            var viewModel = new TestViewModel();
            viewModel.Name = "Velin";
            viewModel.Year = 1987;
            viewModel.Numbers = new List<int> {12, 23, 1987, 2018};


            var viewContent = File.ReadAllText($"ViewTests/{testName}.html");
            var expectedResultContent = File.ReadAllText($"ViewTests/{testName}.Expected.html");


            IViewEngine viewEngine = new ViewEngine();
            var actualResult = viewEngine.GetHtml(viewContent, viewModel);

            Assert.Equal(expectedResultContent,actualResult);

        }


    }
}
