using System.ComponentModel;
using Tais.Models;
using Tais.Views;

namespace Tais.UIViews.Messages
{
    public class MESSAGE_SHOW_PERSON_DETAIL
    {
        public readonly object context;

        public MESSAGE_SHOW_PERSON_DETAIL()
        {
            context = new PersonDetailViewMode();
        }
    }

    public class MESSAGE_SHOW_MAP_DETAIL
    {
        public readonly object model;

        public MESSAGE_SHOW_MAP_DETAIL(BindingList<Province> provinces)
        {
            this.model = provinces;
        }
    }
}
