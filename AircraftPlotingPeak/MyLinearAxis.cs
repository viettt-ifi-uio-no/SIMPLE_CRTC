using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Axes;
using System.Collections;

namespace AircraftPlotingPeak
{
    class MyLinearAxis : LinearAxis
    {
        private Hashtable value_and_label = new Hashtable();
        public MyLinearAxis(Hashtable value_and_label)
        {
            this.value_and_label = value_and_label;
        }

        public new string FormatValue(double x)
        {
            return (string)value_and_label[x];
        }
    }
}
