// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "FabioTest/EchoVisualizer"
{
	Properties
	{
		_Color("Color", Color) = (1.0,1.0,1.0,1.0)
		_SpecColor ("Specular Color", Color) = (1.0,1.0,1.0,1.0)
		_Shininess ("Shininess", Float) = 10
		_RimColor ("Rim Color", Color) = (1.0,1.0,1.0,1.0)
		_RimPower ("Rim Power", Range(0.1, 10.0)) = 3.0

		_Distance ("Distance", Range(0.1, 10.0)) = 1.0
	}
	SubShader
	{
		Pass
		{
			Tags { "LightMode" = "ForwardBase" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			uniform float4 _Color;
			uniform float4 _SpecColor;
			uniform float4 _RimColor;
			uniform float _Shininess;
			uniform float _RimPower;

			uniform float _Distance;

			uniform float4 _LightColor0;

			float4 SoundSourceProperties[5];

			float3 PointLightPosition;

			int SoundsCount;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD;
			};

			struct vertexOutput
			{
				float4 posWorld : SV_POSITION;
				float2 _uv : TEXCOORD0;
				float4 pos : TEXCOORD1;
			};

			float2 unpack_float(float x)
			{
				int a = (int)(x / 10000);
				int b = (int)(x - (a * 10000));

				return float2 (a, b);
			}

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;
				o.pos = mul(unity_ObjectToWorld, v.vertex);
				o._uv = v.uv;
				//o.normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);
				o.posWorld = mul(UNITY_MATRIX_MVP, v.vertex);

				return o;
			}

			float4 frag(vertexOutput vOut) : COLOR
			{
				float _range = 0;

				float4 OutColor = float4(0.0,0.0,0.0,1.0);
				for(int i = 0; i < SoundsCount; i++)
				{
					PointLightPosition = float3(SoundSourceProperties[i].xyz);
					float2 IntensityAndRange = unpack_float(SoundSourceProperties[i].w);

					_range = IntensityAndRange.y * 0.01;
					
					float3 DirectionToLight = PointLightPosition.xyz - vOut.pos.xyz;
					float DistanceToLight = length(DirectionToLight);

					if(DistanceToLight <= _range)
					{
						if(sin(DistanceToLight*(IntensityAndRange.x*1.4f)-(_Time.y*10))*20.0f < 0.1f)
							OutColor += float4(0.1, 0.3, 0.8, 0.0) * 1/(_range*2);
					}
				}

				return OutColor;//float4(OutColor, 1.0);
			}

			ENDCG
		}
	}
}