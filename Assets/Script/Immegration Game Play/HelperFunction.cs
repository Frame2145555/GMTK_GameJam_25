using UnityEngine;

public static class Auxiliary
{
    public static T RandomEnum<T>()
    {
        var values = System.Enum.GetValues(typeof(T));
        int index = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(index);
    }
    //Convert Texture2D to Sprite
    public static Sprite TextureToSprite(Texture2D texture)
    {
        if (texture == null) return null;

        return Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f)
        );
    } 
}