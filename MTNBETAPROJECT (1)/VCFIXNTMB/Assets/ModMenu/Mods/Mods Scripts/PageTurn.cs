using System.Collections;
using GorillaNetworking;
using UnityEngine;
using System.Collections.Generic;

public class PageTurn : GorillaPressableButton
{
    [System.Serializable]
    public class ToggledObject
    {
        public GameObject gameObject;
        public Material toggledMaterial;
        public Material originalMaterial;
    }

    public List<ToggledObject> ObjectsToToggle;
    public List<GameObject> Pages; // List of pages to toggle between
    public float buttonFadeTime = 0.25f;

    private bool isButtonToggled = false;
    private bool wasButtonToggled = false;
    private int currentPageIndex = 0; // Index of the current page

    public override void ButtonActivation()
    {
        wasButtonToggled = isButtonToggled;
        isButtonToggled = !isButtonToggled; // Toggle the button state

        foreach (ToggledObject toggledObject in ObjectsToToggle)
        {
            toggledObject.gameObject.SetActive(isButtonToggled);
            Renderer objectRenderer = toggledObject.gameObject.GetComponent<Renderer>();

            if (objectRenderer != null)
            {
                if (isButtonToggled)
                {
                    objectRenderer.material = toggledObject.toggledMaterial;
                }
                else
                {
                    objectRenderer.material = toggledObject.originalMaterial;
                }
            }
        }

        // Toggle between pages
        if (isButtonToggled)
        {
            currentPageIndex = (currentPageIndex + 1) % Pages.Count;
        }

        // Set the active state of pages based on the current page index
        for (int i = 0; i < Pages.Count; i++)
        {
            Pages[i].SetActive(i == currentPageIndex);
        }

        base.ButtonActivation();
        StartCoroutine(ButtonColorUpdate());
    }

    private IEnumerator ButtonColorUpdate()
    {
        buttonRenderer.material = pressedMaterial;

        if (!isButtonToggled && wasButtonToggled)
        {
            buttonRenderer.material = unpressedMaterial;
        }

        yield return new WaitForSeconds(buttonFadeTime);

        if (!isButtonToggled)
        {
            buttonRenderer.material = unpressedMaterial;
        }
    }
}