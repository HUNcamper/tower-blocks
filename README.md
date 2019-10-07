# Tower Blocks
A tower building game written in C#

## Gameplay:
- The goal is to stack as many tower blocks on top of each other as you can!
- You have to drop them on each other while the one you're dropping is moving left-right, making it difficult to line them up.
- If a part of it isn't lined up well, the parts hanging off will be cut, making the game harder as it progresses.

## Compiling
Tower Blocks was written in C#, using [Visual Studio 2017](https://visualstudio.microsoft.com/), uses [SDL2](https://github.com/flibitijibibo/SDL2-CS/) and the [4.6.1 .NET framework](https://www.microsoft.com/en-us/download/details.aspx?id=49981).
It also uses [DocFX](https://dotnet.github.io/docfx/index.html) to automatically generate a documentation for the project.
To access the full project, open [tower-blocks/tower-blocks.sln](https://github.com/HUNcamper/tower-blocks/blob/master/tower-blocks/tower-blocks.sln)

##### Important:

You might have to set the VSINSTALLDIR and VisualStudioVersion environment variables, in case DocFx isn't able to build the project.
To set this, open the Developer Command Prompt for VS 2017 (search in cortana to find easily) and run the commands below.

```
SET VSINSTALLDIR=C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools
SET VisualStudioVersion=15.0
```

## Full code documentation:
You can find it here: [https://huncamper.github.io/tower-blocks/](https://huncamper.github.io/tower-blocks/)