using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public enum SceneName
    {
        BlizzardBlast,
        WheresMymom,
        SaveThePenguins,
        FeedThePolarBear
    }
    public static bool isInMainArea;
    public static SceneName currentScene;
    public static WheresMyMomData wheresMyMomData = new WheresMyMomData();
}
