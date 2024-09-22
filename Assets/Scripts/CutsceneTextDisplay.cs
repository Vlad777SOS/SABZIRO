using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this to manage scene loading

public class CutsceneTextDisplay : MonoBehaviour
{
    [TextArea(3, 10)]
    public string fullText; // Input full text in Inspector

    public TextMeshProUGUI uiText; // TextMeshPro text field
    public Button continueButton; // Reference to the "Click to Continue" button
    public int linesPerDisplay = 3; // Number of lines per display
    public float typingSpeed = 0.05f; // Speed of text appearance
    public string nextSceneName; // Name of the next scene to load

    private List<string> textChunks = new List<string>(); // Store chunks of text
    private int currentChunkIndex = 0; // Keep track of current chunk
    private bool isTyping = false; // Check if the text is currently typing
    private bool skipTyping = false; // Flag to skip the typing animation

    void Start()
    {
        continueButton.gameObject.SetActive(false); // Hide the button at the start

        // Split the text into paragraphs or lines, ensuring that paragraph breaks are preserved
        string[] lines = fullText.Split(new[] { "\n\n" }, System.StringSplitOptions.None); // Split by double newlines (paragraphs)

        for (int i = 0; i < lines.Length; i += linesPerDisplay)
        {
            // Combine paragraphs back into text chunks of size `linesPerDisplay`
            textChunks.Add(string.Join("\n\n", lines, i, Mathf.Min(linesPerDisplay, lines.Length - i)));
        }

        // Start displaying the first chunk
        DisplayCurrentChunk();
    }

    void Update()
    {
        // Handle user input to skip the typing animation or move to the next chunk
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                skipTyping = true; // Skip typing if the text is still typing
            }
        }
    }

    void DisplayCurrentChunk()
    {
        if (currentChunkIndex < textChunks.Count)
        {
            continueButton.gameObject.SetActive(false); // Hide the button while typing
            StartCoroutine(TypeText(textChunks[currentChunkIndex]));
        }
    }

    IEnumerator TypeText(string chunk)
    {
        isTyping = true;
        uiText.text = ""; // Clear the UI text before typing begins

        foreach (char letter in chunk.ToCharArray())
        {
            if (skipTyping)
            {
                uiText.text = chunk; // Immediately display the entire chunk if skipTyping is true
                break;
            }
            uiText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Adjust typing speed
        }

        isTyping = false;
        skipTyping = false;

        // Show the button after typing finishes
        continueButton.gameObject.SetActive(true);
    }

    public void OnContinueButtonPressed()
    {
        // If there are more chunks, display the next chunk
        if (currentChunkIndex < textChunks.Count - 1)
        {
            currentChunkIndex++;
            DisplayCurrentChunk();
        }
        else
        {
            // If all chunks are displayed, load the next scene
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Load the next scene if a valid scene name is set
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}
