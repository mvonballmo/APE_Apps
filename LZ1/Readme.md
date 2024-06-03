# LZ1

## Aufgaben

Das Ziel ist möglichst viele Aufgaben zu lösen. Keine Panik: Auch wenn man nur die erste Aufgabe gelöst hat, ist man schon gut unterwegs.

### Projekt anschauen

Zuerst soll man sich mit dem Code vertraut machen. Insbesondere sind die folgenden Dateien zu beachten:

- LZ1.Core/Services/*.cs
- LZ1.Core.Tests/TestsBase.cs
- LZ1.Core.Tests/*Tests.cs
- LZ1.Maui/MauiProgram.cs
- LZ1.Maui/Services/DialogService.cs

### Tests und Code beheben

Bei jedem Test musst du entscheiden, ob der Fehler liegt am Test oder irgendwo
im Code. Gut überlegen, weil man nicht allzu viel umschreiben muss. ;-)

### LZ1.Maui beheben

Auch wenn alle Tests erfolgreich ausgeführt werden können läuft die Applikation
noch nicht wie erwartet.

Was ist hier los? Haben wir nicht alles getestet? Nein, nicht ganz alles. Wie
unterscheiden sich die Tests von der App? Gibt es ein Dienst/Service, welcher
in der App anders ist als in die Tests?

### Decrement() implementieren

In der App werden `ICounterState.Increment()` und `ICounterService.TryIncrement()` implementiert und getestet.

Die App soll ausgebaut werden, so dass nicht nur das Inkrementieren, sondern auch das Dekrementieren unterstützt wird.

- `ICounterState` und `CounterState` ausbauen.
- `CounterStateTests` ausbauen.
- `ICounterService.TryDecrement()` implementieren.
- Tests in `CounterServiceTests` ausbauen.
- Ein weiteres Button in `MainPage.xaml` einfügen, um dekrementieren zu können.
- Evtl. die bestehenden Methoden umbenennen (passt `OnCounterClicked()` noch?)
