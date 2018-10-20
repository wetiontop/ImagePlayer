using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickRefresh : MonoBehaviour {
    public void OnClick() {
        // 刷新打开过目录的文件路径
        bool resultOk = GlobalDataManager.Instance.ReloadSpriteList();
        if (resultOk) {
            // 刷新格子
            GameObject.Find("Content").GetComponent<GridContent>().ReloadData();
        }
    }
}