using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;           // List of all resolutions and refresh rates of the screen
    private List<Resolution> resolutionsFilter; // Filter list for the resolution list
    public int currentScreenResolution;         // Current resolution of the screen
    public float currentAspectRatio;            // Current Aspect ratio of the screen

    // Start is called before the first frame update
    void Start()
    {   // Finds all the available resolutions of the screen
        resolutions = Screen.resolutions;
        resolutionsFilter = new List<Resolution>();
        
        // Clears the dropdown menu of placeholder options
        resolutionDropdown.ClearOptions();
        
        // Finds the current aspect ratio the screen is in
        currentAspectRatio = (float)Screen.currentResolution.width / Screen.currentResolution.height;
        
        // Loops through the list and filters out all resolutions off the wrong aspect ratio
        for (int i = resolutions.Length - 1; i >= 0; i--)
        {
            float aspectRatio = (float)resolutions[i].width / resolutions[i].height;
            if (aspectRatio == currentAspectRatio)
            {
                resolutionsFilter.Add(resolutions[i]);
            }
        }
        
        // Makes a final list of resolutions for the dropdown menu
        List<string> optionsOfDropdown = new List<string>();

        // Loops through the filtered resolutions and formats them and adds them to the dropdown menu
        for (int i = 0; i < resolutionsFilter.Count; i++)
        {
            string resolutionOption = resolutionsFilter[i].width + "x" +  
                                      resolutionsFilter[i].height + " : " +  
                                      resolutionsFilter[i].refreshRate + "Hz";
            optionsOfDropdown.Add(resolutionOption);
            
            // Finds the formatted current resolution of the screen 
            if (resolutionsFilter[i].width == Screen.width && resolutionsFilter[i].height == Screen.height)
            {
                currentScreenResolution = i;
            }
        }
        
        // Adds all the resolutions to the menu, sets the correct default value and updates the list
        resolutionDropdown.AddOptions(optionsOfDropdown);
        resolutionDropdown.value = currentScreenResolution;
        resolutionDropdown.RefreshShownValue();
    }

    // Sets the resolution and refresh rate of the game to the inputted value
    public void SetResolutionOfGame(int resolutionChange)
    {
        Resolution resolution = resolutionsFilter[resolutionChange];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
