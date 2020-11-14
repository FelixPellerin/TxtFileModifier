# TxtFileModifier

## About this project

This all begin when a friend of mine asked me to do some kind of formating on a large txt file. It was not practical to do it by hand, so i made a quick tool to do it, and it grew into this. Still not much but im putting it here in hope that it will be useful to someone. Looking forward to add more features.

## Built With

* .Net Core
* Visual Studio

## Usage 

Here are the parameters and their function. Currently only supports UTF-8 encoding, but will add more in the future

> -F : Set the file to be edited. This parameter is required at all time.

> -O : Set the output file. If not set, default file will be output.txt .

> -L : Cut the lines when they have more then "X" characters.

> -C : Cut the lines when they contain "X" character or chain of characters.

> -S : Cut the lines when they start by "X" character or chain of characters.

> -E : Cut the lines when they end by "X" character or chain of characters.

> -H : Help, displays the above.