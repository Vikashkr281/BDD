using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Utlilities
{
    public class CoreCode
    {
        protected void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot iss = (ITakesScreenshot)driver;
            Screenshot ss = iss.GetScreenshot();

            string? currdir = Directory.GetParent(@"../../../").FullName;
            string? filepath = currdir + "/Screenshots/ss_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            ss.SaveAsFile(filepath);

        }
        protected void LogTestResult(string testName, string result,
            string errorMessage = null)
        {
            Log.Information(result);

            if (errorMessage == null)
            {
                Log.Information(testName + " Passed");
            }
            else
            {
                Log.Error($"Test failed for {testName}." +
                    $" \n Exception: \n {errorMessage}");
            }
        }
    }
}
