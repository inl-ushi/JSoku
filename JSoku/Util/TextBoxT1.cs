using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JSoku
{
    class TextBoxT1:TextBox
    {
        public TextBoxT1()
        {
            cstmComponent();
        }
        private void cstmComponent()
        {
            this.Margin = new Padding(0);
        }
    }
}

