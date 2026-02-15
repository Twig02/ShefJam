using System;
using UnityEngine;

public class TickScript : MonoBehaviour
{
    public GameObject contentObject;
    public void onButtonClick()
    {
        Swipee currentSwipe = contentObject.GetComponent<Init>().currentSwipe;
        Swiper player = contentObject.GetComponent<Init>().player;
        int successfulMatches = contentObject.GetComponent<Init>().successfulMatches;

        System.Random rmd = new System.Random();
        if (matchOrNot(currentSwipe, player, rmd)) {
            successfulMatches ++;
            MessageController messageController = GameObject.FindGameObjectWithTag("MessageController").GetComponent<MessageController>();
            messageController.startMessaging(currentSwipe.Personality);
        }

        currentSwipe = new Swipee(rmd);
        contentObject.GetComponent<Init>().UpdateSwipeScreen(currentSwipe);
    }

    public bool matchOrNot(Swipee swipee, Swiper player, System.Random rnd) {
        if (!hitPreferences(swipee, player)) {
            double jobModifier = jobModifierCalculator(swipee, player);
            double ageModifier =  ageModifierCalculator(swipee, player);
            double datingGoalsModifier =  datingGoalsModifierCalculator(swipee, player);
            double heightModifier =  heightModifierCalculator(swipee, player);
            double ricePurityModifier =  ricePurityModifierCalculator(swipee, player);

            double totalModifier = Math.Max(jobModifier * ageModifier * datingGoalsModifier * heightModifier * ricePurityModifier, 0.2);
            
            if (rnd.Next(101) <= (totalModifier * 100)) {
                return true;
            } else {
                return false;
            }
        }
        return false;
    }

    public bool hitPreferences(Swipee swipee, Swiper player) {
        for (int i = 0; i < 1; i++)
        {
            switch (player.Preferences[i].Category)
            {
                case "Hair Length":
                    if (swipee.Looks[0] != player.Preferences[i].Value) return false;
                    break;
                case "Hair Colour":
                    if (swipee.Looks[1] != player.Preferences[i].Value) return false;
                    break;
                case "Eye Colour":
                    if (swipee.Looks[2] != player.Preferences[i].Value) return false;
                    break;
                case "Glasses":
                    if (swipee.Looks[3] != player.Preferences[i].Value) return false;
                    break;
            }
        }
        return true;
    }

    public double jobModifierCalculator(Swipee swipee, Swiper player) {
        return Swiper.jobsArray[Swiper.jobsDict[swipee.Job], Swiper.jobsDict[player.Job]];
    }

    public double ageModifierCalculator(Swipee swipee, Swiper player) {
        int swipeeAge = swipee.Age;
        int playerAge= player.Age;

        if ((playerAge - swipeeAge) >= 20) {
            return 0.7;
        } else if ((playerAge - swipeeAge) >= 10) {
            return 0.9;
        } else if ((playerAge - swipeeAge) >= 5) {
            return 1.1;
        } else if ((playerAge - swipeeAge) >= 3) {
            return 1.2;
        } else if ((playerAge - swipeeAge) >= -2) {
            return 1.4;
        } else if ((playerAge - swipeeAge) >= -4) {
            return 1.2;
        } else if ((playerAge - swipeeAge) >= -9) {
            return 1.1;
        } else if ((playerAge - swipeeAge) >= -19) {
            return 1;
        } else if ((playerAge - swipeeAge) >= -49) {
            return 0.8;
        } else {
            return 1.5;
        }
    }

    public double datingGoalsModifierCalculator(Swipee swipee, Swiper player) {
        return Swiper.datingGoalsArray[Swiper.datingGoalsDict[swipee.DatingIntentions], Swiper.datingGoalsDict[player.DatingIntentions]];
    }

    public double heightModifierCalculator(Swipee swipee, Swiper player) {
        int swipeeHeight = int.Parse(swipee.Height[0].ToString()) * 12 + int.Parse(swipee.Height[2..^1].ToString());
        int playerHeight = int.Parse(player.Height[0].ToString()) * 12 + int.Parse(player.Height[2..^1].ToString());

        int heightDifference = Math.Abs(playerHeight - swipeeHeight);

        if (heightDifference < 3) {
            return 1.4;
        } else if (heightDifference < 6) {
            return 1.2;
        } else if (heightDifference < 10) {
            return 1;
        } else {
            return 0.7;
        }
    }

    public double ricePurityModifierCalculator(Swipee swipee, Swiper player) {
        int ricePurityDifference = Math.Abs(swipee.RicePurityScore - player.RicePurityScore);
            if (ricePurityDifference <= 9) {
                return 1.3;
            } else if (ricePurityDifference <= 19) {
                return 1.1;
            } else if (ricePurityDifference <= 39) {
                return 1;
            } else if (ricePurityDifference <= 59) {
                return 0.9;
            } else {
                return 0.8;
            }
    }

}
