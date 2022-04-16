using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AssignmentGame.Models;

namespace AssignmentGame.Controllers
{
    public class GameController : Controller
    {
        public static int counter;

        [Authorize]
        public ActionResult checkNumber(Game obj)
        {

            counter++;
            if (ModelState.IsValid)
            {
                String guess = obj.Number;
                int Cow = 0;
                int Bull = 0;
                var date = DateTime.Now;
                String SecretNumber = date.ToString("ddHH");
                int[] visited = new int[4];
                int[] visitedCow = new int[4];

                //get all bulls
                for (int i = 0; i < 4; i++)
                {
                    char secretVal = SecretNumber[i];
                    char guessVal = guess[i];
                    if (secretVal == guessVal)
                    {
                        visited[i] = 1;
                        Bull++;
                    }
                }

                if (Bull == 4)
                {
                    ViewBag.Counter = counter;
                    return View("checkNumber");
                }

                //find all cows
                for (int i = 0; i < 4; i++)
                {
                    if (visited[i] == 1) continue;
                    char guessVal = guess[i];
                    for (int j = 0; j < 4; j++)
                    {
                        char secretVal = SecretNumber[j];
                        if (secretVal == guessVal && visited[j] == 0 && visitedCow[i] == 0)
                        {
                            visitedCow[i] = 1;
                            Cow++; break;
                        }
                    }
                }

                ViewBag.Cow = Cow.ToString();
                ViewBag.Bull = Bull.ToString();
                ViewBag.Counter = counter + "";
                return View("CowAndBull");
            }
            else
            {
                return View("CowAndBull");
            }
        }

        public ActionResult CowAndBull()
        {
            return View();
        }
    }

}