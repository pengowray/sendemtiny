# send em tiny
_send em tiny_ is a Windows utility to make it easy to configure keyboards and mice from many vendors—including Razer, Logitech, and Corsair—using their own configuration tools, so that they can output a Unicode character on a key/button press.

Motivation: It was too difficult to configure my mouse to send an emdash (—), so I made this tiny program to make it easier to send it or any other Unicode character.

The mouse/keyboard configuration tool from a hardware vendor typically allows you to customize macro keys/buttons, but does not allow a simple Unicode character assignment. For example, em dash (—) or tiger (🐯) cannot simply be assigned to a macro key/button in Razer Synapse, Logitech Keyboard and Mouse Settings, nor Corsair Utility Engine. You can't paste the Unicode character or emoji anywhere and you can't enter the Unicode hexcode. _Send Em Tiny_ is designed to work with these utilities to send a Unicode character.

# What hardware does it work with?

Tested with: 
* ✅ Razer Synapse (Razer Naga Epic Chroma) Win10
* ✅ Logitech Keyboard and Mouse Settings (MK700) Win10
* ✅ Corsair Utility Engine (Strafe RGB) Win7
* ❌ Asus Strix Software (Strix Tactic Pro) Win10 — the current app loses focus when _send em tiny_ is run
* ❓ Valve controller (will test shortly)
* Please report if _send em tiny_ works or fails with your own hardware, or if it's unnecessary due to superior configuration options.

# How to use it

1. Copy `sendemtiny.exe` to somewhere, e.g. `c:\send-em`
2. Make a bunch of copies of it
3. Find the Unicode hex code you want to use, e.g. `U+2014` for the _em dash_ (—)
4. Rename one of the files so it ends with a capital **U** followed by the hexcode, e.g. "emdash U2014.exe" (If `.exe` is hidden, then no need to add it)
5. Configure your mouse or keyboard to launch `emdash U2014.exe` when a key or button is pressed.
6. Save your changes and that's it. Enjoy your new emdash button.
7. But also rename the other files too.
8. And configure the some other keys and buttons.

# How it works
When _Send Em Tiny_ is run by your keyboard or mouse driver, it searches its own filename for a capital U followed by a Unicode hex code, and then sends that character as if it was typed by a keyboard.
Why this way? No keyboard/mouse utility software that I tested allows a command line parameter, so renaming the executable is the best way I could find to allow you to choose which Unicode character to send.

# Is there another way that doesn't use any third party software like _send em tiny_?
Yes, you can typically set up a macro to type the [Alt Code](https://en.wikipedia.org/wiki/Alt_code). This tends to be inelegant and error prone. It may mess up if your numlock is currently disabled, if other applications—such as f.lux—are override alt-keys with its own global shortcuts, or if you choose the wrong delay between key presses.

Here's an example:

# Roadmap

What's planned for the future:

The _tiny_ version of _send em tiny_ will likely not have change dramatically, as having a tiny code base also helps users to audit the code themselves (it's currently only five lines of code), and the one-character output limitation makes it less likely to be used in any nafarious ways. But that's not to say I'm done with development.

I plan to make another version (_send em_) which will have more flexible Unicode/text input, allow multiple characters of output, and perhaps even allow the creation of menus.