using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor = 1.05f;
    [SerializeField] private Color outlineColor = Color.white;
    private Renderer outlineRenderer;

    private void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
        if (outlineRenderer != null)
        {
            outlineRenderer.enabled = true;
        }
    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);


        outlineObject.transform.localScale = Vector3.one;

        if (outlineObject.TryGetComponent<OutlineScript>(out var outlineScript))
        {
            Destroy(outlineScript);
        }
        if (outlineObject.TryGetComponent<Collider>(out var col))
        {
            Destroy(col);
        }
        /*if (outlineObject.TryGetComponent<DiceScript>(out var scr))
        {
            Destroy(scr);
        }
        */

        Renderer rend = outlineObject.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = outlineMat;
            rend.material.SetColor("_OutlineColor", color);
            rend.material.SetFloat("_Scale", scaleFactor);
            rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }

        return rend;
    }
}