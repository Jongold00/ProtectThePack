using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotkeyAbilitySystem : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ObjectPlacer.Instance.ChooseBarricade(0);
            ItemSelector.instance.ChangeOverlay(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ObjectPlacer.Instance.ChooseBarricade(1);
            ItemSelector.instance.ChangeOverlay(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ObjectPlacer.Instance.ChooseBarricade(2);
            ItemSelector.instance.ChangeOverlay(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ObjectPlacer.Instance.ChooseBarricade(3);
            ItemSelector.instance.ChangeOverlay(3);

        }
    }
}
