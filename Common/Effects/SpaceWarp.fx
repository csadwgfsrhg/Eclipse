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

float4 FilterMyShader(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float2 UV = coords;
    float2 Center = (uTargetPosition - uScreenPosition) / uScreenResolution;
    UV.x *= uScreenResolution.x / uScreenResolution.y;
    Center.x *= uScreenResolution.x / uScreenResolution.y;
    //float power = 0.35; //between 0.1 - 10.0 def 1.2
    //final 0.1 - 0.35
    float power = 0.05 + 0.60 * uProgress * 0.5;
    float shit = (uProgress - 0.5);
    float radius = 0.8 + shit * 0.5; //between 0.1 - 1.0 def 9.3

    float dist = distance(Center, UV);
    float warp = clamp(0.25 - pow(dist / radius, 5.0), 0, 1);
    //float warp = abs(0.001 - pow(dist / radius, 5.0)); SPHERE
    //float warp = pow(dist / radius, 5.0);
    float zoom = pow(warp, 1.0 / (power * 2.4));
    
    
    //float theintensity = abs(sin(uTime)); // * 1.5 + 0.5
    float pie = 3.14159265358979323846264338327950;
    float theta = (uTime * 2 * pow((uProgress) * 0.2, 2)) % (pie * 2);
    float2 wave = float2(0, 0);
    float2 rotUV = float2(0, 0);
    if (dist < radius)
    {
        //adding will bulge, subtracting will shrink
        coords -= zoom * (Center - UV);
        //wave = float2(sin(uTime + coords.y * 22) * 0.025 * (radius - dist), 0);
        
        //if (uProgress > 0.8)
        //    coords -= normalize(Center - UV) * (1.0 - dist) * 9;
        
        float2 fr = (uTargetPosition - uScreenPosition) / uScreenResolution;
        //rotUV = float2((coords.x - Center.x) * cos(theta) - (coords.y - 0.5 - Center.y) * sin(theta) + 0.5, (coords.x - Center.x) * sin(theta) + (coords.y - 0.5 - Center.y) * cos(theta) + 0.5);
        rotUV = float2((coords.x - fr.x) * cos(theta) - (coords.y - fr.y) * sin(theta) + 0.5, (coords.x - fr.x) * sin(theta) + (coords.y - fr.y) * cos(theta) + 0.5);
        float4 Swirl = tex2D(uImage2, rotUV) * clamp(1 - dist * 2, 0, 1);
        wave = warp * power * 3.69 * (Swirl.r - 0.55);
    }
    
    
    float newdist = distance(rotUV, Center);
    float4 color = tex2D(uImage0, coords - wave * abs(0.9 - 1.6 * newdist));
    
    if (dist < radius)
    {   
        float thedeal = clamp(1 - pow(dist, 2) * pow(10, 7 - 6 * uProgress) * 0.01 * radius, 0, 1) + warp;
        //float thedeal = clamp(0.75 - distance(Center, UV), 0, 1);
        color -= (color - (float4(0.098, 0.027, 0.161, 1))) * thedeal * 1.25 * clamp(1 - dist * 2, 0, 1);
        color += float4(1, 0.251, 0.451, 1.0) * tex2D(uImage2, -rotUV) * 1.7 * clamp(1 - dist * 2, 0, 1) * power * 3;
        
    }
        //color -= (color - (float4(0.098, 0.027, 0.161, 1.0))) * clamp(0.5 - dist, 0, 1);
    
    float4 add = float4(0, 0, 0, 1);
    
    if (shit > -0.25)
        add -= float4(0.12, 0.12, 0.12, 0) * (shit + 0.25) * 2;        
    
    return (color * float4(uColor, dist + 0.2)) + add;
}


technique Technique1
{
    pass Fard
    {
        PixelShader = compile ps_3_0 FilterMyShader();
    }
}