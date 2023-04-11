//using Aya.DataBinding;
using Aya.Events;
using Tais.UIViews.Messages;
using Tais.Views;
using Sericaer.UIBind.Runtime;
using UnityEngine;
using System.ComponentModel;

public class MainScene : MonoListener
{
    MainSceneViewMode view;

    public BindContext mainContext;
    public BindContext personDetailContext;

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
        personDetailContext.gameObject.SetActive(true);
        personDetailContext.SetContextData(msg.context as INotifyPropertyChanged);
    }
}
