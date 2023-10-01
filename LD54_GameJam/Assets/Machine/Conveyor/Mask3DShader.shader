Shader "Custom/Mask3DShader"
{
   SubShader
   {
	   Tags{"Queue" = "Transparent+1"}

	   Pass {
			Blend Zero One
	   }
   }
}
