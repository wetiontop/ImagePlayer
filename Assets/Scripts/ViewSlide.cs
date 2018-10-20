using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ViewSlide : MonoBehaviour {
    public Image fristImage;
    public Image secondImage;
    private Image currentImage;
    private List<Sprite> spriteList;
    private int currentIdx = 0;
    private int interval;

    private void Update() {
        // 按下ESC键
        if (Input.GetKey("escape")) {
            Hide();
        }
    }

    public void Show() {
        gameObject.SetActive(true);

        currentIdx = 0;
        currentImage = null;
        interval = GlobalDataManager.Instance.playInterval;
        spriteList = GlobalDataManager.Instance.spriteList;

        TakeTurns();
    }

    public void Hide() {
        gameObject.SetActive(false);
        CancelInvoke("TakeTurns");
    }

    private void TakeTurns() {
        if (gameObject.activeSelf == false) {
            return;
        }

        if (currentIdx == spriteList.Count) {
            currentIdx = 0;
        }

        if (currentImage != null) {
            LTDescr descr = LeanTween.moveY(currentImage.gameObject, -Screen.height, 1.5f);
            descr.setEaseOutQuad();
            descr.setOnComplete(MoveComplete);
            descr.setOnCompleteParam(currentImage);
        } else {
            // 初始化显示
            fristImage.gameObject.SetActive(true);
            fristImage.transform.SetAsLastSibling();
            secondImage.gameObject.SetActive(false);
            secondImage.transform.SetAsFirstSibling();
        }

        // 取出精灵
        Sprite sprite = spriteList[currentIdx];
        if ((currentIdx % 2) == 0) {
            currentImage = fristImage;
            fristImage.sprite = sprite;
            fristImage.gameObject.SetActive(true);
        } else {
            currentImage = secondImage;
            secondImage.sprite = sprite;
            secondImage.gameObject.SetActive(true);
        }

        currentIdx++;

        Invoke("TakeTurns", interval);
    }

    private void MoveComplete(object obj) {
        currentImage.transform.SetAsLastSibling();

        Image previousImage = (Image) obj;
        previousImage.gameObject.SetActive(false);
        previousImage.transform.SetAsFirstSibling();
        previousImage.rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
}