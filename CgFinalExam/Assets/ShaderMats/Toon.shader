Shader"Custom/Toon"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _RampTexture ("Ramp Texture", 2D) = "white" {}
    }
    SubShader
    {
       

        CGPROGRAM
        
        #pragma surface surf ToonRamp

        
    sampler2D _RampTexture;

        

        half _Glossiness;
        half _Metallic;
        float4 _Color;
float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed attem)
{
    float diff = dot(s.Normal, lightDir);
    float4 h = diff * 0.5 + 0.5;
    float2 rh = h;
    float3 ramp = tex2D(_RampTexture, rh).rgb;
    float4 c;
    c.rgb = s.Albedo * _LightColor0.rgb * (ramp);
    c.a = s.Alpha;
    return c;
}

struct Input
{
    float2 uv_MainTex;
};

void surf(Input IN, inout SurfaceOutput o)
{
    o.Albedo = _Color.rgb;
}
        ENDCG
    }
    FallBack "Diffuse"
}
