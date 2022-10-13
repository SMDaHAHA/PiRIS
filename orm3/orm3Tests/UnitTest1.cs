using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using orm3;

namespace orm3Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Div_2div2_1expected()
        {
            //arrange
            int a = 2;
            int b = 2;
            float expected = 1;

            //act
            // тут мы должны создать экземляр класса, чтобы протестировать его
            float actual = MyCalc.Div(a, b);

            //assert
            Assert.AreEqual(actual, expected);

        }
        static Calc MyCalc = null;

        /* используем атрибут [ClassInitialize], 
        который скажет тестировщику, 
        что этот метод нужно выполнить ДО запуска тестов 
        (поэтому и этот метод и свойство Mycalc 
        должны быть объявлены статические)*/
        [ClassInitialize]
        static public void Init(TestContext tc)
        {
            MyCalc = new Calc();
        }

        // и аналогично для завершения
        [ClassCleanup]
        static public void Done()
        {
            MyCalc = null;
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException), "Деление на 0")]
        public void Div_2div0_exceptionexpected()
        {
            //arrange
            float a = 2;
            float b = 0;
            float expected = 2;

            //act
            float actual = MyCalc.Div(a, b);

            //assert
            Assert.AreNotEqual(actual, expected);
        }
    }
}
