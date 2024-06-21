using System;
using NUnit.Framework;
using SeleniumCSharp.Core.DriverWrapper;
using SeleniumCSharp.Core.ElementWrapper;
using SeleniumCSharp.Core.Utilities;
using System.ComponentModel;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace SeleniumTests.Utilities
{
    public class Utils
    {
        public static string GeScreenshotFile(TestContext context = null)
        {
            if (context != null)
                return
                    $"{FileUtils.GetBasePath()}Resources\\Screenshots\\{GetFileName("IMG", context)}{Constants.ImgExtension}";
            return
                $"{FileUtils.GetBasePath()}Resources\\Screenshots\\{Guid.NewGuid().ToString()}{Constants.ImgExtension}";
        }

        public static string GetScreenshotFolder()
        {
            return $"{FileUtils.GetBasePath()}Resources\\Screenshots";
        }

        public static string GetLogFile(TestContext context = null)
        {
            if (context != null)
                return
                    $"{FileUtils.GetBasePath()}Resources\\Logs\\{GetFileName("Log", context)}{Constants.LogExtension}";
            return $"{FileUtils.GetBasePath()}Resources\\Logs\\{Guid.NewGuid().ToString()}{Constants.LogExtension}";
        }

        public static string GetLogFolder()
        {
            return $"{FileUtils.GetBasePath()}Resources\\Logs";
        }

        private static string GetFileName(string type, TestContext context)
        {
            var filename =
                $"[Test]_[{type}]_{context.Test.MethodName}_{DateTime.Now.ToString("yy-MM-dd HH.mm.ss")}";

            //If log file name length > 70+ , incorrect tests count published to VSO. Hence limiting log file name to max 70 char.
            if (filename.Length > 70) filename = filename.Substring(0, 70);

            return filename;
        }

        public static void EnterValue(BaseElement ele, String value)
        {
            ele.SendKeys(value);
        }


        public static BaseElement FormatElement(BaseElement ele, params object[] parameters)
        {
            return new BaseElement(string.Format(ele.ToString(), parameters));
        }


        public static string GetDisplayName(System.Enum enumValue)
        {
            var nm = enumValue.ToString();
            var tp = enumValue.GetType();
            var field = tp.GetField(nm);
            var attrib = System.Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) 
                as System.ComponentModel.DescriptionAttribute;

            if (attrib != null)
                return attrib.Description;
            else
                return nm;
        }

       

    }






}