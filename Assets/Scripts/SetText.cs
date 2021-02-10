using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _preText;
    [SerializeField] private string _playerPrefsString;
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = _preText + PlayerPrefs.GetInt(_playerPrefsString);
    }

    public void UpdateText()
    {
        _text.text = _preText + PlayerPrefs.GetInt(_playerPrefsString).ToString();
        Debug.Log("updated");
    }
}
