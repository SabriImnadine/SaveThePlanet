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

## 📺 Tutorials & Inspiratie

Aan het begin van mijn project heb ik tutorials gevolgd van het YouTube-kanaal [**GameDev Experiments**](https://www.youtube.com/@GameDevExperiments/videos). Deze tutorials hielpen mij bij het begrijpen van:

- Interactie met NPC’s  
- Quest-logica  
- ScriptableObjects voor dialogen  
- Veldzicht en automatische beweging  

Na het opbouwen van deze basis heb ik het spel **volledig gepersonaliseerd en aangepast aan mijn eigen projectdoel**:

- Educatieve thema’s rond klimaatverandering  
- Eigen geschreven dialogen in het Nederlands  
- Specifieke opdrachten per gebied (lampen, afval, bomen)  
- Toegevoegde quiz en eco-score  
- Unieke combinatie van grafische en auditieve assets  

🎯 **Het eindresultaat is dus een eigen creatie**, gebouwd op geleerde technieken maar met een volledige persoonlijke invulling.


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
- NPC Sprites: [solaarnoble.itch.io](https://solaarnoble.itch.io/free-npcs)
- Katten sprites: [pop-shop-packs](https://pop-shop-packs.itch.io/cats-pixel-asset-pack?download)
- Boerderij dieren: [Solaria Farm](https://jamiebrownhill.itch.io/solaria-farm-animal-sprites?download)
- Afval sprites: [BTL Games](https://btl-games.itch.io/trash-and-junk-asset-pack?download)
- Bijen sprites: [Elthen](https://elthen.itch.io/2d-pixel-art-bumble-bee-sprites)
- Wilde dieren: [TTH Animals](https://thkaspar.itch.io/tth-animals)

### 🎵 Audio & Muziek
- Village muziek: [OpenGameArt - Village Music](https://opengameart.org/content/village-music)
- Strand muziek: [OpenGameArt - Beach 01](https://opengameart.org/content/beach-01)
- Bos muziek: [OpenGameArt - Forest Theme](https://opengameart.org/content/forest-theme)
- Stadsthema: [OpenGameArt - Town Theme](https://opengameart.org/content/town-theme-rpg)
- Menu muziek: [Dreamy RPG Theme](https://opengameart.org/content/dreamy-side-scrolling-rpg-title-menu-and-rpg-village-exploration-hitctrl-remixed)
- Win sound, light switch, beep, teleport: zie `Bronnen.txt` in het project

### 🖼️ Afbeeldingen
- Hoofdmenu achtergrond: **AI gegenereerd via ChatGPT**

---

## 🗃️ Volledig overzicht

Een volledig overzicht van alle assets, muziek, geluiden en bronnen bevindt zich in het bestand **`Bronnen.txt`** in deze projectmap.

---

## 👨‍💻 Auteur

**Sabri Imnadine**  
Eindproject – Erasmus Hogeschool Brussel   
Mentor: Jan Van Caneghem (EHB) 

---

## 🙏 Bedankt

Dank aan iedereen die mij begeleid heeft tijdens dit project. Ik heb veel bijgeleerd op vlak van Unity, programmeren, storytelling en educatief spelontwerp.






