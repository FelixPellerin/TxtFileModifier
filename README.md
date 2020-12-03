# TxtFileModifier

This utility allows you to modify large txt files using command line arguments. It is sometimes not practical to manually remove lines from a txt file when it is large, so why not let the machine to it for you? There is no real limit to how large a file can be, but you will most likely cap your ram usage if you are using a file that is bigger or close to the available ram on your machine. Currently only supports UTF-8 encoding, but will add more in the future. Currently compatible with windows and linux since i have no way to test it on other platforms.

## About this project

This all begin when a friend asked me to do some kind of formating on a large txt file. It was not practical to do it by hand, and i didn't find any command line tools online, so i made a quick tool to do it, and it grew into this. Still not much but im putting it here in hope that it will be useful to someone, even if it is only a simple program. Looking forward to add more features.

## Built With

* .Net Core
* Visual Studio

## Usage 

Here are the parameters and their function. If you need to use an argument with multiple different characters or chain of characters, you can simply call it multiple times (Yes its funky but for now it is what it is) Example (-C a -C b) <ins>If a parameter is invalid, the program will still execute the other instructions and write to file but it will tell you when a parameter was invalid.</ins>

> -F  : Set the file to be edited. This parameter is required at all time.

> -O  : Set the output file. If not set, default file will be output.txt.

> -L  : Cut the lines when they have <ins>more</ins> than "X" characters. <br />
> -LK : Cut the lines when they have <ins>less</ins> than "X" characters.

> -C  : Cut the lines when they contain "X" character or chain of characters. <br />
> -CK : Cut the lines when they <ins>do not</ins> contain "X" character or chain of characters. <br />
> -CI : C argument but not case sensitive. <br />
>       I and K can be used together

> -S  : Cut the lines when they start by "X" character or chain of characters.<br />
> -SK : Cut the lines when they <ins>do not</ins> start by "X" character or chain of characters. <br />
> -SI : S argument but not case sensitive. <br />
>       I and K can be used together

> -E  : Cut the lines when they end by "X" character or chain of characters. <br />
> -EK : Cut the lines when they <ins>do not</ins> end by "X" character or chain of characters. <br />
> -EI : E argument but not case sensitive. <br />
>       I and K can be used together

> -H  : Help, displays the above. Can also be triggered by anything containing the word help.

### Not yet implemented

> -A : Set encoding type of input file. (Default : UTF-8)

> -B : Set encoding type of output file. (Default : UTF-8)

> -P : Sort the lines in alphabetical order
> -PR : Sort the lines in reverse alphabetical order
