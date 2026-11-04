using Frisch_Flott_GmbH;

BildschirmMelder bildschirm = new BildschirmMelder();
EmailMelder email = new EmailMelder("kuehllager@frisch-flott.de");

List <Sensor> sensoren = new List<Sensor>
{
    new Sensor("S1", "Kuehlkammer 1"),
    new Sensor("S2", "Kuehlkammer 1"),
    new Sensor("S3", "Kuehlkammer 2"),
    new Sensor("S4", "Kuehlkammer 2")
};

foreach (Sensor sensor in sensoren)
{
    sensor.AlarmMelder += bildschirm.MeldeAlarm;
    sensor.AlarmMelder += email.MeldeAlarm;
}
Protokoll protokoll = new Protokoll(sensoren);
protokoll.Starten(10.0);

Console.ReadKey();
protokoll.Beenden();
protokoll.Speichern($"protokoll_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv");

