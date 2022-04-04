using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class MessageEditModel
    {
        public string NameUser { get; set; }
        public string ImageSource { get; set; }

        public static List<MessageEditModel> init()
        {
            return new List<MessageEditModel>()
    {
        new MessageEditModel{NameUser="vahid",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="amin",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="majid",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="karim",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="fagir",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="naser",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="kazem",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="shazdeh",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="vahid",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="morad",ImageSource= "PicPerson.png" },
        new MessageEditModel{NameUser="mamad",ImageSource= "PicPerson.png" },
    };
        }

    }
    public class MessageEditModel2
    {
        public string GroupName { get; set; }

        public static MessageEditModel2 init()
        {
            return new MessageEditModel2 { GroupName = "abolGhasem" };
        }
    }
}
