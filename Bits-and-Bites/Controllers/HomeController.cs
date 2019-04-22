using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bits_and_Bites.Models;
using Microsoft.AspNet.Identity;

namespace Bits_and_Bites.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogPost()
        {
            return View();
        }

        public ActionResult Static()
        {
            return View();
        }

        public ActionResult Archive()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bits and Bites";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out to us.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

        public ActionResult AddNewRecipe()
        {
            RecipeAndPictureModel re = new RecipeAndPictureModel();
            return View(re);
        }        

        [Authorize]
        [HttpPost]
        public ActionResult AddNewRecipe(RecipeAndPictureModel newRecipe)
        {
            Image im = new Image();
            if (newRecipe.CombImage != null)
            {
                im.StoredImage = im.ReturnArray(newRecipe.CombImage);
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    newRecipe.CombImage.InputStream.CopyTo(ms);
                //    array = ms.GetBuffer();
                //    im.StoredImage = array;
                //}
            }
            im.ImageName = newRecipe.CombRecipe.RecipieName;
            im.ImageAlt = newRecipe.CombRecipe.RecipieName;
            db.ImageDB.Add(im);
            newRecipe.CombRecipe.ImageID = im.Id;
            newRecipe.CombRecipe.LikeCounter = 0;
            newRecipe.CombRecipe.SubmittedByID = User.Identity.GetUserId();
            newRecipe.CombRecipe.DateSubmitted = DateTime.Parse(DateTime.Today.Date.ToString("MM/dd/yy"));
            db.RecipieDB.Add(newRecipe.CombRecipe);
            db.SaveChanges();
            return View();
        }

        public ActionResult ViewAllRecipes (int id = 1)
        {
            List<Recipie> recList = new List<Recipie>();
            List<Recipie> newList = new List<Recipie>();
            recList = db.RecipieDB.ToList();
            //this should find the total number of pages, using the decimal to keep decimals until after rounding.
            int totalPages = (int)Math.Ceiling(((decimal)recList.Count) / (decimal)(12));
            

            //Checks to see if the id is a valid number
            if (id < 1)
            {
                id = 1;
            }

            //Checks to see if the id is within number of archive pages.
            else if (id > totalPages)
            {
                //TODO should add an error page for out of range ids
                id = totalPages;
            }

            //this should return the beginning record of a page.  
            int counter = ((id - 1) * 12);

            if (recList.Count > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            else
            {
                for (int i = 0; i < recList.Count; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            List<Bits_and_Bites.Models.Image> imList = new List<Image>();
            List<RecipeWhole> wholeRec = new List<RecipeWhole>();
            foreach (Recipie i in newList)
            {
                Image result = db.ImageDB.SingleOrDefault(tempIm => tempIm.Id == i.ImageID);
                imList.Add(result);
            }

            for (int i = 0; i < newList.Count; i++)
            {
                RecipeWhole x = new RecipeWhole
                {
                    CombRecipe = newList[i],
                    CombImage = imList[i]
                };
                wholeRec.Add(x);
            }

            ViewBag.Total = totalPages;
            ViewBag.ThisPage = id;

            return View(wholeRec);
            
            
        }

        public ActionResult RecipeTable ()
        {
            List<Recipie> recList = new List<Recipie>();            
            recList = db.RecipieDB.ToList();
            
            ViewBag.Total = recList.Count;

            return View(recList);
        }

        
        public ActionResult RecipeTable1(int id)
        {
            Recipie IdRec = new Recipie();
            IdRec = db.RecipieDB.Where(i => i.Id == id).Single();
            db.RecipieDB.Remove(IdRec);
            db.SaveChanges();

            return RedirectToAction("RecipeTable", "Home", null);
        }

        [Authorize]
        public ActionResult UserHome(int id = 1)
        {
            List<Recipie> recList = new List<Recipie>();
            List<Recipie> newList = new List<Recipie>();
            string y = User.Identity.GetUserId();
            recList = db.RecipieDB.Where<Recipie>(x => x.SubmittedByID == y).ToList();
            //this should find the total number of pages, using the decimal to keep decimals until after rounding.
            int totalPages = (int)Math.Ceiling(((decimal)recList.Count) / (decimal)(12));


            //Checks to see if the id is a valid number
            if (id < 1)
            {
                id = 1;
            }

            //Checks to see if the id is within number of archive pages.
            else if (id > totalPages)
            {
                //TODO should add an error page for out of range ids
                id = totalPages;
            }

            //this should return the beginning record of a page.  
            int counter = ((id - 1) * 12);

            if (recList.Count > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            else
            {
                for (int i = 0; i < recList.Count; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            List<Bits_and_Bites.Models.Image> imList = new List<Image>();
            List<RecipeWhole> wholeRec = new List<RecipeWhole>();
            foreach (Recipie i in newList)
            {
                Image result = db.ImageDB.SingleOrDefault(tempIm => tempIm.Id == i.ImageID);
                imList.Add(result);
            }

            for (int i = 0; i < newList.Count; i++)
            {
                RecipeWhole x = new RecipeWhole
                {
                    CombRecipe = newList[i],
                    CombImage = imList[i]
                };
                wholeRec.Add(x);
            }

            ViewBag.Total = totalPages;
            ViewBag.ThisPage = id;
            return View(wholeRec);
        }

        [Authorize]
        public ActionResult UserLike(int id = 1)
        {
            List<Recipie> recList = new List<Recipie>();
            List<Recipie> newList = new List<Recipie>();
            List<Like> likeList = new List<Like>();
            string y = User.Identity.GetUserId();
            //Returns a list of likes that the user has chosen.
            likeList = db.LikeDB.Where<Like>(x => x.UserId == y).ToList();

            foreach (Like lk in likeList)
            {
                recList.Add(db.RecipieDB.Where(x => x.Id == lk.RecipeId).Single());
            }
            //this should find the total number of pages, using the decimal to keep decimals until after rounding.
            int totalPages = (int)Math.Ceiling(((decimal)recList.Count) / (decimal)(12));


            //Checks to see if the id is a valid number
            if (id < 1)
            {
                id = 1;
            }

            //Checks to see if the id is within number of archive pages.
            else if (id > totalPages)
            {
                //TODO should add an error page for out of range ids
                id = totalPages;
            }

            //this should return the beginning record of a page.  
            int counter = ((id - 1) * 12);

            if (recList.Count > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            else
            {
                for (int i = 0; i < recList.Count; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            List<Bits_and_Bites.Models.Image> imList = new List<Image>();
            List<RecipeWhole> wholeRec = new List<RecipeWhole>();
            foreach (Recipie i in newList)
            {
                Image result = db.ImageDB.SingleOrDefault(tempIm => tempIm.Id == i.ImageID);
                imList.Add(result);
            }

            for (int i = 0; i < newList.Count; i++)
            {
                RecipeWhole x = new RecipeWhole
                {
                    CombRecipe = newList[i],
                    CombImage = imList[i]
                };
                wholeRec.Add(x);
            }

            ViewBag.Total = totalPages;
            ViewBag.ThisPage = id;
            return View(wholeRec);
        }

        public ActionResult ViewSingleRecipie(int id = -1)
        {
            if (id == - 1 || db.RecipieDB.Where<Recipie>(x => x.Id == id).FirstOrDefault() == null)
            {
                id = db.RecipieDB.FirstOrDefault().Id;
            }
            RecipeWhole rec = new RecipeWhole();
            rec.CombRecipe = db.RecipieDB.Where<Recipie>(x => x.Id == id).Single();
            if (rec.CombRecipe.ImageID != 0)
            {
                rec.CombImage = db.ImageDB.Where<Image>(x => x.Id == rec.CombRecipe.ImageID).Single();
            }
            return View(rec);
        }
    }
}