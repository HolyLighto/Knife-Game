using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    private Text _text;
    private string _preText;
    private void Start()
    {
        _text = GetComponent<Text>();
        _preText = _text.text;
        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = _preText + ScoreAndStage.Stage;
    }
}
