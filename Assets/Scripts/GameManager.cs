using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Word Settings")]
    public string targetWord = "UNITY";
    private HashSet<char> collectedLetters = new HashSet<char>();

    [Header("UI References")]
    public TextMeshProUGUI collectedWordText;
    public GameObject meaningPanel;
    public TextMeshProUGUI meaningText;
    public TextMeshProUGUI targetWordText;

    [Header("Lose UI")]
    public GameObject restartButton;   // button after completing the word

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        collectedLetters.Clear();
        meaningPanel.SetActive(false);

        if (targetWordText != null)
            targetWordText.text = "WORD: " + targetWord;

        UpdateCollectedWordUI();
        Time.timeScale = 1f;
    }

public bool AddLetterAndReturnIfNew(char letter)
{
    // Ignore fake letters
    if (!targetWord.Contains(letter))
        return false;

    // Add only if not already collected
    if (collectedLetters.Add(letter))
    {
        UpdateCollectedWordUI();

        if (AllLettersCollected())
            OnWordCompleted();

        return true; // NEW letter added
    }

    return false; // Already had this letter before
}


    private bool AllLettersCollected()
    {
        foreach (char c in targetWord)
        {
            if (!collectedLetters.Contains(c))
                return false;
        }
        return true;
    }

    private void UpdateCollectedWordUI()
    {
        string display = "";
        foreach (char c in targetWord)
        {
            display += collectedLetters.Contains(c) ? c + " " : "_ ";
        }
        collectedWordText.text = display;
    }

    private void OnWordCompleted()
    {
        Time.timeScale = 0f;

        // show meaning panel
        meaningPanel.SetActive(true);

        // OPTIONAL: show restart button if it's separate
        if (restartButton != null)
            restartButton.SetActive(true);

        meaningText.text = 
            "UNITY:\nThe state of being united or joined as a whole.";
    }


    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
