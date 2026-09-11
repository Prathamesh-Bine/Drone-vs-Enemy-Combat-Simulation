A 3D drone combat simulation developed in Unity, demonstrating physics-based movement, projectile combat, and UI management.

## Controls
* **Directional Movement:** W, A, S, D
* **Altitude (Up/Down):** Q, E
* **Rotation:** Z, C
* **Pause Menu:** Escape

## Features Implemented
* **Combat System:** Universal health and damage scripts with invincibility frames (i-frames) to prevent multi-hit physics bugs.
* **Health Mechanics:** The player drone and enemy entities each have 3 hitpoints. Yellow target boxes have 1 hitpoint.
* **Score Tracking:** Real-time UI score updates using a static variable architecture across all enemy prefabs.
* **Visual Effects:** Upgraded to the Universal Render Pipeline (URP) with custom-colored unlit particle explosions for destroyed entities.
* **Modern Inputs:** Integrated Unity's new Input System via direct InputActions to handle UI and pause state toggling.

 ## Known bugs or limitations
* **Static Enemies:** Enemy placement is currently fixed within the scene and they do not feature complex pathfinding AI.
* **Game Loop**: Upon player destruction, the scene immediately reloads to reset the score, rather than transitioning to a dedicated "Game Over" screen.

## Screenshots
<img width="1920" height="1080" alt="Screenshot (316)" src="https://github.com/user-attachments/assets/66962aa1-9e76-4901-8543-de201bdb681c" />
<img width="1920" height="1080" alt="Screenshot (317)" src="https://github.com/user-attachments/assets/f7f81593-a429-4de7-a878-9f801289b1f6" />
<img width="1920" height="1080" alt="Screenshot (320)" src="https://github.com/user-attachments/assets/465ccf94-81b9-4cda-9f34-52ab526064b3" />
<img width="1920" height="1080" alt="Screenshot (319)" src="https://github.com/user-attachments/assets/2149ed02-3721-41aa-bf0d-203eb4a740a3" />
<img width="1920" height="1080" alt="Screenshot (318)" src="https://github.com/user-attachments/assets/cd9b3033-1165-4e1f-a668-841c35c3d608" />


