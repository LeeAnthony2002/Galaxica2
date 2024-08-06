using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]

public class SkyboxSetting : MonoBehaviour
{
   
   [SerializeField] List<Material> skyboxMaterials;

   Skybox Sky;

    
    void Awake()
    {
        Sky = GetComponent<Skybox>();
    }

    void OnEnable()
    {
        ChangeSkybox(0);
    }

    void ChangeSkybox(int skyBox)
    {
        if (Sky != null && skyBox >=0 && skyBox <= skyboxMaterials.Count)
        {
            Sky.material = skyboxMaterials[skyBox];
        }
    }
}
