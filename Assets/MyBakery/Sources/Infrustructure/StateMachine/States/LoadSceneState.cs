using System;
using Virvon.StateMachineModul;

public class LoadSceneState : IPayloadState<string>
{
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingPanel _loadingPanel;

    public LoadSceneState(SceneLoader sceneLoader, LoadingPanel loadingPanel)
    {
        _sceneLoader = sceneLoader;
        _loadingPanel = loadingPanel;
    }

    public void Enter(string sceneName, Action callback)
    {
        _sceneLoader.Load(sceneName, callback);

        _loadingPanel.Open();
    }

    public void Exit() =>
        _loadingPanel.Close();
}
