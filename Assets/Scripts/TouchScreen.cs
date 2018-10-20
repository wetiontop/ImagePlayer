using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchScreen : MonoBehaviour {
    public string sceneName;

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            this.GotoScene();
        }
    }

    private void GotoScene() {
        SceneManager.LoadScene(sceneName);
    }
}