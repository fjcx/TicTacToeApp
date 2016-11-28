using System;

[Serializable]
public enum PlayerType {
    HUMAN, AIMINIMAX
}

[Serializable]
public class PlayerModel {
    public string playerName = "Player 0";
    public CellContent playerSymbol = CellContent.X;
    public PlayerType playerType = PlayerType.HUMAN;
    public int score = 0;
}
