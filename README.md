# SaveThePlanet - Educatieve Game over Klimaatbewustzijn 🌍

## 🎮 Over het project

**SaveThePlanet** is een educatief 2D-spel dat jongeren van **11 tot 15 jaar** bewust wil maken van de impact van hun acties op het milieu. Door middel van interactieve missies, minigames, weetjes en een quiz aan het einde, leert de speler hoe kleine acties een verschil kunnen maken voor onze planeet.

Dit spel werd ontwikkeld als **eindproject** in het kader van mijn opleiding aan de **Erasmus Hogeschool Brussel**.

---

## 🛠️ Gebruikte technologieën

- Unity (versie 2022.3.15f1)
- C#
- DOTween (voor animaties en fades)
- ScriptableObjects (voor dialogen en quests)
- PlayerPrefs (voor opslag van voortgang)
- Tilemaps en colliders (2D wereld)

---

## 🗺️ Inhoud van het spel

### 🌱 Missies
- **Lichten uitschakelen** in huizen (energie besparen) – gegeven door de burgemeester
- **Plastic flessen oprapen** op het strand – gegeven door de visser
- **Bomen planten** in het bos – gegeven door de boswachter

### 🧠 Weetjes via NPC's
- NPC's geven educatieve weetjes over milieu-onderwerpen
- Geschreven in natuurlijke taal, aangepast aan jongeren

### ❓ Quiz + Eco-score
- Een quiz van 10 vragen in de laatste scène test wat de speler geleerd heeft
- De speler krijgt een **eco-score** op basis van zijn/haar acties in het spel

---

## 📁 Structuur van het project

```plaintext
Assets/
│
├── Animations/             → Speler- en objectanimaties
├── Audio/                  → Sound effects (lichtschakelaar, teleport, etc.)
├── Materials/              → Materialen voor 2D-objecten
├── Music/                  → In-game en menu muziek
├── Plugins/                → DOTween en andere externe tools
├── Prefabs/                → Herbruikbare objecten (speler, NPC's, interacties)
├── Resources/              → Persistentie-objecten (Fade, GameManager, etc.)
├── SceneManagement/        → Scripts voor scèneovergangen
├── Scenes/                 → Alle spelscènes
├── Scripts/                → Interacties, quests, NPC-logica, dialogen
├── Settings/               → Projectinstellingen
├── Sprites/                → Alle 2D-afbeeldingen
├── TextMesh Pro/           → UI-fonts
├── Tiles/                  → Tilesets voor maps
├── UI/                     → Knoppen, quiz, eco-score UI
```

---

## 🔧 Installatie & Uitvoering

1. Open het project in **Unity 2022.3.15f1**
2. Start het spel vanaf `MainScene.unity`
3. Gebruik de **pijltjestoetsen** om te bewegen, **spatiebalk** om te interageren
4. Spelvoortgang wordt automatisch opgeslagen met **PlayerPrefs**
5. Voor testdoeleinden is een **resetfunctie** voorzien

---

## 📺 Inspiratie & Technische Basis

