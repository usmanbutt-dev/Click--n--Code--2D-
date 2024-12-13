using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ButtonInteraction : MonoBehaviour {
    public TMP_Text codeText; // Change to TMP_Text for TextMeshPro compatibility
    public TMP_Text earnedText;
    public string codeSnippets;
    private AudioSource audioSource;
    private int currentCharIndex = 0; // Tracks the current character index
    private int lineCount = 0; // Tracks the current number of lines written
    private bool isTyping = false;
    private int earning;

    void Start() {
        earning = PlayerPrefs.GetInt("Earning");
        earnedText.text = "Earned: $" + earning;
        audioSource = GetComponent<AudioSource>();

        // Initialize codeSnippets with default value if it's not set in the Inspector
        if (string.IsNullOrEmpty(codeSnippets)) {
            codeSnippets = "int a = 0;~float b = 3.14f;~Debug.Log(\"Hello World\");~void Start() { }~if (x > y) { }~for (int i = 0; i < 10; i++) { }~while (true) { }~GameObject.Find(\"Player\");~Transform.position = new Vector3(0, 0, 0);~Input.GetKeyDown(KeyCode.Space);~// Comment line~string name = \"Unity\";~public class Example { }~private void Update() { }~AudioSource.Play();~Vector3 direction = Vector3.forward;~Time.deltaTime;~Camera.main.transform;~Rigidbody.velocity;~Renderer.material.color;~Quaternion.Euler(0, 90, 0);~Physics.Raycast(origin, direction);~NavMeshAgent.SetDestination(target);~Animation.Play(\"Walk\");~Debug.DrawLine(start, end);~Application.Quit();~SceneManager.LoadScene(\"MainScene\");~Mathf.Clamp(value, min, max);~UIManager.Instance.ShowPanel();~playerHealth.TakeDamage(10);~Light.intensity = 2.0f;~AudioClip myClip;~List<string> myList = new List<string>();~Instantiate(prefab, position, rotation);~Destroy(gameObject);~bool isActive = true;~public delegate void MyEvent();~OnCollisionEnter(Collision collision);~Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);~Shader.SetGlobalColor(\"_Color\", Color.red);~Text.text = \"Updated!\";~new WaitForSeconds(1f);~Invoke(\"MyFunction\", 2f);~SetActive(true);~transform.localScale = Vector3.one;~ParticleSystem.Play();~Event.current.mousePosition;~GUILayout.Label(\"Label Text\");~EditorGUILayout.ColorField(Color.white);~Debug.LogError(\"An error occurred\");~transform.Rotate(Vector3.up * 90);~Material.SetFloat(\"_Glossiness\", 0.5f);~SceneManager.GetActiveScene().name;~Resources.Load<GameObject>(\"PrefabName\");~Physics.IgnoreCollision(collider1, collider2);~gameObject.layer = 8;~Mathf.Lerp(a, b, t);~Random.Range(0, 100);~Texture2D.Apply();~CanvasGroup.alpha = 1.0f;~new Rect(0, 0, 100, 100);~Cursor.lockState = CursorLockMode.None;~AnimationCurve.Evaluate(0.5f);~Color.Lerp(Color.red, Color.blue, 0.5f);~UI.Button(\"Click Me\");~System.DateTime.Now;~Screen.width;~Physics.gravity = new Vector3(0, -9.8f, 0);~new Vector2(Random.value, Random.value);~AudioListener.volume = 0.5f;~playerScore += 10;~";
        }
    }

    public void OnButtonClick() {
        if (audioSource != null) {
            audioSource.Play();
        }

        if (!isTyping && currentCharIndex < codeSnippets.Length) {
            char currentChar = codeSnippets[currentCharIndex];

            // Check if the current character is the line delimiter
            if (currentChar == '~') {
                codeText.text += "\n";
                lineCount++;
                earning += 10;

                // Clear text if 18 lines are written
                if (lineCount >= 15) {
                    codeText.text = "";
                    lineCount = 0;
                    earning += 40;
                }
                PlayerPrefs.SetInt("Earning", earning);
            }
            else {
                codeText.text += currentChar;
            }

            // Move to the next character
            currentCharIndex++;

            // If we reach the end of the string, reset
            if (currentCharIndex >= codeSnippets.Length) {
                currentCharIndex = 0;
                codeText.text += "\n--- Starting Over ---\n";
            }
        }
        earnedText.text = "Earned: $" + earning;
    }
}
