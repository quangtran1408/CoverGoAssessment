using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp.Core.ElementWrapper
{
    public class IFrame : BaseElement
    {
        public IFrame(string locator) 
            : base(locator)
        {
        }

        public IFrame(IWebElement element) 
            : base(element)
        {
        }

        public IFrame(By locator) 
            : base(locator)
        {
        }
    }
}
