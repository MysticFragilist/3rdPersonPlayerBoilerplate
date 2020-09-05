# Third Person Player Boilerplate
A collection of all my favorite packages and nice pattern used for a Unity 2020.1 project and above version. The purpose of this repo is to be able download and start developing as fast and as easy as possible. It has multiple code pattern which make this boilerplate a lot scalable.   

## Features
This project features a tons of cool stuff including but not limited to:
 - A custom 3rd person player controller inspired from different tutorials found online.
 - The new Input system v1.0.0 with an already preloaded input actions for moving, looking, crouching, jumping and running. (For more [info](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html))
 - A preload scene (As seen from this [thread](https://forum.unity.com/threads/preload-scene-always-or-it-depends.513349/) and this [StackOverflow post](https://stackoverflow.com/questions/35890932/unity-game-manager-script-works-only-one-time/35891919#35891919))
 - A Scene Autoloader; which prevent always having to going back to the preload scene to test the game ([source](http://wiki.unity3d.com/index.php/SceneAutoLoader?_ga=2.101303617.112309283.1599237104-196129604.1599063044))
 - A Grid System, to reference your many Singletons MonoBehaviour object (designed by [Fattie](https://answers.unity.com/questions/663351/design-advice-power-up-system-static-variables.html?childToView=663681#answer-663681))
 - An instance of Cinemachine v2.6.1, it handles correctly the integration with the new input system. ([This](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.6/manual/CinemachineAlternativeInput.html) is where I found how to integrate cinemachine with the new input system)
 - The test framework v1.1.16 already ready to be used. (For more [info](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html))
 - A well implemented GameManager which is easy to get into.
 - An input Manager script which takes Player Input and distribute them across Game Objects that has subscribed to them (never have to worry about using directly the Input component inside any GameObject). Now to add a new input listener, simply bind the event in the input manager script (using interface) and creates the method in your desired class.
 - There is also an already rigged sample of GameEvents class for which you can use if you want your game to be scalable (instead of linking all your gameObject between each other, you can instead use event base development) [This](https://www.youtube.com/watch?v=gx0Lt4tCDE0&ab_channel=GameDevGuide) is where I saw it being implemented, if you have more question.
 - In place, there is also a boilerplate for a SaveSystem script which is used to save some state of the game (As of now, this is only used to save location of a player in binary) (source from [Brackeys](https://www.youtube.com/watch?v=XOjd_qU2Ido&t=624s&ab_channel=Brackeys) video)


## Futur Initiative
This project could be expand a lot more, in many direction either using different version of the same package or using a variety of other patterns. This is a list of a nice to have that it would be great to insert in the project:
 - A sample menu scene with basic New Game, Load Game and Quit
 - A better way to be able to debug cinemachine camera while in game.
 - Makes all the code as more of a library then a boilerplate for starting a project (I.E not having to modify the character controller would be great)
 - [...]

If you have any idea that would benefit this project feel free to share by creating a support ticket.

## Installation
To install simply clone this project or download it and extract it someplace on your computer. Make sure to have at least **250mb** of free space. Then, launch unity and instead of hitting New, click on **Add** and navigate to the project folder.


## Support

Please [open an issue](https://github.com/MysticFragilist/3rdPersonPlayerBoilerplate/issues/new) for support.

## Contributing

Please contribute using [Github Flow](https://guides.github.com/introduction/flow/). Create a branch, add commits, and [open a pull request](https://github.com/MysticFragilist/3rdPersonPlayerBoilerplate/compare/).

## License
This project is under the [MIT](LICENSE) License.