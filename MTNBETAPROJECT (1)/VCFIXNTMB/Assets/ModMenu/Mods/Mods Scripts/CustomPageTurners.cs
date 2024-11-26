using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class CustomPageTurners : MonoBehaviour
{
    [Header("SCRIPT BY KALBITE... DO NOT STEAL!!!")]
	public GameObject nextPage;
	public GameObject previousPage;
	public GameObject currentPage;
	public bool usingBothTriggers;
	public bool usingBothGrips;
	public bool usingBothPrimary;
	public EasyHand rightHand;
	public EasyHand leftHand;
	private bool usingNothing;

	
	void Update()
	{
	    if (usingBothTriggers)
		{
			if (EasyInputs.GetTriggerButtonDown(leftHand))
			{
			    previousPage.SetActive(true);
				currentPage.SetActive(false);
				nextPage.SetActive(false);
			}

			if (EasyInputs.GetTriggerButtonDown(rightHand))
			{
				nextPage.SetActive(true);
				previousPage.SetActive(false);
				currentPage.SetActive(false);
			}
		}

		if (usingBothGrips)
		{
			if (EasyInputs.GetGripButtonDown(leftHand))
			{
				previousPage.SetActive(true);
				currentPage.SetActive(false);
				nextPage.SetActive(false);
			}

			if (EasyInputs.GetGripButtonDown(rightHand))
			{
			    nextPage.SetActive(true);
				previousPage.SetActive(false);
				currentPage.SetActive(false);
			}
		}

		if (usingBothPrimary)
		{
			if (EasyInputs.GetPrimaryButtonDown(leftHand))
			{
				previousPage.SetActive(true);
				currentPage.SetActive(false);
				nextPage.SetActive(false);
			}

			if (EasyInputs.GetPrimaryButtonDown(rightHand))
			{
				nextPage.SetActive(true);
				previousPage.SetActive(false);
				currentPage.SetActive(false);
			}
		}
	}
}
