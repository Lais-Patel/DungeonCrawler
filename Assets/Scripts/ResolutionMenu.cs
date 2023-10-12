using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> resolutionsFilter;

    private float currentScreenRefreshRate;
    private int currentScreenResolution = 0;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsFilter = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentScreenRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentScreenRefreshRate)
            {
                resolutionsFilter.Add(resolutions[i]);
            }
        }

        List<string> optionsOfDropdown = new List<string>();

        for (int i = resolutionsFilter.Count - 1; i >= 0; i--)
        {
            string resolutionOption = resolutionsFilter[i].width + "x" +  resolutionsFilter[i].height + " : " +  resolutionsFilter[i].refreshRate + "Hz";
            optionsOfDropdown.Add(resolutionOption);
            if (resolutionsFilter[i].width == Screen.width && resolutionsFilter[i].height == Screen.height)
            {
                currentScreenResolution = i - resolutionsFilter.Count - 1;
            }
        }

        resolutionDropdown.AddOptions(optionsOfDropdown);
        resolutionDropdown.value = currentScreenResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolutionOfGame(int resolutionChange)
    {
        Resolution resolution = resolutionsFilter[resolutionChange];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
