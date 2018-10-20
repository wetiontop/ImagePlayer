using UnityEngine;

public class TextBink : MonoBehaviour {
    private void Start() {
        LeanTween.alpha(gameObject, 100, 1);
        LeanTween.alpha(gameObject, 255, 1);
        LeanTween.sequence();
    }
}