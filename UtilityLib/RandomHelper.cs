using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityLib
{
    public class RandomHelper
    {
        private static Random _rd = new Random();

        public static string PasswordCreator(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();
                pwd += (_rd.Next(0, 9)).ToString();

            }
            return pwd;
        }

        public static string ApplePasswordCreator()
        {

            string[] first = {"Qq","Aa","Zz","Ww","Ss","Xx","Ee","Dd","Cc","Rr","Ff","Vv","Tt","Gg","Bb","Yy","Hh",
                                  "Nn","Uu","Jj","Mm","Ii","Kk","Oo","Ll","Pp"};

            string[] second = { "11", "22", "33", "44", "55", "66", "77", "88", "99", "00" };

            string firstStr = first[_rd.Next(first.Length)];
            string secondStr = second[_rd.Next(second.Length)];

            List<string> third = second.ToList();
            third.Remove(secondStr);

            string thirdStr = third[_rd.Next(third.Count)];
            third.Remove(thirdStr);

            string fourthStr = third[_rd.Next(third.Count)];


            return firstStr + secondStr + thirdStr + fourthStr;
        }
        public static string CreatorZiMu(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();

            }
            return pwd;
        }

        public static string ApplePasswordCreator2()
        {
            string[] second = { "11", "22", "33", "44", "55", "66", "77", "88", "99", "00" };
            string secondStr = second[_rd.Next(second.Length)];
            return CreatorZiMu2(6,6) + secondStr;
        }

        public static string CreatorZiMu2(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length - 2; i++)
            {
                char str_t = ((char)_rd.Next(65, 123));
                while(!char.IsLetter(str_t))
                {
                    str_t = ((char)_rd.Next(65, 123));
                }

                pwd += str_t.ToString();
            }

            pwd += ((char)_rd.Next(65, 90)).ToString().ToUpper();
            pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();
            return pwd;
        }

        public static string GetRandomPhoneNum()
        {
            string[] phoneSecondNum = { "3", "5", "8" };

            return string.Format("1{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                                phoneSecondNum[_rd.Next(0, phoneSecondNum.Length)], _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10),
                                _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10), _rd.Next(0, 10));
        }

        public static string GetRandomZipCode(int minLength, int maxLength)
        {
            string zipCode = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                zipCode += _rd.Next(0, 10).ToString();

            }
            return zipCode;
        }

        public static string GetBirthday()
        {
            return _rd.Next(1960, 1996) + "-" + _rd.Next(1, 13) + "-" + _rd.Next(1, 29);
        }

        private static List<string> _wordList = new List<string> {"Strength","Intellect","Spirit","Vigor","Willpower","Cleansing","Charmsty","Luck","Prayer","Perception","Mighty","Infiltrate","Infest","Reincarnate","Impending","Impale","Fortitude","Feint","Plague","Feign","Petrify","Pierce","Detection","Combat",
                                                         "Damage","Cauterize","Conflagration","Detonation","Incinerate","Armor","Smite","Evocation","Block","Accuracy","speed","Defense","Kick","Precision","Throwing","Frenzy","Concussion","Subtlety","Camouflage","Elusiveness","Evasion","Vanish","Blind",
                                                         "Opportunity","Backstab","Ambush","Garrorte","Alchemy","Ambush","Arcane","Banish","Blast","Blizzard","Clasp","absorb","Grasp","Miss","Clock","Thick","Durability","Wild","Blessed","Wing","Dim","Diabolical","Devout","Dispel","Discipline","Aura","Aim",
                                                         "Charge","Defiance","Thorns","Mana","Jump","Shooter","Flail","Dragonslayer","Falchion","Brand","Sword","Rapier","Runesword","Shortsword","Broadsword","Stick","Quarterstaff","Pillar","Tail","Axe","Edge","Dragontooth","Francisca","Reaver","Tomahawk",
                                                         "Chopper","Hatchet","Fist","Weapon","Ballista","Catapult","Ram","Talons","Fork","Bow","Arrow","Godblade","Dragonfang","Thorn","Spike","Longbow","Crossbow","Razor","Rod","Splinter","Poker","Kris","Shiv","Poniard","Blade","Knife","Spear","Pike",
                                                         "Lance","Halberd","Hammer","Staff","Wand","Bardiche","Scythe","Staff","Pole","Gun","Dart","Phylactert","Crystal","Ball","Sphere","Globe","Orb","Stone","Scarab","Zither","Harpanola","Lyre","Didgeridoo","Psaltery","Alphorn","Harp","","Necklace",
                                                         "Pendant","Bauble","Talisman","Charm","Chain","Collar","Relic","Fang","Ion","Plasma","Laser","Bomb","Flare","Launcher","Rocket","Shotgun","Cannon","Howitzer","AP","HE","AA-Guns","Gauss","Battery","Armor","Ammo","Clip","Nail","Radar","Loof",
                                                         "Helmet","Halo","Crest","Greathelm","Circlet","Horns","Tiara","Sickle","Uniforms","Satchel","Backpack","Cinch","Strap","Belt","Sinew","Girdle","Sash","Cord","Waistguard","Kneepads","Gloves","Pants","Vestments","Scale","Cover","Shawl","Veil",
                                                         "Shroud","Drape","Cape","Cloak","Link","Band","Sinew","Signet","Circle","Seal","Bracer","Plate","Buckler","Aegis","Bulwark","Defender","Disk","Targe","Protector","Guard","Amulet","Greaves","Sandals","Footwraps","Striders","Sabatons","Slippers",
                                                         "Geta","Shoes","Loop","Bracelet","Ring","Granary","Tent","Avenger","Collar","Epaulet","Horn","Bugle","Dragonhorn","Star","Spade","Banner","Flag","Medallion","Badge","Totem","Symbol","Writ","Hide","Tablet","Forge","Flint","Ship","Flame","Arena",
                                                         "Armory","Cloister","Auction","Bandage","Mill","Cache","Caldron","Catalyst","Cyclone","Deed","Defile","Delicate","Morale","Demoralize","Manual","Codex","Tome","Scroll","Income","Turtle","Eagle","Crab","Skull","Horse","Spider","Sheep","Scorpion",
                                                         "Crow","Ladybug","Beetle","Chipmunk","Lizard","Bunny","Caterpillar","Cockroach","Fox","Starfish","Camel","Dragonfly","Lobster","Seagull","Giraffe","Rooster","Tarantula","Dinosaur","Dragon","Pack","Dummy","Devourer","Centurion","Centaur","Barbarian",
                                                         "Augur","General","Army","Shaman","Grunt","Gyrocopter","Peon","Sorceress","Blademaster","Knight","Rifleman","Civilian","Milltia","Wisp","Archer","Huntress","Dryad","Hippogryph","Chimaera","Warden","Acolyte","Ghoul","Gargoyle","Necromancer",
                                                         "Banshee","Abomination","Destroyer","Shade","Lich","Beastmaster","Archmage","Gunslinger","Convoy","Alliance","Monarch","Human","Dwarf","Gnome","Draenei","Horde","Orc","Troll","Tauren","Murlocs","Ogres","Nagas","Warrior","Priest","Rogue","Hunter",
                                                         "Mage","Warlock","Druid","Paladin","Apprentice","Panther","Pork","Bacon","Tomato","Beer","Banana","Spinach","Honey","Potato","Pear","Iron","Anvil","Copper","Stannum","Gold","Silver","Ore","Gem","Ruby","Diamond","Amazonium","Lumber","，Crude",
                                                         "Duration","Elite","Duel","Emissary","Encounter","Engulf","Lighten","Enrage","Entangle","Epic","Etch","Glacial","Halo","Heal","Hoof","Imbue","Mend","Martyr","","Cheat","Walkthrough","Character","game","play","player","save","load","continue",
                                                         "back","apply","sound","volume","video","audio","register","sell","crack","patch","tutorial","skip","single","multiply","、press","difficulty","easy","normal","medium","insane","nightmare","expert","profile","opponent","choose","magic","north",
                                                         "south","west","east","creature","slow","enemy","defeat","mission","stage","complete","fail","lose","cost","power","target","send","receive","Beginner","Intermediate","Advanced","skill","quest","danger","safety","abort","resume","legend","original",
                                                         "Cheat","Chanllenge","Adventure","Hire","Pardon","unfair","Rabot","Resolution","Brightness","Bloom","Glow","Blur","Flares","Decals","Exposure","Sprint","Crouch","Inventory","Bracer","Leggings","Telescope","Binoculars","Mask","Cap","Diadem","Crowns",};

        public static string GetRandomDevName(int minlength, int maxLength)
        {
            int length = _rd.Next(minlength, maxLength + 1);

            string pwd = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string t = ((char)_rd.Next(65, 90)).ToString();

                if (i == 0)
                {
                    pwd = t.ToUpper();
                }
                else
                {
                    pwd += t.ToLower();
                }
            }

            int i1 = _rd.Next(1, 3);
            List<string> sList_t = new List<string>();

            for (int i = 0; i < i1; i++)
            {
                sList_t.Add(_wordList[_rd.Next(0, _wordList.Count)]);
            }

            sList_t.Insert(_rd.Next(0, sList_t.Count + 1), pwd);

            StringBuilder sb = new StringBuilder();

            foreach (var s in sList_t)
            {
                sb.Append(s + " ");
            }

            return sb.ToString().Trim();
        }

        public static string GetRandomName()
        {
            return _nameWordList[_rd.Next(0, _nameWordList.Count)];
        }

        private static List<string> _nameWordList = new List<string>
        {
            "Abbott","Abe","Abraham","Acheson","Ackermann","Adam","Adams","Addison","Adela","Adelaide",
            "Adolph","Agnes","Albert","Alcott","Aldington","Aldridge","Aledk","Alerander","Alfred","Alice",
            "Alick","Alsopp","Aly","Amelia","Anderson","Andrew","Ann","Anna","Anne","Anthony","Antoinette",
            "Antonia","Arabella","Archibald","Armstrong","Arnold","Arthur","Attlee","Augustine","Augustus",
            "Austen","Austin","Babbitt","Bach","Bacon","Baldwin","Barnard","Barney","Barrett","Barrie","Bart",
            "Bartholomew","Bartlett","Barton","Bauer","Beard","Beaufort","Becher","Beck","Becky","Beerbohm",
            "Bell","Bellamy","Belle","Belloc","Ben","Benedict","Benjamin","Bennett","Benson","Bentham","Berkeley",
            "Bernal","Bernard","Bert","Bertha","Bertie","Bertram","Bess","Bessemer","Bessie","Bethune","Betsy",
            "Betty","Bill","Billy","Birrell","Black","Blake","Bloomer","Bloomfield","Bloor","Blume","Bob","Bobby",
            "Boswell","Bowen","Bowman","Boyle","Bradley","Bray","Brewster","Bridges","Bright","Broad","Bronte","Brooke",
            "Brown","Browne","Browning","Bruce","Bruno","Bryan","Bryce","Buck","Buckle","Bulwer","Bunyan","Burke","Burne-Jones",
            "Burns","Butler","Byron","Camilla","Camp","Carey","Carl","Carllyle","Carmen","Carnegie","Caroline","Carpenter","Carrie",
            "Carroll","Carter","Catharine","Cecillia","Chamberlain","Chaplin","Chapman","Charles","Charley","Charlotte","Charles",
            "Chaucer","Chesterton","Child","Childe","Christ","Christian","Christiana","Christie","Christopher","Christy","Church",
            "Churchill","Cissie","Clapham","Clara","Clare","Clarissa","Clarke","Clemens","Clement","Cocker","Coffey","Colclough",
            "Coleridge","Collins","Commons","Conan","Congreve","Connie","Connor","Conrad","Constance","Cooke","Cooper",
            "Copperfield","Cotton","Coverdale","Cowper","Craigie","Crane","Crichton","Croft","Crofts","Cromwell","Cronin",
            "Cumberland","Curme","Daisy","Dalton","Dan","Daniel","Daniell","Darwin","David","Davy","Defoe","Delia","Dennis",
            "DeQuincey","Dewar","Dewey","Dick","Dickens","Dickey","Dillon","Dobbin","Dodd","Doherty","Dolly","Donne","Dora",
            "Doris","Dorothea","Dorothy","Douglass","Doyle","Dierser","Dryden","DuBois","Dulles","Dunbar","Duncan","Dunlop",
            "Dupont","Dutt","Eddie","Eden","Edgeworth","Edie","Edison","Edith","Edmund","Edward","Effie","Eipstein","Eisenhower",
            "Eleanor","Electra","Elinor","Eliot","Elizabeth","Ella","Ellen","Ellis","Elsie","Emerson","Emily","Emma","Emmie",
            "Ernest","Esther","Eugen","Eugene","Euphemia","Eva","Evan","Evans","Eve","Evelina","Eveline","Ezekiel","Fanny",
            "Faraday","Fast","Faulkner","Felix","Felton","Ferdinand","Ferguson","Field","Fielding","Finn","FitzGerald","Flower",
            "Flynn","Ford","Forster","Foster","Fowler","Fox","Frances","Francis","Frank","Franklin","Fred","Frederick","Freeman",
            "Funk","Gabriel","Galbraith","Gallacher","Gallup","Galsworthy","Garcia","Garden","Gardiner","Gaskell","Geoffrey",
            "Geordie","George","Gibbon","Gibson","Gilbert","Giles","Gill","Gissing","Gladstone","Godwin","Gold","Goldsmith",
            "Gosse","Grace","Gracie","Graham","Grant","Grantham","Gray","Green","Gregory","Gresham","Grey","Grote","Gunter",
            "Gunther","Gus","Guy","Habakkuk","Haggai","Hal","Halifax","Hamilton","Hamlet","Hansen","Hansom","Hardy","Harold",
            "Harper","Harriman","Harrington","Harrison","Harrod","Harry","Hart","Harte","Harvey","Hawthorne","Haydn","Haywood",
            "Hazlitt","Hearst","Helina","Hemingway","Henley","Henrietta","Henry","Herbert","Herty","Hewlett","Hicks","Hill",
            "Hobbes","Hobson","Hodge","Hodgson","Holmes","Holt","Hood","Hoover","Hope","Hopkins","Horace","Horatio","Hornby",
            "Hosea","House","Housman","Houston","Howard","Howells","Hoyle","Hubbard","Hudson","Huggins","Hugh","Hughes","Hume",
            "Humphrey","Huntington","Hutt","Huxley","Ingersoll","Irving","Isaac","Isabel","Isaiah","Ivan","Jack","Jackson",
            "Jacob","James","Jane","Jasper","Jeames","Jean","Jefferson","Jenkins","Jennings","Jenny","Jeremiah","Jeremy",
            "Jerome","Jerry","Jessie","Jim","Jimmy","Joan","Job","Joe","Joel","John","Johnny","Johnson","Johnstone","Jonah",
            "Jonathan","Jones","Jonson","Jordan","Joseph","Josh","Joshua","Joule","Joyce","Judd","Judith","Judson","Julia",
            "Julian","Juliana","Juliet","Julius","Katte","Katharine","Kathleen","Katrine","Keats","Kelley","Kellogg","Kelsen",
            "Kelvin","Kennan","Kennedy","Keppel","Keynes","Kingsley","Kipling","Kit","Kitto","Kitty","Lamb","Lambert","Lancelot",
            "Landon","Larkin","Lattimore","Laurie","Law","Lawrence","Lawson","Leacock","Lee","Leigh","Leighton","Lena","Leonard",
            "Leopold","Lew","Lewis","Lily","Lincoln","Lindbergh","Lindsay","Lizzie","Lloyd","Locke","London","Longfellow","Longman",
            "Louie","Louis","Louisa","Louise","Lowell","Lucas","Lucia","Lucius","Lucy","Luke","Lyly","Lynch","Lynd","Lytton","MacAdam",
            "MacArthur","Macaulay","MacDonald","Mackintosh","MacMillan","MacPherson","Madge","Maggie","Malachi","Malan","Malory",
            "Malthus","Maltz","Mansfield","Marcellus","Marcus","Margaret","Margery","Maria","Marion","Marjory","Mark","Marlowe",
            "Marner","Marshall","Martha","Martin","Mary","Masefield","Mathilda","Matthew","Maud","Maugham","Maurice","Max","Maxwell",
            "May","McCarthy","McDonald","Meg","Melville","Meredith","Micah","Michael","Michelson","Middleton","Mike","Mill","Milne",
            "Milton","Minnie","Moll","Mond","Monroe","Montgomery","Moore","More","Morgan","Morley","Morris","Morrison","Morse","Morton",
            "Moses","Motley","Moulton","Murray","Nahum","Nancy","Nathaniei","Needham","Nehemiah","Nell","Nelly","Nelson","Newman","Newton",
            "Nicholas","Nichols","Nick","Nicol","Nixon","Noah","Noel","Nora","Norris","North","Norton","Noyes","Obadiah","O’Casey","Occam",
            "OConnor","Oliver","ONeil","Onions","Orlando","Oscar","Owen","Palmer","Pansy","Parker","Partridge","Pater","Patience",
            "Patrick","Paul","Peacock","Pearson","Peg","Peggy","Penn","Pepys","Perkin","Peter","Petty","Philemon","Philip","Piers",
            "Pigou","Pitman","Poe","Pollitt","Polly","Pope","Pound","Powell","Price","Priestley","Pritt","Pulitzer","Pullan","Pullman",
            "Quiller","Raglan","Raleign","Ralph","Raman","Ramsden","Raphael","Rayleign","Raymond","Reade","Rebecca","Reed","Reynolds",
            "Rhodes","Rhys","Ricardo","Richard","Richards","Richardson","Rob","Robbins","Robert","Robeson","Robin","Robinson","Rockefeller",
            "Roger","Roland","Romeo","Roosevelt","Rosa","Rosalind","Rose","Rossetti","Roy","Rudolph","Rusk","Ruskin","Russell","Ruth","Rutherford",
            "Sainsbury","Sailsbury","Sally","Salome","Sam","Samson","Samuel","Sander","Sandy","Sapir","Sarah","Saroyan","Sassoon","Saul","Sawyer",
            "Saxton","Scott","Scripps","Senior","Service","Shakespeare","Sharp","Shaw","Shelley","Sheridan","Sherwood","Sidney","Silas","Simon",
            "Simpson","Sinclair","Smedley","Smith","Smollett","Snow","Sonmerfield","Sophia","Sophy","Southey","Spencer","Spender","Spenser",
            "Springhall","Steele","Steinbeck","Stella","Stephen","Stephens","Stevenson","Stilwell","Stone","Stowe","Strachey","Strong","Stuart",
            "Surrey","Susan","Susanna","Sweet","Swift","Swinburne","Symons","Tate","Taylor","Ted","Temple","Tennyson","Terry","Thackeray",
            "Thodore","Theresa","Thomas","Thompson","Thomson","Thoreau","Thorndike","Timothy","Titus","Tobias","Toby","Toland","Tom",
            "Tomlinson","Tommy","Tony","Tours","Tout","Toynbee","Tracy","Trevelyan","Trollpoe","Truman","Turner","Tuttle","Twain","Tyler",
            "Ulysses","Valentine","Van","Vaughan","Veblen","Victor","Vincent","Violet","Virginia","Vogt","Wagner","Walker","Walkley",
            "Wallace","Wallis","Walpole","Walsh","Walter","Walton","Ward","Warner","Warren","Washington","Wat","Waters","Watt","Webb",
            "Webster","Wells","Wesley","Wheatley","Wheeler","Whit","Whitehead","Whitman","Whittier","Whyet","Wilcox","Wild","Wilde",
            "Wilhelmina","Will","Willard","William","Wilmott","Wilson","Windsor","Winifred","Wodehous","Wolf","Wollaston","Wood","Woolf",
            "Woolley","Wordsworth","Wright","Wyatt","Wycliffe","Wylde","Yale","Yeates","Yerkes","Young","Yule","Zacharias","Zangwill",
            "Zechariah","Zephaniah","Zimmerman"
        };

        public static string CreateGBChar(int minLen, int maxLen)
        {
            int charLen = _rd.Next(minLen, maxLen + 1);

            int area, code;//汉字由区位和码位组成(都为0-94,其中区位16-55为一级汉字区,56-87为二级汉字区,1-9为特殊字符区)
            StringBuilder sb = new StringBuilder();

            Random rand = new Random();
            for (int i = 0; i < charLen; i++)
            {
                area = rand.Next(16, 88);
                if (area == 55)//第55区只有89个字符
                {
                    code = rand.Next(1, 90);
                }
                else
                {
                    code = rand.Next(1, 94);
                }
                sb.Append(Encoding.GetEncoding("GB2312").GetString(new byte[] { Convert.ToByte(area + 160), Convert.ToByte(code + 160) }));
            }
            return sb.ToString();
        }

        public static string LastNameGetter()
        {
            string target = @"王陈张李周杨吴黄刘徐朱胡沈潘章程方孙郑金叶汪何马赵林蒋俞姚许丁施高余谢董卢江蔡宋曹邱罗杜郭戴洪唐袁肖姜傅范顾吕邵陆彭韩梁万龚冯崔魏毛邹曾邓任费苏康黎孔田于韦孟柳舒向贾谭庄成郝秦尉詹谷易段包乔伊贺耿霍仲纪卓庞奚席晋";

            int index = _rd.Next(0, target.Length);
            return target.Substring(index, 1);
        }       

    }
}
