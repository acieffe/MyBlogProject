using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Political Propaganda")]
        Political,
        [Description("Offensive Language")]
        Language,
        [Description("Illegal  Drug Reference")]
        Drugs,
        [Description("Inciting Violence")]
        Threatening,
        [Description("Explicit Content")]
        Sexual,
        [Description("Unnecessary Rudeness")]
        Shaming,
        [Description("False Information")]
        FactChecked
    }
}
