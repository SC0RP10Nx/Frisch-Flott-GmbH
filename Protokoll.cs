using System;
using System.Collections.Generic;
using System.Text;

namespace Frisch_Flott_GmbH
{
    public class Protokoll
    {
        private readonly List<Sensor>_sensoren;
        private readonly Random _zufall = new Random();

        public DateTime Start { get; private set;}
        public DateTime End { get; private set;}
        private System.Timers.Timer? _timer;
        public Protokoll(List<Sensor> sensoren)
        {
            _sensoren = sensoren;
        }

        public void Starten(double intervallSekunden)
        {
            Start = DateTime.Now;
            Console.WriteLine($"Protokoll gestartet um {Start}");

            _timer = new System.Timers.Timer(intervallSekunden * 1000);
            _timer.Elapsed += TimerAbgelaufen;
            _timer.Start();
        }

        private void TimerAbgelaufen(object? sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (Sensor sensor in _sensoren)
            {
                sensor.TemperaturMessen(TemperaturErmitteln());
            }
        }

        public void Beenden() {
            End = DateTime.Now;
            Console.WriteLine($"Protokoll beendet um {End}");
        }
        public void Speichern(string dateipfad)
        {
            StringBuilder inhalt = new StringBuilder();

            inhalt.AppendLine($"Protokollstart;{Start}");
            inhalt.AppendLine($"Protokollende;{End}");
            inhalt.AppendLine();

            inhalt.AppendLine("Zeitpunkt;Sensor;Kuehlkammer;Temperatur");
            foreach (Sensor sensor in _sensoren)
            {
                foreach (Messwert messwert in sensor.Verlauf)
                {
                    inhalt.AppendLine($"{messwert.Zeitpunkt};{sensor.Bezeichnung};{sensor.KuehlKammer};{messwert.Wert}");
                }
            }
            inhalt.AppendLine();
            inhalt.AppendLine("Zeitpunkt;Sensor;Meldung");
            foreach (Sensor sensor in _sensoren)
            {
                foreach (AlarmEintrag alarm in sensor.Alarme)
                {
                    inhalt.AppendLine($"{alarm.Zeitpunkt:dd.MM.yyyy HH:mm:ss};{alarm.Sensor};{alarm.Meldung}");
                }
            }
            
            File.WriteAllText(dateipfad, inhalt.ToString(), new  UTF8Encoding(true));
            Console.WriteLine($"Protokoll gespeichert: {dateipfad}");
        }
        private double TemperaturErmitteln()
        {
            double wert = _zufall.NextDouble() * 16.0 - 17.0;
            return Math.Round(wert, 1);
        }
    }
}
