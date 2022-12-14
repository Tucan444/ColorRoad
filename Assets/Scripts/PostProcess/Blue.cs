using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable, VolumeComponentMenuForRenderPipeline("Custom/Blue", typeof(UniversalRenderPipeline))]
public class Blue : VolumeComponent, IPostProcessComponent
{
	// For example, an intensity parameter that goes from 0 to 1
    public ClampedFloatParameter blend = new ClampedFloatParameter(value: 0, min: 0, max: 1, overrideState: true);
    // A color that is constant even when the weight changes
    public NoInterpColorParameter overlayColor = new NoInterpColorParameter(Color.cyan);
    
    // Other 'Parameter' variables you might have
    
    // Tells when our effect should be rendered
    public bool IsActive() => blend.value > 0;
   
   	// I have no idea what this does yet but I'll update the post once I find an usage
    public bool IsTileCompatible() => true;
}