using UnityEngine;

public class VerticalLever : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float triggerPoint;

    private bool activated = false;
    private Vector3 startPosition;

    [SerializeField] private GameObject OffScreens = null;

    // LIGHT GROUPS
    [SerializeField] private GameObject RectangleLights;
    [SerializeField] private GameObject ArtisticLights1;
    [SerializeField] private GameObject ArtisticLights2;
    [SerializeField] private GameObject CeilingLights;
    [SerializeField] private GameObject BarLights;
    [SerializeField] private GameObject BasketBallLight1;
    [SerializeField] private GameObject BasketBallLight2;
    [SerializeField] private GameObject PacMan;

    // MATERIALS
    [SerializeField] private Material RectangleMaterial;
    [SerializeField] private Material ArtisticMaterial1;
    [SerializeField] private Material ArtisticMaterial2;
    [SerializeField] private Material CeilingMaterial;
    [SerializeField] private Material BarMaterial;
    [SerializeField] private Material BasketBallMaterial1;
    [SerializeField] private Material BasketBallMaterial2;
    [SerializeField] private Material PacManMaterial;

    // Cached renderers
    private Renderer[] rectangleRenderers;
    private Renderer[] artistic1Renderers;
    private Renderer[] artistic2Renderers;
    private Renderer[] ceilingRenderers;
    private Renderer[] barRenderers;
    private Renderer[] basketball1Renderers;
    private Renderer[] basketball2Renderers;
    private Renderer[] pacmanRenderers;

    void Start()
    {
        startPosition = transform.position;

        maxY = startPosition.y;
        minY = startPosition.y - 0.31f;
        triggerPoint = minY + 0.1f;

        // Cache all renderers in each group
        if (RectangleLights) rectangleRenderers = RectangleLights.GetComponentsInChildren<Renderer>();
        if (ArtisticLights1) artistic1Renderers = ArtisticLights1.GetComponentsInChildren<Renderer>();
        if (ArtisticLights2) artistic2Renderers = ArtisticLights2.GetComponentsInChildren<Renderer>();
        if (CeilingLights) ceilingRenderers = CeilingLights.GetComponentsInChildren<Renderer>();
        if (BarLights) barRenderers = BarLights.GetComponentsInChildren<Renderer>();
        if (BasketBallLight1) basketball1Renderers = BasketBallLight1.GetComponentsInChildren<Renderer>();
        if (BasketBallLight2) basketball2Renderers = BasketBallLight2.GetComponentsInChildren<Renderer>();
        if (PacMan) pacmanRenderers = PacMan.GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = startPosition.x;
        pos.z = startPosition.z;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        if (!activated && pos.y <= triggerPoint)
        {
            activated = true;
            Activate();
        }
    }

    void Activate()
    {
        ChangeMaterials(rectangleRenderers, RectangleMaterial);
        ChangeMaterials(artistic1Renderers, ArtisticMaterial1);
        ChangeMaterials(artistic2Renderers, ArtisticMaterial2);
        ChangeMaterials(ceilingRenderers, CeilingMaterial);
        ChangeMaterials(barRenderers, BarMaterial);
        ChangeMaterials(basketball1Renderers, BasketBallMaterial1);
        ChangeMaterials(basketball2Renderers, BasketBallMaterial2);
        ChangeMaterials(pacmanRenderers, PacManMaterial);

        if (OffScreens != null)
        {
            OffScreens.SetActive(false);
        }
    }

    void ChangeMaterials(Renderer[] renderers, Material mat)
    {
        if (renderers == null || mat == null) return;

        foreach (Renderer r in renderers)
        {
            r.material = mat;
        }
    }
}