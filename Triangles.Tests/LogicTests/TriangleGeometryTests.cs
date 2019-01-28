using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Triangles.Logic;

namespace Triangles.Tests.LogicTests
{
    [TestClass]
    public class TriangleGeometryTests: TriangleGeometry
    {
        public const byte NUMBER_OF_TEST_TRIANGLES = 3;

        private static Triangle[] _triangles = new Triangle[NUMBER_OF_TEST_TRIANGLES];
        private static Triangle triangleWrong;

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            _triangles = new Triangle[]                  //Expected that they are correct triangles.
            {
                new Triangle(5.6, 2.7, 3.4),
                new Triangle(1.4, 3.8, 2.6),
            };

            triangleWrong = new Triangle(1.2, 4.6, 7.9); //Expected that triangleWrong is not triangle.
        }

        [TestMethod]
        public void GetPerimeter_CountPerimeterTriangleCorrect_expected12p6()
        {
            double expected = 5.6 + 2.7 + 3.4;
            double act = _triangles[0].GetPerimeter();

            Assert.AreEqual(act, expected, "Perimeter does not match expected.");
        }

        [TestMethod]
        public void GetSemiperimeter_CountSemiperimeter_expected6p3()
        {
            double expected = (5.6 + 2.7 + 3.4)/2;
            double act = _triangles[0].GetSemiperimeter();

            Assert.AreEqual(act, expected, "Semiperimeter does not match expected.");
        }

        [TestMethod]
        public void IsTriangle_CheckIfTriangle_CorrectTriangle()
        {
            bool act = _triangles[0].IsTriangle();
            bool expected = true;

            Assert.AreEqual(expected, act, "Correct triangle has not passed a triangle validation check");
        }

        [TestMethod]
        public void IsTriangle_CheckIfTriangle_WrongTriangle()
        {
            bool act = _triangles[0].IsTriangle();
            bool expected = false;

            Assert.AreNotEqual(expected, act, "Wrong triangle has passed a triangle validation check");
        }

        [TestMethod]
        public void GetSquare_CountSquare_СorrectМalue()
        {
            double p = _triangles[0].GetSemiperimeter();

            double expected = System.Math.Sqrt(p * (p - _triangles[0].A) * (p - _triangles[0].B) * (p - _triangles[0].C));
            double act = _triangles[0].GetSquare();

            Assert.AreEqual(act, expected, "Square does not match expected.");
        }

        [TestProperty()]
        public void Sides_SidesArray_ReturnsSidesArray()
        {

        }
    }
}
