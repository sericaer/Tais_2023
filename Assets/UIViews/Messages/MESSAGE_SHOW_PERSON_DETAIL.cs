using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
