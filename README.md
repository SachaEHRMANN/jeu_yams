# 🎲 SAE P11-W11 : Jeu de Yam's

Projet académique : jeu de Yam’s en C# (console) et visualisation web (HTML/CSS/JS).

---

## ⚡ Fonctionnalités

- **Console C#**
  - Partie à 2 joueurs, 13 tours, 5 dés 🎲
  - Challenges mineurs et majeurs à choisir à chaque tour
  - Calcul des scores, gestion du bonus
  - Export du résumé en JSON

- **Interface Web**
  - Import du JSON (API)
  - Deux affichages : global ou tour par tour 👀
  - Design responsive (Flexbox, adaptatif PC/tablette/mobile)

---

## 🗂️ Exemple JSON

```json
{
  "joueur": "Pseudo",
  "challenges": { "nombre1": 3, "brelan": 12, ... },
  "bonus": 35,
  "score_total": 201
}
```

---

## 🚀 Installation

- **C#** : Compiler, lancer la console et récupérer le fichier JSON.
- **Web** : Ouvrir `index.html`, charger le JSON et explorer la partie.

---

## 🛠️ Technologies

- C#
- HTML / CSS (Flexbox)
- JavaScript
- JSON

---

*Projet réalisé dans le cadre de la SAE P11-W11.*
