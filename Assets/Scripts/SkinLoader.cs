using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public GameObject defaultSkin;
    public static GameObject skinToLoad;

    private void Awake()
    {
        if (skinToLoad != null)
        {
            defaultSkin.SetActive(false);
            Instantiate(skinToLoad, transform);
        }
    }
}
