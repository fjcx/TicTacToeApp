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
        this.Model.players = new Player[2];
        this.Model.playerScores = new int[2];

        this.Model.playerScores[0] = 0;
        this.Model.playerScores[1] = 0;
        this.Model.currentPlayerIndex = 0;
    }
}
