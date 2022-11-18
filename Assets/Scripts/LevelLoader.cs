using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField]
    private MeshRenderer _blocking;

    private Material _material;

    void Start()
    {
        _material = _blocking.material;
        _material.DOFade(0f, 1.5f).onComplete += () =>
        {
            _blocking.gameObject.SetActive(false);
        };
    }
    public void LoadNextLevel()
    {
        _blocking.gameObject.SetActive(true);
        _material.DOFade(1f, 1.5f).onComplete += () =>
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        };

    }
}
