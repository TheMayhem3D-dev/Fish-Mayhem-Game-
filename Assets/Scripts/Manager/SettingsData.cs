using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SettingsData
{
    [Header("Settings (Screen)")]
    public int resolutionHeight;
    public int resolutionWidth;

    public int quality;
    public bool fullscreen;

    [Header("Settings (Volume)")]
    public float volumeSound;
    public float volumeMusic;

    [Header("Settings (Language)")]
    public string lang = "Rus/";

    public void SetDefaultValues()
    {
        // Значения настроек
        // Разрешение экрана
        resolutionHeight = Screen.currentResolution.height; // Высота экрана
        resolutionWidth = Screen.currentResolution.width; // Ширина экрана

        quality = 4; // Качество
        fullscreen = true; // Полный экран

        volumeSound = -10f; // Громкость звука
        volumeMusic = -10f; // Громкость музыки

        lang = "Rus/"; // Язык
    }
}
