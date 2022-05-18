using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{   
    [SerializeField]
    private Text _playerName;
    [SerializeField]
    private Text _bestScore;
    [SerializeField]
    private InputField _inputText;

    private void Start()
    {
        DataManager.Instance.LoadData();
        _bestScore.text = $"Best Score. {DataManager.Instance?.BestScorePlayer} : {DataManager.Instance.BestScore}";
        if (DataManager.Instance.BestScorePlayer != null)
            _inputText.text = DataManager.Instance.BestScorePlayer;

    }
    public void StartNew()
    {
        DataManager.Instance.PlayerName = _playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
