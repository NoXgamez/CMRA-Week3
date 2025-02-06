using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using DG.Tweening;
using System;

[Serializable]
public class UIScreenDictionary : SerializableDictionaryBase<string, CanvasGroup> { }

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [SerializeField]
    UIScreenDictionary Screens;

    CanvasGroup currentScreen;
    public float FadeInOutTime = 0.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        ResetUI();
    }

    void ResetUI()
    {
        foreach (var screen in Screens.Values)
        screen.gameObject.SetActive(false);
    }

    public void ShowScreen(string screenName)
    {
        if(!Screens.ContainsKey(screenName))
            Debug.Log($"Screen with Key {screenName} does not exist.");
        else
        {
            CanvasGroup foundScreen = Screens[screenName];

            if (foundScreen == currentScreen)
                return;

            if (currentScreen)
                FadeOutScreen(currentScreen);

                currentScreen = foundScreen;
                FadeInScreen(currentScreen);
        }
    }

    void FadeInScreen(CanvasGroup screen)
    {
        screen.alpha = 0f;
        screen.gameObject.SetActive(true);
        screen.DOFade(1f, FadeInOutTime);
    }

    void FadeOutScreen(CanvasGroup screen)
    {
        screen.DOFade(0f, FadeInOutTime).OnComplete(() =>
        {
            screen.gameObject.SetActive(false);
        });
    }
}
