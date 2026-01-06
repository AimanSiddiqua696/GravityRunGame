# Game Report: Evasion Protocol

## 1. Project Overview
**Title:** Evasion Protocol  
**Genre:** 2D High-Stakes Arcade Runner  
**Platform:** Windows (C# .NET Windows Forms)  
**Core Objective:** Survive increasingly difficult levels by dodging hazards, collecting valuable data fragments (coins), and managing health while escaping the automated "Evasion Protocol."

---

## 2. The Narrative: The Spark of Evasion
In the year 2148, the Neo-City is governed by "The Core," a central AI that maintains perfect order. During a routine maintenance sweep, an anonymous courier (the Player) intercepted a corrupted data packet containing evidence of the Core's plan to "re-index" (permanently remove) the outer sector’s population.

The moment the courier accessed the data, the Core triggered the **Evasion Protocol**—a city-wide security lockout and automated neutralization directive. The courier must now navigate through various defensive sectors of the city to reach the subterranean resistance base. 

The story follows this desperate race against time, where every box, falling stone, and automated chaser is a direct manifestation of the Core's intent to silence the truth.

---

## 3. The Meaning of "Evasion Protocol"
In this game, **Evasion Protocol** represents two distinct concepts:
1.  **The System’s Directive:** It is the tactical security procedure initiated by the Core. In this mode, the environment becomes hostile, deploying stationary traps (boxes), environmental kinetic strikes (falling stones), and lethal predator units (The Chaser).
2.  **The Player’s survival Code:** For the player, "Evasion Protocol" is the mental and technical agility required to navigate a space where every frame of movement counts. It is a test of precision, reaction, and endurance.

---

## 4. Gameplay Features & Mechanics

### A. Dynamic Movement System
- **Omni-Directional Control:** The player has full control (Up, Down, Left, Right) using the keyboard arrow keys.
- **Animated Sprites:** The player character features a frame-based animation system that changes based on the direction of movement, providing a fluid and immersive visual experience.
- **Speed Scaling:** As the player progresses through levels, the base movement speed increases, demanding higher precision.

### B. Health and Scoring
- **Integrated Health Bar:** A visual UI element that tracks player integrity. Each collision with a hazard reduces lives and triggers a brief invincibility period.
- **Scoring & Economy:** Silver (2 pts) and Gold (5 pts) coins represent the data fragments the courier is collecting.
- **Save System:** Every session’s performance (Level, Score, Coins, Lives) is logged into a persistent file history, allowing for progression tracking and competitive play.

### C. Visuals & Atmosphere
- **Parallax Tiling Background:** A smooth-scrolling background that alternates between tiles to create a feeling of constant, high-speed travel.
- **3-2-1 Countdown:** Each level begins with a high-pressure countdown, emphasizing the "Evasion" theme.

---

## 5. Level Scenarios

### Level 1: Sector Alpha (The Breach)
- **Environment:** Low-security containment zone.
- **Hazards:** Stationary automated defense boxes that move in vertical patrol patterns.
- **Atmosphere:** Relatively slow-paced (Background Speed: 2.0), allowing the player to synchronize with the controls.

### Level 2: The Kinetic Core (The Falling Waste)
- **Environment:** A vertical processing shaft where structural integrity is failing.
- **New Hazard:** **Falling Stones.** Massive debris falls from above, forcing the player to manage vertical and horizontal positioning simultaneously. 
- **Stats Buff:** The player is granted more lives (7) to compensate for the chaotic nature of the falling hazards.

### Level 3: The Hunter's Pursuit (The AI Predator)
- **Environment:** The final escape corridor leading to the resistance base.
- **New Hazard:** **The Chaser Enemy** (Advanced Tracking) and **Gravity Stones** (Accelerating Physics Hazards).
- **Challenge:** Fastest background speed (6.0) and reduced health (4 lives). Real-time gravity acceleration makes environmental hazards much more unpredictable.

---

## 6. Technical Implementation Summary
The game is built on a modular architecture:
- **Interfaces:** Uses `IMovable`, `ICollidable`, and `IPhysicsObject` to ensure scalability.
- **Movements:** Each object follows a specific behavior class (e.g., `VerticalPatrolMovement`, `ChasePlayerMovement`), separating logic from the entity itself.
- **Physics Layer:** A latent physics system is present in the code, capable of handling gravity and force, laying the groundwork for more complex environmental interactions.

---

## 7. Audio & Sensory Feedback
The auditory experience is managed by a custom `SoundManager` engine that provides high-performance audio playback:
- **Hardware Acceleration:** Uses the native Windows Multimedia API (`winmm.dll`) to play audio without stalling the main game thread.
- **Background Music (BGM):** A dedicated channel for looping music that creates the high-stakes atmosphere appropriate for an "Evasion" scenario.
- **Concurrent Sound Effects (SFX):** Utilizes a GUID-based aliasing system, allowing multiple sounds (like coin collection and collision alerts) to play simultaneously without cutting each other off.
- **Resource Streaming:** Automatically handles the extraction and playback of embedded `.wav` resources from the project binaries.

---

## 8. Technical Framework Utilization
The game is built upon a professional-grade game development framework. Based on an analysis of the active logic versus the total provided infrastructure:

**Estimated Framework Usage: ~75%**

- **Highly Utilized:** The core entity architecture (`GameObject`), the polymorphic movement library (`IMovement`), and the frame-based `AnimationSystem`.
- **Advanced Integration:** The **`PhysicsSystem`** is actively utilized in Level 3 to drive the "Gravity Stones." This demonstrates an advanced integration of velocity-based movement and acceleration logic.
- **Dormant Features:** The `CollisionSystem` is currently in a "latent" state, as the game uses direct bounding-box checks for performance optimization.

---
**Report generated for:** Professor's Review  
**Date:** January 6, 2026
