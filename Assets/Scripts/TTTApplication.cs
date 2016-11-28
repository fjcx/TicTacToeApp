using UnityEngine;
using System.Collections;

public class TTTApplication : MonoBehaviour {

    // Model references
    public BoardModel Model { get; private set; }

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

    public void InitModels() {
        this.Model = new BoardModel();
        this.Model.cells = new CellContent[9];
        for (int i = 0; i < Model.cells.Length; i++) {
            Model.cells[i] = CellContent.EMPTY;
        }
        this.Model.p1Total = 0;
        this.Model.p2Total = 0;
    }
}
