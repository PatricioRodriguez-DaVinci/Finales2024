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
    [SerializeField] private AudioClip _errorClip;

    public void PlaySFX(AudioClip clip)
    {
        _source.clip = clip;

        if (_source.clip != null)
        {
            _source.PlayOneShot(clip);
        }

        else
        {
            Debug.LogWarning("Falta asignar clip de audio");
            _source.clip = _errorClip;
            _source.Play();
        }
    }
}
