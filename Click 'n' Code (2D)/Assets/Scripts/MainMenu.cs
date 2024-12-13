using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {
    public Slider progressBar;
    public Text progressText;

    public void PlayGame() {
        StartCoroutine(LoadSceneAsync("Game"));
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadSceneAsync("MainMenu"));
    }

    private IEnumerator LoadSceneAsync(string sceneName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone) {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            progressBar.value = progress;

            if (progressText != null) {
                progressText.text = Mathf.RoundToInt(progress * 100) + "%";
            }

            if (asyncLoad.progress >= 0.9f) {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    public void QuitGame() {
        Application.Quit();
    }
}