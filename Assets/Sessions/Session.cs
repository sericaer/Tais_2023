using DynamicData;
using System.Collections.ObjectModel;

namespace Tais.Models
{
    public class Session
    {
        public SourceList<Province> provinces;

        public Session()
        {
            provinces = new SourceList<Province>();

            provinces.Add(new Province(new ProvinceInit() 
            { 
                name = "P01",
                popInits = new PopInit[]
                {
                    new PopInit{ type = "POP1", count = 1000 }
                }
            }));

            provinces.Add(new Province(new ProvinceInit()
            {
                name = "P02",
                popInits = new PopInit[]
                {
                    new PopInit{ type = "POP1", count = 2000 }
                }
            }));
        }
    }

    public class Person
    {
        public string name;
    }
}
