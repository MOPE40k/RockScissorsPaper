using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Toggle _opponentAiToggle;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _opponentName;

    public bool opponentAi
    {
        get { return PlayerPrefs.GetInt("OpponentAi", 1) == 1 ? true : false; }
        set { PlayerPrefs.SetInt("OpponentAi", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public string playerName
    {
        get { return PlayerPrefs.GetString("PlayerName", "Player"); }
        set { PlayerPrefs.SetString("PlayerName", value);
            PlayerPrefs.Save();
        }
    }
    public string opponentName
    {
        get { return PlayerPrefs.GetString("OpponentName", "Opponent"); }
        set { PlayerPrefs.SetString("OpponentName", value);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        _opponentAiToggle.isOn = opponentAi;
        _playerName.text = playerName;
        _opponentName.text = opponentName;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            Debug.Log("PlayerPrefs DELETED");
        }
    }
#endif

    public void SetOpponentIsAi()
    {
        opponentAi = _opponentAiToggle.isOn;
    }

    public void SetPlayerName()
    {
        this.playerName = _playerName.text;
    }

    public void SetOpponentName()
    {
        this.opponentName = _opponentName.text;
    }
}
