using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridContent : MonoBehaviour {
    // 子预设
    public GameObject prefabs;
    private void Start() {
        // 加载保存过的配置目录
        string selectedDir = PlayerPrefs.GetString("openedFileDir");
        if (selectedDir != null) {
            // 加载文件
            bool resultOK = GlobalDataManager.Instance.ReloadSpriteList(selectedDir);
            if (resultOK) {
                ReloadData();
            }
        }
    }

    // 刷新格子
    public void ReloadData() {
        // 先删除旧的
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }

        List<Sprite> spriteList = GlobalDataManager.Instance.spriteList;
        if (spriteList != null && spriteList.Count > 0) {
            // 创建格子
            foreach (var sprite in spriteList) {
                GameObject obj = (GameObject) Instantiate(prefabs);
                Image thumbnail = obj.GetComponent<Image>();
                thumbnail.sprite = sprite;
                thumbnail.transform.SetParent(transform);
            }
        }
    }
}