using UnityEngine;
using UnityEngine.UI;

public class Normal : MonoBehaviour {
    public Text contentTextObject;
    public void SetAlertContent(string content) {
        contentTextObject.text = content;
    }

    public void OnClickOK() {
        gameObject.SetActive(false);
    }
}