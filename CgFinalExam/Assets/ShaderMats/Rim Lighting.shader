Shader"Custom/Rim Lighting"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _RimColor("Rim Color", Color) = (0,0.5,0.5,0)
        _RimPower("Rim Power", Range(0.5,8.0)) = 3
    }
    SubShader
    {
    Tags{ "Queue" =  "Transparent"}
CGPROGRAM
#pragma surface surf Lambert alpha:fade
struct Input{
    float3 viewDir;
};

float4 _RimColor;
float _RimPower;

void surf(Input IN, inout SurfaceOutput o)
{
    half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
    o.Emission = _RimColor.rgb * pow(rim, _RimPower);
    o.Alpha = pow(rim, _RimPower);
}

        
        ENDCG
    }
    FallBack "Diffuse"
}
