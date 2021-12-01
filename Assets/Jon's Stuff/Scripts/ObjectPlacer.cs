using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    #region Instantiatables
    [SerializeField] private List<PlaceableObjecSO> placedObjectTypeSO = null;
    private PlaceableObjecSO placeableObjecSO;

    [SerializeField]
    GameObject fencePrefab;

    [SerializeField]
    GameObject fencePrefabPreview;

    #endregion Instantiatables

    #region PlacementVariables
    public bool placementMode = false;

    private GameObject currentPlacement;

    private Vector3 currentPlacementRotation = new Vector3(0, 0, 0);

    private bool snapPointsSatisfied = false;


    public GameObject placementGrid;
    #endregion PlacementVariables

    #region Materials

    [SerializeField]
    Material placementBad;

    [SerializeField]
    Material placementGood;

    #endregion Materials

    private GameObject player;

    #region Singleton

    private static ObjectPlacer _instance;

    public static ObjectPlacer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ObjectPlacer>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        placeableObjecSO = placedObjectTypeSO[0];
        DontDestroyOnLoad(gameObject);
    }

    #endregion Singleton


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePlacementMode();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RotatePlacement();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (placementMode && snapPointsSatisfied)
            {
                FinalizePlacement();
            }
        }

        if (placementMode)
        {
            snapPointsSatisfied = false;
            placementGrid.SetActive(true);
            if (currentPlacement == null)
            {
                currentPlacement = Instantiate(placeableObjecSO.prefabsPreview.transform.GetChild(0).gameObject);
            }

            Vector3 placementPos = player.transform.position + (player.transform.forward * 5);



            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider[] hitColliders = Physics.OverlapSphere(placementPos, 1.1f);
            foreach (Collider curr in hitColliders)
            {
                if (curr.gameObject.GetComponent<SnapPoint>() != null)
                {
                    placementPos = curr.transform.position;
                    snapPointsSatisfied = true;
                    break;
                }
            }



            currentPlacement.transform.position = placementPos + new Vector3(0, 1f, 0);
            currentPlacement.transform.LookAt(player.transform);
            currentPlacement.transform.rotation = Quaternion.Euler(currentPlacementRotation.x, currentPlacementRotation.y, currentPlacementRotation.z);

            if (snapPointsSatisfied)
            {
                currentPlacement.GetComponent<Renderer>().material = placementGood;
                //placementGrid.GetComponent<Renderer>().material = placementGood;
            }

            else
            {
                currentPlacement.GetComponent<Renderer>().material = placementBad;
            }
        }

        if (!placementMode)
        {
            placementGrid.SetActive(false);


            if (currentPlacement != null)
            {
                DestroyCurrentPlacement();
            }
        }
    }

    public void TogglePlacementMode()
    {
        placementMode = !placementMode;
    }

    public void RotatePlacement()
    {
        currentPlacementRotation.y += 90f;
    }

    public void FinalizePlacement()
    {
        GameObject finalized = Instantiate(placeableObjecSO.prefabs);
        finalized.transform.position = currentPlacement.transform.position;
        finalized.transform.rotation = currentPlacement.transform.rotation;
        TogglePlacementMode();
    }

    public void ChooseBarricade(int value)
    {
        placeableObjecSO = placedObjectTypeSO[value];
        Destroy(currentPlacement);
        currentPlacement = null;
    }

    private void DestroyCurrentPlacement()
    {
        foreach (StructureSnapPoint curr in currentPlacement.GetComponentsInChildren<StructureSnapPoint>())
        {
            curr.Delete();
        }
        Destroy(currentPlacement);
        currentPlacement = null;
    }

}
