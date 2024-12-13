using System.Collections;
using TMPro;
using UnityEngine;

public class GameName : MonoBehaviour {
    public TMP_Text tmpText;
    private string message = "Click 'n' Code~By~Raycast Interactive";
    public float typingSpeed = 1f;
    void Start() {
        tmpText.text = "";
        if (tmpText != null) {
            StartCoroutine(TypeText());
        }
    }
    private IEnumerator TypeText() {
        tmpText.text = "";
        foreach (char letter in message) {
            if(letter == '~') {
                tmpText.text += "\n";
            }
            else {
                tmpText.text += letter; 
            }
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
