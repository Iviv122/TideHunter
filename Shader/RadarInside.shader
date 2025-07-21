Shader "Unlit/RadarInside"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1)
        _WaveColor ("WaveColor", Color) = (2, 0, 1)
        _Scale ("Scale", float) = 5
        _Speed ("Speed", float) = 1
        _Height ("Height", float) = 1
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
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
            float4 _MainTex_TexelSize; // Automatically set by Unity
            fixed4 _Color;
            fixed4 _WaveColor;
            float4 _MainTex_ST;

            float _Scale;
            float _Speed;
            float _Height;


            // geometry
            v2f vert (appdata v)
            {
                v2f o;
                float4 vertex = v.vertex;

                o.vertex = UnityObjectToClipPos(vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            // color
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);

                //float x = abs(sin(i.uv.x) - _MainTex_TexelSize.x / 2) / (sin(i.uv.x) - _MainTex_TexelSize.x / 2);
                //float y = abs(sin(i.uv.y) - _MainTex_TexelSize.y / 2) / (sin(i.uv.y) - _MainTex_TexelSize.y / 2);

                float x = i.uv.y;
                float y = i.uv.x;

                //float wave_y = 0.5 + _Height + sin(x + _Time * _Speed) / _Scale;
                float wave_y = 0.5 + _Height + sin(x+ _Time * _Speed) / _Scale;
                float distance = abs(y - wave_y) + 0.5;

                UNITY_APPLY_FOG(i.fogCoord, col);
                if(distance > 1 / _Scale){
                    return fixed4(0, 0, 0, 1);
                }
                // apply fog
                return _WaveColor;
            }
            ENDCG
        }
    }
}
