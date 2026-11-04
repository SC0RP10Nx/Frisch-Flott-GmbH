using System;
using System.Collections.Generic;
using System.Text;

namespace Frisch_Flott_GmbH
{
    public class Sensor
    {
        public string Bezeichnung { get; }
        public string KuehlKammer { get; }
        private bool _alarmausgeloest;
        private readonly List<Messwert> _verlauf = new List<Messwert>();
        public IReadOnlyList<Messwert> Verlauf => _verlauf;
        private readonly List<AlarmEintrag> _alarme = new List<AlarmEintrag>();
        public IReadOnlyList<AlarmEintrag> Alarme => _alarme;

        public Sensor(string bezeichnung, string kuehlKammer)
        {
            this.Bezeichnung = bezeichnung;
            this.KuehlKammer = kuehlKammer;

        }

        public event Melder? AlarmMelder;

        public void TemperaturMessen(double wert)
        {
            Console.WriteLine($"Sensor: {Bezeichnung} in {KuehlKammer}, Temperatur: {wert} °C");
            _verlauf.Add(new Messwert(DateTime.Now, wert));

            bool ausserhalbGrenzen = wert < -14.0 || wert > -2.0;

            if (ausserhalbGrenzen && !_alarmausgeloest)
            {
                string richtung = wert < -14.0 ? "zu niedrig" : "zu hoch";
                AlarmMelder?.Invoke($"Warnung: Temperatur {richtung}! {Bezeichnung} in {KuehlKammer} Temperatur: {wert} °C ");
                _alarme.Add(new AlarmEintrag(DateTime.Now, Bezeichnung, $"Temperatur {richtung}: {wert} °C"));
                _alarmausgeloest = true;
            }
            else if(!ausserhalbGrenzen && _alarmausgeloest)
            {
                _alarmausgeloest = false;
            }

        }
    }
}
