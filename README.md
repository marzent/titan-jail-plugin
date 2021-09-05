# Titan Jail ACT Plugin!

This plugin is used to mark players based on a priority list.

![alt text](https://github.com/marzent/titan-jail-plugin/blob/master/jail_plugin_pic.png?raw=true)

## Steps:
1- Fill in priority list

2- Fill in party list

3- Set up ingame macros with `CTRL + SHIFT + F{1-8}` the following way:
> /mk attack <{1-8}>

4- Set up a macro with  `CTRL + SHIFT + F9` with:
> /mk off <1> \
> /mk off <2> \
> /mk off <3> \
> /mk off <4> \
> /mk off <5> \
> /mk off <6> \
> /mk off <7> \
> /mk off <8> 

5- (optional) Hide the hotbar you used for this


you can export and share the priority list with other forks of this plugin.
***


## How it works:
It will only call out if there are 3 log lines that match the regular expression\
`:[a-zA-Z-']+?:2B6(B|C):.*?:.*?:`\
of getting a Titan Gaol, within 1 second.

## How to test it:
Put these lines in a macro and change the names below to members within the priority list, then run the macro. 

`/e 15:4000596E:Garuda:2B6C:Rock Throw:106D93DF:A'oshane Taru`\
`/e 15:4000596F:Garuda:2B6C:Rock Throw:1070B706:Akela Freya`\
`/e 15:40005974:Titan:2B6B:Rock Throw:106966DD:Rai Lionheart`

Good Luck! :)