Aan het begin van mijn project heb ik tutorials bekeken van het YouTube-kanaal [**GameDev Experiments**](https://www.youtube.com/@GameDevExperiments/videos). Deze tutorials hielpen mij bij het begrijpen van:

- De werking van ScriptableObjects voor dialogen 
- De implementatie van veldzicht en simpele NPC-interacties 

Na het opbouwen van deze basis heb ik het spel **volledig gepersonaliseerd en aangepast aan mijn eigen projectdoel**:

- Educatieve thema’s rond klimaatverandering  
- Eigen geschreven dialogen in het Nederlands  
- Specifieke opdrachten per gebied (lampen, afval, bomen)  
- Toegevoegde quiz en eco-score  
- Unieke combinatie van grafische en auditieve assets  

🎯 Mijn spel is dus geen kopie van een tutorial, maar een persoonlijk project dat gebruikmaakt van enkele technieken die ik heb geleerd, net zoals je leert autorijden op les maar zelf je weg kiest.


---

### 🤖 Gebruik van AI - ChatGPT

Tijdens het ontwikkelen van het spel heb ik ook regelmatig gebruik gemaakt van **ChatGPT** voor hulp bij:
- Het oplossen van bugs (bv. duplicatie van teleportatieobjecten, cutscene triggers, foutieve quest-validaties…)
- Het verbeteren en structureren van scripts in Unity
- Het schrijven van educatieve dialogen in het Nederlands

Deze AI-ondersteuning hielp me vooral om sneller oplossingen te vinden en problemen te begrijpen, maar de implementatie en aanpassing gebeurden altijd op basis van mijn eigen inzicht en projectdoelen.

---

## 📚 Bronnen & Credits

### 🎨 Grafische assets
- Katten sprites: [pop-shop-packs](https://pop-shop-packs.itch.io/cats-pixel-asset-pack?download)
- Boerderijdieren: [Solaria Farm](https://jamiebrownhill.itch.io/solaria-farm-animal-sprites?download)
- Afval en rommel: [BTL Games](https://btl-games.itch.io/trash-and-junk-asset-pack?download)
- Bijen sprites: [Elthen](https://elthen.itch.io/2d-pixel-art-bumble-bee-sprites)
- Wilde dieren: [TTH Animals](https://thkaspar.itch.io/tth-animals)
- Pokémon Tutorial Art Assets: [GameDevExperiments GitHub](https://github.com/GameDevExperiments/Pokemon-Tutorial-Art-Assets)
- Eco Dog: [Artoellie](https://artoellie.itch.io/adopt-goldie-for-free)
- Nieuwe huizen tileset: [netorca91](https://netorca91.itch.io/basictowntiles)
- Zelf ontworpen NPC’s gebaseerd op: [Universal LPC Character Generator](https://liberatedpixelcup.github.io/Universal-LPC-Spritesheet-Character-Generator)

---

### 🎵 Audio & Muziek
- Village muziek: [OpenGameArt – Village Music](https://opengameart.org/content/village-music)  
- Strand muziek: [OpenGameArt – Beach 01](https://opengameart.org/content/beach-01)  
- Bos muziek: [OpenGameArt – Forest Theme](https://opengameart.org/content/forest-theme)  
- Stadsthema: [OpenGameArt – Town Theme](https://opengameart.org/content/town-theme-rpg)  
- Menu muziek: [OpenGameArt – Dreamy RPG Theme](https://opengameart.org/content/dreamy-side-scrolling-rpg-title-menu-and-rpg-village-exploration-hitctrl-remixed)  

- Win geluid: [OpenGameArt – Win Sound](https://opengameart.org/content/win-sound-2)  
- Beep geluid: [OpenGameArt – Beep Tone SFX](https://opengameart.org/content/beep-tone-sound-sfx)  
- Teleport geluid: [OpenGameArt – Teleport Spell](https://opengameart.org/content/teleport-spell)  
- Lichtschakelaar geluid: [OpenGameArt – Light Switch](https://opengameart.org/content/light-switch-on-sfx-sound-effect)  
- Regengeluid / ambiance: [OpenGameArt – School Day Rain](https://opengameart.org/content/school-day-rain-sun-loop)  

---

### 📺 Inspiratie
- Tutorials: [GameDev Experiments – YouTube](https://www.youtube.com/@GameDevExperiments/videos)

---

### 🖼️ AI-gegenereerde beelden
- Hoofdmenu pixel-art achtergrond (stijlvol landschap): **gegenereerd via ChatGPT / DALL·E**


### 📁 Designmateriaal
-  Afbeeldingen zijn te vinden in de map `/Design`
- **Quizvragen**: zelf geschreven in het Nederlands, afgestemd op 11–15 jaar.  
- **Quiz‑UI**: zelf ontworpen pixelart‑schoolbord als achtergrond (map `/Design`).  
- **DialogBox (pixelart)**: **zelf ontworpen** dialoogvenster (rechthoekige sprite met zachte rand), handmatig gepositioneerd/geschaald en geïntegreerd met mijn dialoogsysteem (`DialogManager`).  
- **Hoofdmenu achtergrond**: AI-gegenereerd via ChatGPT/DALL·E, met persoonlijke prompt en integratie.  
- **Sleutelbeeld (cover Save The Planet)**: zelf samengesteld voor presentaties.  
- **Tiles**: eigen ontworpen tilesets voor strand, water, bos, gras en interieurvloeren.  
- **NPC’s**: zelf ontworpen via de LPC Character Generator, met eigen outfits/kleuren/details.  

---

## 🗃️ Volledig overzicht

Een volledig overzicht van alle assets, muziek, geluiden en bronnen bevindt zich in het bestand **`Bronnen.txt`** in deze projectmap.

---

## 📑 Tweede Zit – Reflectie & Eigen Inbreng

In deze reflectie toon ik aan hoeveel werk en persoonlijke inzet ik geleverd heb in de verdere ontwikkeling van mijn educatieve game **‘Save The Planet’**.  
Alle onderstaande toevoegingen en verbeteringen zijn specifiek uitgewerkt in het kader van mijn **tweede zit**.  

Na de eerste feedbackronde (8/20 wegens *"onvoldoende eigen inzet"*) heb ik besloten om mijn bijdrage grondig uit te breiden. In totaal heb ik **18 onderdelen** volledig zelf ontworpen, gecodeerd of geanalyseerd, inclusief animaties, interactieve systemen, visuele elementen en gameplay-mechanica.  

Elk onderdeel wordt hieronder concreet opgesomd, maar voor de **volledige technische en pedagogische details** verwijs ik naar mijn **documentatie**. Daarin heb ik elke toevoeging uitgebreid beschreven met uitleg over het proces, de oplossingen voor bugs, en de educatieve keuzes.  

---

### 1. Dynamisch weersysteem in het bos  
### 2. Optiemenu – Geluidsinstellingen  
### 3. Wind-effect op het strand  
### 4. Eigen karakter + realistische graafanimatie  
### 5. Realistische zaai-animatie bij bomen planten  
### 6. Oprap-animatie bij flessen  
### 7. Schakel-animatie bij lampen  
### 8. Eigen DialogBox implementatie  
### 9. Unieke NPC-creatie  
### 10. Eigen pixelart-schoolbord voor quiz  
### 11. AI-achtergrond hoofdmenu met persoonlijke prompt  
### 12. Poging richtingspijl (pointer)  
### 13. Trashcan animatie  
### 14. Statistieken bovenaan het scherm  
### 15. Nieuwe huizen met unieke stijl  
### 16. EcoDog volgsysteem  
### 17. Eigen ontworpen tiles (strand, water, bos, gras, vloertileset)  
### 18. Aanpassingen aan mijn magazine – visuele samenhang met het spel  

---

### 🎯 Onderzoeksvraag
**Hoe kunnen we een educatief spel ontwerpen dat jongeren bewust maakt van klimaatproblemen en hen aanzet tot duurzamer gedrag?**

### 💡 Antwoord van mijn game
- Jongeren voeren drie concrete acties uit: bomen planten, afval opruimen, energie besparen.  
- Bij elke actie verandert de spelwereld én dalen de live-statistieken.  
- NPC’s geven weetjes in verhalende vorm, gekoppeld aan thema’s.  
- Aan het einde: een **eco-score**, gebaseerd op keuzes.  

Zo maakt mijn spel duidelijk: **jouw keuzes hebben impact**.  
Dat is precies de kern van mijn onderzoeksvraag.

---

Met dit document toon ik aan dat ik tijdens mijn tweede zit **actief en zelfstandig gewerkt** heb aan mijn spel.  
Ik heb gekozen om verschillende onderdelen volledig zelf te ontwerpen, te programmeren en te verbeteren.  

👉 Voor meer details over elk onderdeel verwijs ik naar mijn **Tweede Zit documentatie**, waarin alles uitgebreid beschreven staat.  


## 👨‍💻 Auteur

**Sabri Imnadine**  
Eindproject – Erasmus Hogeschool Brussel   
Mentor: Jan Van Caneghem (EHB) 

---

## 🙏 Bedankt

Dank aan iedereen die mij begeleid heeft tijdens dit project. Ik heb veel bijgeleerd op vlak van Unity, programmeren, storytelling en educatief spelontwerp.






