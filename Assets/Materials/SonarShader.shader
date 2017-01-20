Shader "Hidden/SonarShader"
{
	Properties
	{
		_TestPosWow("TestPos", Vector) = (0.0, 0.0, 0.0)
		_MainTex ("Texture", 2D) = "black" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Back ZWrite on ZTest LEqual

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float4 _TestPosWow;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 world : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.world = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
				col = col;

				if (i.world.x > _TestPosWow.x && i.world.x < _TestPosWow.x + 10) {
				//if (_TestPosWow.sx != 4) {
					return fixed4(1, 1, 1, 1);
				}
				else {
					return col;
				}
			}
			ENDCG
		}
	}
}
