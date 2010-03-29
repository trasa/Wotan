using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using log4net;
using NUnit.Framework;

namespace Wotan.Test
{
    [TestFixture]
    public class Log4NetFixture
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void Log4NetTest()
        {
            Assert.IsTrue(log.IsDebugEnabled, "debug is not enabled");
            log.Debug("Hello, World");
        }
    }
}
