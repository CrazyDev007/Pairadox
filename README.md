# Pairadox Game Analysis

## Features
Pairadox is a card matching game where players flip cards to find matching pairs. The game features a grid of cards with symbols from categories like Animals, Birds, Cartoons, Foods, and Toys. The name "Pairadox" likely combines "Pair" (referring to matching pairs) and "Paradox" (possibly for thematic flair or a twist, though not evident in code). Gameplay involves turns, matching cards, and tracking stats like match count and turn count. Scenes include Startup, Lobby, and Gameplay.

## Coding Patterns
- **MVP (Model-View-Presenter)**: Used for card interactions. CardEntity (Model), CardView (View), CardPresenter (Presenter).
- **Use Cases**: Business logic encapsulated in classes like CardMatchUseCase, CardUseCase, StartGameUseCase.
- **Dependency Injection**: Implemented via DependencyInjection.cs, likely using a framework like Zenject.
- **Observer Pattern**: Listeners for events like IGameplayListener, ICardMatchListener.
- **Factory Pattern**: Implicit in instantiation and initialization of cards and presenters.

## Design Patterns
- **Clean Architecture**: Project structured in layers:
  - Domain: Entities (e.g., CardEntity).
  - Application: Use Cases and Interfaces.
  - Infrastructure: Services like SaveService.
  - Presentation: Views, Presenters.
- **Modular Architecture**: Separate assemblies (.csproj) for each layer (Game.Domain, Game.Application, etc.).
- **Scene-Based Architecture**: Different installers for Startup, Lobby, Gameplay scenes.

## Colors
- **Primary Theme**: Neon dark theme.
- Background: #0a0a0a (very dark gray/black).
- Accent: #00fff7 (cyan/teal neon).
- Secondary: #3f37c9 (purple).
- Text/Highlights: #ffffff (white), with glow effects.

## Typography
- **Screen Title Font**: UncialAntiqua-Regular
- **Other Screen Text Font**: BebasNeue-Regular

## Folder/Project Structure
- **Root**: Unity project with .sln, multiple .csproj for modularity.
- **Assets/**: Main Unity assets.
  - **Scripts/Game/**: Core code in layers (Application, Bootstrap, Domain, Infrastructure, Presentation).
  - **Scenes/**: Startup.unity, Lobby.unity, Gameplay.unity.
  - **UI/**: UXML and USS files for UI Toolkit (e.g., GameplayScreen, LobbyScreen).
  - **Sprites/**: Card symbols in categories (Animals, Birds, etc.), UI elements.
  - **Prefabs/**: Reusable objects.
  - **Resources/**: Assets loaded at runtime.
  - **Sounds/**: Audio files.
  - **Fonts/**: Typography.
  - **TextMesh Pro/**: Advanced text rendering.
  - **ThirdParties/**: External libraries.
  - **Test/**: Unit tests.
- **Packages/**: Unity Package Manager dependencies.
- **ProjectSettings/**: Unity configuration.
- **Library/**: Generated files (build artifacts, caches).