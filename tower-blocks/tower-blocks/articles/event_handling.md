# Event handling
In a game it's important to have some kind of event handling. SDL2 provides this for us by forwarding event types and data.

# In this game
Events are automatically forwarded to [Scenes](https://huncamper.github.io/tower-blocks/api/Scenes.Scene.html), and from there it's up to [SceneElements](https://huncamper.github.io/tower-blocks/api/Scenes.SceneElement.html) to decide if they want to subscribe or not.
This way performance is increased as not every element in the scene gets loads of event data unneccesarily.