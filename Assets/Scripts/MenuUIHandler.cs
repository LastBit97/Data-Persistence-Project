using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{   
    [SerializeField]
    private Text _playerName;
    [SerializeField]
    private Text _bestScore;

    private void Start()
    {
        DataManager.Instance.LoadData();
        _bestScore.text = $"Best Score. {DataManager.Instance?.PlayerName} : {DataManager.Instance.BestScore}";
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
