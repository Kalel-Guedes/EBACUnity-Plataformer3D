using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using NaughtyAttributes;
using UnityEngine.Rendering;


public class EffectManager : Singleton<EffectManager>
{
    /*public PostProcessVolume processEffect;
    [SerializeField]private Vignette _vignette;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        Vignette tmp;

        if(processEffect.profile.TryGetSettings<Vignette>(out tmp))
        {
            _vignette = tmp;
        }

        ColorParameter c = new ColorParameter();

        c.value = Color.red;

        _vignette.color = c;
    }*/
}
