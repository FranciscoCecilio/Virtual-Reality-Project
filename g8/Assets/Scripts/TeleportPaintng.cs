using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPaintng : Painting
{
    public Material skyboxMat;

    public override void Execute()
    {
        base.Execute();
        RenderSettings.skybox = skyboxMat;
        if(base.player!=null){
            base.player.position = new Vector3(0,base.player.position.y,0);
        }
    }

    public void SetSkyboxMat(Material mat){
        skyboxMat = mat;
    }
}
