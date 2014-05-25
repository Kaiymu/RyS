Shader "Custom/rim" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_RimColor ("Rim Color", color) = (1,1,1,1)
		_RimPower ("Rim Power", Range(0,5)) = 1
	}
	SubShader {
		
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
		};
		
		sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _RimColor;
		float _RimPower;
		
		void surf (Input IN, inout SurfaceOutput o) 
		{
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
			
			float rim = 1.0 - saturate(dot(normalize(o.Normal), normalize(IN.viewDir)));
			
			o.Emission = _RimColor * pow(rim, _RimPower);
		}
		ENDCG
	} 
}
