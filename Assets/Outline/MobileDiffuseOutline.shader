// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Simplified Diffuse shader. Differences from regular Diffuse one:
// - no Main Color
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Outline/Mobile Diffuse" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}

        [Header(Outline)]
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineThickness ("Outline Thickness", Range(0, 5)) = 0
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 150

        Pass {
            Cull Front

            Name "Outline"

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _OutlineThickness;
            fixed4 _OutlineColor;

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct vertexToFragment {
                float4 position : SV_POSITION;
            };

            vertexToFragment vert (appdata b) {
                vertexToFragment o;

                o.position = UnityObjectToClipPos(b.vertex);

                float3 clipSpaceNormal = mul((float3x3)UNITY_MATRIX_VP, mul((float3x3)UNITY_MATRIX_M, b.normal));

                o.position.xy += normalize(clipSpaceNormal.xy) / _ScreenParams.xy * 2 * _OutlineThickness * o.position.w;

                return o;
            }

            fixed4 frag (vertexToFragment i) : SV_Target {
                return _OutlineColor;
            }


            ENDCG

        }

    CGPROGRAM
    #pragma surface surf Lambert noforwardadd

    sampler2D _MainTex;

    struct Input {
        float2 uv_MainTex;
    };

    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
        o.Albedo = c.rgb;
        o.Alpha = c.a;
    }
    ENDCG
    }

    Fallback "Mobile/VertexLit"
}
