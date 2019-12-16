using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{

    public static List<string[]> allItems = new List<string[]>() { 
        new[] { "Mud", "Earth", "Water", "Reason of the nickname to Waters, because he liked to play in it" },
        new[] { "Lake", "Mud", "Water", "Everybody sings about lakes. Think of something else" }, //TODO
        new[] { "Rain", "Cloud", "Water", "Somebody call Rihanna!" }, 
        new[] { "Brick", "Fire", "Mud", "Hey! Teachers! Leave them kids alone" },
        new[] { "Wall", "Brick", "Brick", "So you figured that out as well. Have you heard the whole album yet?" }, //TODO
        new[] { "Lava", "Earth", "Fire", "Lots of cool info here" }, //TODO
        new[] { "Building", "Wall", "Wall", "Why a building? Well, this game is about rock, not house"}, //TODO
        new[] { "Sea", "Lake", "Water", "Don't follow the stream" }, //TODO
        new[] { "Sea", "Lake", "Lake", "Don't follow the stream" }, //TODO
        new[] { "Cloud", "Air", "Water", "WTF my computer broke down, all my new files are gone" },
        new[] { "Energy", "Fire", "Air", "Or you could just do a really fast powerslide" }, //More things that can be energy?
        new[] { "Lightning", "Cloud", "Energy", "Don't follow the stream" },
        new[] { "Pressure", "Air", "Air", "The obtrusive feeling when trying to come up with a good flavour text" }, 
        new[] { "Pressure", "Earth", "Earth", "The obtrusive feeling when trying to come up with a good flavour text" },
        new[] { "Sky", "Air", "Cloud", "Every positive lyric writer think they can tounch this. They're also always high" }, //TODO
        new[] { "Sun", "Sky", "Fire", "Here it comes!" },
        new[] { "Planet", "Earth", "Sky", "I don't believe in humans" }, //TODO
        new[] { "Planet", "Sun", "Earth", "I don't believe in humans" }, //TODO
        new[] { "Star", "Planet", "Sun", "How I wonder where you are..." }, //TODO
        new[] { "Wind", "Air", "Pressure", "You're telling me the answer has been here the whole time?" }, //TODO
        new[] { "Wave", "Wind", "Sea", "Old or new?" }, //TODO
        new[] { "Sound", "Air", "Wave", "..." }, //TODO
        new[] { "Music", "Sound", "Sound", "Can appearantly give life to hills" }, //TODO
        new[] { "Music", "Sound", "Human",  "Can appearantly give life to hills" }, //TODO
        new[] { "Hell", "Earth", "Lava", "Also a small village in Norway" }, //TODO
        new[] { "Stone", "Lava", "Air", "Just keep on rolling" }, //TODO
        new[] { "Metal", "Stone", "Fire", "..." }, //TODO
        new[] { "Heavy Metal", "Music", "Metal", "You're clever, you!" }, //TODO
        new[] { "Electricity", "Metal", "Energy", "..." }, //TODO
        new[] { "Sand", "Pressure", "Stone", "Sand... man, something, right?" }, //TODO
        new[] { "Glass", "Sand", "Fire", "If it ain't broken you need to turn up that bass amp!" },
        new[] { "Time", "Glass", "Sand", "Too short when playing your own solo, eternity when someone else does" },
        new[] { "Bacteria Cell", "Lake", "Lightning", "..." }, //TODO
        new[] { "Bacteria Cell", "Sea", "Lightning", "..." }, //TODO
        new[] { "Life", "Bacteria Cell", "Time", "..." }, //TODO
        new[] { "Animal", "Lake", "Life", "..." }, //TODO
        new[] { "Animal", "Sea", "Life", "..." }, //TODO
        new[] { "Plant", "Life", "Earth", "No, of course I don't mean Robert" }, 
        new[] { "Human", "Animal", "Time", "Wow, maybe you can start a band now?" }, 
        new[] { "Oil", "Earth", "Time", "Midnight..." }, //TODO
        new[] { "Plastic", "Oil", "Human", "Not so fantastic" }, 
        new[] { "Glitter", "Plastic", "Star", "..." }, //TODO
        new[] { "Pyro", "Pressure", "Fire", "Always be prepared, you never know when the pyro person pushes the button" }, //TODO
        new[] { "Love", "Human", "Human", "..." }, //TODO
        new[] { "Cotton", "Cloud", "Plant", "..." }, //TODO
        new[] { "Tool", "Human", "Metal", "..." }, //TODO - something about the band?
        new[] { "Thread", "Tool", "Cotton", "..." }, //TODO
        new[] { "Rope", "Thread", "Thread", "..." }, //TODO
        new[] { "Clothes", "Tool", "Thread", "..." }, //TODO 
        new[] { "Outfit", "Clothes", "Clothes", "..." }, //TODO - maybe also artist + clothes?
        new[] { "Dance Band", "Clothes", "Glitter", "Who put this in here? Serioulsy? Who!?" },
        new[] { "Cable", "Rope", "Electricity", "Are you the one making a knot? Get out!" },
        new[] { "Singer", "Human", "Sound", "If they put as much effort in learning the lyrics as asking for more monitor they might be decent band mates" },
        new[] { "Microphone", "Singer", "Electricity", "It DOES sound better if you make out with it" },
        new[] { "XLR Cable", "Microphone", "Cable", "The mic will definatley detach if you spin it around every single song. It is known" },
        new[] { "Satan", "Hell", "Animal", "From whence you came, you shall remain, until you are complete again" },
        new[] { "Satan", "Hell", "Human", "From whence you came, you shall remain, until you are complete again" },
        new[] { "Death", "Time", "Human", "..." }, //TODO
        new[] { "Death Metal", "Heavy Metal", "Death", "As long as you growl your mother won't be able to hear the lyrics" },
        new[] { "Death Metal", "Metal", "Death", "As long as you growl your mother won't be able to hear the lyrics" },
        new[] { "Death Metal", "Heavy Metal", "Satan", "As long as you growl your mother won't be able to hear the lyrics" },
        new[] { "Tree", "Plant", "Time", "..." }, //TODO
        new[] { "Wood", "Tool", "Tree", "..." },
        new[] { "Drum Kit", "Wood", "Plastic", "Never complain on the kit at the venue if you're too lazy to bring your own" },
        new[] { "Drum Kit", "Musician", "Drummer", "Softer? What do you mean play softer?" },
        new[] { "Musician", "Music", "Human", "I just can't listen to this song anymore, the guitars aren't panned correctly" },
        new[] { "Stage Fright", "Musician", "Pressure", "Ever wondered why there are 1 bottle of wine and 30 beer cans on my rider?" }, 
        new[] { "Drumsticks", "Tool", "Wood", "Ever wondered why it looks like a sawdust behind the drums?" },
        new[] { "Knife", "Stone", "Metal", "..." }, //TODO
        new[] { "Leather", "Knife", "Animal", "..." }, //TODO
        new[] { "Studded Belt", "Metal", "Leather", "..." }, //TODO
        new[] { "Leather Jacket", "Leather", "Clothes", "You need to own at least one" }, //TODO
        new[] { "Guitar", "Wood", "Electricity", "..." }, //TODO
        new[] { "Guitarist", "Guitar", "Musician", "Hey what du you mean we can't have a guitar solo in every song?" }, //TODO - make this with human?
        new[] { "Fan", "Love", "Guitarist", "..." }, //TODO
        new[] { "Fan", "Love", "Drummer", "..." }, //TODO
        new[] { "Fan", "Love", "Singer", "..." }, //TODO
        new[] { "Crowd", "Fan", "Fan", "..." }, //TODO
        new[] { "Crowd Surfing", "Crowd", "Wave", "..." }, //TODO
        new[] { "Tele Cable", "Guitar", "Cable", "..." }, //TODO
        new[] { "Fist Sign", "Fan", "Heavy Metal", "..." },
        
        /*
        new[] { "Double Neck", "Guitar", "Guitar", "Isn't it quite lame you don't play both at the same time?" }, //TODO
        new[] { "Satanism", "Satan", "Fan", "..." }, //TODO
        new[] { "Satanism", "Satan", "Love", "..." }, //TODO
        new[] { "Amplifier", "Electricity", "Sound", "Turn it to 11!" },
        new[] { "PA System", "Amplifier", "Microphone", "..." }, //TODO
        new[] { "Fruit", "Sun", "Tree", "Always in a bowl backstage, but nobody ever eats it" }, //TODO
        new[] { "Alcohol", "Time", "Fruit", "..." }, //TODO
        new[] { "Crops", "Earth", "Plant", "..." }, //TODO
        new[] { "Beer", "Crops", "Alcohol", "..." }, //TODO
        new[] { "Pin", "Plastic", "Metal", "..." }, //TODO 
        new[] { "Band", "Musician", "Musician", "..." }, //TODO - make more!
        new[] { "Gig", "Band", "Crowd", "..." }, //TODO
        new[] { "Merch", "Band", "Clothes", "..." }, //TODO
        new[] { "Paper", "Pressure", "Tree", "..." }, //TODO
        new[] { "Poster", "Paper", "Fan", "..." }, //TODO
        new[] { "Autograph", "Band", "Paper", "..." }, //TODO
        new[] { "Ticket", "Gig", "Paper", "..." }, //TODO
        new[] { "Timing", "Human", "Time", "..." }, //TODO - make songs, rhythm, riff etc!!!!
        */       
    }; 
}
