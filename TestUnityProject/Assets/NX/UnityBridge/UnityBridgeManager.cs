using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace NX.UnityBridge {

    public class UnityBridgeManager : MonoBehaviour {

        // // mocked methods for non-WebGL platforms
        // public static string unityToJs(string _event, string _payload) {
        //     Debug.Log($"[UB][Test] unityToJs: {_event} : {_payload}");
        //     return "";
        // }
        // public static void unityWatch(string _event, string _objectName, string _functionName) {
        //     Debug.Log($"[UB][Test] unityWatch: {_event} : {_objectName}.{_functionName}");
        // }
        // public static void unityUnwatch(string _event, string _objectName, string _functionName) {
        //     Debug.Log($"[UB][Test] unityUnwatch: {_event} : {_objectName}.{_functionName}");
        // }

        [DllImport("__Internal")]
        public static extern string unityToJs(string _event, string _payload);

        [DllImport("__Internal")]
        public static extern void unityWatch(string _event, string _objectName, string _functionName);

        [DllImport("__Internal")]
        public static extern void unityUnwatch(string _event, string _objectName, string _functionName);

        public List<GameObject> listInstantiateOnReady;

        public void JsToUnity(string payload) {
            if (payload == "Ready") {
                listInstantiateOnReady.ForEach(delegate(GameObject obj) {
                    Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
                });
            } else if (payload == "Stop") {
                // TBD
            }
        }

    }

}
