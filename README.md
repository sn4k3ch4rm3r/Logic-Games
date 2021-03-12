[![CodeFactor](https://www.codefactor.io/repository/github/sn4k3ch4rm3r/logic-games/badge/master)](https://www.codefactor.io/repository/github/sn4k3ch4rm3r/logic-games/overview/master)

# Tetris
### Leírás
Klasszikus játék, 1984-ben jött ki az első verziója. Azóta sok verziója jött ki, ahol különböző játékszabályokkal kell minél tovább jutni, vagy szinteket teljesíteni. Tóth Boldizsár az eredeti szabályokkal írta meg. 
### Játék menete: 
- Nyilakkal lehet irányítani:
  - Fel nyíllal lehet forgatni az éppen leeső tetriminot.
  - Le nyíllal lehet felgyorsítani az esését. Ilyenkor több pontot kap a felhasználó.
  - Jobb/Bal nyilakkal lehet vízszintesen mozgatni.
-	Úgy kell egymás mellé helyezni az ábrákat, hogy ne maradjanak lyukak. Ha egy teljes sort sikerül lyukak nélkül megépíteni, a sor eltűnik.
### Statisztika
- Legmagasabb pontszám
- Törölt sorok
- Játékban töltött idő
- Játékok száma

![image](https://user-images.githubusercontent.com/39193138/110919145-38312580-831c-11eb-917d-c937b540dc5a.png) ![tetrisgo](https://user-images.githubusercontent.com/39193138/110919242-51d26d00-831c-11eb-9c15-0800c775a111.png)


# 2048
### Leírás
2014-ben jött ki a játék, eredetileg JavaScriptben írták. Tóth Balázs az alap szabályukon alapuló 2048 játékot írta meg.
### Játék menete
- Nyilakkal lehet irányítani:
  - Nyilakkal lehet mozgatni a csempéket. A nyíl megnyomására az összes csempe a pályán elmozdul abba az irányba, ha el tud.
- Úgy kell a számokat mozgatni, hogy a 2 hatványai végül 2048-at adjanak ki.
- A játék akkor ér véget:
  - ha már egyik csempét sem tudod mozgatni egyik irányba sem.
  - vagy ha egyik csempének az értéke egyenlő 2048-cal.
    - viszont ilyenkor a játék megkérdezi, hogy szeretnéd-e folytatni.
### Statisztika
- Legmagasabb pontszám
- Megnyert játékok száma
- Játékban töltött idő
- Játékok száma

![image](https://user-images.githubusercontent.com/39193138/110917732-86452980-831a-11eb-8e83-f7b4f22aeedd.png) ![image](https://user-images.githubusercontent.com/39193138/110917756-8e04ce00-831a-11eb-9a9c-ce944d28640b.png)

# Aknakereső
### Leírás
Az aknakereső (Minesweeper) számítógépes játék, melynek célja a mezőn lévő összes akna megtalálása, illetve azok elkerülése. Az aknakereső alapvetően logikai játék, de bármely játékmenetben előfordulhat olyan szituáció is, amelyben a helyes megoldás a szerencsén múlik. Egyszemélyes játék, de létezik kétszemélyes változata is, annak szabályai és stratégiái néhány ponton eltérnek az egyszemélyes verzióétól.
### Játék menete 
- Egy egyforma mezőkre osztott táblával indul a játék, ezek alatt rejtőzködnek az aknák. A tábla mérete és az aknák száma a nehézségi szinttől függően változik.
- A mezők állapotai a következők lehetnek:
  - lefedett (alaphelyzet),
  - feltárt, szomszédos aknával,
  - feltárt aknamentes,
  - zászlós (véleményünk szerint akna van alatta),
  - kérdőjeles (lehetséges, hogy akna van alatta),
  - feltárt, robbanó aknával (ha egy mező ilyen állapotba kerül, a játék véget ér, a játékos a menetet elvesztette).
- Egéren bal kattintással a mezőre tippet hajtunk végre, hogy azt mondjuk, hogy ott nincs bomba
- Egéren jobb kattintással a mezőre tippet hajtunk végre, hogy azt mondjuk, hogy ott a felhasználó szerint biztosan van bomba.
- A program folyamatosan jelzi a még megjelöletlen aknák számát, illetve az eltelt időt.
### Statisztika
- Legjobb időt, ami alatt megnyerted a játékot
- Megnyert játékok száma
- Felfedezett mezők száma
- Lerakott zászlók száma
- Játékban töltött idő

![image](https://user-images.githubusercontent.com/39193138/110918505-87c32180-831b-11eb-9553-29b365c2a7a6.png) ![image](https://user-images.githubusercontent.com/39193138/110918515-8bef3f00-831b-11eb-94d4-e0f952b10bec.png)

# Statisztika
Megjeleníti a játékokról gyűjtött adatokat

![image](https://user-images.githubusercontent.com/39193138/110919677-d1f8d280-831c-11eb-925d-49c23856c1ab.png)

