using Aya.DataBinding;
using Tais.Views;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    MainSceneView view;
    // Start is called before the first frame update
    void Awake()
    {
        view = new MainSceneView();
        BindMap.Bind(view);
    }

    // Update is called once per frame
    void Update()
    {
        view.roleHeath = 100;

        view.popNum = 100000;
    }
}
