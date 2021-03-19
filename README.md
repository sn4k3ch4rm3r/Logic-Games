[![CodeFactor](https://www.codefactor.io/repository/github/sn4k3ch4rm3r/logic-games/badge/master)](https://www.codefactor.io/repository/github/sn4k3ch4rm3r/logic-games/overview/master)

# Telepítés
Maga a program nem igényel különösebb telepítést, csak el kell indítanunk a `Játék` mappában található `JatekKancso.exe` fájlt és már használhatjuk is, azonban a program összes funkciójának működéséhez adatbázis kapcsolatra van szükségünk. A főmenü `Adatbázis Beállítások` vagy a `Játék` mappában található `config.json` fájl segítségével adhatjuk meg a MySQL adatbázis címét, bejelentkezési adatait, illetve a program által használt adatbázis nevét. Ezen kívül nincs más teendőnk, amennyiben az adatbázis, vagy valamelyik a program által használt tábla nem áll rendelkezésre, az automatikusan létrehozásra kerül.
# Tetris
### Leírás
Klasszikus játék, 1984-ben jött ki az első verziója. Azóta sok verziója jött ki, ahol különböző játékszabályokkal kell minél tovább jutni, vagy szinteket teljesíteni. Tóth Boldizsár az eredeti szabályokkal írta meg. 
### Irányítás
A formákat a nyilak segítségével tudjuk irányítani.
- ⬅/➡ segítségével tudjuk a jelenlegi formát jobbra/balra elmozdítani
- ⬆ segítségével forgathatjuk a jelenlegi formát
- ⬇ segítségével felgyorsíthatjuk a jelenlegi forma esését, ilyenkor kétszer annyi pontot kapunk, mint ha csak az alapsebességgel esne
### A játék célja
A pálya tetején megjelenő formákat kell úgy mozgatnunk, hogy mikor leérkeznek a lehető legkevesebb üres hely maradjon ki, ha egy teljes sort sikerült feltöltenünk, az a sor törlésre kerül, a feljebb lévő sorok pedig lejjebb kerülnek, ezen kívül bónusz pontokat kapunk, attól függően, hogy egyszerre hány sort töröltünk így egyetlen sor 100 pontot ér, ha pedig egyszerre négy sort törlünk az 800 pontot ér. Az elhelyezés előre tervezését segíti az oldalt megjelenő ábra, ami megmutatja, hogy mi lesz a következő forma. A játék akkor ér véget, hogyha nem tudtunk elég sort törölni és a formák elérik a játéktér tetejét.
### Statisztika
- Legmagasabb pontszám
- Törölt sorok
- Játékban töltött idő
- Játékok száma

![image](https://user-images.githubusercontent.com/39193138/110919145-38312580-831c-11eb-917d-c937b540dc5a.png) ![tetrisgo](https://user-images.githubusercontent.com/39193138/110919242-51d26d00-831c-11eb-9c15-0800c775a111.png)


# 2048
### Leírás
2014-ben jött ki [az eredeti játék](https://play2048.co/). Tóth Balázs az eredeti szabályokon alapuló 2048 játékot írta meg.
### Irányítás
A ⬅⬆➡⬇ nyilak segítségével mozdíthatjuk el a csempéket, ilyenkor az összes csempe az adott irányba mozdul egészen amíg a pálya szélébe vagy egy másik csempébe nem ütközik.
### A játék célja
A játék kezdetén kettő, ezután minden lépésnél egy új csempe jelenik meg, melynek értéke lehet 2, vagy ritkább esetben 4.
Mozgatás során hogyha két egyforma értékű csempe van egymás mellett, akkor egy csempévé olvadnak össze, és értékük össze adódik, a feladatunk, hogy ilyen módon elérjük a 2048-at, ilyenkor a játékot befejezhetjük, vagy folytathatjuk tovább.
A játék akkor is véget ér, hogyha a pálya megtelik, és nincs két egyforma értékű csempe egymás mellett, ilyenkor azonban veszítettünk.
### Statisztika
- Legmagasabb pontszám
- Megnyert játékok száma
- Játékban töltött idő
- Játékok száma

![image](https://user-images.githubusercontent.com/39193138/110917732-86452980-831a-11eb-8e83-f7b4f22aeedd.png) ![image](https://user-images.githubusercontent.com/39193138/110917756-8e04ce00-831a-11eb-9a9c-ce944d28640b.png)

# Aknakereső
### Leírás
A játék legismertebb verziója először 1990-ben jelent meg, igazán akkor vált elterjedté, amikor 1992-ben bekerült a Windows 3.1-be és egészen Windows 7-ig elérhető volt az operációs rendszer programjai közt kisebb változtatásokkal. Tóth Bálint a [Google által készített változat](https://www.google.com/fbx?fbx=minesweeper) mintájára készítette el ezt a játékot.
### Irányítás
A bal egérgomb segítségével fedhetünk fel mezőket.
A jobb egérgomb segítségével helyezhetünk el, illetve távolíthatunk el zászlókat. Zászlóval megjelölt mezőt nem tudunk felfedni, először el kell távolítanunk a zászlót.
### A játék célja
Fel kell fednünk az összes olyan mezőt, ahol nincs akna. A zászlóknak a játék eredménye szempontjából nincs jelentősége, csupán nekünk szolgálnak segítségül, így nem tudunk véletlenül felfedni olyan mezőt, amiről biztosan tudjuk, hogy akna, illetve segít átlátni a játékteret. 
A felfedett mezőnek háromféle állapota lehet:
- Üres: ez azt jelenti, hogy az adott mezőn, illteve közvetlen szomszédjában nincs egy akna sem. Üres mező esetén az összes környező üres mező is felfedésre kerül egészen addig amíg szám mezőbe nem ütközünk.
- Szám: a mezőn egy szám jelenik meg 1 és 8 között, ez azt jelenti, hogy az adott mező közvetlen szomszédai közül hány mező tartalmaz aknát. Szomszédnak számítanak az adott mező oldalait, illetve sarkait érintő mezők.
### Statisztika
- Lergrövidebb idő alatt megnyert játék
- Megnyert játékok száma
- Felfedezett mezők száma
- Lerakott zászlók száma
- Játékban töltött idő

![image](https://user-images.githubusercontent.com/39193138/110918505-87c32180-831b-11eb-9553-29b365c2a7a6.png) ![image](https://user-images.githubusercontent.com/39193138/110918515-8bef3f00-831b-11eb-94d4-e0f952b10bec.png)

# Statisztika
Megjeleníti a játékokról gyűjtött adatokat

![image](https://user-images.githubusercontent.com/39193138/110919677-d1f8d280-831c-11eb-925d-49c23856c1ab.png)

