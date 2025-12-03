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
    public TextMeshProUGUI targetWordText;

    [Header("Collected Letter UI")]
    public Transform collectedLettersContainer;    // parent UI next to WORD: UNITY
    public GameObject letterBoxUIPrefab;           // prefab for collected letter block

    [Header("Meaning UI")]
    public GameObject meaningPanel;
    public TextMeshProUGUI meaningText;

    [Header("Lose / Restart UI")]
    public GameObject restartButton;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        collectedLetters.Clear();
        meaningPanel.SetActive(false);
        UpdateCollectedSlots();


        if (targetWordText != null)
            targetWordText.text = "WORD: " + targetWord;

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Called by LetterCollision when the bird hits a letter.
    /// Returns true only if this is a newly collected letter.
    /// </summary>
    public bool AddLetterAndReturnIfNew(char letter)
    {
        // Ignore letters that are not part of the target word
        if (!targetWord.Contains(letter))
            return false;

        // Add only if we haven't collected this letter yet
        if (collectedLetters.Add(letter))
        {
            UpdateCollectedSlots();

            if (AllLettersCollected())
                OnWordCompleted();

            return true; // new letter
        }

        return false; // letter already collected before
    }

    /// <summary>
    /// Spawns the letter UI block next to WORD: UNITY.
    /// </summary>
    private void UpdateCollectedSlots()
    {
        // Clear all children
        foreach (Transform child in collectedLettersContainer)
            Destroy(child.gameObject);

        // Rebuild UI slots in correct order
        foreach (char c in targetWord)
        {
            GameObject slot = Instantiate(letterBoxUIPrefab, collectedLettersContainer);

            var text = slot.GetComponentInChildren<TextMeshProUGUI>();

            if (collectedLetters.Contains(c))
                text.text = c.ToString();     // filled slot
            else
                text.text = "";               // empty slot
        }
    }


    /// <summary>
    /// Checks whether ALL letters in the target word have been collected.
    /// </summary>
    private bool AllLettersCollected()
    {
        foreach (char c in targetWord)
        {
            if (!collectedLetters.Contains(c))
                return false;
        }
        return true;
    }

    /// <summary>
    /// Called when all letters of the word are collected.
    /// Pauses game and shows meaning panel and restart button.
    /// </summary>
    private void OnWordCompleted()
    {
        Time.timeScale = 0f;

        meaningPanel.SetActive(true);

        if (restartButton != null)
            restartButton.SetActive(true);

        meaningText.text =
            targetWord + ":\nThe state of being united or joined as a whole.";
    }

    /// <summary>
    /// Restart the current level.
    /// </summary>
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
