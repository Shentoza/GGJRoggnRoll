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

			float4 SoundSourceProperties[8];

			float3 PointLightPosition;

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
				int a = (int)(x / 1000);
				int b = (int)(x - (a * 1000));

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
				float3 pos;
				float _range = 0;

				float4 OutColor = float4(1.0,0.0,0.0,1.0);

				//for(int i = 0; i < 8; i++)
				{
					PointLightPosition = float3(SoundSourceProperties[0].xyz);
					pos+=PointLightPosition;
					float2 IntensityAndRange = unpack_float(SoundSourceProperties[0].w);

					_range = IntensityAndRange.y * 0.01;

					float3 DirectionToLight = PointLightPosition.xyz - vOut.pos.xyz;
					float DistanceToLight = length(DirectionToLight);

					//if((0.5f*cos(DistanceToLight*100)) >= 0)
					//	OutColor = float4(1.0,1.0,1.0,1.0) * _range;

					if(sin(DistanceToLight + _Time.y)*2 < 1.0f)
						OutColor = float4(1.0,1.0,1.0,1.0) * _range;
				}

				return OutColor;//float4(OutColor, 1.0);
			}

			ENDCG
		}
	}
}