namespace CYT.Web.DataContext.CytMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using System.Collections.Generic;
    using CYT.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<CYT.Web.DataContext.CytDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\CytMigrations";
        }

        protected override void Seed(CYT.Web.DataContext.CytDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(u => u.UserId,
                    new User
                    {
                        UserId = 1,
                        FirstName = "Viktor",
                        LastName = "Veljanoski",
                        UserRole = UserRole.Regular,
                        ProfileImage = "/Content/Users/1/viktor.jpg",
                        Email = "viktor@gmail.com",
                        Rating = 3,
                        Username = "Viktor",
                        isBlocked = false,
                    },
                    new User
                    {
                        UserId = 2,
                        FirstName = "Martin",
                        LastName = "Bonchanoski",
                        UserRole = UserRole.Regular,
                        ProfileImage = "/Content/Users/2/viktor.jpg",
                        Email = "martin@gmail.com",
                        Rating = 4,
                        Username = "Martin",
                        isBlocked = false,
                    },
                    new User
                    {
                        UserId = 3,
                        FirstName = "Ivan",
                        LastName = "Ginovski",
                        UserRole = UserRole.Regular,
                        ProfileImage = "/Content/Users/3/ivan.png",
                        Email = "ivan.ginovski@yahoo.com",
                        Rating = 5,
                        Username = "Ivan",
                        isBlocked = false,
                    },
                    new User
                    {
                        UserId = 4,
                        FirstName = "Goran",
                        LastName = "Butevski",
                        UserRole = UserRole.Regular,
                        ProfileImage = "/Content/Users/4/userImage.png",
                        Email = "goran@gmail.com",
                        Rating = 3,
                        Username = "Goran",
                        isBlocked = false,
                    },
                    new User
                    {
                        UserId = 5,
                        FirstName = "Eleonora",
                        LastName = "Gigoska",
                        UserRole = UserRole.Regular,
                        ProfileImage = "/Content/Users/5/userImage.png",
                        Email = "eli@gmail.com",
                        Rating = 4,
                        Username = "Eli",
                        isBlocked = false,
                    },
                    new User
                    {
                        UserId = 6,
                        FirstName = "Admin",
                        LastName = "Adminovski",
                        UserRole = UserRole.Administrator,
                        ProfileImage = "/Content/Users/6/userImage.png",
                        Email = "admin@gmail.com",
                        Rating = 4,
                        Username = "Admin",
                        isBlocked = false,
                    }
                );
            context.RecipeCategories.AddOrUpdate(rc => rc.RecipeCategoryId,
                new RecipeCategory
                {
                    RecipeCategoryId = 1,
                    Name = "Appetizer"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 2,
                    Name = "Breakfast"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 3,
                    Name = "Chicken"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 4,
                    Name = "Drinks"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 5,
                    Name = "Barbecue"
                },
                  new RecipeCategory
                {
                    RecipeCategoryId = 6,
                    Name = "Dessert"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 7,
                    Name = "Healthy"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 8,
                    Name = "Main dish"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 9,
                    Name = "Pasta"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 10,
                    Name = "Pork"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 11,
                    Name = "Salad recipes"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 12,
                    Name = "Soups"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 13,
                    Name = "Quick & Easy"
                },
                new RecipeCategory
                {
                    RecipeCategoryId = 14,
                    Name = "Vegetarian"
                }
            );
            context.Recipes.AddOrUpdate(r => r.RecipeId,
                    new Recipe
                    {
                        RecipeId = 1,
                        Name = "Greek Chicken",
                        ShortDescription = "A very good light summer dish. Serve it with sliced tomatoes, feta cheese, and garlic bread.",
                        Description = "In a glass dish, mix the olive oil, garlic, rosemary, thyme, oregano, and lemon juice. Place the chicken pieces in the mixture, cover, and marinate in the refrigerator 8 hours or overnight.Preheat grill for high heat. Lightly oil the grill grate. Place chicken on the grill, and discard the marinade. Cook chicken pieces up to 15 minutes per side, until juices run clear. Smaller pieces will not take as long.",
                        GlutenFree = false,
                        PreparationTime = 480,
                        VideoUrl = "https://www.youtube.com/watch?v=h6OSMbfhIao",
                        Difficulty = RecipeDifficulty.Advanced,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 3,
                        UserId = 1
                    },
                    new Recipe
                    {
                        RecipeId = 2,
                        Name = "Chocolate and Cookie Dough Pretzel Crisps Sandwiches",
                        ShortDescription = "Your favorite cookie dough is sandwiched between Original Pretzel Crisps. Dip in chocolate for a sweet treat.",
                        Description = "Melt chocolate chips on a low setting in microwave-safe bowl until soft, about 15 seconds. Stir; microwave until completely melted, in 10-second intervals. <br/> Place a teaspoon of cookie dough between two Original Pretzel Crisps®. Dip one side of the sandwich into melted chocolate and allow for it to settle/harden before serving.",
                        GlutenFree = false,
                        PreparationTime = 10,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Medium,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 5,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 6,
                        UserId = 2
                    },
                    new Recipe
                    {
                        RecipeId = 3,
                        Name = "Todd's Famous Blueberry Pancakes",
                        ShortDescription = "Well worth the hour wait! Serve them with butter and brown sugar.",
                        Description = "In a large bowl, sift together flour, salt, baking powder and sugar. In a small bowl, beat together egg and milk. Stir milk and egg into flour mixture. Mix in the butter and fold in the blueberries. Set aside for 1 hour. <br/> Heat a lightly oiled griddle or frying pan over medium high heat. Pour or scoop the batter onto the griddle, using approximately 1/4 cup for each pancake. Brown on both sides and serve hot.",
                        GlutenFree = false,
                        PreparationTime = 75,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Easy,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 6,
                        UserId = 3
                    },
                    new Recipe
                    {
                        RecipeId = 4,
                        Name = "Jewel's Watermelon Margaritas",
                        ShortDescription = "These are so amazing and refreshing on hot summer days.",
                        Description = "Bring 1/2 cup sugar, water, and orange zest in a small saucepan to boil, stirring constantly. Simmer until sugar is dissolved, about 3 minutes. Remove simple syrup from heat and allow to cool completely. <br/> Place watermelon in a blender or food processor. Pulse until pureed. <br/> Stir watermelon puree into a large pitcher with simple syrup, tequila, and lime juice. <br/> Place a small amount of salt or sugar into a saucer. Rub edge of margarita glasses with a lime wedge to moisten. Lightly dip the rim of the glass into the saucer to rim the glass; tap off excess salt or sugar. <br/> Fill rimmed glasses with crushed ice; pour margarita mixture into glasses and garnish with lime wedges to serve.",
                        GlutenFree = false,
                        PreparationTime = 45,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Easy,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 4,
                        UserId = 4
                    },
                    new Recipe
                    {
                        RecipeId = 5,
                        Name = "Cheesy Oven Scrambled Eggs",
                        ShortDescription = "Light, fluffy scrambled eggs are perfect for a breakfast or brunch crowd!",
                        Description = "Preheat oven to 350 degrees F (175 degrees C). <br/> Pour melted butter into a glass 9x13-inch baking dish. Tilt dish to coat bottom with butter. <br/> Beat eggs, Cheddar cheese, seasoned salt, hot pepper sauce, and mustard powder together with a whisk in a large bowl. Stream milk into egg mixture while whisking; pour into the baking dish. <br/> Bake in preheated oven for 15 minutes, stir, and continue baking until eggs are set in the middle, 15 to 20 minutes more. Serve immediately.",
                        GlutenFree = false,
                        PreparationTime = 40,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Medium,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 2,
                        UserId = 5
                    },
                    new Recipe
                    {
                        RecipeId = 6,
                        Name = "Pasta Primavera with Smoked Gouda",
                        ShortDescription = "It's a wonderful combination of crunchy and creamy.",
                        Description = "Fill a large pot with lightly salted water and bring to a rolling boil over high heat. Once the water is boiling, stir in the penne, and return to a boil. Cook the pasta uncovered, stirring occasionally, until the pasta has cooked through, but is still firm to the bite, about 11 minutes. Drain well in a colander set in the sink. <br/> Heat the olive oil in a skillet over medium heat. Stir in the zucchini, bell pepper, carrots, mushrooms, and onion; cook and stir until the onion has softened and turned translucent, about 5 minutes. Add the garlic and cook for one minute more. Stir in the tomatoes, chicken broth, parsley, basil, oregano, and red pepper flakes. Bring to a boil, then reduce heat to low and simmer until sauce thickens. Stir in the pasta and cook until heated through, about 2 minutes. Top with Parmesan and Gouda cheeses before serving.",
                        GlutenFree = false,
                        PreparationTime = 50,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Medium,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 9,
                        UserId = 1
                    },
                    new Recipe
                    {
                        RecipeId = 7,
                        Name = "Best Marinara Sauce Yet",
                        ShortDescription = "This is a very easy homemade red sauce. Serve with your favorite pasta.",
                        Description = "In a food processor place Italian tomatoes, tomato paste, chopped parsley, minced garlic, oregano, salt, and pepper. Blend until smooth. <br /> In a large skillet over medium heat saute the finely chopped onion in olive oil for 2 minutes. Add the blended tomato sauce and white wine. <br/> In a large skillet over medium heat saute the finely chopped onion in olive oil for 2 minutes. Add the blended tomato sauce and white wine.",
                        GlutenFree = false,
                        PreparationTime = 45,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Easy,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 9,
                        UserId = 2
                    },
                    new Recipe
                    {
                        RecipeId = 8,
                        Name = "Perfect Summer Fruit Salad",
                        ShortDescription = "The perfect fruit salad for a backyard bbq or any occasion",
                        Description = "Bring orange juice, lemon juice, brown sugar, orange zest, and lemon zest to a boil in a saucepan over medium-high heat. Reduce heat to medium-low, and simmer until slightly thickened, about 5 minutes. Remove from heat, and stir in vanilla extract. Set aside to cool. <br/> Layer the fruit in a large, clear glass bowl in this order: pineapple, strawberries, kiwi fruit, bananas, oranges, grapes, and blueberries. Pour the cooled sauce over the fruit. Cover and refrigerate for 3 to 4 hours before serving.",
                        GlutenFree = false,
                        PreparationTime = 200,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Advanced,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 11,
                        UserId = 3
                    },
                    new Recipe
                    {
                        RecipeId = 9,
                        Name = "Spinach Enchiladas",
                        ShortDescription = "If you like spinach and Mexican food, you'll love these easy vegetarian enchiladas made with ricotta cheese and spinach.",
                        Description = "Preheat the oven to 375 degrees F (190 degrees C). <br /> Melt butter in a saucepan over medium heat. Add garlic and onion; cook for a few minutes until fragrant, but not brown. Stir in spinach, and cook for about 5 more minutes. Remove from the heat, and mix in ricotta cheese, sour cream, and 1 cup of Monterey Jack cheese. <br /> In a skillet over medium heat, warm tortillas one at a time until flexible, about 15 seconds. Spoon about 1/4 cup of the spinach mixture onto the center of each tortilla. Roll up, and place seam side down in a 9x13 inch baking dish. Pour enchilada sauce over the top, and sprinkle with the remaining cup of Monterey Jack. <br /> Bake for 15 to 20 minutes in the preheated oven, until sauce is bubbling and cheese is lightly browned at the edges.",
                        GlutenFree = false,
                        PreparationTime = 40,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Advanced,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 14,
                        UserId = 4
                    },
                    new Recipe
                    {
                        RecipeId = 10,
                        Name = "Guacamole",
                        ShortDescription = "You can make this avocado salad smooth or chunky depending on your tastes",
                        Description = "In a medium bowl, mash together the avocados, lime juice, and salt. Mix in onion, cilantro, tomatoes, and garlic. Stir in cayenne pepper. Refrigerate 1 hour for best flavor, or serve immediately.",
                        GlutenFree = false,
                        PreparationTime = 10,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Easy,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 14,
                        UserId = 5
                    },
                    new Recipe
                    {
                        RecipeId = 11,
                        Name = "Cherry Crisp",
                        ShortDescription = "Crumbled shortbread cookies and toasted pecans top succulent red cherries in this easy-to-make dessert",
                        Description = "In a small bowl, combine sugar and cornstarch. In a large saucepan, sprinkle cornstarch mixture over cherries; stir to combine. Cook and stir over medium heat about 10 minutes or until thickened and bubbly. Cook and stir for 2 minutes more. Meanwhile, in a medium bowl, thoroughly combine crumbled cookies, butter, and nuts. Divide cherry mixture among four dessert dishes. Sprinkle cookie mixture over cherry mixture. If desired, serve with ice cream",
                        GlutenFree = false,
                        PreparationTime = 20,
                        VideoUrl = "",
                        Difficulty = RecipeDifficulty.Easy,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 6,
                        UserId = 1
                    },
                    new Recipe
                    {
                        RecipeId = 12,
                        Name = "Corn and Tomato Pasta",
                        ShortDescription = "Shredded chicken makes this gorgeous pasta hearty enough to serve on its own for dinner",
                        Description = "In a Dutch oven, cook pasta according to package directions. Add corn during the last 7 minutes of cooking pasta. Return to boil and continue cooking. When pasta is cooked and corn is crisp-tender, drain pasta and corn in a colander. (If using fresh ears, it may be easier to remove the ears with tongs, and then drain the pasta.) Rinse pasta and corn with cold water to stop cooking, and drain well again. If using fresh corn, cut the kernels off the cobs. In a large bowl combine pasta, corn, chicken, and tomato. For dressing: In a screw-top jar, combine the olive oil, vinegar, pesto, chicken broth, salt and pepper. Cover and shake well. Pour dressing over pasta mixture; toss gently to coat. Chill, covered, for at least 2 hours or up to 24 hours. Sprinkle with Parmesan cheese and basil before serving",
                        GlutenFree = false,
                        PreparationTime = 25,
                        VideoUrl = "https://www.youtube.com/watch?v=6aw73wS1zs8",
                        Difficulty = RecipeDifficulty.Easy,
                        RecipeStatus = RecipeStatus.Approved,
                        Rating = 3,
                        TimeCreated = DateTime.Now,
                        RecipeCategoryId = 9,
                        UserId = 2
                    }
                );

            context.Ingredients.AddOrUpdate(i => i.IngredientId,
                new Ingredient
                {
                    IngredientId = 1,
                    Name = "olive oil",
                    RecipeId = 1,
                    Quantity = "1/2 cup"
                },
                new Ingredient
                {
                    IngredientId = 2,
                    Name = "3 cloves",
                    Quantity = "3 cloves",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 3,
                    Name = "chopped fresh rosemary",
                    Quantity = "1 tablespoon",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 4,
                    Name = "chopped fresh thyme",
                    Quantity = "1 tablespoon",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 5,
                    Name = "chopped fresh origano",
                    Quantity = "1 tablespoon",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 6,
                    Name = "lemons",
                    Quantity = "2",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 7,
                    Name = "chicken cut into pieces",
                    Quantity = "1",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 8,
                    Name = "chocolate chips",
                    Quantity = "1 cup",
                    RecipeId = 2
                },
                new Ingredient
                {
                    IngredientId = 9,
                    Name = "cookie dough",
                    Quantity = "1 package",
                    RecipeId = 2
                },
                new Ingredient
                {
                    IngredientId = 10,
                    Name = "pretzel crisps",
                    Quantity = "1 package",
                    RecipeId = 2
                },
                new Ingredient
                {
                    IngredientId = 11,
                    Name = "all-purpose flour",
                    Quantity = "1 1/4 cups",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 12,
                    Name = "salt",
                    Quantity = "1/2 teaspoon",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 13,
                    Name = "chopped fresh rosemary",
                    Quantity = "1 tablespoon",
                    RecipeId = 1
                },
                new Ingredient
                {
                    IngredientId = 14,
                    Name = "baking powder",
                    Quantity = "1 tablespoon",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 15,
                    Name = "white sugar",
                    Quantity = "1 1/4 teaspoons",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 16,
                    Name = "egg",
                    Quantity = "1",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 17,
                    Name = "milk",
                    Quantity = "1 cup",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 18,
                    Name = "butter, melted",
                    Quantity = "1/2 tablespoon",
                    RecipeId = 3
                },
                new Ingredient
                {
                    IngredientId = 19,
                    Name = "frozen blueberries",
                    Quantity = "1/2 cup",
                    RecipeId = 3
                }, new Ingredient
                {
                    IngredientId = 20,
                    Name = "white sugar",
                    Quantity = "1/2 cup",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 21,
                    Name = "water",
                    Quantity = "1/2 cup",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 22,
                    Name = "orange zest",
                    Quantity = "3 strips",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 23,
                    Name = "cubed seeded watermelon",
                    Quantity = "2 cups",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 24,
                    Name = "white tequila",
                    Quantity = "3/4 cup",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 25,
                    Name = "lime juice",
                    Quantity = "1/4 cup",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 26,
                    Name = "salt or sugar for rimming glasses (optional)",
                    Quantity = "",
                    RecipeId = 4
                },
                new Ingredient
                {
                    IngredientId = 27,
                    Name = "lime",
                    Quantity = "1",
                    RecipeId = 4
                }
                ,
                new Ingredient
                {
                    IngredientId = 28,
                    Name = "crushed ice",
                    Quantity = "2 cups",
                    RecipeId = 4
                }
                ,
                new Ingredient
                {
                    IngredientId = 29,
                    Name = "butter, melted",
                    Quantity = "1/3 cup",
                    RecipeId = 5
                }
                ,
                new Ingredient
                {
                    IngredientId = 30,
                    Name = "eggs",
                    Quantity = "24",
                    RecipeId = 5
                }
                ,
                new Ingredient
                {
                    IngredientId = 31,
                    Name = "shreeded Cheddar cheese",
                    Quantity = "1 1/2 cups",
                    RecipeId = 5
                }
                ,
                new Ingredient
                {
                    IngredientId = 32,
                    Name = "seasoned salt",
                    Quantity = "2 1/4 teaspoons",
                    RecipeId = 5
                }
                ,
                new Ingredient
                {
                    IngredientId = 33,
                    Name = "hot pepper sauce",
                    Quantity = "2 teaspoons",
                    RecipeId = 5
                }
                ,
                new Ingredient
                {
                    IngredientId = 34,
                    Name = "mustard powder",
                    Quantity = "2 teaspoons",
                    RecipeId = 5
                },
                new Ingredient
                {
                    IngredientId = 35,
                    Name = "milk",
                    Quantity = "2 cups",
                    RecipeId = 5
                }
                ,
                new Ingredient
                {
                    IngredientId = 36,
                    Name = "whole wheat penne pasta",
                    Quantity = "1 package",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 37,
                    Name = "olive oil",
                    Quantity = "2 tablespoons",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 38,
                    Name = "green bell pepper",
                    Quantity = "1",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 39,
                    Name = "carrots",
                    Quantity = "2",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 40,
                    Name = "mushrooms",
                    Quantity = "1 package",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 41,
                    Name = "onions",
                    Quantity = "3",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 42,
                    Name = "stewed tomatoes",
                    Quantity = "1 can",
                    RecipeId = 6
                }
                ,
                new Ingredient
                {
                    IngredientId = 43,
                    Name = "low-sodium chicken broth",
                    Quantity = "1 cup",
                    RecipeId = 6
                },
                new Ingredient
                {
                    IngredientId = 44,
                    Name = "fresh parsley",
                    Quantity = "2 tablespoons",
                    RecipeId = 6
                },
                new Ingredient
                {
                    IngredientId = 45,
                    Name = "Parmesan cheese",
                    Quantity = "2 tablespoons",
                    RecipeId = 6
                },
                new Ingredient
                {
                    IngredientId = 46,
                    Name = "smoked Gouda cheese",
                    Quantity = "2/3 cup",
                    RecipeId = 6
                },
                new Ingredient
                {
                    IngredientId = 47,
                    Name = "stewed tomatoes",
                    Quantity = "2 cans",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 48,
                    Name = "tomato paste",
                    Quantity = "1 can",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 49,
                    Name = "chopped fresh parsley",
                    Quantity = "4 tablespoons",
                    RecipeId = 7
                }
                ,
                new Ingredient
                {
                    IngredientId = 50,
                    Name = "clove garlic",
                    Quantity = "1",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 51,
                    Name = "dried origano",
                    Quantity = "1 teaspoon",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 52,
                    Name = "salt",
                    Quantity = "1 teaspoon",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 53,
                    Name = "black pepper",
                    Quantity = "1/4 teaspoon",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 54,
                    Name = "olive oil",
                    Quantity = "6 tablespoons",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 55,
                    Name = "diced onion",
                    Quantity = "1/3 cup",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 56,
                    Name = "white wine",
                    Quantity = "1/2 cup",
                    RecipeId = 7
                },
                new Ingredient
                {
                    IngredientId = 57,
                    Name = "orange juice",
                    Quantity = "1 teaspoon",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 58,
                    Name = "lemon juice",
                    Quantity = "1/3 cup",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 59,
                    Name = "brown sugar",
                    Quantity = "1/3 cup",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 60,
                    Name = "orange zest",
                    Quantity = "1/2 teaspoon",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 61,
                    Name = "lemo zest",
                    Quantity = "1/2 teaspoon",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 62,
                    Name = "vanilla extract",
                    Quantity = "1 teaspoon",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 63,
                    Name = "cubed fresh pineapple",
                    Quantity = "2 cups",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 64,
                    Name = "straweberries",
                    Quantity = "2 cups",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 65,
                    Name = "kiwi fruit",
                    Quantity = "3",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 66,
                    Name = "bananas",
                    Quantity = "3",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 67,
                    Name = "oranges",
                    Quantity = "2",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 68,
                    Name = "seedless grapes",
                    Quantity = "1 cup",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 69,
                    Name = "blueberries",
                    Quantity = "2 cups",
                    RecipeId = 8
                },
                new Ingredient
                {
                    IngredientId = 70,
                    Name = "butter",
                    Quantity = "1 tablespoon",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 71,
                    Name = "sliced green onions",
                    Quantity = "1/2 cup",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 72,
                    Name = "cloves garlic",
                    Quantity = "2",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 73,
                    Name = "frozen chopped spinach",
                    Quantity = "1 package",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 74,
                    Name = "rciotta cheese",
                    Quantity = "1 cup",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 75,
                    Name = "sour cream",
                    Quantity = "1/2 cup",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 76,
                    Name = "shredded Monterey Jack cheese",
                    Quantity = "2 cups",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 77,
                    Name = "corn tortillas",
                    Quantity = "10",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 78,
                    Name = "enchillada sauce",
                    Quantity = "1 can",
                    RecipeId = 9
                },
                new Ingredient
                {
                    IngredientId = 79,
                    Name = "avocado",
                    Quantity = "avocado",
                    RecipeId = 10
                },
                new Ingredient
                {
                    IngredientId = 80,
                    Name = "avocado",
                    Quantity = "1",
                    RecipeId = 10
                },
                new Ingredient
                {
                    IngredientId = 81,
                    Name = "salt",
                    Quantity = "1 teaspoon",
                    RecipeId = 10
                },
                new Ingredient
                {
                    IngredientId = 82,
                    Name = "diced onion",
                    Quantity = "1/2 cup",
                    RecipeId = 10
                },
                new Ingredient
                {
                    IngredientId = 83,
                    Name = "chopped fresh cilantro",
                    Quantity = "3 tablespoons",
                    RecipeId = 10
                }
                ,
                new Ingredient
                {
                    IngredientId = 84,
                    Name = "tomatoes",
                    Quantity = "2",
                    RecipeId = 10
                }
                ,
                new Ingredient
                {
                    IngredientId = 85,
                    Name = "minced garlic",
                    Quantity = "1 teaspoon",
                    RecipeId = 10
                }
                ,
                new Ingredient
                {
                    IngredientId = 86,
                    Name = "ground cayenne pepper",
                    Quantity =  "1 pinch",
                    RecipeId = 10
                },
                new Ingredient
                {
                    IngredientId = 87,
                    Name = "cup sugar",
                    Quantity = "1/3-1/2",
                    RecipeId = 11
                },
                new Ingredient
                {
                    IngredientId = 88,
                    Name = "tablespoon cornstarch",
                    Quantity = "1",
                    RecipeId = 11
                },
                new Ingredient
                {
                    IngredientId = 89,
                    Name = "cups frozen unsweetened pitted tart red cherries",
                    Quantity = "4",
                    RecipeId = 11
                },
                new Ingredient
                {
                    IngredientId = 90,
                    Name = "cup crumbled shortbread cookies",
                    Quantity = "1",
                    RecipeId = 11
                },
                new Ingredient
                {
                    IngredientId = 91,
                    Name = "tablespoons butter or margarine, melted",
                    Quantity = "2",
                    RecipeId = 11
                },
                new Ingredient
                {
                    IngredientId = 92,
                    Name = "Ice cream (optional)",
                    Quantity = "2",
                    RecipeId = 11
                },
                new Ingredient
                {
                    IngredientId = 93,
                    Name = "cups dried bow-tie pasta",
                    Quantity = "1",
                    RecipeId = 12
                },
                new Ingredient
                {
                    IngredientId = 94,
                    Name = "fresh ears of corn",
                    Quantity = "2",
                    RecipeId = 12
                }, new Ingredient
                {
                    IngredientId = 95,
                    Name = "cup shredded, cooked chicken",
                    Quantity = "1",
                    RecipeId = 12
                },
                new Ingredient
                {
                    IngredientId = 96,
                    Name = "large tomato, seeded and chopped",
                    Quantity = "1",
                    RecipeId = 12
                },
                new Ingredient
                {
                    IngredientId = 97,
                    Name = "cup olive oil",
                    Quantity = "1/4",
                    RecipeId = 12
                },
                new Ingredient
                {
                    IngredientId = 98,
                    Name = "tablespoons salt",
                    Quantity = "1/4",
                    RecipeId = 12
                },
                new Ingredient
                {
                    IngredientId = 99,
                    Name = "tablespoons vinegar",
                    Quantity = "3",
                    RecipeId = 12
                }

                );
            context.RecipeImages.AddOrUpdate(ri => ri.RecipeImageId,
                new RecipeImage
                {
                    RecipeImageId = 1,
                    ImageUrl = "/Content/Users/1/Recipes/1/1.1.jpg",
                    Description = "Greek Chicken",
                    RecipeId = 1,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 2,
                    ImageUrl = "/Content/Users/1/Recipes/1/1.2.jpg",
                    Description = "Greek Chicken",
                    RecipeId = 1,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 3,
                    ImageUrl = "/Content/Users/1/Recipes/1/1.3.jpg",
                    Description = "Greek Chicken",
                    RecipeId = 1,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 4,
                    ImageUrl = "/Content/Users/1/Recipes/1/1.4.jpg",
                    Description = "Greek Chicken",
                    RecipeId = 1,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 5,
                    ImageUrl = "/Content/Users/1/Recipes/2/6.1.jpg",
                    Description = "Pasta Primavera with Smoked Gouda",
                    RecipeId = 6,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 6,
                    ImageUrl = "/Content/Users/1/Recipes/2/6.2.jpg",
                    Description = "Pasta Primavera with Smoked Gouda",
                    RecipeId = 6,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 7,
                    ImageUrl = "/Content/Users/1/Recipes/2/6.3.jpg",
                    Description = "Pasta Primavera with Smoked Gouda",
                    RecipeId = 6,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 8,
                    ImageUrl = "/Content/Users/1/Recipes/2/6.4.jpg",
                    Description = "Pasta Primavera with Smoked Gouda",
                    RecipeId = 6,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 9,
                    ImageUrl = "/Content/Users/2/Recipes/1/2.1.jpg",
                    Description = "Chocolate and Cookie Dough Pretzel Crisps Sandwiches",
                    RecipeId = 2,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 10,
                    ImageUrl = "/Content/Users/2/Recipes/1/2.2.jpg",
                    Description = "Chocolate and Cookie Dough Pretzel Crisps Sandwiches",
                    RecipeId = 2,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 11,
                    ImageUrl = "/Content/Users/2/Recipes/1/2.3.jpg",
                    Description = "Chocolate and Cookie Dough Pretzel Crisps Sandwiches",
                    RecipeId = 2,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 12,
                    ImageUrl = "/Content/Users/2/Recipes/2/7.1.jpg",
                    Description = "Best Marinara Sauce Yet",
                    RecipeId = 7,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 13,
                    ImageUrl = "/Content/Users/2/Recipes/2/7.2.jpg",
                    Description = "Best Marinara Sauce Yet",
                    RecipeId = 7,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 14,
                    ImageUrl = "/Content/Users/2/Recipes/1/7.3.jpg",
                    Description = "Best Marinara Sauce Yet",
                    RecipeId = 7,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 15,
                    ImageUrl = "/Content/Users/2/Recipes/2/7.4.jpg",
                    Description = "Best Marinara Sauce Yet",
                    RecipeId = 7,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 16,
                    ImageUrl = "/Content/Users/3/Recipes/1/3.1.jpg",
                    Description = "Todd's Famous Blueberry Pancakes",
                    RecipeId = 3,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 17,
                    ImageUrl = "/Content/Users/3/Recipes/1/3.2.jpg",
                    Description = "Todd's Famous Blueberry Pancakes",
                    RecipeId = 3,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 18,
                    ImageUrl = "/Content/Users/3/Recipes/1/3.3.jpg",
                    Description = "Todd's Famous Blueberry Pancakes",
                    RecipeId = 3,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 19,
                    ImageUrl = "/Content/Users/3/Recipes/1/3.4.jpg",
                    Description = "Todd's Famous Blueberry Pancakes",
                    RecipeId = 3,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 20,
                    ImageUrl = "/Content/Users/3/Recipes/2/8.1.jpg",
                    Description = "Perfect Summer Fruit Salad",
                    RecipeId = 8,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 21,
                    ImageUrl = "/Content/Users/3/Recipes/2/8.2.jpg",
                    Description = "Perfect Summer Fruit Salad",
                    RecipeId = 8,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 22,
                    ImageUrl = "/Content/Users/3/Recipes/2/8.3.jpg",
                    Description = "Perfect Summer Fruit Salad",
                    RecipeId = 8,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 23,
                    ImageUrl = "/Content/Users/3/Recipes/2/8.4.jpg",
                    Description = "Perfect Summer Fruit Salad",
                    RecipeId = 8,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 24,
                    ImageUrl = "/Content/Users/4/Recipes/1/4.1.jpg",
                    Description = "Jewel's Watermelon Margaritas",
                    RecipeId = 4,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 25,
                    ImageUrl = "/Content/Users/4/Recipes/1/4.2.jpg",
                    Description = "Jewel's Watermelon Margaritas",
                    RecipeId = 4,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 26,
                    ImageUrl = "/Content/Users/4/Recipes/1/4.3.jpg",
                    Description = "Jewel's Watermelon Margaritas",
                    RecipeId = 4,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 27,
                    ImageUrl = "/Content/Users/4/Recipes/1/4.4.jpg",
                    Description = "Jewel's Watermelon Margaritas",
                    RecipeId = 4,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 28,
                    ImageUrl = "/Content/Users/4/Recipes/2/9.1.jpg",
                    Description = "Spinach Enchiladas",
                    RecipeId = 9,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 29,
                    ImageUrl = "/Content/Users/4/Recipes/2/9.2.jpg",
                    Description = "Spinach Enchiladas",
                    RecipeId = 9,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 30,
                    ImageUrl = "/Content/Users/4/Recipes/2/9.3.jpg",
                    Description = "Spinach Enchiladas",
                    RecipeId = 9,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 31,
                    ImageUrl = "/Content/Users/4/Recipes/2/9.4.jpg",
                    Description = "Spinach Enchiladas",
                    RecipeId = 9,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 32,
                    ImageUrl = "/Content/Users/5/Recipes/1/5.1.jpg",
                    Description = "Cheesy Oven Scrambled Eggs",
                    RecipeId = 5,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 33,
                    ImageUrl = "/Content/Users/5/Recipes/1/5.2.jpg",
                    Description = "Cheesy Oven Scrambled Eggs",
                    RecipeId = 5,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 34,
                    ImageUrl = "/Content/Users/5/Recipes/2/10.1.jpg",
                    Description = "Guacamole",
                    RecipeId = 10,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 35,
                    ImageUrl = "/Content/Users/5/Recipes/2/10.2.jpg",
                    Description = "Guacamole",
                    RecipeId = 10,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 36,
                    ImageUrl = "/Content/Users/5/Recipes/2/10.3.jpg",
                    Description = "Guacamole",
                    RecipeId = 10,
                    TimeCreated = DateTime.Now
                }
                ,
                new RecipeImage
                {
                    RecipeImageId = 37,
                    ImageUrl = "/Content/Users/5/Recipes/2/10.4.jpg",
                    Description = "Guacamole",
                    RecipeId = 10,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 38,
                    ImageUrl = "/Content/Users/1/Recipes/3/1.jpg",
                    Description = "Cherry crisp",
                    RecipeId = 11,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 39,
                    ImageUrl = "/Content/Users/1/Recipes/3/2.jpg",
                    Description = "Cherry crisp",
                    RecipeId = 11,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 40,
                    ImageUrl = "/Content/Users/2/Recipes/3/3.jpg",
                    Description = "Cherry crisp",
                    RecipeId = 12,
                    TimeCreated = DateTime.Now
                },
                new RecipeImage
                {
                    RecipeImageId = 41,
                    ImageUrl = "/Content/Users/2/Recipes/3/4.jpg",
                    Description = "Cherry crisp",
                    RecipeId = 12,
                    TimeCreated = DateTime.Now
                }
            );
            context.RecipeVotes.AddOrUpdate(rv => rv.RecipeVoteId,
                new RecipeVote
                {
                    RecipeVoteId = 1,
                    RecipeId = 5,
                    UserId = 2,
                    VoteValue = VoteValue.Five
                },
                new RecipeVote
                {
                    RecipeVoteId = 2,
                    RecipeId = 6,
                    UserId = 3,
                    VoteValue = VoteValue.Four
                }
            );
            context.SaveChanges();
        }
    }
}
