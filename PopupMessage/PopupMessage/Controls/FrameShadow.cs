using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PopupMessage.Controls
{
    public class FrameShadow : Frame
    {
        public FrameShadow()
        {
            Elevation = 5;
        }

        public int Elevation { get; set; }
    }
}
