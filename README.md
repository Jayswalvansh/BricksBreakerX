# 🎮 BricksBreakerX

> A neon-themed 2D arcade brick breaker game developed using Unity and C#.

BricksBreakerX is a 2D arcade-style brick breaker game inspired by the classic brick-breaking genre. The player controls a paddle to keep a ball in play while destroying colored brick formations.

The project combines physics-based ball movement, paddle interaction, destructible bricks, score tracking, a lives system, audio feedback, and a neon-inspired visual environment.

---

## 📌 Table of Contents

- [About the Project](#-about-the-project)
- [Game Overview](#-game-overview)
- [Features](#-features)
- [Gameplay](#-gameplay)
- [Game Mechanics](#-game-mechanics)
- [Scoring System](#-scoring-system)
- [Lives System](#-lives-system)
- [Collision and Physics](#-collision-and-physics)
- [Audio](#-audio)
- [Visual Design](#-visual-design)
- [User Interface](#-user-interface)
- [Technologies Used](#-technologies-used)
- [Unity Version](#-unity-version)
- [Project Structure](#-project-structure)
- [How the Project Works](#-how-the-project-works)
- [How to Open the Project](#-how-to-open-the-project)
- [How to Play](#-how-to-play)
- [Building the Game](#-building-the-game)
- [Development](#-development)
- [Challenges and Learning](#-challenges-and-learning)
- [Future Improvements](#-future-improvements)
- [Project Status](#-project-status)
- [Credits](#-credits)
- [License](#-license)
- [Developer](#-developer)

---

# 🎯 About the Project

BricksBreakerX is a Unity-based 2D game project created to implement the core mechanics of a traditional brick breaker game while experimenting with physics, collision handling, game-state management, UI systems, audio, and 2D visual presentation.

The player controls a paddle positioned near the bottom of the play area. A ball moves around the game area and interacts with the paddle, walls, and brick formations.

The primary objective is to destroy the bricks while keeping the ball from leaving the playable area.

The game includes a score system and lives system to provide progression and feedback during gameplay.

---

# 🎮 Game Overview

The core gameplay loop is simple:

1. The player controls the paddle.
2. The ball moves through the play area.
3. The paddle is used to keep the ball in play.
4. The ball collides with bricks.
5. Bricks are destroyed through collision.
6. The player's score increases as bricks are destroyed.
7. The lives counter tracks the player's remaining attempts.
8. The player continues until the available lives are exhausted or the brick formation is cleared.

The game uses a neon-inspired visual style to give the classic brick breaker concept a modern arcade appearance.

---

# ✨ Features

## 🎮 Core Gameplay

- Paddle-controlled gameplay
- Ball-based brick breaking
- Destructible brick formations
- Ball and paddle interaction
- Physics-based movement
- Wall and boundary interaction
- Collision-based brick destruction
- Score tracking
- Lives tracking
- Multiple brick arrangements
- Game-state based gameplay

## 🧱 Brick System

The game contains colored brick formations that interact with the ball through collision detection.

When the ball hits a brick, the corresponding brick can be destroyed and the player's score is updated.

Different brick arrangements provide variation in the gameplay area.

## 🏓 Paddle System

The paddle is the primary player-controlled object.

The player uses the paddle to influence the ball's movement and prevent the ball from leaving the playable area.

The paddle is visually represented using a bright cyan/neon style that matches the overall game theme.

## 🟡 Ball System

The ball is the primary gameplay object responsible for interacting with:

- Paddle
- Bricks
- Walls
- Game boundaries

Its movement is handled using Unity's physics and collision systems.

The ball's trajectory changes when it interacts with different objects within the game environment.

## 🏆 Score System

The game includes an on-screen score counter that provides real-time feedback to the player.

The score is updated as gameplay objectives such as destroying bricks are completed.

This gives the player a measurable goal and adds an arcade-style progression system.

## ❤️ Lives System

A lives counter is displayed as part of the game's HUD.

The lives system gives the player multiple attempts to continue playing after losing the ball.

This creates a simple risk-and-reward structure while maintaining the arcade gameplay experience.

---

# 💥 Collision and Physics

Physics and collision detection are an important part of BricksBreakerX.

The game uses Unity's 2D physics functionality to handle interactions between gameplay objects.

Important collision interactions include:

- Ball ↔ Paddle
- Ball ↔ Brick
- Ball ↔ Wall
- Ball ↔ Game boundaries

These interactions determine the ball's movement and control the brick destruction gameplay loop.

Using physics-based interactions allows the gameplay to feel dynamic rather than relying entirely on manually calculated movement.

---

# 🔊 Audio

The project contains audio assets for gameplay feedback and background atmosphere.

Audio is used to enhance the arcade-style experience.

The project includes assets for:

- Ball bounce sound effects
- Gameplay sound effects
- Background music
- Retro/synthwave-style music

Sound feedback helps make important gameplay events more noticeable, particularly ball interactions and collisions.

> **Note:** Audio assets should be properly credited according to the license/usage terms of their original sources.

---

# 🎨 Visual Design

BricksBreakerX uses a neon-inspired visual style.

The game environment combines:

- Purple/blue background tones
- Grid-based background
- Bright cyan paddle
- Yellow gameplay ball
- Colorful brick formations
- High-contrast HUD elements

The visual design is intended to create a retro-futuristic arcade atmosphere.

The contrast between the dark environment and bright gameplay objects makes the ball, paddle, and bricks easy to identify during gameplay.

---

# 🖥️ User Interface

The game includes an in-game HUD that displays important gameplay information.

### HUD Elements

- Score
- Lives

The HUD provides immediate feedback to the player without requiring them to leave the gameplay screen.

The interface follows the overall neon visual style of the game.

---

# 🕹️ Gameplay

The main objective is to destroy the brick formations while maintaining control of the ball.

### Basic gameplay loop

```text
              ┌───────────────┐
              │ Brick Formation│
              └───────┬───────┘
                      │
                      ▼
                    🟡 Ball
                      │
                      ▼
                 ─────────
                  Paddle
                      │
                      ▼
              Keep Ball In Play
                      │
                      ▼
               Destroy Bricks
                      │
                      ▼
                 Increase Score
