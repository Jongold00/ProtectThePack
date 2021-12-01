using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSheepShear : MonoBehaviour
{
    public float raycastDistance;
    [SerializeField]
    GameObject ShearUI;
    void Update()
    {
        if (!ObjectPlacer.Instance.placementMode)
        {
            RaycastHit hit;

            bool success = Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance);



            //print("success" + success);

            if (success && hit.transform.gameObject.CompareTag("sheep"))
            {

                WoolHandler targetSheep = hit.transform.gameObject.GetComponent<WoolHandler>();

                if (targetSheep.CanShear())
                {
                    ShearUI.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        targetSheep.Shear();
                    }
                }
                else
                {
                    ShearUI.SetActive(false);
                }

                hit.transform.gameObject.GetComponent<WoolHandler>();
            }
            else
            {
                ShearUI.SetActive(false);
            }
        }   
    }
}
