using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Abstract;
using Concrete;
using LargeNumberCalculator.Controllers;
using Entities;

namespace LargeNumberCalculateTests
{
    [TestClass]
    public class CalculationTest
    {
        [TestMethod]
        public void isAddOperandChosen()
        {
            //Arrange
            string posNum = "150";            
            string negNum = "-150";            

            //Act
            OperatorService osAdd1 = new OperatorService(posNum, posNum);
            OperatorService osAdd2 = new OperatorService(negNum, negNum);            

            //Assert
            Assert.AreEqual("+", osAdd1.OperandString);
            Assert.AreEqual("+", osAdd1.OperandString);
        }

        [TestMethod]
        public void isSubOperandChosen()
        {
            //Arrange
            string posNum = "150";
            string negNum = "-200";

            //Act
            OperatorService osSub1 = new OperatorService(posNum, negNum);
            OperatorService osSub2 = new OperatorService(negNum, posNum);

            //Assert
            Assert.AreEqual("-", osSub1.OperandString);
            Assert.AreEqual("-", osSub2.OperandString);
        }

        [TestMethod]
        public void AddSimpleNumbers()
        {
            //Arrange
            int number1 = 14;
            int number2 = 58;
            string knownAnswer = (number1 + number2).ToString();

            //Act
            OperatorService add = new OperatorService(number1.ToString(), number2.ToString());
            string answer = add.Calculate();

            //Assert
            Assert.AreEqual(knownAnswer, answer);
        }

        [TestMethod]
        public void AddNegativeNumbers()
        {
            //Arrange            
            int number1 = -154;
            int number2 = -89;
            string knownAnswer = (number1 + number2).ToString();

            //Act
            OperatorService add = new OperatorService(number1.ToString(), number2.ToString());
            string answer = add.Calculate();

            //Assert
            Assert.AreEqual(knownAnswer, answer);

        }

        [TestMethod]
        public void AddReallyLargeNumbers()
        {
            //Arrange
            string number1 = "123456789101112131415161718192021222324252627282930";
            string number2 = "302928272625242322212019181716151413121110987654321";
            string knownAnswer = "426385061726354453627180899908172635445363614937251";

            //Act
            OperatorService add = new OperatorService(number1, number2);
            string answer = add.Calculate();

            //Assert
            Assert.AreEqual(knownAnswer, answer);

        }
    }
}
