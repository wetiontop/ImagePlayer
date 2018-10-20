using UnityEngine;
using UnityEngine.UI;

public class PlayInterval : MonoBehaviour
{
    private void Start()
    {
        int playInterval = PlayerPrefs.GetInt("playInterval");
        if (playInterval < 3)
        {
            playInterval = 3;
        }
        gameObject.GetComponent<InputField>().text = playInterval.ToString();
    }
}