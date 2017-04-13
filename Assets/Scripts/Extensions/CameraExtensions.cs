using UnityEngine;

// Método de extensão para poder pegar os bounds da camera ortografica.
// Usado para apagar o tiro quando fora da tela
public static class CameraExtensions
{
    public static Bounds OrthographicBounds(this Camera camera)
    {
        var screenAspect = Screen.width / (float)Screen.height;
        var cameraHeight = camera.orthographicSize * 2;
        var pos = camera.transform.position;
        var bounds = new Bounds(
            new Vector3(pos.x, pos.y, 0),
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}