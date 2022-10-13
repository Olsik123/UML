using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UML_Psotka.Class;

namespace UML_Psotka
{
    public class Method
    {
        public string Name { get; set; }

        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

          public string Output { get; set; }

        public accessModifiers AccessM { get; set; }

        public override string ToString()
        {
            string parameters = "";
            foreach (var item in Parameters)
            {
                parameters += item.Key;
                parameters += " : ";
                parameters += item.Value;
                parameters += ", ";
            }
            if(parameters.Length >2)
            parameters = parameters.Substring(0,parameters.Length - 2);
            return $"{(char)this.AccessM}{this.Name}({parameters}) : {this.Output}";
        }

    }
}
