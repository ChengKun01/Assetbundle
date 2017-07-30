using UnityEditor;
using System.IO;

public class CreateAssetBundles{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundels() {
        string dir = "AssetBundels";
        if (Directory.Exists(dir) == false) {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
