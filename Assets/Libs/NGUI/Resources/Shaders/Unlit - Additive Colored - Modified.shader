Shader "Unlit/Additive Colored - Modified"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_Mask ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_Color ("Tint Color", Color) = (1,1,1,1)
	}
	
	SubShader
	{
		Pass
		{	
			SetTexture [_Mask]
			{
				ConstantColor [_Color]
				Combine Texture * Constant
			}
			SetTexture [_MainTex]
			{
				Combine Texture + Previous
			}
		}
	}
}