using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("-----------Audio Source-----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header ("-----------Audio Source-----------")]
    public AudioClip Gameplay;
    public AudioClip Menu;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip Victory;

    private void Start()
    {
        musicSource.clip = Gameplay;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}