using System;
using System.Collections;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

[Serializable]
public class InteractionModesDictionary : SerializableDictionaryBase<string, GameObject> { }

public class InteractionManager : MonoBehaviour
{
public static InteractionManager Instance { get; private set; }

    [SerializeField]
    InteractionModesDictionary Modes;

    GameObject currentMode;

    [SerializeField]
    private string StartingMode = "Start";

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        ResetModes();
    }

    private void Start()
    {
        EnableMode(StartingMode);
    }

    void ResetModes()
    {
        foreach (var mode in Modes.Values)
        mode.SetActive(false);
    }

    public void EnableMode(string modeName)
    {
        if (!Modes.ContainsKey(modeName))
            Debug.Log($"Mode with key {modeName} does not exist.");
        else
        {
            GameObject foundMode = Modes[modeName];
            StartCoroutine(SwitchMode(foundMode));
        }
    }

    IEnumerator SwitchMode(GameObject mode)
    {
        if (mode == currentMode)
            yield break;

        if (currentMode)
        {
            currentMode.SetActive(false);
            yield return null;
        }

        currentMode = mode;
        mode.SetActive(true);
    }
}
