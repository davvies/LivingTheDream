using System.Collections.Generic;
using UnityEngine;

/// <summary> Class <c>EmailLogic</c> A file containing lists of all emails </summary>
public class EmailLogic : MonoBehaviour
{
    public EmailSystem emailSystemFirstLevel;
    public List<EmailSystem.Email> emails;
    public int emailsLeftToAnswer = 0; 

    void Start()
    {
        emailSystemFirstLevel = GetComponent<EmailSystem>();
        string currentDay = transform.parent.transform.parent.name;

        switch (currentDay) //dynamically allocate lists of emails relative to day
        {
            case "DayOne":
                emails = new List<EmailSystem.Email>
        {
            new EmailSystem.Email("Head Office",
                                         "Another Week!",
                                         "Good morning. \n\n I hope you are all ready for another week, E-CORP© has joined us in the " +
                                         "workplace efforts. I've been getting some complaints about several people feeling under the weather, " +
                                         "I'd just like to remind you that getting on with it is the best thing to do. \n\n" +
                                         "We're all in the same boat.\n\nHead Office.", "Greetings Head Office, \n\n" +
                                         "This week will be my week, I'm feeling positive about the challenges ahead and am looking forward to working " +
                                         "to the best of my ability. \n\n All the best!, \n\n Yours.", "Hi. \n\n I'm not feeling so great this week, I understand " +
                                         "this is not the best time to be mentioning this but my productivity may be slacking. \n\n I happy to discuss this if needed. \n\n" +
                                         "I hope you understand, I'm not feeling my best.\n\n Yours.",false,false,5,0),

            new EmailSystem.Email("Unknown", "Your fortune","HELLO SIR OR MADAM\n\n" +
                                                            "YES I AM SENDING YOU EMAIL TO TELL YOU ABOUT YOU BEING SELECTED FOR A FREE CD PLAYER." +
                                                            "ALL YOU HAVE TO DO IS TO SIMPLY RESPOND WITH YOUR COMPANIES NAME AND COMPANY PASSWORD " +
                                                            "THE CD PLAYER WILL BE SEND OUT THEN OKAY\n\nBYE","Hello, \n\n"+"Whilst I thank you for your offer. "+
                                                            "I must decline, unfortunately it is against company policy to enter competitions like this.\n\n All the best!","HI.\n\n"+
                                                            "Please never contact me again or you will be traced and report to the authorities.\n\n Yours.",false,false,0,0),

            new EmailSystem.Email("Partner","Help her","Hey you!\n\n"+
                                  "I know you said not to email you on your work email but I'm sorry I've got too! The little guy needs picking up at pre-school, would you mind finishing work early today?"+
                                  "This is big deal for me, I don't have access to a car today and I really need you to swing by and get him. It'll mean the world.\n\n Have a great day at work! x","Helllooo,\n\n That's not a problem at all!" +
                                  "I'll pull a sickie (I'm overdue time off anyway at this place) :-)\n\n Have a good day!!","Heyy, \n\n I'm so sorry but I'm in work late tonight, maybe another time\n\n(Sorry again) x",false,false,-15,15),

             new EmailSystem.Email("Boss","PROMOTION!","How's my worker bees?\n\n"+
                                  "It's monday again! Lets not lose sight of that promotion, eh? With a long week ahead, there's plenty of chances to go up in the world "+
                                  "Make a mark on this workforce today! Want that comfy lifestyle? it's all up to you, my friends \n\n Yours.","Greetings,\n\n I'm doing everything in my power to progress up the ranks. " +
                                  "This means everything to me! This is my week. \n\n Kindest Regards.","Greetings, \n\n As much as I'd love that promotion, I've got a lot on my plate currently.\n\n Kindest Regards.",false,false,5,0),

             new EmailSystem.Email("IT Dept.","Upgrade time","Hello, \n\n"+
                                  "We've heard word that the department machines are unreliable. With new funding from head office it may be time to upgrade the firmware. "+
                                  "The current machines often overheat and are sorely missing colour screens. \n\n IT Dept.","Greetings,\n\n My colleagues and I feel such an upgrade is very much needed " +
                                  "Moving to paper won't be an issue at all. In many ways it's easier to organise. \n\n Kindest Regards.","Greetings, \n\n My colleagues and I feel such an upgrade is asking for trouble. \n\n " +
                                  "Perhaps if the department does not hold overtime this weekend, then maybe then. \n\n Kindest Regards.",false,false,0,0),
        };
                emailsLeftToAnswer = emails.Count;
                break;

            case "DayTwo":
                emails = new List<EmailSystem.Email>
        {
            new EmailSystem.Email("Boss",
                                         "It's yours!",
                                         "Happy Tuesday all, \n\nHead office had sent me an email late last night about out departments attendance."
                                         +" Yes, in an ideal world we can all have a few days off but it's crunch time and I feel many of you are using"
                                         +" this suddenly as a means of not showing up to work. I'd like to remind all of you that if you really"
                                         +" want that promotion then you HAVE to do the time.\n\nYour family and peers will look at you with endearment.\n\nYours.","Greetings Boss,\n\n I'm happy to go that extra mile "+
                                         "I have seen this myself in the department and have reminded my colleagues that this behaviour is not accepted.\n\nYours.",
                                         "Greetings Boss, \n\nWith all due respect the department is stretched thin, I can assure you we all try our best.\n\nYours.",
                                         false,false,5,0),

                new EmailSystem.Email("Barbra",
                                         "Hurry now!","Marketing are kicking up a storm at the moment, I really need those projection papers on my desk by noon today!\n\n"
                                         +"The department have pointed the finger at you and word's going round that you may be one of the folks about to take time off work.\n\nPlease"+
                                         " don't let that be the case.\n\nBarbs.","Barbra, \n\nI am not sure where you heard that, it's completely false. \n\n"+
                                         " the projection papers are almost ready, I'll have them by noon on your desk. I've also gone and sketched out a diagram"+
                                         " for potential integrations with ECORP technology (as I heard yesterday, they'll be partnering with us)\n\nSorry"+
                                         " again about the scare, \n\n Yours.","Hi.\n\nBarbra, I'm afraid to tell you those papers may be slightly late.\n\n"+
                                         "Although I don't plan to take time off work, it's true that I haven't been feeling myself lately (must be one of those weeks). \n\n Despite all this "+
                                         "Do you mind putting in a good word for me anyway?\n\nYours.",false,false,10,0),

                new EmailSystem.Email("ElectricCo",
                                         "The mains","Hello.\n\nThis is Steve from ElectricCo (we spoke via telephone) on Sunday.\n\n"+
                                         "We unfortunately could not fix the power surge problem within your household. These problems are serious "+
                                         "and can lead to further electrical damages/surges and eventually fire. Our service offers house callouts but these are costly - " +
                                         "typically the sum of £2500. If you like we can dicuss this payment from your personal account later this week?\n\n" +
                                         "AUTOMATED COMPUTER SIGN OFF: {{bring security in electrics to your house with ElectricCo}}","Hi Steve.\n\nIf these electrical problems are as serious "+
                                         "as they sound then it only makes sense to apply for the callouts, I'm happy to discuss via the telephone.\n\nThanks.","Hi Steve,\n\n"+
                                         "£2500 is far beyond anything I'm currently able to afford, the damages will have to sustain. \n\n Yours.",false,false,0,10),

                new EmailSystem.Email("Boss",
                                         "Infrastructure","Hello All,\n\nA quick update from the IT department after yesterdays email, thank you all for you feedback.\n\n"+
                                         "Colour CRT monitors have been ordered. The expected date of arrival is not set in stone (you will all hear back from the IT department "+
                                         "by the end of the week). We expect all employees to move to a paper-based system, as always remember to keep a smile.\n\nYours.","Greetings.\n\n"+
                                         "This upgrade will help the departments overall productivity and is welcome change.\n\nHappy to hear!\n\nYours.","Hi\n\n" +
                                         "I had my reservations. One must assume this choice will disrupt the flow of productivity.\n\nMany will not be pleased.",false,false,0,0)
                };
                emailsLeftToAnswer = emails.Count;
                break;

            case "DayThree":
                emails = new List<EmailSystem.Email>
                {
                    new EmailSystem.Email("Boss",
                                         "Manual", "Happy wednesday all,\n\nWe've added a manual to your machines, covering the basis of the new legal partnership.\n\n" +
                                         "We expect ALL employees to read the documentation and understand it throughly. You can find this documentation on your digital home-screen"
                                         + " under the symbol of 'Legal'. Again, make sure you take the time to read this, as many of you will be discussing the implications within fridays meeting.\n\nBest.",
                                         "Hi Boss, \n\nI'll have that read as quick as possible. I'm feeling confident ahead of fridays legal meeting.\n\nYours.", "Hi Boss, \n\nAlthough I'll make every effort to get round to reading the post" +
                                         " however, I'm a little busy today. I'll see to it when I can\n\nYours.", false, false,5,0),

                     new EmailSystem.Email("Finance Dept.",
                                         "A favour", "Hi,\n\nThis is the Finance Department. In honour of our upcoming conference on friday, we need a dedicated staff member to take home the raw financial data readings and analyse them. \n\n"+
                                         "*DISCLAIMER: There are over two hundred records that need analysing. Please fax the final readings to the department*\n\n"+
                                         "Finance Dept.","Greetings,\n\nDespite the mountain of work I currently find myself doing, I'll be more than happy to take on the responsibility","Greetings,\n\n"+
                                         "There's far too much on my plate at this current point. This was a task I was especially eager to take on but won't be able too anymore, cheers.\n\nRegards.",false,false,10,-10),

                     new EmailSystem.Email("IT Dept.",
                                         "'VIRUS'","Hello all,\n\nWe've received word that machines have been acting unusually strange. The root cause of this appears to have been a malicious floppy disk intentionally used to cause internal damage."+
                                         "Whilst the situation is being monitored it is highly advised that any unusual e-documents or e-photographs found on the machines be avoided. DO NOT click these. Several departments have been affected by the breach.\n\n"+
                                         "We ask for your full co-operation in this situation.\n\nIT Dept.","Greetings,\n\nI will ensure my best to avoid anything out of the ordinary.\n\nSo far I've not noticed anything unusual about my machine but will be sure to "+
                                         "to send a notification via e-mail if such an issue occurs. \n\nYours.","Greetings,\n\nFantastic! Well I'm glad there's extra requirements to a role I'm currently already being underpaid for.\n\n"+
                                         "Whatever happens, happens. The department already has enough on its plate without this extra 'virus' nonsense.\n\nRegards.",false,false,0,0),

                      new EmailSystem.Email("Christopher",
                                         "Drinks","Hey!\n\nI know we always talk about grabbing drinks but never have the time, I am especially finding this week a drag. Perhaps all the gang can arrange heading down the pub? "+
                                         "Thursday night might be the best night to head down. I understand you may be taking part in the conference friday, so if you can't go that's fine. But we really need to sort something out, it seems like"+
                                         " forever since we all got together. I imagine it might do you some good also! There's lots of office drama behind your back recently, so it'll be nice.\n\nChris.",
                                         "Chris!\n\nThis week has honestly felt like every single one before it. Truly we are all living the dream.\n\nI would love to get some head-space away from family and work matters. I hope this time we can sort something out "+
                                         ", lord knows I need it. \n\nYours.","Chris,\n\nIf I'm being quite honest work feels the same as always. Truly we are all living the dream.\n\nAlthough I would love to join you all, the conference friday is too important to risk oversleeping"+
                                         "; given how the office is already, my neck will well and truly be on the line.\n\n Sorry again.Yours",false,false,-10,-10),

                      new EmailSystem.Email("Unknown",
                                         "I'm watching","Do you really think the department boss has no idea what you're doing? \n\n You're work ethic is abysmal. I see you slacking off constantly and it quite frankly gives this company a bad name. \n\n"+
                                         "If I catch you taking anymore breaks throughout the day, believe me I will make your life more hell than it already seems. I know a lot more about you than you think."+
                                         "I have ties right to the top of the company, so don't even think about reporting this email.\n\nAn enemy","Hello.\n\nThreats don't work on me. I've done nothing wrong\n\nAs you were.",
                                         "I don't care who you are, I'm reporting this email to personnel.\n\nAs you were.",false,false,0,0)

                };
                emailsLeftToAnswer = emails.Count;
                break;

            case "DayFour":
                emails = new List<EmailSystem.Email>
                {
                    new EmailSystem.Email("Boss",
                                         "Rumours", "Good thursday to all,\n\nThere have been rumours going round that the department will be making redundancies. Whilst there's some truth to this "+
                                         "unless you know you're going I strongly suggest being quiet about such matters. When the time is right the people who are leaving will be told.\n\n"+
                                         "For now, carry on with your tasks.\n\nBesides from this interlude the big promotion will be announced tomorrow.\n\nYours.","Greetings,\n\nI'm feeling confident ahead of the promotion annonced tomorrow.\n\n"+
                                         "Best.","Greetings, \n\nI hope whoever gets it is really worthy of the role.\n\nI've lost interest in chasing it.\n\n Best.",false,false,5,0),

                     new EmailSystem.Email("IT Dept.",
                                         "Virus update Dept.","Hello,\n\nAfter yesterdays' breach it should be clear that the virus situation is under control. Users have still be reporting mysterious e-documents and e-photgraphs showing on their digital desktops.\n\n"+
                                         "Please do not interact with anything that you do not recognise on the machine. We have reason to believe hackers may have gotten hold of information. Please change your login information and password. "+
                                         "We'll be sure not to let something like this happen again in future.\n\nIT Dept.","Greetings,\n\nI would like to change my password but am I afraid of co-workers passing my cubicle and seeing it, am I able to arrange a meeting to change the password?\n\nYours.",
                                         "Hi.\n\nThis is honestly the last thing I needed to hear today, does this mean that the hacker will able to read my personal email? Why did your department not see this coming?\n\nYours.",false,
                                         false,0,0),

                     new EmailSystem.Email("Marketing Dept.",
                                         "Tomorrow","Hi,\n\nTomorrow is the big day for the conference. I hope all are ready, we're planning to establish an upper hand within the conference. Additional external investors may be there so it's our chance to shine. We'll have the representatives from each department give their speech. "+
                                         "Remember to do all the additional reading throughout today. It's important that this conference goes well. Next week the debriefing will take place on tuesday at 10:30am. None of you should have free-time during today\n\nMarketing Dept.","Hello,\n\nI've done all reading thus far and am ready for the conference tomorrow.\n\n"+
                                         "Yours.","Greetings,\n\nI'm slightly under-prepared for the conference but standard tasks today will be the priority.\n\nYours.",false,false,5,0),

                      new EmailSystem.Email("Partner",
                                         "He's so smart!","Hey you! x\n\nGuess who's won top results in their class! That's right! I know there's this talk of a conference happening tomorrow, but would it kill to leave work five minutes early?\n\nI'm not even saying to skip it, but it'll be his graduation friday and he'd hate for his role model to be missing!\n\n"+
                                         "Would you at least come and show your face?\n\nBesides all that, have a good day at work! x","Hey!\n\nWork won't like it but I've worked hard this week. I'm taking time off, the conference will be all but over once I'm done!\n\nCan't wait to see him x",
                                         "Hey,\n\nI HATE to do this but this conference for work is important, I need to go.\n\nI'm sorry.",false,false,-15,15),


                };
                emailsLeftToAnswer = emails.Count;
                break;

            case "DayFive":
                emails = new List<EmailSystem.Email>
                {
                    new EmailSystem.Email("Marketing Dept.",
                                         "Big day!", "Hi all\n\nTodays the day of the conference. WE NEED EVERYTHING TO GO WELL. Remember investors will be there and you all need to perform at your highest level.\n\n"+
                                         "To ensure you all understand your roles, we've attached some preparation to your machines, these can be found under the 'speech' and 'brief' document icons, please read this and take in all information. "+
                                         "For users who have complained about the internal damage of the 'VIRUS' attack, there should be no problem with the preparation you have done.\n\nPlease keep re-reading everything. Good luck!\n\nMarketing Department","Hello,\n\nI'm more than "+
                                         "confident for todays speech. I believe I can deliver all key points. \n\n We'll all smash it.\n\n Yours","Hi\n\nI hate to be all negative but I have a sinking feeling this conference will fall flat, I do not have access to the documents.\n\nHELP QUICK\n\nYours.",false,false,3,0),

                     new EmailSystem.Email("Boss",
                                         "Promotion","Morning all,\n\nThank GOD it's friday. Lets have a productive day, ready for next week! Quick announcement: No one was able to obtain the promotion. Not to worry, there will be another chance again next week.\n\n"+
                                         "Some of you in the department have put your soul into work this week, lets keep that up for next week and that promotion may be yours. Others.. have disappointed to say the least. Those with poor performance will be receiving a letter via the post soon. This sort of behavior is not acceptable.\n\n"+
                                         "Remember to keep a smile.\n\nYours","Hi\n\n"+
                                         "I'm not sure exactly who is keeping the department behind but today will be a good one for me - I can feel it\n\nBest.","Hi,\n\nThis has been a frantic week, I feel many members of the department are burnt out.\n\nIt's not fair to keep this pressure on every week\n\nYours.",false,false,6,0),

                     new EmailSystem.Email("In-laws",
                                         "Photographs","Hello,\n\nWe cordially request that you send the photographs of the graduation ceremony yesterday for the little one. Send these via first-class post as we'd like to frame them on the mantel piece.\n\nWe were told not to email this address but it's our first time using this technology, so we thought we'd try.\n\nWe look forward to having you round for dinner in the near feature.\n\nBest.",
                                         "Hello,\n\nI did not expect this email. It's not a problem at all, I'll send them as soon as I finish work today (it may be slightly late).\n\nYours.","Hello,\n\nI don't know how many times I have to mention to folks not to send personal emails on my work email.\n\nI'll mail the photographs when I have the time.\n\nBest.",false,false,0,15),

                      new EmailSystem.Email("Personnel",
                                         "Fess up","Hi,\n\nA state of a vandalism happened on the premise yesterday, we have reason to believe you know exactly who the culprits are. Head office have sent word that there could be severe punishments if the names are not given. Please fax the names to the personnel department by the end of the day.\n\nPersonnel","Hello,\n\n"+
                                         "I know exactly who it was, I'm sending it right over this instance!\n\nYours.","Hello,\n\nI have some idea of those people you mention but don't wish to send names.\n\nYours.",false,false,15,0),

                      new EmailSystem.Email("Unknown",
                                         "The last straw","Hello again,\n\nSince you took no interest in my last email you'll soon find out enough why I should be feared. This is what you get for ignoring threats\n\nAn Enemy","Hi,\n\nAs I've mentioned before there's nothing to be afraid of, I don't think you understand the severity of threatening me via my work email but that's on you.\n\n"+
                                         "Nothing's going to happen. Have a good day!:-)\n\nBye.","Hi,\n\nI'm not exactly sure what your game is here but it's certainly not legal. I made the mistake of not reporting this email the first time, but I won't again.\n\nYou will be traced. I'm not afraid.\n\nYours",false,false,0,0)


                };
                emailsLeftToAnswer = emails.Count;
                break;
        }
        
    }


}
