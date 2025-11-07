using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Word Settings")]
    public string targetWord = "UNITY";
    private string collectedWord = "";

    [Header("UI References")]
    public TextMeshProUGUI collectedWordText; // Assign in inspector
    public GameObject meaningPanel;           // Assign in inspector (panel GameObject)
    public TextMeshProUGUI meaningText;       // Assign in inspector (text inside panel)

    public TextMeshProUGUI targetWordText;

    private void Awake()
    {
        // singleton-ish
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Ensure UI initial state
        collectedWord = "";
        if (collectedWordText != null) collectedWordText.text = "";
        meaningPanel.SetActive(false);
        if (targetWordText != null)
            targetWordText.text = "WORD: " + targetWord;

        Time.timeScale = 1f;
    }

    // public void AddLetter(char letter)
    // {
    //     collectedWord += letter;
    //     if (collectedWordText != null)
    //         collectedWordText.text = collectedWord;

    //     if (collectedWord.Equals(targetWord))
    //         OnWordCompleted();
    // }
    
    public void AddLetter(char letter)
    {
        collectedWord += letter;

        string display = "";
        for (int i = 0; i < targetWord.Length; i++)
        {
            if (i < collectedWord.Length)
                display += collectedWord[i] + " ";
            else
                display += "_ ";
        }

        collectedWordText.text = display;
        
        if (collectedWord.Equals(targetWord))
            OnWordCompleted();
    }


    private void OnWordCompleted()
    {
        // Pause the game
        Time.timeScale = 0f;

        if (meaningPanel != null)
        {
            meaningPanel.SetActive(true);
            if (meaningText != null)
            {
                meaningText.text = "UNITY:\nThe state of being united or joined as a whole.";
            }
        }
    }

    // Hook this to the Restart button OnClick
    public void RestartLevel()
    {
        // Unpause first (important because Time.timeScale was 0)
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
