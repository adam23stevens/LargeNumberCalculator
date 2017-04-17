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
            string number1 = "14";
            string number2 = "58";

            //Act
            OperatorService add = new OperatorService(number1, number2);
            string answer = add.Calculate();
            
            //Assert


        }

        [TestMethod]
        public void AddNegativeNumbers()
        {

        }

        [TestMethod]
        public void AddReallyLargeNumbers()
        {

        }
    }
}
