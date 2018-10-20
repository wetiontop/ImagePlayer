using UnityEngine;
using UnityEngine.UI;

public class ClickPlay : MonoBehaviour {
    public GameObject viewSlide;
    public InputField inputField;

    public void OnClick() {
        int playInterval = int.Parse(inputField.text);
        if (playInterval < 3) {
            GameObject uiRoot = GameObject.Find("Canvas_ui_root");
            GameObject alert = uiRoot.transform.Find("Panel_alert").gameObject;
            if (alert != null) {
                alert.SetActive(true);
                alert.GetComponent<Normal>().SetAlertContent("播放间隔不能小于3秒哦～");
            }
            return;
        }

        GlobalDataManager.Instance.playInterval = playInterval;
        PlayerPrefs.SetInt("playInterval", playInterval);

        // 显示幻灯片
        viewSlide.GetComponent<ViewSlide>().Show();
    }
}