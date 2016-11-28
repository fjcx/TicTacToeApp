using UnityEngine;

// Entry point for application
 public class TTTApplication : MonoBehaviour {

    public BoardModel Model { get; private set; }       // Model reference

    private static TTTApplication _instance;
    public static TTTApplication Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<TTTApplication>();
                if (_instance == null) {
                    GameObject go = new GameObject("TTTApplication");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<TTTApplication>();
                }
            }
            return _instance;
        }
    }

    void Start() {
        InitModels();
    }

    // Setting initial model values, or reading stored values
    public void InitModels() {
        this.Model = new BoardModel();
        this.Model.cells = new CellContent[9];
        for (int i = 0; i < Model.cells.Length; i++) {
            Model.cells[i] = CellContent.EMPTY;
        }

        this.Model.players = new PlayerModel[2] {new PlayerModel(), new PlayerModel()};
        this.Model.players[1].playerName = "Player 1";
        this.Model.players[1].playerSymbol = CellContent.O;
        this.Model.players[1].playerType = PlayerType.AIMINIMAX;

        Debug.Log("To Json: " + JsonUtility.ToJson(this.Model));
    }
}
