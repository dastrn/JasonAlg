using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class Calc_Tests
    {
        private Calc _sut;

        [SetUp]
        public void Initialize()
        {
            _sut = new Calc();
        }
    }
}