using UnityEngine;
using DG.Tweening;

public class DayNighCycle : MonoBehaviour
{
    public Material dayMaterial;
    public Material nightMaterial;

    [SerializeField] [Range(0, 5)] private float lerpTime;
    bool change;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            change = true;

        if (change)
        {
            RenderSettings.skybox = dayMaterial;
            RenderSettings.skybox.Lerp(dayMaterial, nightMaterial, lerpTime * Time.deltaTime);
        }
        else
        {
            RenderSettings.skybox = nightMaterial;
            RenderSettings.skybox.Lerp(nightMaterial, dayMaterial, lerpTime * Time.deltaTime);
        }
    }
}
