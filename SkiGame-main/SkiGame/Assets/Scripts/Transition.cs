using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private Image overlay;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private float fadeDuration;
    [SerializeField] private int nextLevelIndex;

    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private List<TextMeshProUGUI> leaderboardTexts;
    [SerializeField] private Leaderboard leaderboards;
    
    private void Start()
    {
        gameOverMenu.SetActive(false);
        leaderboardPanel.SetActive(false);
        StartCoroutine(FadeIn());
    }
    
    private void OnEnable()
    {
        GameEvents.raceEnd += EnableGameOver;
        GameEvents.QuitGame += Exit;
    }

    private void OnDisable()
    {
        GameEvents.raceEnd -= EnableGameOver;
        GameEvents.QuitGame -= Exit;
    }

    private void EnableGameOver()
    {
        gameOverMenu.SetActive(true);
        leaderboardPanel.SetActive(true);

        // Показываем топ-5 рекордов
        for (int i = 0; i < leaderboardTexts.Count; i++)
        {
            float time = PlayerPrefs.GetFloat("time" + i, 99999);
            if (time < 99999)
                leaderboardTexts[i].text = $"{i + 1}. {time:F2} sec";
            else
                leaderboardTexts[i].text = $"{i + 1}. ---";
        }
    }


    public void QuitButton()
    {
        GameEvents.CallQuit();
    }
    
    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine());
    }
    
    public void GoToNextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    public void Exit()
    {
        StartCoroutine(QuitCoroutine());
    }
    
    private IEnumerator FadeIn()
    {
        overlay.CrossFadeAlpha(0,fadeDuration,true);
        yield return new WaitForSeconds(fadeDuration);
    }

    private IEnumerator RestartCoroutine()
    {
        overlay.CrossFadeAlpha(1f,1f,true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator NextLevelCoroutine()
    {
        overlay.CrossFadeAlpha(1f,fadeDuration,true);
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(nextLevelIndex);
    }

    private IEnumerator QuitCoroutine()
    {
        overlay.CrossFadeAlpha(1f,fadeDuration,true);
        yield return new WaitForSeconds(fadeDuration);
        Application.Quit();
    }
}
