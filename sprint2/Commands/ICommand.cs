using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    interface ICommand
    {

        Game1 Game { get; set; }
        void Execute();
        
    }
}
