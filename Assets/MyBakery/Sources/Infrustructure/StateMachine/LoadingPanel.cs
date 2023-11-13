using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] private GameObject _background;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Open()
    {
        _background.SetActive(true);
    }

    public void Close()
    {
        _background.SetActive(false);
    }
}