using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Audio Manager")]
    [SerializeField] private AudioSource _source;

    public void PlaySFX(AudioClip clip)
    {
        _source.Stop();
        _source.clip = clip;
        _source.Play();
    }
}
