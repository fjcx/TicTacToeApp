using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class WinConditionsTest {

	[Test]
	public void CheckWinningXPatterns() {
        CellContent[] testRow1X = new CellContent[9] {CellContent.X, CellContent.X, CellContent.X,
                                                      CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testRow1X, CellContent.X));

        CellContent[] testRow2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                      CellContent.X, CellContent.X, CellContent.X,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testRow2X, CellContent.X));

        CellContent[] testRow3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.X, CellContent.X, CellContent.X};
        Assert.IsTrue(WinConditions.isWinningCondition(testRow3X, CellContent.X));

        CellContent[] testCol1X = new CellContent[9] {CellContent.X, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.X, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.X, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testCol1X, CellContent.X));

        CellContent[] testCol2X = new CellContent[9] {CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.X, CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testCol2X, CellContent.X));

        CellContent[] testCol3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.X,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.X,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.X};
        Assert.IsTrue(WinConditions.isWinningCondition(testCol3X, CellContent.X));

        CellContent[] testDiag1X = new CellContent[9] {CellContent.X, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.X};
        Assert.IsTrue(WinConditions.isWinningCondition(testDiag1X, CellContent.X));

        CellContent[] testDiag2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.X,
                                                        CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                            CellContent.X, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testDiag2X, CellContent.X));
    }

    [Test]
    public void CheckWinningOPatterns() {
        CellContent[] testRow1X = new CellContent[9] {CellContent.O, CellContent.O, CellContent.O,
                                                      CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testRow1X, CellContent.O));

        CellContent[] testRow2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                      CellContent.O, CellContent.O, CellContent.O,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testRow2X, CellContent.O));

        CellContent[] testRow3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.O, CellContent.O, CellContent.O};
        Assert.IsTrue(WinConditions.isWinningCondition(testRow3X, CellContent.O));

        CellContent[] testCol1X = new CellContent[9] {CellContent.O, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.O, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.O, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testCol1X, CellContent.O));

        CellContent[] testCol2X = new CellContent[9] {CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.O, CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testCol2X, CellContent.O));

        CellContent[] testCol3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.O,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.O,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.O};
        Assert.IsTrue(WinConditions.isWinningCondition(testCol3X, CellContent.O));

        CellContent[] testDiag1X = new CellContent[9] {CellContent.O, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.O};
        Assert.IsTrue(WinConditions.isWinningCondition(testDiag1X, CellContent.O));

        CellContent[] testDiag2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.O,
                                                        CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                            CellContent.O, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testDiag2X, CellContent.O));
    }

    [Test]
    public void CheckFalsePositivesWinningOPatterns() {
        CellContent[] testRow1X = new CellContent[9] {CellContent.O, CellContent.O, CellContent.O,
                                                      CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testRow1X, CellContent.X));

        CellContent[] testRow2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                      CellContent.O, CellContent.O, CellContent.O,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testRow2X, CellContent.X));

        CellContent[] testRow3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.O, CellContent.O, CellContent.O};
        Assert.IsFalse(WinConditions.isWinningCondition(testRow3X, CellContent.X));

        CellContent[] testCol1X = new CellContent[9] {CellContent.O, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.O, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.O, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testCol1X, CellContent.X));

        CellContent[] testCol2X = new CellContent[9] {CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.O, CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testCol2X, CellContent.X));

        CellContent[] testCol3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.O,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.O,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.O};
        Assert.IsFalse(WinConditions.isWinningCondition(testCol3X, CellContent.X));

        CellContent[] testDiag1X = new CellContent[9] {CellContent.O, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.O};
        Assert.IsFalse(WinConditions.isWinningCondition(testDiag1X, CellContent.X));

        CellContent[] testDiag2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.O,
                                                        CellContent.EMPTY, CellContent.O,  CellContent.EMPTY,
                                                            CellContent.O, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testDiag2X, CellContent.X));
    }

    [Test]
    public void CheckFalsePositiveWinningXPatterns() {
        CellContent[] testRow1X = new CellContent[9] {CellContent.X, CellContent.X, CellContent.X,
                                                      CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testRow1X, CellContent.O));

        CellContent[] testRow2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                      CellContent.X, CellContent.X, CellContent.X,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testRow2X, CellContent.O));

        CellContent[] testRow3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.X, CellContent.X, CellContent.X};
        Assert.IsFalse(WinConditions.isWinningCondition(testRow3X, CellContent.O));

        CellContent[] testCol1X = new CellContent[9] {CellContent.X, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.X, CellContent.EMPTY,  CellContent.EMPTY,
                                                            CellContent.X, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testCol1X, CellContent.O));

        CellContent[] testCol2X = new CellContent[9] {CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.X, CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testCol2X, CellContent.O));

        CellContent[] testCol3X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.X,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.X,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.X};
        Assert.IsFalse(WinConditions.isWinningCondition(testCol3X, CellContent.O));

        CellContent[] testDiag1X = new CellContent[9] {CellContent.X, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                            CellContent.EMPTY, CellContent.EMPTY, CellContent.X};
        Assert.IsFalse(WinConditions.isWinningCondition(testDiag1X, CellContent.O));

        CellContent[] testDiag2X = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY,  CellContent.X,
                                                        CellContent.EMPTY, CellContent.X,  CellContent.EMPTY,
                                                            CellContent.X, CellContent.EMPTY, CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testDiag2X, CellContent.O));
    }

    [Test]
    public void CheckMixedWinningPatterns() {
        CellContent[] testMixed1 = new CellContent[9] {CellContent.X, CellContent.X, CellContent.X,
                                                      CellContent.O, CellContent.O,  CellContent.O,
                                                        CellContent.O, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsTrue(WinConditions.isWinningCondition(testMixed1, CellContent.X));
        Assert.IsTrue(WinConditions.isWinningCondition(testMixed1, CellContent.O));

        CellContent[] testMixed2 = new CellContent[9] {CellContent.O, CellContent.X, CellContent.X,
                                                      CellContent.O, CellContent.O,  CellContent.X,
                                                        CellContent.O, CellContent.EMPTY,  CellContent.X};
        Assert.IsTrue(WinConditions.isWinningCondition(testMixed2, CellContent.X));
        Assert.IsTrue(WinConditions.isWinningCondition(testMixed2, CellContent.O));
    }

    [Test]
    public void CheckFalseWinningEmptyPatterns() {
        CellContent[] testEmpty = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY, CellContent.EMPTY,
                                                      CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isWinningCondition(testEmpty, CellContent.EMPTY));
    }

    [Test]
    public void CheckDrawPatterns() {
        CellContent[] testDraw1 = new CellContent[9] {CellContent.EMPTY, CellContent.EMPTY, CellContent.EMPTY,
                                                      CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY,
                                                        CellContent.EMPTY, CellContent.EMPTY,  CellContent.EMPTY};
        Assert.IsFalse(WinConditions.isDraw(testDraw1));

        CellContent[] testDraw2 = new CellContent[9] {CellContent.O, CellContent.X, CellContent.X,
                                                      CellContent.O, CellContent.O,  CellContent.X,
                                                        CellContent.O, CellContent.EMPTY,  CellContent.X};
        Assert.IsFalse(WinConditions.isDraw(testDraw2));

        CellContent[] testDraw3 = new CellContent[9] {CellContent.O, CellContent.X, CellContent.X,
                                                      CellContent.X, CellContent.O,  CellContent.X,
                                                        CellContent.O, CellContent.X,  CellContent.O};
        Assert.IsTrue(WinConditions.isDraw(testDraw3));

        // Allowed as draw is only checked after a win condition is checked. This could be updated to not be a dependency though
        CellContent[] testDraw4 = new CellContent[9] {CellContent.O, CellContent.X, CellContent.X,
                                                      CellContent.O, CellContent.O,  CellContent.X,
                                                        CellContent.O, CellContent.O,  CellContent.X};
        Assert.IsTrue(WinConditions.isDraw(testDraw4));
    }
}
