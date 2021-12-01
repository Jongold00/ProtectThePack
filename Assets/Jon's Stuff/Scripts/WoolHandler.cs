using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolHandler : MonoBehaviour
{

    #region SheepMaterial

    [SerializeField]
    Material grownWool;

    [SerializeField]
    Material cutWool;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Renderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    #endregion SheepMesh


    [SerializeField]
    private float totalRegrowTime;

    private float regrowTimer;

    [SerializeField]
    private int sellValue;


    public void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        regrowTimer = Mathf.Max(regrowTimer - Time.fixedDeltaTime, 0);

        if (regrowTimer <= 0)
        {
            ResetWool();
        }
    }


    public void Shear() {
        if (regrowTimer > 0)
        {
            return;
        }
        regrowTimer = totalRegrowTime;
        MoneyManager.Instance.AddMoney(sellValue);

        renderer.material = cutWool;
    }

    private void ResetWool()
    {
        renderer.material = grownWool;
    }

    public bool CanShear()
    {
        return (regrowTimer <= 0);
    }

}
