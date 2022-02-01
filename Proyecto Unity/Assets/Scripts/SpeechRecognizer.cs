using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SpeechRecognizerPlugin;

public class SpeechRecognizer : MonoBehaviour, ISpeechRecognizerPlugin {
    [SerializeField] private Button startListeningBtn = null;
    [SerializeField] private Text resultsTxt = null;
    [SerializeField] private Text errorsTxt = null;

    private SpeechRecognizerPlugin plugin = null;

    private void Start() {
        plugin = SpeechRecognizerPlugin.GetPlatformPluginVersion(this.gameObject.name);
        startListeningBtn.onClick.AddListener(StartListening);
    }

    private void StartListening() {
        plugin.StartListening(true, "en-US", 1);
    }

    private void StopListening() {}

    private void SetContinuousListening(bool isContinuous) {}

    private void SetLanguage(int dropdownValue) {}

    private void SetMaxResults(string inputValue) {}

    public void OnResult(string recognizedResult)
    {
        char[] delimiterChars = { '~' };
        string[] result = recognizedResult.Split(delimiterChars);

        resultsTxt.text = "";
        for (int i = 0; i < result.Length; i++)
        {
            resultsTxt.text += result[i];
        }
    }

    public void OnError(string recognizedError)
    {
        ERROR error = (ERROR)int.Parse(recognizedError);
        switch (error)
        {
            case ERROR.UNKNOWN:
                Debug.Log("<b>ERROR: </b> Unknown");
                errorsTxt.text += "Unknown";
                break;
            case ERROR.INVALID_LANGUAGE_FORMAT:
                Debug.Log("<b>ERROR: </b> Language format is not valid");
                errorsTxt.text += "Language format is not valid";
                break;
            default:
                break;
        }
    }
}
