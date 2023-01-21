using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageChooser : MonoBehaviour
{
    [SerializeField] private CloudRecoBehaviour reconocedorCloud;
    [SerializeField] private ImageTargetBehaviour[] targets;

    private void Awake()
    {
        reconocedorCloud.RegisterOnNewSearchResultEventHandler(ImagenEncontrada);
    }

    private void ImagenEncontrada(CloudRecoBehaviour.CloudRecoSearchResult results)
    {
        foreach(ImageTargetBehaviour target in targets)
        {
            if(target.gameObject.name == results.TargetName)
            {
                reconocedorCloud.EnableObservers(results, target.gameObject);
            }
        }
    }
}
