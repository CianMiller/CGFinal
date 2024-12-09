using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class GradingCamera : MonoBehaviour
{
    //public Shader awesomeShader = null;
    public Material m_renderMaterial;
    public Material m_renderMaterialWarm;
    public Material m_renderMaterialLow;
    Material m;

    private void Start()
    {
        m = m_renderMaterial;
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m = m_renderMaterial;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m = m_renderMaterialWarm;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m = m_renderMaterialLow;
        }
    }

}
