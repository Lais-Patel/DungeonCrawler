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
    public int currentScreenResolution;

    public float currentAspectRatio;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsFilter = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentScreenRefreshRate = Screen.currentResolution.refreshRate;
        currentAspectRatio = (float)Screen.currentResolution.width / Screen.currentResolution.height;
        Debug.Log("CurrentAspectRatio:   " + currentAspectRatio);
        for (int i = resolutions.Length - 1; i >= 0; i--)
        {
            float aspectRatio = (float)resolutions[i].width / resolutions[i].height;
            Debug.Log("Checking aspect: " + aspectRatio);
            if (aspectRatio == currentAspectRatio)
            {
                resolutionsFilter.Add(resolutions[i]);
            }
        }

        List<string> optionsOfDropdown = new List<string>();

        for (int i = 0; i < resolutionsFilter.Count; i++)
        {
            string resolutionOption = resolutionsFilter[i].width + "x" +  resolutionsFilter[i].height + " : " +  resolutionsFilter[i].refreshRate + "Hz";
            optionsOfDropdown.Add(resolutionOption);
            if (resolutionsFilter[i].width == Screen.width && resolutionsFilter[i].height == Screen.height)
            {
                currentScreenResolution = i;
            }
        }

        resolutionDropdown.AddOptions(optionsOfDropdown);
        resolutionDropdown.value = currentScreenResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolutionOfGame(int resolutionChange)
    {
        Debug.Log("Changing resolution to: " + resolutionsFilter[resolutionChange].width + "x" + resolutionsFilter[resolutionChange].height);
        Resolution resolution = resolutionsFilter[resolutionChange];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
