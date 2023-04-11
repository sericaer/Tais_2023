//using Aya.DataBinding;
using Aya.Events;
using Tais.UIViews.Messages;
using Tais.Views;
using Sericaer.UIBind.Runtime;
using UnityEngine;

public class MainScene : MonoListener
{
    MainSceneViewMode view;

    public PersonDetailPanel personDetail;

    public BindContext mainContext;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        view = new MainSceneViewMode();
        mainContext.SetContextData(view);
    }

    // Update is called once per frame
    void Update()
    {
        //view.roleHeath = 100;

        view.popNum++;
    }


    [Listen(typeof(MESSAGE_SHOW_PERSON_DETAIL))]
    public void TestMethod(MESSAGE_SHOW_PERSON_DETAIL msg)
    {
        personDetail.SetContext(msg.context);
        personDetail.gameObject.SetActive(true);
    }
}
