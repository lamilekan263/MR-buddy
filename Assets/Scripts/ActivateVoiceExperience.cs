using UnityEngine;
using Oculus.Voice;

public class ActivateVoiceExperience : MonoBehaviour
{
    [SerializeField] private AppVoiceExperience _appVoiceExperience;
    [SerializeField] private AnimalController _animalController;

    void Awake()
    {
        if (_appVoiceExperience == null)
        {
            Debug.LogError("AppVoiceExperience not set in Inspector!");
            return;
        }

        // Hook into voice events for debugging
        _appVoiceExperience.VoiceEvents.OnResponse.AddListener(OnWitResponse);
        _appVoiceExperience.VoiceEvents.OnRequestCompleted.AddListener(OnRequestCompleted);
        _appVoiceExperience.VoiceEvents.OnError.AddListener(OnRequestError);
    }

    public void ActivateVoiceButtonClicked()
    {
        if (_appVoiceExperience.Active)
        {
            _appVoiceExperience.DeactivateAndAbortRequest();
            Debug.Log("App Voice Experience Deactivated");
        }
        else
        {
            _appVoiceExperience.Activate();
            Debug.Log("App Voice Experience Activated");
        }
    }

    private void OnRequestCompleted()
    {
        Debug.Log("Voice request completed.");
    }
    private void OnWitResponse(Meta.WitAi.Json.WitResponseNode response)
    {

        string text = response["text"];
        string intent = response["intents"][0]["name"];

        switch (intent)
        {
            case "angry_intent":
                _animalController._currentState = AnimalController._animalState.ANGRY;
                break;
            case "casual_walking_intent":
                _animalController._currentState = AnimalController._animalState.WALKING01;

                break;
            case "eating_intent":
                _animalController._currentState = AnimalController._animalState.EATING;
                break;
            case "idle_intent":
                _animalController._currentState = AnimalController._animalState.IDLE;
                break;
            case "playing_intent":
                _animalController._currentState = AnimalController._animalState.PLAYING;
                break;
            case "running_intent":
                _animalController._currentState = AnimalController._animalState.RUNNING;
                break;
            case "sitting_intent":
                _animalController._currentState = AnimalController._animalState.SITTING;
                break;
            default:
                Debug.Log("No matching intent found.");
                break;
        }
    }

    private void OnRequestError(string error, string message)
    {
        Debug.LogError($"Voice request error: {error} - {message}");
    }
}
