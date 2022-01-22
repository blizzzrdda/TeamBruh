Shader "Unlit/Outline"
{
    Properties
    {
        [HDR]_LineCol("Outline Color", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100


        Pass
        {
            Tags {"LightMode" = "SRPDefaltUnlit"}
            Cull Front
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            float3 _LineCol
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                float3 worldPos = TransformObjectToWorld(v.vertex);
                float distanceFN = distance(worldPos, _WorldSpaceCameraPos.xyz);
                half Length = smoothstep(0, 0.5, distanceFN) * 0.1;
             
                o.vertex = TransformObjectToHClip(float4(v.vertex.xyz + v.normal * Length, 1));
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half4 col = (_LineCol,1)
                return col;
            }
            ENDHLSL
        }
    }
        FallBack "Diffuse"
}
