Přidejte dvě ikony do této složky:
 - cookie.png         (normální stav)
 - cookie_hover.png   (hover stav, může mít jasnější okraje nebo "lesk")

Nastavení v IDE (Rider/Visual Studio):
 - Klikněte pravým tlačítkem na každý soubor -> Properties
 - Build Action = Resource
 - Copy to Output Directory = Do not copy

Alternativa: místo PNG použijte vektor (SVG nebo DrawingImage) pro lepší kvalitu při škálování.

Poznámka: použij přesné názvy souborů výše, aby XAML pack URI fungovalo.
