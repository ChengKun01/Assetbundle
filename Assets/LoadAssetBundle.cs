using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundle : MonoBehaviour {
    string path = "AssetBundels/scenes/prefabs.prefab";


    //通过内存加载---LoadFromMemoryAsync
    //IEnumerator Start(){
    //    AssetBundleCreateRequest createRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
    //    yield return createRequest;

    //    AssetBundle bundle = createRequest.assetBundle;
    //    var prefab = bundle.LoadAsset<GameObject>("Capsule");
    //    Instantiate(prefab);
    //}


    //本地文件加载--LoadFromFileAsync
    //IEnumerator Start() {
    //    AssetBundleCreateRequest createRequest = AssetBundle.LoadFromFileAsync(path);
    //    yield return createRequest;

    //    AssetBundle bundle = createRequest.assetBundle;
    //    var prefab = bundle.LoadAsset<GameObject>("Capsule");
    //    Instantiate(prefab);
    //}

    //服务器加载
    //IEnumerator Start(){
    //    while (!Caching.ready)
    //        yield return null;
    //    //var WWW1 = WWW.LoadFromCacheOrDownload(@"file:///E:\unity\AssetBundlesProject\AssetBundels\scenes\prefabs.prefab",1);

    //    var WWW1 = WWW.LoadFromCacheOrDownload(@"file:///E:\unity\AssetBundlesProject\AssetBundels\scenes\prefabs.prefab", 1);
    //    yield return WWW1;
    //    if (!string.IsNullOrEmpty(WWW1.error)) {
    //        Debug.Log(WWW1.error);
    //        yield break;
    //    }
    //    AssetBundle bundle = WWW1.assetBundle;
    //    var prefab = bundle.LoadAsset<GameObject>("Capsule");
    //    Instantiate(prefab);
    //}
    //使用UnityWebRequest
    private IEnumerator Start()
    {
        //string url1 = @"file:///" + Application.dataPath + path;
        string url = @"file:///E:\unity\AssetBundlesProject\AssetBundels\scenes\prefabs.prefab";
        //Debug.Log(url1);
        //Debug.Log(url);
        //Debug.Log(url1.Equals(url));
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(url, 0);
        yield return request.Send();

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        var prefab = bundle.LoadAsset<GameObject>("Capsule");
        Instantiate(prefab);
    }

}
