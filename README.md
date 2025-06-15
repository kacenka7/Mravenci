# Mravenci

## Návrh hry

**Mravenci** – hra pro dva hráče v Blazoru.  
Zjednodušená verze počítačové hry Miroslava Němečka:  
[https://mravenci.qex.cz](https://mravenci.qex.cz)

---

## Technologie

- C# (herní logika, modely, OOP) – Blazor WebAssembly App
- Blazor (UI – tlačítka, zobrazování karet, tahy)
- HTML/CSS (styling rozhraní)

---

## Popis hry

Karetní hra pro dva hráče.  
**Cílem hry** je postavit hrad o výšce 100 nebo zničit hrad soupeře.

Hráči používají karty reprezentující akce – **stavbu** nebo **útok**.  
Každá karta spotřebuje určité množství surovin.

---

## Herní princip

- Hráči se střídají, každý:
  - zahraje jednu kartu
  - dobere si jednu kartu
- Každé kolo:
  - hráč získá automaticky 2 cihly a 2 meče
- Na začátku hry:
  - 5 surovin od každého druhu
  - hrad má velikost 30

---

## Hráč (`Hrac`)

- `string Jmeno`
- `int Hrad`
- `int PocetCihel`
- `int PocetZbrani`
- `List<Karta> Ruka`

Dva hráči: **černí** a **červení**.

---

## Karty

Každá karta je `<div>`, má dvě tlačítka: **Hrát** a **Zahodit** (volají metody pomocí `onClick`).

| Název     | Cena       | Účinek                               | Počet |
|-----------|------------|---------------------------------------|--------|
| **Stavební karty** ||||
| Zeď       | 1 cihla    | Hrad +3                               | 8      |
| Základy   | 3 cihly    | Hrad +5                               | 7      |
| Věž       | 7 cihel    | Hrad +10                              | 6      |
| Pevnost   | 15 cihel   | Hrad +20                              | 5      |
| Babylon   | 25 cihel   | Hrad +40                              | 4      |
| Povoz     | 10 cihel   | Hrad +10, soupeřův hrad -10           | 4      |
| Stavitel  | 3 cihly    | Cihly +8                              | 3      |
| Demolice  | 5 cihel    | Cihly soupeře -10                     | 3      |
| **Útočné karty** ||||
| Střelec   | 1 zbraň    | Útok 3                                | 8      |
| Rytíř     | 3 zbraně   | Útok 5                                | 7      |
| Četa      | 5 zbraní   | Útok 10                               | 6      |
| Swat      | 10 zbraní  | Útok 10, Hrad +10                     | 5      |
| Zloděj    | 10 zbraní  | Nepřítel -10 zbraní, hráč +10 zbraní  | 4      |
| Drak      | 15 zbraní  | Útok 20                               | 4      |
| Kovář     | 3 zbraně   | Zbraně +8                             | 3      |
| Sabotáž   | 5 zbraní   | Zbraně nepřítele -10                  | 3      |

---

## Struktura tříd

### Abstraktní třída `Karta`

- `string Nazev`
- `int Cena`
- `string Popis`
- `int Stavba` – stavba vlastního hradu
- Abstraktní metoda `Akce` – zpracuje efekt karty

### `StavebniKarta` (dědí z `Karta`)

- `int Utok` – útok na hrad soupeře
- `int MojeCihly` – připsání cihel
- `int CihlySoupere` – odebrání cihel soupeři

### `UtocnaKarta` (dědí z `Karta`)

- `int Utok`
- `int MojeZbrane`
- `int ZbraneSoupere`

---

## Balíček

- 80 karet celkem (40 stavebních, 40 útočných)
- Reprezentován jako `List<Karta> balicek = new List<Karta>()`
- Míchání pomocí **Fisher–Yates shuffle**

---

## Ruka

- Každý hráč má v ruce vždy **5 karet**
- Každé kolo:
  - dobere 1 kartu
  - zahraje 1 kartu

---

## Průběh hry

1. Vytvoření balíčku: `NovyBalicek`
2. Hráči mají:
   - Hrad: 30
   - Cihly: 5
   - Zbraně: 5
3. Rozdání karet: každý 5 ks (`VezmiKartu`)
4. Začínají **černí mravenci**
5. Hráč zahraje kartu:
   - zavolá se `Akce` → proběhne efekt
   - karta se odstraní z ruky
   - pokud není dost surovin → nelze zahrát
6. Pokud nelze zahrát žádnou kartu → **zahodí** jednu kartu
7. Přepnutí hráče: `aktualniHrac = (aktualniHrac == hrac1) ? hrac2 : hrac1`
8. Dobrání karty (pokud má méně než 5)
9. Hra končí:
   - Hrad ≥ 100 → výhra
   - Hrad ≤ 0 → prohra
10. Pokud dojdou karty → vytvoří se nový balíček

---
