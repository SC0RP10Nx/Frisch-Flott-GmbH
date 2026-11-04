using System;
using System.Collections.Generic;
using System.Text;

namespace Frisch_Flott_GmbH
{
    public class AlarmEintrag
    {
        public DateTime Zeitpunkt { get; }
        public string Sensor { get; }
        public string Meldung { get; }

        public AlarmEintrag(DateTime zeitpunkt, string sensor, string meldung)
        {
            Zeitpunkt = zeitpunkt;
            Sensor = sensor;
            Meldung = meldung;
        }
    }
}
