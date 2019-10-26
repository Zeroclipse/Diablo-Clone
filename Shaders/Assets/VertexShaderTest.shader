Shader "Custom/Unlit/VertexShaderTest"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;

				v.vertex.y += sin(-(v.vertex.x) + _Time[1]) * .3;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float2 uv = i.uv - 0.5;
				//float a = _Time[1];
				float2 p = float2(_SinTime[3], _CosTime[3]) * 0.4;
				float2 p2 = float2(_CosTime[3], _SinTime[3] * -1) * 0.4;
				float2 distort = uv - p;
				float2 distort2 = uv - p2;
				float d = length(distort);
				float d2 = length(distort2);

				float m = smoothstep(0.1, 0.08, d);
				float m2 = smoothstep(0.1, 0.08, d2);
				distort = distort * .7 * m;
				distort2 = distort2 * 5 * m2;

				fixed4 col = tex2D(_MainTex, i.uv + distort + distort2);
				return col;
            }
            ENDCG
        }
    }
}
