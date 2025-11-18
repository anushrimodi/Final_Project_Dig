using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource sfxSource;
    public AudioClip collectClip;
    public AudioClip wrongClip;

    public AudioClip LoseClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayCollect()
    {
        if (collectClip != null)
            sfxSource.PlayOneShot(collectClip);
    }

    public void PlayWrong()
    {
        if (wrongClip != null)
            sfxSource.PlayOneShot(wrongClip);
    }

    public void PlayLose()
    {
        if (LoseClip != null)
            sfxSource.PlayOneShot(LoseClip);
    }
}
