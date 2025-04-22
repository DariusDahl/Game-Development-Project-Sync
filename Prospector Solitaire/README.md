# Prospector Solitaire

Welcome to Prospector Solitaire, a stylish twist on the classic Tri-Peaks card game! Clear the board by selecting cards in ascending or descending order, keeping your streak alive and your score climbing. This version was built entirely in Unity, with a smooth UI and animated card transitions.

## 🎮 How to Play
- Click face-up cards from the mine that are one rank above or below the current target card.
- If no moves are available, click the draw pile to reveal the next target card.
- Continue playing until all cards are cleared from the mine or no moves remain.
- Watch your chain combo increase your score as you clear cards consecutively!

## 🛠 Unique Features
- **Smooth Card Animation** – Card movements use Bézier curves for fluid, polished transitions.
- **Scoring System with Floating Text** – Visual score updates fly toward the scoreboard and scale dynamically.
- **Tri-Peaks Layout** – Features a custom JSON-based layout system for flexible card placement.
- **UI Game Over Messages** – End-of-round messages display whether you win or lose and update the high score in real time.
- **TextMeshPro Integration** – Sharp, responsive text for game state, score, and more.
- **Multi-State Card Logic** – Cards can be in draw pile, mine, target, or discard states with appropriate rules and behavior.

## 🧪 Project Setup
This folder contains all the Unity project files necessary to build, run, and extend **Prospector Solitaire**. It includes:
- `Assets/` – All game assets including art, prefabs, scenes, and scripts
- `Scenes/` – The primary game scene (`__Prospector_Scene_0`)
- `Scripts/` – Organized and commented C# files for game logic, UI, score tracking, and animation
- `UserSettings/` – Editor and input configuration files
- `ProjectSettings/` – Unity-specific project settings for consistent builds and behavior

> **Note:** This folder does *not* include the WebGL build. Please refer to the separate WebGL folder if you’re looking to run the game in-browser.

## 🏗 Built With
- **Unity 2022.3** – Game engine
- **C#** – Full game logic and state handling
- **TextMeshPro** – Clean, modern UI rendering
- **BezierMover** – Custom script for animating objects using Bézier paths
- **PlayerPrefs** – Local high score saving and reset functionality

## 📜 License
This project is open-source and available for anyone to play, improve, or remix. Fork it, make your own layout, or swap out the graphics – have fun!

---

Enjoy playing **Prospector Solitaire**! ♠️♦️♣️♥️
