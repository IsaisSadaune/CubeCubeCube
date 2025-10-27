Shader "Unlit/FrontOnlyWireframe"
{
    Properties
    {
        _WireframeColour ("Wireframe Colour", Color) = (1,1,1,1)
        _FillColour ("Fill Colour", Color) = (0.1,0.1,0.1,1)
        _WireframeScale ("Wireframe Scale", Float) = 1.5

        [KeywordEnum(BASIC, FIXEDWIDTH, ANTIALIASING)] _WIREFRAME ("Wireframe Rendering Type", Integer) = 0
        [Toggle] _QUADS ("Show Only Quads", Integer) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        // --- PASS 1 : Faces intérieures (remplissage sombre)
        Pass
        {
            Name "Fill"
            Cull Front
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment fragFill
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            fixed4 _FillColour;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 fragFill(v2f i) : SV_Target
            {
                return _FillColour;
            }
            ENDCG
        }

        // --- PASS 2 : Wireframe sur les faces visibles
        Pass
        {
            Name "Wireframe"
            Cull Back
            ZWrite On
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #pragma multi_compile_fog

            #pragma shader_feature_local _WIREFRAME_BASIC _WIREFRAME_FIXEDWIDTH _WIREFRAME_ANTIALIASING
            #pragma shader_feature_local _QUADS

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 bary : TEXCOORD1; // les barycentrics (venus du script)
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 bary : TEXCOORD0;
            };

            sampler2D _MainTex;
            fixed4 _WireframeColour;
            float _WireframeScale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.bary = v.bary;
                return o;
            }

            [maxvertexcount(3)]
            void geom(triangle v2f IN[3], inout TriangleStream<v2f> triStream)
            {
                v2f o;
                [unroll]
                for (int i = 0; i < 3; i++)
                {
                    o.vertex = IN[i].vertex;
                    o.bary = IN[i].bary;
                    triStream.Append(o);
                }
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float alpha = 0;

                #ifdef _WIREFRAME_BASIC
                    float closest = min(i.bary.x, min(i.bary.y, i.bary.z));
                    alpha = step(closest, _WireframeScale / 20.0);
                #elif defined(_WIREFRAME_FIXEDWIDTH)
                    float3 unitWidth = fwidth(i.bary);
                    float3 edge = step(i.bary, unitWidth * _WireframeScale);
                    alpha = max(edge.x, max(edge.y, edge.z));
                #elif defined(_WIREFRAME_ANTIALIASING)
                    float3 unitWidth = fwidth(i.bary);
                    float3 aliased = smoothstep(float3(0,0,0), unitWidth * _WireframeScale, i.bary);
                    alpha = 1 - min(aliased.x, min(aliased.y, aliased.z));
                #endif

                return fixed4(_WireframeColour.rgb, alpha * _WireframeColour.a);
            }
            ENDCG
        }
    }
    FallBack Off
}
