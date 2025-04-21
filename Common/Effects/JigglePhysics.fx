sampler uImage0 : register(s0); //learn how to pass images like this
Texture2D uImage1;

sampler2D samplor = sampler_state
{
    Texture = <uImage1>;
};

float time;

float4 FilterMyShader(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float2 distortcoords = coords + float2(0.1, 0.08) * (time / 4);
    float4 distorttex = tex2D(samplor, distortcoords);
    
    float2 distortamount = float2(distorttex.r, distorttex.b) * 0.25;
    float4 scaledowncolr = tex2D(uImage0, coords + distortamount);
    
    return scaledowncolr;
}


technique Technique1
{
    pass Fard
    {
        PixelShader = compile ps_3_0 FilterMyShader();
    }
}