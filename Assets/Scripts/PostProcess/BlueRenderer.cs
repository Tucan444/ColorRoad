using UnityEngine.Rendering.Universal;

[System.Serializable]
public class BlueRenderer : ScriptableRendererFeature
{
    CustomPostProcessPass pass;

    public override void Create()
    {
        pass = new CustomPostProcessPass();
    }
    
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(pass);
    }
}
