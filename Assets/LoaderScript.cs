using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using BulletUnity.Primitives;

public class LoaderScript : MonoBehaviour
{
    [SerializeField] string dataFile;
    private string path;
    private float pX, pY, pZ, rX, rY, rZ;
    private GameObject obj;

    void Start()
    {
        using (var reader = XmlReader.Create("Assets\\" + dataFile))
        {
            while (reader.ReadToFollowing("item"))
            {
                reader.MoveToAttribute("prefab");
                path = "Prefabs\\" + reader.Value;
                pX = reader.MoveToAttribute("pX") ? float.Parse(reader.Value) : 0.0f;
                pY = reader.MoveToAttribute("pY") ? float.Parse(reader.Value) : 0.0f;
                pZ = reader.MoveToAttribute("pZ") ? float.Parse(reader.Value) : 0.0f;
                rX = reader.MoveToAttribute("rX") ? float.Parse(reader.Value) : 0.0f;
                rY = reader.MoveToAttribute("rY") ? float.Parse(reader.Value) : 0.0f;
                rZ = reader.MoveToAttribute("rZ") ? float.Parse(reader.Value) : 0.0f;

                obj = Resources.Load(path) as GameObject;
                obj = Instantiate(obj, new Vector3(pX, pY, pZ), Quaternion.Euler(rX, rY, rZ));

                if (reader.MoveToAttribute("bullet") && bool.Parse(reader.Value))
                {
                    BuildMesh(reader.MoveToAttribute("buildMesh") ? int.Parse(reader.Value) : 1);
                }
            }
        }
    }

    void BuildMesh(int n)
    {
        switch(n)
        {
            case 1:
                obj.SendMessage("BuildMesh");
                break;
            case 2:
                foreach(BBox child in obj.GetComponentsInChildren<BBox>())
                {
                    child.SendMessage("BuildMesh");
                }
                break;
            default:
                break;
        }
    }
}