
# 🧑‍💻 **Team Management Application**

Aplikacja "Team Management Application" jest prostym narzędziem do zarządzania zespołem.

Aplikacja została wykonana w języku C#, na platformie WPF. 


## 📱 Opis aplikacji
Po uruchomieniu użytkownik zostaje przywitany ekranem, w którym ma do woboru dwie opcje: 
* **SELECT YOUR TEAM** - pozwala otworzyć istniejący plik .xml z zespołem*.
* **CREATE NEW TEAM** - daje możliowść utworzenia nowego zespołu. Należy podać nazwę zespołu oraz wypełnić informację o liderze, po czym zatwierdzić wszystko przyciskiem "CONFIRM".

Po wybraniu lub utworzeniu zespołu otwiera nam się główne okno aplikacji. Możemy w nim zobaczyć nazwę zespołu, informację o liderze oraz członków zespołu. 

Główne funkcjonalności aplikacji:
* **EDIT** - po naciśnięciu tego przycisku otwiera nam się nowe okno, w którym mamy możliwość edycji informacji o liderze.
* **ADD** - otwiera nam się okno, w którym mamy możliwość utworzenia nowego członka zespołu po wypełnieniu informacji o nim. 
* **REMOVE** - usuwa nam wybranego członka z listy członków zespołu.
* **EDIT MEMBER** - otwiera nam się nowe okno, w którym mamy możliwość edycji informacji o członku zespołu.
* **SORT** i **SORT BY PESEL** - przyciski pozwalają posortować naszą listę członków zespołu
* **CHANGE STATUS** - pozwala nam zmienić status (aktywny / nie aktywny) wybranego członka z listy. 
* **CLONE** - pozwala utworzyć kopię członka zespołu z listy. 

Na samym dole głównego okna mamy textbox **"Function"**, dzięki któremu możemy wyświetlić na liście tylko tych członków pełniących wpisaną przez nas funkcję po naciśnięciu przycisku FIND. Przyciskiem RESET możemy wrócić do początkowej listy.

Dodatkowo w lewym górnym roku głównej aplikacji mamy DockPanel, w którym mamy opcję:
* **Save** - zapisu pliku naszego zespołu w formacie .xml, w wybranym przez nas folderze
* **Open** - otwarcia pliku .xml innego zespołu
* **Exit** - zamknąć główne okno aplikacji 

Przed zamknięciem głównego okna użytkownikowi wyświetla się informacja czy chce zapisać zmiany przez zamknięciem. 


##  
*w pliku na githubie, w folderze TeamManagementApp\bin\Debug umieszczone są dwa pliki xml z przykładowymi zespołami "teamFile.xml" oraz "teamAFile.xml". 

