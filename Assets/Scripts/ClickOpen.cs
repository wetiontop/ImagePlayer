using SFB;
using UnityEngine;

public class ClickOpen : MonoBehaviour {
    public void OnClick() {
        // 打开文件夹
        string[] selectedDirs = StandaloneFileBrowser.OpenFolderPanel("Open File", "", false);

        // 加载文件
        bool resultOK = GlobalDataManager.Instance.ReloadSpriteList(selectedDirs[0]);
        if (resultOK) {
            PlayerPrefs.SetString("openedFileDir", selectedDirs[0]);

            // 刷新格子
            GameObject.Find("Content").GetComponent<GridContent>().ReloadData();
        }
    }
}