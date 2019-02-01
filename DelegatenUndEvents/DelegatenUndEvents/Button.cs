using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEvents
{
    class Button
    {
        #region Variante "Lang"
        //private EventHandler buttonClick;
        //public event EventHandler ButtonClick_Event
        //{
        //    add
        //    {
        //        buttonClick += value;
        //    }
        //    remove
        //    {
        //        buttonClick -= value;
        //    }
        //} 
        #endregion
        public event EventHandler ButtonClick_Event;
        public void Click()
        {
            // Logik
            //if (ButtonClick == null)
            //    return;

            // Null-Conditional Operator
            ButtonClick_Event?.Invoke(this, EventArgs.Empty);
        }
    }
}
