using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject levelScreen;
    [SerializeField] private GameObject HighScorePanel;
    public TMP_Text[] scoreTexts;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Options()
    {

    }
    public void Levels()
    {
        if (mainScreen != null && levelScreen != null)
        {
            mainScreen.SetActive(false);
            levelScreen.SetActive(true);
        }
    }

    public void ShowHighScores()
    {
        HighScorePanel.SetActive(true);

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            scoreTexts[i].text = score.ToString();
        }
    }

    public void HideHighScores()
    {
        HighScorePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
