# send em tiny
_send em tiny_ is a Windows utility to make it easy to configure keyboards and mice from many vendors—including Razer, Logitech, and Corsair—using their own configuration tools, so that they can output a Unicode character on a key/button press.

Motivation: It was too difficult to configure my mouse to send an emdash (—), so I made this tiny program to make it easier to send it or any other Unicode character.

The mouse/keyboard configuration tool from a hardware vendor typically allows you to customize macro keys/buttons, but they make it overly difficult to have a simple Unicode character assignment. For example, em dash "—" or an emoji tiger "🐯" cannot simply be assigned to a macro key/button in Razer Synapse 2 (nor in Logitech SetPoint). You can't paste the Unicode character or emoji anywhere and you can't enter the Unicode hexcode. _send em tiny_ is designed to work with these utilities to add the ability to send a Unicode character from a key or button press.

# Quick guide

![quick guide instructions. Mouse image CC-BY 2.0 Osman Gucel (via flickr)](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/quickguide/quickguide.png)

**Note / Before you ask:** Razer Synapse does not allow sending of parameters to an executable, so the `sendemtiny.exe` file must be renamed in order to change its behavior. Sending parameters to an executable is simply not an option. There must be multiple executables to allow multiple target behaviors. To create multiple behaviors, you simply duplicate the executable file. (see quick guide above)

# What hardware does it work with?

Tested with: 
* ✅ Razer Synapse (Razer Naga Epic Chroma) Win10
* ✅ Logitech SetPoint (MK700) Win10
* ✅ Corsair Utility Engine (Strafe RGB) Win7
* ❌ Asus Strix Software (Strix Tactic Pro) Win10 [Fail: the current app loses focus when _send em tiny_ is run]
* ❌ Valve controller [Does not support launching external apps?]
* Please report if _send em tiny_ works or fails with your own hardware, or if it's unnecessary due to superior configuration options.

# Features

_send em tiny_ is the full-featured solution and is generally recommended. But if you only need to send a single Unicode character, you might prefer _send em micro_. It gives maximum performance and a smaller, more stable code base. Both executables are found under [/release](https://github.com/quole/sendemtiny/tree/master/release).

| Feature | Example | _send em tiny_ | _send em micro_ |
| --- | --- | --- | --- | 
| Single Unicode literal | `U+2014.exe` | ✅ | ✅ |
| Comment | `thumbs up U+1F44D.exe`<br/>("thumbs up" is ignored) | ✅ | ✅ |
| Multiple literals | `U+1F336️ U+FE0.exe` | ✅ | - |
| Entities | `&rarr;.exe` | ✅ | - |
| `say` _string_ | `say ⊂(◉‿◉)つ.exe` | ✅ | - |
| `type` _filename_ | `type greeting.txt.exe` | ✅ | - |
| Pause between Unicode literals (`s` or `ms`) | `U+1F914 850ms U+1F4A1.exe` | ✅ | - |
| Filesize | - | ~16 KB | ~5.5 KB |

# How to use it (longer guide)

1. Copy `sendemtiny.exe` somewhere, e.g. `c:\send-em`
![step 1](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step01.png)
2. Make a bunch of copies of it
![step 2](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step02.png)
3. Find the Unicode hex code you want to use, e.g. `U+2014` for the _em dash_ (—)
![step 3](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step03.png)
4. Rename one of the files so it ends with a capital **U** followed by the hexcode, e.g. "emdash U2014.exe" (If `.exe` is hidden, then no need to add it)
![step 4](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step04.png)
5. Configure your mouse or keyboard to launch `emdash U2014.exe` when a key or button is pressed.
![step 5](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step05_Razer_Synapse.png)
6. Save your changes and that's it. Enjoy your new emdash button.
7. But also rename the other files too.
![step 7](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step07.png)
8. And configure the some other keys and buttons.
![step 8](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/step08_Razer_Synapse.png)

# How it works
When _send em micro_ is run (launched) by your keyboard or mouse driver, it searches its own filename for `U+` followed by a Unicode hex code, sends that character as if it was typed by a keyboard, and then exits.

_send em tiny_ does the same but adds more commands, as listed in the _features_ table above.

Why this way? Keyboard/mouse utility software typically does not allow a command line parameter when choosing an application to launch, so renaming the executable is the best way I could find to allow users to choose which Unicode character to send.

# Is there another way that doesn't use any third party software like _send em tiny_?
Yes, you can typically set up a macro to type the [Alt Code](https://en.wikipedia.org/wiki/Alt_code). This tends to be inelegant and error prone. It may mess up if your numlock is currently disabled, if another application—such as f.lux—overrides alt-keys with its own global shortcuts, or if you choose the wrong delay between key presses.

However, you still might find macros are a beter solution for you. Here's an example of an emdash macro in Razer Synapse 2 (does not require _send em tiny_). Note it uses the Alt Code (0151) rather than the Unicode hexadecimal code point (U+2014):

![Emdash Macro Example](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/emdash-macro-example_Razor_Synapse.png)

Corsair Utility Engine has a text option, so _send em tiny_ is unneeded. Paste the Unicode or emoji into the text box.

![Emdash Macro Example](https://raw.githubusercontent.com/quole/sendemtiny/master/docs/screenshots/emdash-macro-example_Corsair.png)

Razer Synapse 3 (in beta as of this writing) is reported to also have a similar text option.

# Roadmap

What's planned for the future:

* a more complex command parser to allow combinations of actions and input types
* more commands: paste text; send keystrokes (for example: separate key up and key down events)
* a menu option to select between multiple commands or Unicode characters
