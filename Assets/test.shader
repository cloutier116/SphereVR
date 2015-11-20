Shader "Crosshair"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
	}
		SubShader
	{
		// No culling or depth
		ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"



			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				return o;
			}
			
			uniform float4 _Color;

			fixed4 frag (v2f i) : COLOR
			{
				return _Color;
			}
			ENDCG
		}
	}
}
