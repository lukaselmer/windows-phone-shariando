using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shariando.Services;
using Shariando.Services.Interfaces;

namespace Shariando.Test
{
    [TestClass]
    public class ServerFacadeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IServerFacade sf = new ServerFacade();
            //Assert.IsTrue(sf.CheckEmail("lukas.elmer@renuo.ch"));
            //Assert.IsFalse(sf.CheckEmail("doesnotextist_bla@renuo.ch"));
        }
    }
}
