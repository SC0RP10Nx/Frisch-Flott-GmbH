using System;
using System.Collections.Generic;
using System.Text;

namespace Frisch_Flott_GmbH
{
    public class Messwert
    {
        public DateTime Zeitpunkt { get; }
        public double Wert { get; }

        public Messwert(DateTime zeitpunkt, double wert)
        {
            Zeitpunkt = zeitpunkt;
            Wert = wert;
        }
    }
}
