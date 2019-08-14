# tgc-monogame
[![Build Status](https://travis-ci.com/rejurime/tgc-mg.svg?branch=master)](https://travis-ci.com/rejurime/tgc-mg)
[![Build status](https://ci.appveyor.com/api/projects/status/3k1herh1qecvr20c?svg=true)](https://ci.appveyor.com/project/rejurime/tgc-mg)

Probando cosas con OpenGL usando MonoGame y .NET Core.
#BuiltWithMonoGame

* [.NET Core](https://dotnet.github.io/)
* [Microsoft XNA](https://en.wikipedia.org/wiki/Microsoft_XNA)
* [MonoGame](http://www.monogame.net/)
* [OpenGL](https://www.opengl.org/)

## Instalación
* [.NET Core](https://dotnet.microsoft.com/download)
* [MonoGame](http://www.monogame.net/documentation/?page=Setting_Up_MonoGame)
* [MonoGame download](http://www.monogame.net/downloads/)

### Linux (Ubuntu 18.04)
* [MonoDevelop](http://www.monodevelop.com/)

#### Problemas
* Compilar HLSL esta solo disponible para Windows oficialmente - https://github.com/MonoGame/MonoGame/issues/2167
  * Posible solucion https://github.com/augustozanellato/MonoGameUniversalEffects
    * Instalar https://www.virtualbox.org/
    * Instalar https://www.vagrantup.com/
    * wget https://github.com/augustozanellato/MonoGameUniversalEffects/releases/download/v1.0.0-beta.1/client.zip
    * unzip client.zip
    * rm client.zip
    * cd client
    * vagrant up
    * Abrir MonoGame Content Pipeline project (Content.mgcb)
    * Click en "Content" 
    * Click en "References" que es el ultimo item de "Properties"
    * Click en "Add" y buscar "MonoGameUniversalEffects.Pipeline.dll" que deberia estar en el directorio "Pipeline Extension" dentro de la carpeta client.
    * Para cada archivo .fx que se quiera compilar cambien "Processor" por "Remote Effects Processor - MonoGameUniversalEffects".

  * Posible solucion solo para Linux https://github.com/peon501/Peon501.Pipeline
  
* DLLNotFoundException for nvtt (NVidia Texture Tools) - https://github.com/MonoGame/MonoGame/issues/5866

### Mac (probado en macOS Mojave)
* [Visual Studio para Mac](https://visualstudio.microsoft.com/)

#### Problemas
* Compilar HLSL esta solo disponible para Windows oficialmente - https://github.com/MonoGame/MonoGame/issues/2167

### Windows 10
* [Visual Studio Community](https://visualstudio.microsoft.com/)

#### Problemas
* Unable to load DLL 'freetype6.dll' - Instalar [Visual C++ Redistributable 2012](https://www.microsoft.com/en-us/download/details.aspx?id=30679)
* Unable to load DLL 'FreeImage' - Instalar [Visual C++ Redistributable 2013](https://www.microsoft.com/en-us/download/details.aspx?id=40784)

### Problemas generales
* Open Asset Import Library con los Obj y Dae falla hay que cambiarlo por Fbx importer.
