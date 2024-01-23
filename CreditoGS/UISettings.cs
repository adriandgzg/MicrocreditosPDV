using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditoGS
{
    internal class UISettings : ConfigurationSection
    {
        [ConfigurationProperty("tokenAuth", DefaultValue = "")]
        public string TokenAuth
        {
            get { return (string)this["tokenAuth"]; }
            set { this["tokenAuth"] = value; }
        }
    }
}
