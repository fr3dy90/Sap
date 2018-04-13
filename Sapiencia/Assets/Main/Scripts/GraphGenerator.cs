using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

[System.Serializable]
public struct GraphProperties
{
    public float radius;
    public Material meshMaterial;
    public Color lowColor;
    public Color maxColor;

    [Space(10.0f)]
    [Header("Main Values---------->")]
    [Space(5.0f)]
    public float realistaLimitX;
    public float realistaLimitY;
    [Space(3.0f)]
    public float investigadorLimitX;
    public float investigadorLimitY;
    [Space(3.0f)]
    public float artisticoLimitX;
    public float artisticoLimitY;
    [Space(3.0f)]
    public float socialLimitX;
    public float socialLimitY;
    [Space(3.0f)]
    public float emprendedorLimitX;
    public float emprendedorLimitY;
    [Space(3.0f)]
    public float convencionalLimitX;
    public float convencionalLimitY;

    [Space(10.0f)]
    [Header("Main Values---------->")]
    [Space(5.0f)]
    [Range(0.0f, 1.0f)]
    public float realista;
    [Range(0.0f, 1.0f)]
    public float investigador;
    [Range(0.0f, 1.0f)]
    public float artistico;
    [Range(0.0f, 1.0f)]
    public float social;
    [Range(0.0f, 1.0f)]
    public float emprendedor;
    [Range(0.0f, 1.0f)]
    public float convencional;
}

public class GraphGenerator : MonoBehaviour
{
    public GraphProperties properties;
    Color32[] colores;
    Mesh mesh;

	void Awake ()
    {
        mesh = gameObject.AddComponent<MeshFilter>().mesh;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.shadowCastingMode = ShadowCastingMode.Off;
        renderer.receiveShadows = false;
        renderer.lightProbeUsage = LightProbeUsage.Off;
        renderer.material = properties.meshMaterial;       

        CreateGraph();
    }

    void CreateGraph()
    {
        mesh.Clear();
        mesh.vertices = new Vector3[]
        {
            Vector3.Lerp(Vector3.zero, new Vector3(/*0.0f*/properties.realistaLimitX, /*1.0f*/properties.realistaLimitY, 0.0f) * properties.radius, properties.realista),
            Vector3.Lerp(Vector3.zero, new Vector3(/*0.86f*/properties.investigadorLimitX, /*0.5f*/properties.investigadorLimitY, 0.0f) * properties.radius, properties.investigador),
            Vector3.Lerp(Vector3.zero, new Vector3(/*0.86f*/properties.artisticoLimitX, /*-0.5f*/properties.artisticoLimitY, 0.0f) * properties.radius, properties.artistico),
            Vector3.Lerp(Vector3.zero, new Vector3(/*0.0f*/properties.socialLimitX, /*-1.0f*/properties.socialLimitY, 0.0f) * properties.radius, properties.social),
            Vector3.Lerp(Vector3.zero, new Vector3(/*-0.86f*/properties.emprendedorLimitX, /*-0.5f*/properties.emprendedorLimitY, 0.0f)* properties.radius, properties.emprendedor),
            Vector3.Lerp(Vector3.zero, new Vector3(/*-0.86f*/properties.convencionalLimitX, /*0.5f*/properties.convencionalLimitY, 0.0f)* properties.radius, properties.convencional),
            new Vector3(0.0f, 0.0f, 0.0f)
        };

        mesh.triangles = new int[] 
        {
            0,1,6,
            6,1,2,
            2,3,6,
            6,3,4,
            4,5,6,
            6,5,0
        };

        colores = new Color32[]
        {
            Color32.Lerp(properties.lowColor, properties.maxColor, properties.realista),
            Color32.Lerp(properties.lowColor, properties.maxColor, properties.investigador),
            Color32.Lerp(properties.lowColor, properties.maxColor, properties.artistico),
            Color32.Lerp(properties.lowColor, properties.maxColor, properties.social),
            Color32.Lerp(properties.lowColor, properties.maxColor, properties.emprendedor),
            Color32.Lerp(properties.lowColor, properties.maxColor, properties.convencional),
            properties.lowColor
        };

        mesh.colors32 = colores;
    }

    private void Update()
    {
        CreateGraph();
    }
}
