using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private string gameSceneName = "Game Scene";

    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;     
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject guidePanel;

    [Header("Audio")]
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private string gameplaySceneName = "Game Scene";

    

    private const string VolumeKey = "MasterVolume";

    private void Start()
    {
        // Load saved volume (default = 1)
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        AudioListener.volume = savedVolume;

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        ShowMain();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit (works only in build)");
    }

    public void ShowOptions()
    {
        if (mainPanel != null) mainPanel.SetActive(false);
        if (optionsPanel != null) optionsPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowMain()
    {
        if (optionsPanel != null) optionsPanel.SetActive(false);
        if (guidePanel != null) guidePanel.SetActive(false); // NEW
        if (mainPanel != null) mainPanel.SetActive(true);
    }

    public void ShowGuide()
    {
        if (mainPanel != null) mainPanel.SetActive(false);
        if (optionsPanel != null) optionsPanel.SetActive(false);
        if (guidePanel != null) guidePanel.SetActive(true);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save();
    }
}
