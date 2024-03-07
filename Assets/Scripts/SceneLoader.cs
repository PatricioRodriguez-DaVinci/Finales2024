using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Loader")]
    [SerializeField] private KeyCode _loadSceneButton = KeyCode.Space;

    [Header("UI Elements")]
    [SerializeField] private Image _loadBarParent;
    [SerializeField] private Image _loadBar;
    [SerializeField] private Color _loadBarProgressColor = Color.red;
    [SerializeField] private Color _loadBarDoneColor = Color.green;
    [SerializeField] private TMP_Text _pressButtonText;
    [SerializeField] private TMP_Text _loadingText;


    private bool _isAsyncLoading;
    public bool IsAsyncLoading { get { return _isAsyncLoading; } }

    private void Start()
    {
        _loadBar.fillAmount = 0f;
        _loadBarParent.enabled = false;
    }

    public void LoadSceneRaw(string sceneToLoad)
    {
        if (_isAsyncLoading) return;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadSceneAsync(string sceneToLoad)
    {
        if (_isAsyncLoading) return;
        StartCoroutine(crAsyncLoad(sceneToLoad));
    }

    private IEnumerator crAsyncLoad(string sceneToLoad)
    {
        _isAsyncLoading = true;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;
        _loadBarParent.enabled = true;
        _loadBar.color = _loadBarProgressColor;

        while(asyncLoad.progress < .9f /*o !asyncLoad.isDone*/)
        {
            _loadBar.fillAmount = asyncLoad.progress / .9f;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        _loadBar.color = _loadBarDoneColor;

        _pressButtonText.text = "Press Space Bar to continue";
        _loadingText.text = "Complete!";

        while (!Input.GetKeyDown(_loadSceneButton))
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }
}
