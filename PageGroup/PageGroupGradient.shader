Shader "Unlit/PageGroupGradient"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Direction ("Direction", float) = 0
        _Type ("Type", float) = 0
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Direction;
            float _Type;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //Left to right or right to left gradient depending on the _Direction
                float ltr_or_rtl_gradient = abs(_Direction - i.uv.x);

                // Inward or outward gradient depending on the _Direction
                float in_or_out_gradient = abs(_Direction - (i.uv.x * (1 - i.uv.x) * 3));

                // Select gradient type depending on _Type
                float gradient = ltr_or_rtl_gradient * (1 - _Type) + in_or_out_gradient * _Type;

                return gradient * _Color;
            }
            ENDCG
        }
    }
}
