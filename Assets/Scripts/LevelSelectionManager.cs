using UnityEngine;
using TMPro;  // For TextMeshPro
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    // References to UI elements
    public GameObject panel;                  // The panel that shows level details
    public TextMeshProUGUI nameLevelText;     // TMP object for the level name (NameLevel)
    public TextMeshProUGUI factLevelText;     // TMP object for the level description (FactLevel)
    public TextMeshProUGUI taskLevelText;     // TMP object for the task description (TaskLevel)

    // Serialized fields for custom text input in the Inspector for each level
    [Header("Level 1 Details")]
    public string level1Name = "Level 1";
    public string level1Fact = "This is the first level.";
    public string level1Task = "Collect all the coins to win.";

    [Header("Level 2 Details")]
    public string level2Name = "Level 2";
    public string level2Fact = "This is the second level.";
    public string level2Task = "Reach the finish line.";

    private string currentLevelName;          // Store the name of the selected level

    // This function is called when a level button is clicked
    public void ShowLevelDetails(string levelName, string levelDisplayName, string fact, string task)
    {
        currentLevelName = levelName;         // Store the current level name (e.g., "Level1")
        panel.SetActive(true);                // Show the panel

        // Update the TMP text elements with the level information
        nameLevelText.text = levelDisplayName;
        factLevelText.text = fact;
        taskLevelText.text = task;
    }

    // This function is called when the Return button is pressed
    public void CloseLevelDetails()
    {
        panel.SetActive(false);               // Hide the details panel
    }

    // This function is called when the Start button is pressed
    public void StartLevel()
    {
        // Load the scene using the stored level name (e.g., "Level1")
        SceneManager.LoadScene(currentLevelName);
    }

    // Wrapper method to display details for Level 1 (values are set in the Inspector)
    public void ShowLevel1Details()
    {
        ShowLevelDetails("Level1", level1Name, level1Fact, level1Task);
    }

    // Wrapper method to display details for Level 2 (values are set in the Inspector)
    public void ShowLevel2Details()
    {
        ShowLevelDetails("Level2", level2Name, level2Fact, level2Task);
    }

    // Repeat similar wrapper functions for each level button if needed
}
