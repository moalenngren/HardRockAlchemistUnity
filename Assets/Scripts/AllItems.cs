using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{

    public static List<string[]> allItems = new List<string[]>() { 
        new[] { "Mud", "Earth", "Water", "Reason of the nickname to Waters, because he liked to play in it" },
        new[] { "Lake", "Mud", "Water", "Everybody sings about lakes. Think of something else" }, 
        new[] { "Rain", "Cloud", "Water", "Somebody call Rihanna!" }, 
        new[] { "Brick", "Fire", "Mud", "Hey! Teachers! Leave them kids alone" },
        new[] { "Wall", "Brick", "Brick", "So you figured that out as well. Clever you!" }, 
        new[] { "Lava", "Earth", "Fire", "Almost as hot as the riff I just wrote" }, 
        new[] { "Building", "Wall", "Wall", "No house of course. This is a hard rock game."}, 
        new[] { "Sea", "Lake", "Water", "Don't follow the stream" }, 
        new[] { "Sea", "Lake", "Lake", "Don't follow the stream" }, 
        new[] { "Cloud", "Air", "Water", "WTF my computer broke down, all my new files are gone" },
        new[] { "Energy", "Fire", "Air", "Or you could just do a really fast powerslide" }, 
        new[] { "Lightning", "Cloud", "Energy", "Very very frightening me" },
        new[] { "Pressure", "Air", "Air", "The obtrusive feeling when trying to come up with a good flavour text" }, 
        new[] { "Pressure", "Earth", "Earth", "The obtrusive feeling when trying to come up with a good flavour text" },
        new[] { "Sky", "Air", "Cloud", "Flavour text here..." }, //TODO
        new[] { "Sun", "Sky", "Fire", "Here it comes!" },
        new[] { "Planet", "Earth", "Sky", "I don't believe in humans" }, 
        new[] { "Planet", "Sun", "Earth", "I don't believe in humans" }, 
        new[] { "Star", "Planet", "Sun", "How I wonder where you are" }, 
        new[] { "Wind", "Air", "Pressure", "You're telling me the answer has been here the whole time?" }, 
        new[] { "Wave", "Wind", "Sea", "Definitely better when it's Brittish" }, 
        new[] { "Sound", "Air", "Wave", "Keep it up! You might be able to make a song soon!" }, 
        new[] { "Music", "Sound", "Sound", "That's what I'm talking about" }, 
        new[] { "Music", "Sound", "Human",  "That's what I'm talking about" }, 
        new[] { "Hell", "Earth", "Lava", "Also a small village in Norway" }, 
        new[] { "Stone", "Lava", "Air", "Just keep on rolling" }, 
        new[] { "Metal", "Stone", "Fire", "You can't kill the metal" },
        new[] { "Heavy Metal", "Music", "Metal", "Didn't actually thought you'd figure that out" }, 
        new[] { "Electricity", "Metal", "Energy", "Acoustic guitars are just not allowed here" }, 
        new[] { "Sand", "Pressure", "Stone", "Sand... boy, something, right?" }, 
        new[] { "Glass", "Sand", "Fire", "If it ain't broken you need to turn up that bass amp!" },
        new[] { "Time", "Glass", "Sand", "Too short when playing your own solo, eternity when someone else does" },
        new[] { "Bacteria", "Lake", "Lightning", "Flavour text here..." }, //TODO
        new[] { "Bacteria", "Sea", "Lightning", "Flavour text here..." }, //TODO
        new[] { "Life", "Bacteria", "Time", "Yes! Now you might be getting somewhere" }, 
        new[] { "Animal", "Lake", "Life", "Don't have a band name yet? Just choose an animal and let your baby sister spell it" }, 
        new[] { "Animal", "Sea", "Life", "Don't have a band name yet? Just choose an animal and let your baby sister spell it" },
        new[] { "Animal", "Time", "Life", "Don't have a band name yet? Just choose an animal and let your baby sister spell it" },
        new[] { "Plant", "Life", "Earth", "No, of course I don't mean Robert" }, 
        new[] { "Human", "Animal", "Time", "You need at least two of them to start a band" }, 
        new[] { "Oil", "Earth", "Time", "Perfect fuel to burn a bed" }, 
        new[] { "Plastic", "Oil", "Human", "Not so fantastic" }, 
        new[] { "Glitter", "Plastic", "Star", "Nah, I prefer the sparkles from a freshly poured beer" }, 
        new[] { "Pyro", "Pressure", "Fire", "Always be prepared, you never know when the pyro person pushes the button" }, 
        new[] { "Love", "Human", "Human", "I'm sorry, you won't get time for this if you wanna be a rock star" }, 
        new[] { "Cotton", "Cloud", "Plant", "Flavour text here..." }, //TODO
        new[] { "Tool", "Human", "Metal", "Flavour text here..." }, //TODO - something about the band?
        new[] { "Thread", "Tool", "Cotton", "Flavour text here..." }, //TODO
        new[] { "Rope", "Thread", "Thread", "Flavour text here..." }, //TODO
        new[] { "Clothes", "Tool", "Thread", "Please just keep them on. There ARE fans on stage" }, 
        new[] { "Outfit", "Clothes", "Clothes", "Never, just NEVER, wear your own band's t-shirt on stage" },
        new[] { "Outfit", "Clothes", "Guitarist", "Never, just NEVER, wear your own band's t-shirt on stage" },
        new[] { "Outfit", "Clothes", "Drummer", "Never, just NEVER, wear your own band's t-shirt on stage" },
        new[] { "Outfit", "Clothes", "Singer", "Never, just NEVER, wear your own band's t-shirt on stage" },
        new[] { "Dance Band", "Clothes", "Glitter", "Who put this in here? Serioulsy? Who!?" },
        new[] { "Dance Band", "Outfit", "Glitter", "Who put this in here? Serioulsy? Who!?" },
        new[] { "Cable", "Rope", "Electricity", "Are you the one making a knot? Get out!" },
        new[] { "Singer", "Human", "Sound", "If they put as much effort in learning the lyrics as asking for more monitor they might be decent band mates" },
        new[] { "Microphone", "Singer", "Electricity", "It DOES sound better if you make out with it" },
        new[] { "XLR Cable", "Microphone", "Cable", "The mic will definatley detach if you spin it around every single song. It is known" },
        new[] { "Satan", "Hell", "Animal", "From whence you came, you shall remain, until you are complete again" },
        new[] { "Satan", "Hell", "Human", "From whence you came, you shall remain, until you are complete again" },
        new[] { "Death", "Time", "Human", "Flavour text here..." }, //TODO
        new[] { "Death Metal", "Heavy Metal", "Death", "As long as you growl your mother won't be able to hear the lyrics" },
        new[] { "Death Metal", "Metal", "Death", "As long as you growl your mother won't be able to hear the lyrics" },
        new[] { "Death Metal", "Heavy Metal", "Satan", "As long as you growl your mother won't be able to hear the lyrics" },
        new[] { "Tree", "Plant", "Time", "Flavour text here..." }, //TODO
        new[] { "Wood", "Tool", "Tree", "Flavour text here..." }, //TODO
        new[] { "Drum Kit", "Wood", "Plastic", "Never complain on the kit at the venue if you're too lazy to bring your own" },
        new[] { "Drummer", "Musician", "Drum Kit", "Softer? What do you mean play softer?" },
        new[] { "Drummer", "Humann", "Drum Kit", "Softer? What do you mean play softer?" },
        new[] { "Musician", "Music", "Human", "I just can't listen to this song, the guitars aren't panned correctly" },
        new[] { "Stage Fright", "Musician", "Pressure", "Ever wondered why there are 1 bottle of wine and 30 beer cans on my rider?" },
        new[] { "Stage Fright", "Guitarist", "Pressure", "Ever wondered why there are 1 bottle of wine and 30 beer cans on my rider?" },
        new[] { "Stage Fright", "Drummer", "Pressure", "Ever wondered why there are 1 bottle of wine and 30 beer cans on my rider?" },
        new[] { "Stage Fright", "Singer", "Pressure", "Ever wondered why there are 1 bottle of wine and 30 beer cans on my rider?" },
        new[] { "Drumsticks", "Tool", "Wood", "Ever wondered why it looks like sawdust behind the drums?" },
        new[] { "Knife", "Stone", "Metal", "Flavour text here..." }, //TODO
        new[] { "Leather", "Knife", "Animal", "Now you might finally make some cool stuff to wear!" }, 
        new[] { "Studded Belt", "Metal", "Leather", "Naaah, only one? I think I can fit a few more" }, 
        new[] { "Leather Jacket", "Leather", "Clothes", "You need to own at least one" }, 
        new[] { "Guitar", "Wood", "Electricity", "If you don't have one you're not actually allowed to play this game, sorry" }, //TODO
        new[] { "Guitarist", "Guitar", "Musician", "Hey what do you mean we can't have a guitar solo in every song?" },
        new[] { "Guitarist", "Guitar", "Human", "Hey what do you mean we can't have a guitar solo in every song?" },
        new[] { "Fan", "Love", "Guitarist", "Flavour text here..." }, //TODO
        new[] { "Fan", "Love", "Drummer", "Flavour text here..." }, //TODO
        new[] { "Fan", "Love", "Singer", "Flavour text here..." }, //TODO
        new[] { "Crowd", "Fan", "Fan", "Flavour text here..." }, //TODO
        new[] { "Crowd Surfing", "Crowd", "Wave", "I recommend you count the crowd before, I've seen bad things..." }, 
        new[] { "Tele Cable", "Guitar", "Cable", "Just fucking buy your own cables already" }, 
        new[] { "Fist Sign", "Fan", "Heavy Metal", "Horns up" },
        new[] { "Satanism", "Satan", "Fan", "Don't be hysterical mum, it's quite popular" }, 
        new[] { "Satanism", "Satan", "Love", "Don't be hysterical mum, it's quite popular" }, 
        new[] { "Fruit", "Sun", "Tree", "Always in a bowl backstage, but nobody ever eats it" }, 
        new[] { "Alcohol", "Time", "Fruit", "Flavour text here..." }, //TODO
        new[] { "Crops", "Earth", "Plant", "Flavour text here..." }, //TODO
        new[] { "Beer", "Crops", "Alcohol", "Flavour text here..." }, //TODO
        new[] { "Amplifier", "Electricity", "Sound", "Turn it to 11!" },
        new[] { "Merch", "Band", "Clothes", "If you liked the show, buy at least one shirt to support the band" },
        new[] { "Merch", "Band", "Outfit", "If you liked the show, buy at least one shirt to support the band" }, 
        
        /*
        new[] { "Double Neck", "Guitar", "Guitar", "Isn't it quite lame you don't play both at the same time?" }, //TODO
        new[] { "PA System", "Amplifier", "Microphone", "..." }, //TODO
        new[] { "Pin", "Plastic", "Metal", "..." }, //TODO 
        new[] { "Band", "Musician", "Musician", "..." }, //TODO - make more!
        new[] { "Gig", "Band", "Crowd", "..." }, //TODO
        new[] { "Paper", "Pressure", "Tree", "..." }, //TODO
        new[] { "Poster", "Paper", "Fan", "..." }, //TODO
        new[] { "Autograph", "Band", "Paper", "..." }, //TODO
        new[] { "Ticket", "Gig", "Paper", "..." }, //TODO
        new[] { "Timing", "Human", "Time", "..." }, //TODO - make songs, rhythm, riff etc!!!!
        */       
    }; 
}
