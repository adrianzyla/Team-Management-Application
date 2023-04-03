
# 🧑‍💻 **Team Management Application**

Aplikacja "Team Management Application" jest prostym narzędziem do zarządzania zespołem.

Aplikacja została wykonana w języku C#, na platformie WPF. 


## 📱 Opis aplikacji
Po uruchomieniu użytkownik zostaje przywitany ekranem, w którym ma do woboru dwie opcje: 
* **SELECT YOUR TEAM** - pozwala otworzyć istniejący plik .xml z zespołem*.
* **CREATE NEW TEAM** - daje możliowść utworzenia nowego zespołu. Należy podać nazwę zespołu oraz wypełnić informację o liderze, po czym zatwierdzić wszystko przyciskiem "CONFIRM".

<div align="center">
<img src = "https://user-images.githubusercontent.com/100830524/229580382-81b6789e-2488-4651-afae-619390328bfc.png" width = "360"/>
<img src = "https://user-images.githubusercontent.com/100830524/229581036-2193beb5-d03b-431e-a47f-dce40851d756.png" width = "400"/>
</div>

Po wybraniu lub utworzeniu zespołu otwiera nam się główne okno aplikacji. Możemy w nim zobaczyć nazwę zespołu, informację o liderze oraz członków zespołu. 

Główne funkcjonalności aplikacji:
* **EDIT** - po naciśnięciu tego przycisku otwiera nam się nowe okno, w którym mamy możliwość edycji informacji o liderze.
* **ADD** - otwiera nam się okno, w którym mamy możliwość utworzenia nowego członka zespołu po wypełnieniu informacji o nim. 
<div align = "center" width = "300">
<img src = "https://user-images.githubusercontent.com/100830524/229583888-df56f604-5fbd-4162-a317-4354b796c8ae.png" />
</div>

* **REMOVE** - usuwa nam wybranego członka z listy członków zespołu.
* **EDIT MEMBER** - otwiera nam się nowe okno, w którym mamy możliwość edycji informacji o członku zespołu.
* **SORT** i **SORT BY PESEL** - przyciski pozwalają posortować naszą listę członków zespołu
* **CHANGE STATUS** - pozwala nam zmienić status (aktywny / nie aktywny) wybranego członka z listy. 
* **CLONE** - pozwala utworzyć kopię członka zespołu z listy. 

Na samym dole głównego okna mamy textbox **"Function"**, dzięki któremu możemy wyświetlić na liście tylko tych członków pełniących wpisaną przez nas funkcję po naciśnięciu przycisku FIND. Przyciskiem RESET możemy wrócić do początkowej listy.


<div align="center">
<video src = "https://user-images.githubusercontent.com/100830524/229593580-3ba5c738-8442-4f63-9dff-0fc36b03b5f7.mp4"/>
</div>


Dodatkowo w lewym górnym roku głównej aplikacji mamy DockPanel, w którym mamy opcję:
* **Save** - zapisu pliku naszego zespołu w formacie .xml, w wybranym przez nas folderze
* **Open** - otwarcia pliku .xml innego zespołu
* **Exit** - zamknąć główne okno aplikacji 

<div width = "300">
<img src = "https://user-images.githubusercontent.com/100830524/229594987-856b8718-56a0-4c5b-a512-986a501fcb40.png" />
</div>



Przed zamknięciem głównego okna użytkownikowi wyświetla się informacja czy chce zapisać zmiany przez zamknięciem. 


##  
*w pliku na githubie, w folderze TeamManagementApp\bin\Debug umieszczone są dwa pliki xml z przykładowymi zespołami "teamFile.xml" oraz "teamAFile.xml". 

