sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uProgress;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float2 uTargetPosition;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;
float2 uScreenResolution;
float2 uScreenPosition;
float uZoom;


float4 MainPS(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
       float2 pixelated = coords * uScreenResolution ;   
        pixelated.x = round(pixelated.x / 2) *2  / (uScreenResolution.x  ) ;
        pixelated.y = round(pixelated.y / 2) *2  / (uScreenResolution.y ) ;
      

    float4 color = tex2D(uImage0, pixelated);
   

    return color;
}



technique Technique1
{
    pass Fard
    {
        PixelShader = compile ps_3_0 MainPS();
    }
}