using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902_Sprint2.Controller
{
    interface IController
    {
        Game1 Game { get; set; }
        void Update();
    }
}
