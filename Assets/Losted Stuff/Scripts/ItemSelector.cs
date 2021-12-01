using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public static ItemSelector instance;
    public GameObject[] overlayGameobjets;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeOverlay(int item)
    {
        switch (item)
        {
            case 0:
                overlayGameobjets[0].SetActive(true);
                overlayGameobjets[1].SetActive(false);
                overlayGameobjets[2].SetActive(false);
                overlayGameobjets[3].SetActive(false);

                break;
            case 1:
                overlayGameobjets[0].SetActive(false);
                overlayGameobjets[1].SetActive(true);
                overlayGameobjets[2].SetActive(false);
                overlayGameobjets[3].SetActive(false);
                break;
            case 2:
                overlayGameobjets[0].SetActive(false);
                overlayGameobjets[1].SetActive(false);
                overlayGameobjets[2].SetActive(true);
                overlayGameobjets[3].SetActive(false);
                break;
            case 3:
                overlayGameobjets[0].SetActive(false);
                overlayGameobjets[1].SetActive(false);
                overlayGameobjets[2].SetActive(false);
                overlayGameobjets[3].SetActive(true);
                break;
        }
    }
}   
