using Aya.DataBinding;
using Aya.Events;
using Tais.UIViews.Messages;
using Tais.Views;
using UnityEngine;

public class MainScene : MonoListener
{
    MainSceneView view;

    public PersonDetailPanel personDetail;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        view = new MainSceneView();
        BindMap.Bind(view);
    }

    // Update is called once per frame
    void Update()
    {
        view.roleHeath = 100;

        view.popNum = 100000;
    }


    [Listen(typeof(MESSAGE_SHOW_PERSON_DETAIL))]
    public void TestMethod(MESSAGE_SHOW_PERSON_DETAIL msg)
    {
        personDetail.SetContext(msg.context);
        personDetail.gameObject.SetActive(true);
    }
}
