using Cyberquiz.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberquiz.DAL.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Questions.AnyAsync())
                return;

            // SVARSALTERNATIV — globalt bibliotek, återanvänds fritt mellan frågor

            // Städer & länder
            var aParis          = new AnswerOptionModel { Answer = "Paris" };
            var aLondon         = new AnswerOptionModel { Answer = "London" };
            var aBerlin         = new AnswerOptionModel { Answer = "Berlin" };
            var aMadrid         = new AnswerOptionModel { Answer = "Madrid" };
            var aRom            = new AnswerOptionModel { Answer = "Rom" };
            var aStockholm      = new AnswerOptionModel { Answer = "Stockholm" };
            var aGoteborg       = new AnswerOptionModel { Answer = "Göteborg" };
            var aMalmo          = new AnswerOptionModel { Answer = "Malmö" };
            var aUppsala        = new AnswerOptionModel { Answer = "Uppsala" };
            var aRyssland       = new AnswerOptionModel { Answer = "Ryssland" };      // ✓ störst land + flest invånare Europa
            var aTyskland       = new AnswerOptionModel { Answer = "Tyskland" };      // ✗ återanvänds i flera frågor
            var aFrankrike      = new AnswerOptionModel { Answer = "Frankrike" };
            var aItalien        = new AnswerOptionModel { Answer = "Italien" };       // ✓ antika Rom, ✗ VM-guld, ✗ invånare
            var aGrekland       = new AnswerOptionModel { Answer = "Grekland" };
            var aSpanien        = new AnswerOptionModel { Answer = "Spanien" };
            var aTurkiet        = new AnswerOptionModel { Answer = "Turkiet" };
            var aKanada         = new AnswerOptionModel { Answer = "Kanada" };
            var aUSA            = new AnswerOptionModel { Answer = "USA" };
            var aKina           = new AnswerOptionModel { Answer = "Kina" };          // ✗ återanvänds i geografi + mat
            var aJapan          = new AnswerOptionModel { Answer = "Japan" };         // ✓ sushi + Spirited Away
            var aBrasilien      = new AnswerOptionModel { Answer = "Brasilien" };     // ✓ VM-guld fotboll + kaffe
            var aArgentina      = new AnswerOptionModel { Answer = "Argentina" };
            var aSydkorea       = new AnswerOptionModel { Answer = "Sydkorea" };      // ✗ återanvänds i mat + film
            var aVietnam        = new AnswerOptionModel { Answer = "Vietnam" };       // ✗ återanvänds i mat + geografi
            var aKolombia       = new AnswerOptionModel { Answer = "Colombia" };
            var aEtiopien       = new AnswerOptionModel { Answer = "Etiopien" };
            var aAthen          = new AnswerOptionModel { Answer = "Aten" };

            // Floder
            var aNilen          = new AnswerOptionModel { Answer = "Nilen" };
            var aAmazonas       = new AnswerOptionModel { Answer = "Amazonas" };
            var aYangtze        = new AnswerOptionModel { Answer = "Yangtze" };
            var aMississippi    = new AnswerOptionModel { Answer = "Mississippi" };

            // Siffror — återanvänds brett över kategorier
            var a2  = new AnswerOptionModel { Answer = "2" };
            var a3  = new AnswerOptionModel { Answer = "3" };
            var a4  = new AnswerOptionModel { Answer = "4" };   // ✗ gitarr, insekt, ✓ OS-intervall
            var a5  = new AnswerOptionModel { Answer = "5" };
            var a6  = new AnswerOptionModel { Answer = "6" };   // ✓ gitarrsträngar + hexagon + insektben
            var a7  = new AnswerOptionModel { Answer = "7" };
            var a8  = new AnswerOptionModel { Answer = "8" };   // ✗ gitarr, insekt, hexagon
            var a9  = new AnswerOptionModel { Answer = "9" };
            var a10 = new AnswerOptionModel { Answer = "10" };
            var a11 = new AnswerOptionModel { Answer = "11" };  // ✓ fotbollsspelare, ✗ kvadratrot 144
            var a12 = new AnswerOptionModel { Answer = "12" };  // ✓ kvadratrot 144, ✗ fotboll
            var a13 = new AnswerOptionModel { Answer = "13" };
            var a14 = new AnswerOptionModel { Answer = "14" };
            var a45  = new AnswerOptionModel { Answer = "45" };
            var a60  = new AnswerOptionModel { Answer = "60" };
            var a90  = new AnswerOptionModel { Answer = "90" };
            var a180 = new AnswerOptionModel { Answer = "180" };

            // Årtal
            var a395  = new AnswerOptionModel { Answer = "395" };
            var a410  = new AnswerOptionModel { Answer = "410" };
            var a476  = new AnswerOptionModel { Answer = "476" };
            var a500  = new AnswerOptionModel { Answer = "500" };
            var a1943 = new AnswerOptionModel { Answer = "1943" };
            var a1944 = new AnswerOptionModel { Answer = "1944" };
            var a1945 = new AnswerOptionModel { Answer = "1945" };
            var a1946 = new AnswerOptionModel { Answer = "1946" };
            var a1969 = new AnswerOptionModel { Answer = "1969" };
            var a1970 = new AnswerOptionModel { Answer = "1970" };
            var a1972 = new AnswerOptionModel { Answer = "1972" };
            var a1975 = new AnswerOptionModel { Answer = "1975" };
            var a1995 = new AnswerOptionModel { Answer = "1995" };
            var a1997 = new AnswerOptionModel { Answer = "1997" };
            var a1998 = new AnswerOptionModel { Answer = "1998" };
            var a1999 = new AnswerOptionModel { Answer = "1999" };
            var a2000 = new AnswerOptionModel { Answer = "2000" };
            var a2001 = new AnswerOptionModel { Answer = "2001" };

            // Svenska regenter
            var aKarlXII       = new AnswerOptionModel { Answer = "Karl XII" };
            var aGustavIIAdolf = new AnswerOptionModel { Answer = "Gustav II Adolf" };
            var aKarlXI        = new AnswerOptionModel { Answer = "Karl XI" };
            var aGustavIII     = new AnswerOptionModel { Answer = "Gustav III" };

            // Kemi
            var aH2O  = new AnswerOptionModel { Answer = "H₂O" };
            var aCO2  = new AnswerOptionModel { Answer = "CO₂" };
            var aNaCl = new AnswerOptionModel { Answer = "NaCl" };
            var aO2   = new AnswerOptionModel { Answer = "O₂" };

            // Grundämnen
            var aVate   = new AnswerOptionModel { Answer = "Väte" };
            var aHelium = new AnswerOptionModel { Answer = "Helium" };
            var aSyre   = new AnswerOptionModel { Answer = "Syre" };
            var aKol    = new AnswerOptionModel { Answer = "Kol" };

            // Hastigheter
            var a300000 = new AnswerOptionModel { Answer = "300 000 km/s" };
            var a150000 = new AnswerOptionModel { Answer = "150 000 km/s" };
            var a500000 = new AnswerOptionModel { Answer = "500 000 km/s" };
            var a100000 = new AnswerOptionModel { Answer = "100 000 km/s" };

            // Vetenskapsmän — återanvänds i fysikfrågor
            var aNewton   = new AnswerOptionModel { Answer = "Newton" };
            var aEinstein = new AnswerOptionModel { Answer = "Einstein" };
            var aGalileo  = new AnswerOptionModel { Answer = "Galileo" };
            var aHawking  = new AnswerOptionModel { Answer = "Hawking" };

            // Kompositörer
            var aBeethoven = new AnswerOptionModel { Answer = "Beethoven" };
            var aMozart    = new AnswerOptionModel { Answer = "Mozart" };
            var aBach      = new AnswerOptionModel { Answer = "Bach" };
            var aChopin    = new AnswerOptionModel { Answer = "Chopin" };

            // Band
            var aQueen         = new AnswerOptionModel { Answer = "Queen" };
            var aBeatles       = new AnswerOptionModel { Answer = "The Beatles" };
            var aLedZeppelin   = new AnswerOptionModel { Answer = "Led Zeppelin" };
            var aRollingStones = new AnswerOptionModel { Answer = "Rolling Stones" };

            // Skådespelare
            var aRDJ            = new AnswerOptionModel { Answer = "Robert Downey Jr." };
            var aChrisEvans     = new AnswerOptionModel { Answer = "Chris Evans" };
            var aChrisHemsworth = new AnswerOptionModel { Answer = "Chris Hemsworth" };
            var aMarkRuffalo    = new AnswerOptionModel { Answer = "Mark Ruffalo" };

            // Animationsstudios
            var aDisney     = new AnswerOptionModel { Answer = "Disney" };
            var aPixar      = new AnswerOptionModel { Answer = "Pixar" };
            var aDreamWorks = new AnswerOptionModel { Answer = "DreamWorks" };
            var aWarnerBros = new AnswerOptionModel { Answer = "Warner Bros" };

            // Förkortningar (teknik)
            var aCpuCorrect = new AnswerOptionModel { Answer = "Central Processing Unit" };
            var aCpuWrong1  = new AnswerOptionModel { Answer = "Computer Power Unit" };
            var aCpuWrong2  = new AnswerOptionModel { Answer = "Central Program Unit" };
            var aCpuWrong3  = new AnswerOptionModel { Answer = "Core Processing Unit" };
            var aWwwCorrect = new AnswerOptionModel { Answer = "World Wide Web" };
            var aWwwWrong1  = new AnswerOptionModel { Answer = "World Wire Web" };
            var aWwwWrong2  = new AnswerOptionModel { Answer = "Wide World Web" };
            var aWwwWrong3  = new AnswerOptionModel { Answer = "Web World Wide" };

            // Teknikföretag — återanvänds i Windows + Google-frågor
            var aMicrosoft = new AnswerOptionModel { Answer = "Microsoft" };
            var aApple     = new AnswerOptionModel { Answer = "Apple" };
            var aGoogle    = new AnswerOptionModel { Answer = "Google" };
            var aIBM       = new AnswerOptionModel { Answer = "IBM" };

            // Pi
            var aPi314 = new AnswerOptionModel { Answer = "3,14" };
            var aPi312 = new AnswerOptionModel { Answer = "3,12" };
            var aPi316 = new AnswerOptionModel { Answer = "3,16" };
            var aPi318 = new AnswerOptionModel { Answer = "3,18" };

            // Djur
            var aElefant   = new AnswerOptionModel { Answer = "Afrikansk elefant" };
            var aNoshorn   = new AnswerOptionModel { Answer = "Noshörning" };
            var aFlodhaest = new AnswerOptionModel { Answer = "Flodhäst" };
            var aGiraff    = new AnswerOptionModel { Answer = "Giraff" };

            // Träd
            var aEk    = new AnswerOptionModel { Answer = "Ek" };
            var aBjork = new AnswerOptionModel { Answer = "Björk" };
            var aGran  = new AnswerOptionModel { Answer = "Gran" };
            var aTall  = new AnswerOptionModel { Answer = "Tall" };

            // Biologiska processer
            var aFotosyntes  = new AnswerOptionModel { Answer = "Fotosyntes" };
            var aMetabolism  = new AnswerOptionModel { Answer = "Metabolism" };
            var aOsmos       = new AnswerOptionModel { Answer = "Osmos" };
            var aRespiration = new AnswerOptionModel { Answer = "Respiration" };

            // Mat & dryck
            var aAvokado = new AnswerOptionModel { Answer = "Avokado" };
            var aTomat   = new AnswerOptionModel { Answer = "Tomat" };
            var aLok     = new AnswerOptionModel { Answer = "Lök" };
            var aLime    = new AnswerOptionModel { Answer = "Lime" };
            var aDruvor  = new AnswerOptionModel { Answer = "Druvor" };
            var aApplen  = new AnswerOptionModel { Answer = "Äpplen" };
            var aParon   = new AnswerOptionModel { Answer = "Päron" };
            var aPlommon = new AnswerOptionModel { Answer = "Plommon" };

            // Skandinaviska städer
            var aOslo        = new AnswerOptionModel { Answer = "Oslo" };
            var aKopenhagen  = new AnswerOptionModel { Answer = "Köpenhamn" };
            var aHelsinki    = new AnswerOptionModel { Answer = "Helsingfors" };
            var aNorge       = new AnswerOptionModel { Answer = "Norge" };
            var aDanmark     = new AnswerOptionModel { Answer = "Danmark" };
            var aFinland     = new AnswerOptionModel { Answer = "Finland" };
            var aSverige     = new AnswerOptionModel { Answer = "Sverige" };

            // Medeltiden — årtal
            var a1066 = new AnswerOptionModel { Answer = "1066" };
            var a1215 = new AnswerOptionModel { Answer = "1215" };
            var a1348 = new AnswerOptionModel { Answer = "1348" };
            var a1389 = new AnswerOptionModel { Answer = "1389" };
            var a1453 = new AnswerOptionModel { Answer = "1453" };
            var a1492 = new AnswerOptionModel { Answer = "1492" };
            var a1500 = new AnswerOptionModel { Answer = "1500" };

            // Biologi
            var a1   = new AnswerOptionModel { Answer = "1" };
            var a22  = new AnswerOptionModel { Answer = "22" };
            var a23  = new AnswerOptionModel { Answer = "23" };
            var a24  = new AnswerOptionModel { Answer = "24" };
            var a46  = new AnswerOptionModel { Answer = "46" };
            var aCellen    = new AnswerOptionModel { Answer = "Cellen" };
            var aAtomen    = new AnswerOptionModel { Answer = "Atomen" };
            var aMolekylen = new AnswerOptionModel { Answer = "Molekylen" };
            var aVavnaden  = new AnswerOptionModel { Answer = "Vävnaden" };

            // Tennis
            var aLove           = new AnswerOptionModel { Answer = "Love" };
            var aZero           = new AnswerOptionModel { Answer = "Zero" };
            var aNil            = new AnswerOptionModel { Answer = "Nil" };
            var aNoll           = new AnswerOptionModel { Answer = "Noll" };
            var aRolandGarros   = new AnswerOptionModel { Answer = "Roland Garros" };
            var aWimbledon      = new AnswerOptionModel { Answer = "Wimbledon" };
            var aUSOpen         = new AnswerOptionModel { Answer = "US Open" };
            var aAustralianOpen = new AnswerOptionModel { Answer = "Australian Open" };

            // Jazz — instrument
            var aTrumpet  = new AnswerOptionModel { Answer = "Trumpet" };
            var aSaxofon  = new AnswerOptionModel { Answer = "Saxofon" };
            var aPiano    = new AnswerOptionModel { Answer = "Piano" };
            var aKlarinet = new AnswerOptionModel { Answer = "Klarinett" };

            // Serier & TV
            var aHBO          = new AnswerOptionModel { Answer = "HBO" };
            var aNetflix      = new AnswerOptionModel { Answer = "Netflix" };
            var aAmazonPrime  = new AnswerOptionModel { Answer = "Amazon Prime" };
            var aHulu         = new AnswerOptionModel { Answer = "Hulu" };

            // Hav & Oceaner
            var aStillahavet     = new AnswerOptionModel { Answer = "Stilla havet" };
            var aAtlanten        = new AnswerOptionModel { Answer = "Atlanten" };
            var aIndiskaOceanen  = new AnswerOptionModel { Answer = "Indiska oceanen" };
            var aArktiskaOceanen = new AnswerOptionModel { Answer = "Arktiska oceanen" };
            var a71pct = new AnswerOptionModel { Answer = "71%" };
            var a50pct = new AnswerOptionModel { Answer = "50%" };
            var a60pct = new AnswerOptionModel { Answer = "60%" };
            var a80pct = new AnswerOptionModel { Answer = "80%" };

            // Mobil & Appar
            var aSamsung = new AnswerOptionModel { Answer = "Samsung" };
            var a2005 = new AnswerOptionModel { Answer = "2005" };
            var a2007 = new AnswerOptionModel { Answer = "2007" };
            var a2008 = new AnswerOptionModel { Answer = "2008" };
            var a2010 = new AnswerOptionModel { Answer = "2010" };

            // Bakning
            var aMjol      = new AnswerOptionModel { Answer = "Mjöl" };
            var aSocker    = new AnswerOptionModel { Answer = "Socker" };
            var aSalt      = new AnswerOptionModel { Answer = "Salt" };
            var aJast      = new AnswerOptionModel { Answer = "Jäst" };
            var aBakpulver = new AnswerOptionModel { Answer = "Bakpulver" };
            var aMaizena   = new AnswerOptionModel { Answer = "Majsstärkelse" };
            var aVanilj    = new AnswerOptionModel { Answer = "Vaniljsocker" };


            // KATEGORIER & SUBKATEGORIER

            var catGeografi  = new CategoryModel { Name = "Geografi" };
            var catHistoria  = new CategoryModel { Name = "Historia" };
            var catVetenskap = new CategoryModel { Name = "Vetenskap" };
            var catSport     = new CategoryModel { Name = "Sport" };
            var catMusik     = new CategoryModel { Name = "Musik" };
            var catFilmTV    = new CategoryModel { Name = "Film & TV" };
            var catMatematik = new CategoryModel { Name = "Matematik" };
            var catNatur     = new CategoryModel { Name = "Natur" };
            var catTeknik    = new CategoryModel { Name = "Teknik" };
            var catMatDryck  = new CategoryModel { Name = "Mat & Dryck" };

            var subEuropa         = new SubCategoryModel { Name = "Europa" };
            var subVarlden        = new SubCategoryModel { Name = "Världen" };
            var subAntiken        = new SubCategoryModel { Name = "Antiken" };
            var subModernHistoria = new SubCategoryModel { Name = "Modern Historia" };
            var subKemi           = new SubCategoryModel { Name = "Kemi" };
            var subFysik          = new SubCategoryModel { Name = "Fysik" };
            var subFotboll        = new SubCategoryModel { Name = "Fotboll" };
            var subOS             = new SubCategoryModel { Name = "Olympiska Spelen" };
            var subKlassisk       = new SubCategoryModel { Name = "Klassisk Musik" };
            var subPopRock        = new SubCategoryModel { Name = "Pop & Rock" };
            var subHollywood      = new SubCategoryModel { Name = "Hollywood" };
            var subAnimation      = new SubCategoryModel { Name = "Animation" };
            var subAritmetik      = new SubCategoryModel { Name = "Aritmetik" };
            var subGeometri       = new SubCategoryModel { Name = "Geometri" };
            var subDjur           = new SubCategoryModel { Name = "Djur" };
            var subVaxter         = new SubCategoryModel { Name = "Växter" };
            var subDatorer        = new SubCategoryModel { Name = "Datorer" };
            var subInternet       = new SubCategoryModel { Name = "Internet" };
            var subMatlagning     = new SubCategoryModel { Name = "Matlagning" };
            var subDrycker        = new SubCategoryModel { Name = "Drycker" };
            var subSkandinavien   = new SubCategoryModel { Name = "Skandinavien" };
            var subMedeltiden     = new SubCategoryModel { Name = "Medeltiden" };
            var subBiologi        = new SubCategoryModel { Name = "Biologi" };
            var subTennis         = new SubCategoryModel { Name = "Tennis" };
            var subJazz           = new SubCategoryModel { Name = "Jazz" };
            var subSerier         = new SubCategoryModel { Name = "Serier & TV" };
            var subAlgebra        = new SubCategoryModel { Name = "Algebra" };
            var subHav            = new SubCategoryModel { Name = "Hav & Oceaner" };
            var subMobil          = new SubCategoryModel { Name = "Mobil & Appar" };
            var subBakning        = new SubCategoryModel { Name = "Bakning" };

            subEuropa.Category     = catGeografi;
            subVarlden.Category    = catGeografi;
            subAntiken.Category    = catHistoria;
            subModernHistoria.Category = catHistoria;
            subKemi.Category       = catVetenskap;
            subFysik.Category      = catVetenskap;
            subFotboll.Category    = catSport;
            subOS.Category         = catSport;
            subKlassisk.Category   = catMusik;
            subPopRock.Category    = catMusik;
            subHollywood.Category  = catFilmTV;
            subAnimation.Category  = catFilmTV;
            subAritmetik.Category  = catMatematik;
            subGeometri.Category   = catMatematik;
            subDjur.Category       = catNatur;
            subVaxter.Category     = catNatur;
            subDatorer.Category    = catTeknik;
            subInternet.Category   = catTeknik;
            subMatlagning.Category = catMatDryck;
            subDrycker.Category    = catMatDryck;
            subSkandinavien.Category = catGeografi;
            subMedeltiden.Category   = catHistoria;
            subBiologi.Category      = catVetenskap;
            subTennis.Category       = catSport;
            subJazz.Category         = catMusik;
            subSerier.Category       = catFilmTV;
            subAlgebra.Category      = catMatematik;
            subHav.Category          = catNatur;
            subMobil.Category        = catTeknik;
            subBakning.Category      = catMatDryck;

            // FRÅGOR

            // --- Geografi: Europa ---
            var qFrankrikesHuvudstad = new QuestionModel
            {
                Question = "Vad är huvudstaden i Frankrike?",
                Category = catGeografi,
                SubCategory = subEuropa
            };
            var qSverigesHuvudstad = new QuestionModel
            {
                Question = "Vad är huvudstaden i Sverige?",
                Category = catGeografi,
                SubCategory = subEuropa
            };
            var qFlestInvanareEuropa = new QuestionModel
            {
                Question = "Vilket land har flest invånare i Europa?",
                Category = catGeografi,
                SubCategory = subEuropa
            };

            // --- Geografi: Världen ---
            var qStorstaLandYta = new QuestionModel
            {
                Question = "Vilket är världens största land till ytan?",
                Category = catGeografi,
                SubCategory = subVarlden
            };
            var qLangstaFlod = new QuestionModel
            {
                Question = "Vilken är världens längsta flod?",
                Category = catGeografi,
                SubCategory = subVarlden
            };

            // --- Historia: Antiken ---
            var qAntikRomLand = new QuestionModel
            {
                Question = "I vilket land låg det antika Rom?",
                Category = catHistoria,
                SubCategory = subAntiken
            };
            var qVastromerriketFall = new QuestionModel
            {
                Question = "Vilket år föll Västromerska riket?",
                Category = catHistoria,
                SubCategory = subAntiken
            };

            // --- Historia: Modern Historia ---
            var qAndraVK = new QuestionModel
            {
                Question = "Vilket år slutade andra världskriget?",
                Category = catHistoria,
                SubCategory = subModernHistoria
            };
            var qStoraNordiskaKriget = new QuestionModel
            {
                Question = "Vem var Sveriges kung under stora nordiska kriget?",
                Category = catHistoria,
                SubCategory = subModernHistoria
            };

            // --- Vetenskap: Kemi ---
            var qVattenFormel = new QuestionModel
            {
                Question = "Vad är den kemiska beteckningen för vatten?",
                Category = catVetenskap,
                SubCategory = subKemi
            };
            var qAtomNummer1 = new QuestionModel
            {
                Question = "Vilket grundämne har atomnummer 1?",
                Category = catVetenskap,
                SubCategory = subKemi
            };

            // --- Vetenskap: Fysik ---
            var qLjusets = new QuestionModel
            {
                Question = "Ungefär hur snabbt rör sig ljus i vakuum?",
                Category = catVetenskap,
                SubCategory = subFysik
            };
            var qGravitationslagen = new QuestionModel
            {
                Question = "Vem formulerade gravitationslagen?",
                Category = catVetenskap,
                SubCategory = subFysik
            };

            // --- Sport: Fotboll ---
            var qFotbollsspelare = new QuestionModel
            {
                Question = "Hur många spelare har ett fotbollslag på planen?",
                Category = catSport,
                SubCategory = subFotboll
            };
            var qVMGuldFotboll = new QuestionModel
            {
                Question = "Vilket land har vunnit flest VM-guld i fotboll?",
                Category = catSport,
                SubCategory = subFotboll
            };

            // --- Sport: OS ---
            var qForstaModernaOS = new QuestionModel
            {
                Question = "Var hölls de första moderna olympiska spelen (1896)?",
                Category = catSport,
                SubCategory = subOS
            };
            var qOSIntervall = new QuestionModel
            {
                Question = "Med hur många års mellanrum hålls de olympiska sommarspelen?",
                Category = catSport,
                SubCategory = subOS
            };

            // --- Musik: Klassisk ---
            var qFurElise = new QuestionModel
            {
                Question = "Vem komponerade \"Für Elise\"?",
                Category = catMusik,
                SubCategory = subKlassisk
            };
            var qGitarrStrangar = new QuestionModel
            {
                Question = "Hur många strängar har en standardgitarr?",
                Category = catMusik,
                SubCategory = subKlassisk
            };

            // --- Musik: Pop & Rock ---
            var qBohemianRhapsody = new QuestionModel
            {
                Question = "Vilket band sjöng \"Bohemian Rhapsody\"?",
                Category = catMusik,
                SubCategory = subPopRock
            };
            var qABBA = new QuestionModel
            {
                Question = "Vilket år bildades ABBA?",
                Category = catMusik,
                SubCategory = subPopRock
            };

            // --- Film & TV: Hollywood ---
            var qIronMan = new QuestionModel
            {
                Question = "Vem spelar Iron Man i MCU?",
                Category = catFilmTV,
                SubCategory = subHollywood
            };
            var qTitanicAr = new QuestionModel
            {
                Question = "Vilket år hade filmen Titanic premiär?",
                Category = catFilmTV,
                SubCategory = subHollywood
            };

            // --- Film & TV: Animation ---
            var qSpiritedAway = new QuestionModel
            {
                Question = "Vilket land producerade animationsfilmen \"Spirited Away\"?",
                Category = catFilmTV,
                SubCategory = subAnimation
            };
            var qLejonkungen = new QuestionModel
            {
                Question = "Vilket studio skapade \"Lejonkungen\" (1994)?",
                Category = catFilmTV,
                SubCategory = subAnimation
            };

            // --- Matematik: Aritmetik ---
            var qKvadratrot144 = new QuestionModel
            {
                Question = "Vad är kvadratroten ur 144?",
                Category = catMatematik,
                SubCategory = subAritmetik
            };
            var qHexagonSidor = new QuestionModel
            {
                Question = "Hur många sidor har en hexagon?",
                Category = catMatematik,
                SubCategory = subAritmetik
            };

            // --- Matematik: Geometri ---
            var qRatVinkel = new QuestionModel
            {
                Question = "Hur många grader är en rät vinkel?",
                Category = catMatematik,
                SubCategory = subGeometri
            };
            var qPi = new QuestionModel
            {
                Question = "Vad är talet pi avrundat till 2 decimaler?",
                Category = catMatematik,
                SubCategory = subGeometri
            };

            // --- Natur: Djur ---
            var qStorstaLanddjur = new QuestionModel
            {
                Question = "Vilket är världens största landlevande djur?",
                Category = catNatur,
                SubCategory = subDjur
            };
            var qInsektBen = new QuestionModel
            {
                Question = "Hur många ben har en insekt?",
                Category = catNatur,
                SubCategory = subDjur
            };

            // --- Natur: Växter ---
            var qEkollon = new QuestionModel
            {
                Question = "Vilket träd producerar ekollon?",
                Category = catNatur,
                SubCategory = subVaxter
            };
            var qFotosyntes = new QuestionModel
            {
                Question = "Vad heter processen där växter omvandlar solljus till energi?",
                Category = catNatur,
                SubCategory = subVaxter
            };

            // --- Teknik: Datorer ---
            var qCPU = new QuestionModel
            {
                Question = "Vad står förkortningen CPU för?",
                Category = catTeknik,
                SubCategory = subDatorer
            };
            var qWindowsSkapare = new QuestionModel
            {
                Question = "Vilket företag skapade operativsystemet Windows?",
                Category = catTeknik,
                SubCategory = subDatorer
            };

            // --- Teknik: Internet ---
            var qWWW = new QuestionModel
            {
                Question = "Vad står WWW för?",
                Category = catTeknik,
                SubCategory = subInternet
            };
            var qGoogleGrundat = new QuestionModel
            {
                Question = "Vilket år grundades Google?",
                Category = catTeknik,
                SubCategory = subInternet
            };

            // --- Mat & Dryck: Matlagning ---
            var qSushiUrsprung = new QuestionModel
            {
                Question = "Vilket land kommer sushi ursprungligen från?",
                Category = catMatDryck,
                SubCategory = subMatlagning
            };
            var qGuacamoleIngrediens = new QuestionModel
            {
                Question = "Vad är huvudingrediensen i guacamole?",
                Category = catMatDryck,
                SubCategory = subMatlagning
            };

            // --- Mat & Dryck: Drycker ---
            var qKaffeProducent = new QuestionModel
            {
                Question = "Vilket land är världens största producent av kaffe?",
                Category = catMatDryck,
                SubCategory = subDrycker
            };
            var qVinIngredienser = new QuestionModel
            {
                Question = "Av vad tillverkas vin?",
                Category = catMatDryck,
                SubCategory = subDrycker
            };

            // --- Geografi: Skandinavien ---
            var qNorgesHuvudstad = new QuestionModel
            {
                Question = "Vad heter Norges huvudstad?",
                Category = catGeografi,
                SubCategory = subSkandinavien
            };
            var qDanmarksHuvudstad = new QuestionModel
            {
                Question = "Vad heter Danmarks huvudstad?",
                Category = catGeografi,
                SubCategory = subSkandinavien
            };

            // --- Historia: Medeltiden ---
            var qMagnaCarta = new QuestionModel
            {
                Question = "Vilket år undertecknades Magna Carta?",
                Category = catHistoria,
                SubCategory = subMedeltiden
            };
            var qKonstantinopel = new QuestionModel
            {
                Question = "Vilket år föll Konstantinopel till osmanska riket?",
                Category = catHistoria,
                SubCategory = subMedeltiden
            };

            // --- Vetenskap: Biologi ---
            var qKromosompar = new QuestionModel
            {
                Question = "Hur många kromosompar har en frisk människa?",
                Category = catVetenskap,
                SubCategory = subBiologi
            };
            var qMinstaEnhet = new QuestionModel
            {
                Question = "Vad kallas den minsta enheten i en levande organism?",
                Category = catVetenskap,
                SubCategory = subBiologi
            };

            // --- Sport: Tennis ---
            var qTennisNollPoang = new QuestionModel
            {
                Question = "Vad kallas noll poäng i tennis?",
                Category = catSport,
                SubCategory = subTennis
            };
            var qTennisGrus = new QuestionModel
            {
                Question = "Vilket är det mest prestigefyllda tennisturneringen på grus?",
                Category = catSport,
                SubCategory = subTennis
            };

            // --- Musik: Jazz ---
            var qJazzUrsprung = new QuestionModel
            {
                Question = "I vilket land uppstod jazzmusiken?",
                Category = catMusik,
                SubCategory = subJazz
            };
            var qMilesDavis = new QuestionModel
            {
                Question = "Vilket instrument är Miles Davis känd för att spela?",
                Category = catMusik,
                SubCategory = subJazz
            };

            // --- Film & TV: Serier ---
            var qGameOfThrones = new QuestionModel
            {
                Question = "Vilket nätverk producerade Game of Thrones?",
                Category = catFilmTV,
                SubCategory = subSerier
            };
            var qSquidGame = new QuestionModel
            {
                Question = "Vilket land producerade serien 'Squid Game'?",
                Category = catFilmTV,
                SubCategory = subSerier
            };

            // --- Matematik: Algebra ---
            var qAlgebra2x = new QuestionModel
            {
                Question = "Vad är x om 2x + 4 = 10?",
                Category = catMatematik,
                SubCategory = subAlgebra
            };
            var qAndragradsekvation = new QuestionModel
            {
                Question = "Hur många lösningar kan en andragradsekvation ha som mest?",
                Category = catMatematik,
                SubCategory = subAlgebra
            };

            // --- Natur: Hav & Oceaner ---
            var qStorstaOcean = new QuestionModel
            {
                Question = "Vilket är världens största ocean?",
                Category = catNatur,
                SubCategory = subHav
            };
            var qJordensVatten = new QuestionModel
            {
                Question = "Hur stor del av jordens yta täcks av vatten (ungefär)?",
                Category = catNatur,
                SubCategory = subHav
            };

            // --- Teknik: Mobil & Appar ---
            var qFoerstaIphone = new QuestionModel
            {
                Question = "Vilket år lanserades den första iPhone?",
                Category = catTeknik,
                SubCategory = subMobil
            };
            var qIphoneTillverkare = new QuestionModel
            {
                Question = "Vilket företag tillverkar iPhone?",
                Category = catTeknik,
                SubCategory = subMobil
            };

            // --- Mat & Dryck: Bakning ---
            var qBrodJaesning = new QuestionModel
            {
                Question = "Vilken ingrediens gör att bröddeg jäser?",
                Category = catMatDryck,
                SubCategory = subBakning
            };
            var qBakpulver = new QuestionModel
            {
                Question = "Vad är det vanligaste pulvret för att få kakor att jäsa utan jäst?",
                Category = catMatDryck,
                SubCategory = subBakning
            };

            // FRÅGA ↔ SVARSALTERNATIV  (IsCorrect = true på exakt ett svar/fråga)
            // Notera: samma AnswerOptionModel-instans återanvänds i flera frågor

            context.QuestionAnswerOptions.AddRange(

                // Vad är huvudstaden i Frankrike?
                new QuestionAnswerOptionModel { Question = qFrankrikesHuvudstad, AnswerOption = aParis,   IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qFrankrikesHuvudstad, AnswerOption = aLondon,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFrankrikesHuvudstad, AnswerOption = aBerlin,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFrankrikesHuvudstad, AnswerOption = aMadrid,  IsCorrect = false },

                // Vad är huvudstaden i Sverige?
                new QuestionAnswerOptionModel { Question = qSverigesHuvudstad, AnswerOption = aStockholm, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qSverigesHuvudstad, AnswerOption = aGoteborg,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSverigesHuvudstad, AnswerOption = aMalmo,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSverigesHuvudstad, AnswerOption = aUppsala,   IsCorrect = false },

                // Vilket land har flest invånare i Europa?
                new QuestionAnswerOptionModel { Question = qFlestInvanareEuropa, AnswerOption = aRyssland,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qFlestInvanareEuropa, AnswerOption = aTyskland,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFlestInvanareEuropa, AnswerOption = aFrankrike, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFlestInvanareEuropa, AnswerOption = aItalien,   IsCorrect = false },

                // Vilket är världens största land till ytan?  — aRyssland återanvänds!
                new QuestionAnswerOptionModel { Question = qStorstaLandYta, AnswerOption = aRyssland, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qStorstaLandYta, AnswerOption = aKanada,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStorstaLandYta, AnswerOption = aUSA,      IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStorstaLandYta, AnswerOption = aKina,     IsCorrect = false },

                // Vilket är världens längsta flod?
                new QuestionAnswerOptionModel { Question = qLangstaFlod, AnswerOption = aNilen,       IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qLangstaFlod, AnswerOption = aAmazonas,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLangstaFlod, AnswerOption = aYangtze,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLangstaFlod, AnswerOption = aMississippi, IsCorrect = false },

                // I vilket land låg det antika Rom?  — aItalien återanvänds!
                new QuestionAnswerOptionModel { Question = qAntikRomLand, AnswerOption = aItalien,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qAntikRomLand, AnswerOption = aGrekland, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAntikRomLand, AnswerOption = aSpanien,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAntikRomLand, AnswerOption = aTurkiet,  IsCorrect = false },

                // Vilket år föll Västromerska riket?
                new QuestionAnswerOptionModel { Question = qVastromerriketFall, AnswerOption = a476, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qVastromerriketFall, AnswerOption = a395, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVastromerriketFall, AnswerOption = a410, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVastromerriketFall, AnswerOption = a500, IsCorrect = false },

                // Vilket år slutade andra världskriget?
                new QuestionAnswerOptionModel { Question = qAndraVK, AnswerOption = a1945, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qAndraVK, AnswerOption = a1944, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAndraVK, AnswerOption = a1946, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAndraVK, AnswerOption = a1943, IsCorrect = false },

                // Vem var Sveriges kung under stora nordiska kriget?
                new QuestionAnswerOptionModel { Question = qStoraNordiskaKriget, AnswerOption = aKarlXII,       IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qStoraNordiskaKriget, AnswerOption = aGustavIIAdolf, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStoraNordiskaKriget, AnswerOption = aKarlXI,        IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStoraNordiskaKriget, AnswerOption = aGustavIII,     IsCorrect = false },

                // Vad är den kemiska beteckningen för vatten?
                new QuestionAnswerOptionModel { Question = qVattenFormel, AnswerOption = aH2O,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qVattenFormel, AnswerOption = aCO2,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVattenFormel, AnswerOption = aNaCl, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVattenFormel, AnswerOption = aO2,   IsCorrect = false },

                // Vilket grundämne har atomnummer 1?
                new QuestionAnswerOptionModel { Question = qAtomNummer1, AnswerOption = aVate,   IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qAtomNummer1, AnswerOption = aHelium, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAtomNummer1, AnswerOption = aSyre,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAtomNummer1, AnswerOption = aKol,    IsCorrect = false },

                // Ungefär hur snabbt rör sig ljus i vakuum?
                new QuestionAnswerOptionModel { Question = qLjusets, AnswerOption = a300000, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qLjusets, AnswerOption = a150000, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLjusets, AnswerOption = a500000, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLjusets, AnswerOption = a100000, IsCorrect = false },

                // Vem formulerade gravitationslagen?
                new QuestionAnswerOptionModel { Question = qGravitationslagen, AnswerOption = aNewton,   IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qGravitationslagen, AnswerOption = aEinstein, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGravitationslagen, AnswerOption = aGalileo,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGravitationslagen, AnswerOption = aHawking,  IsCorrect = false },

                // Hur många spelare har ett fotbollslag på planen?
                // a11 och a12 återanvänds i matematik!
                new QuestionAnswerOptionModel { Question = qFotbollsspelare, AnswerOption = a11, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qFotbollsspelare, AnswerOption = a10, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFotbollsspelare, AnswerOption = a12, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFotbollsspelare, AnswerOption = a9,  IsCorrect = false },

                // Vilket land har vunnit flest VM-guld i fotboll?
                // aBrasilien återanvänds i kaffeproducent! aTyskland + aItalien återanvänds!
                new QuestionAnswerOptionModel { Question = qVMGuldFotboll, AnswerOption = aBrasilien, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qVMGuldFotboll, AnswerOption = aTyskland,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVMGuldFotboll, AnswerOption = aItalien,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVMGuldFotboll, AnswerOption = aArgentina, IsCorrect = false },

                // Var hölls de första moderna olympiska spelen?
                // aParis, aLondon, aRom återanvänds!
                new QuestionAnswerOptionModel { Question = qForstaModernaOS, AnswerOption = aAthen,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qForstaModernaOS, AnswerOption = aParis,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qForstaModernaOS, AnswerOption = aLondon, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qForstaModernaOS, AnswerOption = aRom,    IsCorrect = false },

                // Vart hur många år hålls de olympiska sommarspelen?
                // a4 återanvänds i gitarr/insekt!
                new QuestionAnswerOptionModel { Question = qOSIntervall, AnswerOption = a4, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qOSIntervall, AnswerOption = a2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOSIntervall, AnswerOption = a3, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOSIntervall, AnswerOption = a5, IsCorrect = false },

                // Vem komponerade "Für Elise"?
                new QuestionAnswerOptionModel { Question = qFurElise, AnswerOption = aBeethoven, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qFurElise, AnswerOption = aMozart,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFurElise, AnswerOption = aBach,      IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFurElise, AnswerOption = aChopin,    IsCorrect = false },

                // Hur många strängar har en standardgitarr?
                // a6 återanvänds i hexagon + insektben!
                new QuestionAnswerOptionModel { Question = qGitarrStrangar, AnswerOption = a6, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qGitarrStrangar, AnswerOption = a4, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGitarrStrangar, AnswerOption = a5, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGitarrStrangar, AnswerOption = a8, IsCorrect = false },

                // Vilket band sjöng "Bohemian Rhapsody"?
                new QuestionAnswerOptionModel { Question = qBohemianRhapsody, AnswerOption = aQueen,         IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qBohemianRhapsody, AnswerOption = aBeatles,       IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBohemianRhapsody, AnswerOption = aLedZeppelin,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBohemianRhapsody, AnswerOption = aRollingStones, IsCorrect = false },

                // Vilket år bildades ABBA?
                new QuestionAnswerOptionModel { Question = qABBA, AnswerOption = a1972, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qABBA, AnswerOption = a1969, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qABBA, AnswerOption = a1975, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qABBA, AnswerOption = a1970, IsCorrect = false },

                // Vem spelar Iron Man i MCU?
                new QuestionAnswerOptionModel { Question = qIronMan, AnswerOption = aRDJ,            IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qIronMan, AnswerOption = aChrisEvans,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIronMan, AnswerOption = aChrisHemsworth, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIronMan, AnswerOption = aMarkRuffalo,    IsCorrect = false },

                // Vilket år hade Titanic premiär?
                new QuestionAnswerOptionModel { Question = qTitanicAr, AnswerOption = a1997, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qTitanicAr, AnswerOption = a1995, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTitanicAr, AnswerOption = a1999, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTitanicAr, AnswerOption = a2001, IsCorrect = false },

                // Vilket land producerade "Spirited Away"?  — aJapan återanvänds i sushi!
                new QuestionAnswerOptionModel { Question = qSpiritedAway, AnswerOption = aJapan,    IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qSpiritedAway, AnswerOption = aUSA,      IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpiritedAway, AnswerOption = aSydkorea, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpiritedAway, AnswerOption = aKina,     IsCorrect = false },

                // Vilket studio skapade "Lejonkungen"?
                new QuestionAnswerOptionModel { Question = qLejonkungen, AnswerOption = aDisney,     IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qLejonkungen, AnswerOption = aPixar,      IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLejonkungen, AnswerOption = aDreamWorks, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLejonkungen, AnswerOption = aWarnerBros, IsCorrect = false },

                // Vad är kvadratroten ur 144?  — a12 och a11 återanvänds från fotboll!
                new QuestionAnswerOptionModel { Question = qKvadratrot144, AnswerOption = a12, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qKvadratrot144, AnswerOption = a14, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKvadratrot144, AnswerOption = a11, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKvadratrot144, AnswerOption = a13, IsCorrect = false },

                // Hur många sidor har en hexagon?  — a6 återanvänds i gitarr + insekt!
                new QuestionAnswerOptionModel { Question = qHexagonSidor, AnswerOption = a6, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qHexagonSidor, AnswerOption = a5, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHexagonSidor, AnswerOption = a7, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHexagonSidor, AnswerOption = a8, IsCorrect = false },

                // Hur många grader är en rät vinkel?
                new QuestionAnswerOptionModel { Question = qRatVinkel, AnswerOption = a90,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qRatVinkel, AnswerOption = a45,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRatVinkel, AnswerOption = a180, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRatVinkel, AnswerOption = a60,  IsCorrect = false },

                // Vad är pi avrundat till 2 decimaler?
                new QuestionAnswerOptionModel { Question = qPi, AnswerOption = aPi314, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qPi, AnswerOption = aPi312, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPi, AnswerOption = aPi316, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPi, AnswerOption = aPi318, IsCorrect = false },

                // Vilket är världens största landlevande djur?
                new QuestionAnswerOptionModel { Question = qStorstaLanddjur, AnswerOption = aElefant,   IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qStorstaLanddjur, AnswerOption = aNoshorn,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStorstaLanddjur, AnswerOption = aFlodhaest, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStorstaLanddjur, AnswerOption = aGiraff,    IsCorrect = false },

                // Hur många ben har en insekt?  — a6 återanvänds i gitarr + hexagon!
                new QuestionAnswerOptionModel { Question = qInsektBen, AnswerOption = a6,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qInsektBen, AnswerOption = a4,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qInsektBen, AnswerOption = a8,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qInsektBen, AnswerOption = a10, IsCorrect = false },

                // Vilket träd producerar ekollon?
                new QuestionAnswerOptionModel { Question = qEkollon, AnswerOption = aEk,    IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qEkollon, AnswerOption = aBjork, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qEkollon, AnswerOption = aGran,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qEkollon, AnswerOption = aTall,  IsCorrect = false },

                // Vad heter processen där växter omvandlar solljus till energi?
                new QuestionAnswerOptionModel { Question = qFotosyntes, AnswerOption = aFotosyntes,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qFotosyntes, AnswerOption = aMetabolism,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFotosyntes, AnswerOption = aOsmos,       IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFotosyntes, AnswerOption = aRespiration, IsCorrect = false },

                // Vad står CPU för?
                new QuestionAnswerOptionModel { Question = qCPU, AnswerOption = aCpuCorrect, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qCPU, AnswerOption = aCpuWrong1,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCPU, AnswerOption = aCpuWrong2,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCPU, AnswerOption = aCpuWrong3,  IsCorrect = false },

                // Vilket företag skapade Windows?  — aMicrosoft/aApple/aGoogle återanvänds i Google!
                new QuestionAnswerOptionModel { Question = qWindowsSkapare, AnswerOption = aMicrosoft, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qWindowsSkapare, AnswerOption = aApple,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWindowsSkapare, AnswerOption = aGoogle,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWindowsSkapare, AnswerOption = aIBM,       IsCorrect = false },

                // Vad står WWW för?
                new QuestionAnswerOptionModel { Question = qWWW, AnswerOption = aWwwCorrect, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qWWW, AnswerOption = aWwwWrong1,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWWW, AnswerOption = aWwwWrong2,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWWW, AnswerOption = aWwwWrong3,  IsCorrect = false },

                // Vilket år grundades Google?  — a1998/a1995/a2000/a2001 återanvänds från historia/film!
                new QuestionAnswerOptionModel { Question = qGoogleGrundat, AnswerOption = a1998, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qGoogleGrundat, AnswerOption = a1995, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGoogleGrundat, AnswerOption = a2000, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGoogleGrundat, AnswerOption = a2001, IsCorrect = false },

                // Vilket land kommer sushi från?  — aJapan återanvänds från Spirited Away!
                new QuestionAnswerOptionModel { Question = qSushiUrsprung, AnswerOption = aJapan,    IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qSushiUrsprung, AnswerOption = aKina,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSushiUrsprung, AnswerOption = aSydkorea, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSushiUrsprung, AnswerOption = aVietnam,  IsCorrect = false },

                // Vad är huvudingrediensen i guacamole?
                new QuestionAnswerOptionModel { Question = qGuacamoleIngrediens, AnswerOption = aAvokado, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qGuacamoleIngrediens, AnswerOption = aTomat,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGuacamoleIngrediens, AnswerOption = aLok,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGuacamoleIngrediens, AnswerOption = aLime,    IsCorrect = false },

                // Vilket land är störst kaffeproducent?  — aBrasilien återanvänds från fotboll!
                new QuestionAnswerOptionModel { Question = qKaffeProducent, AnswerOption = aBrasilien, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qKaffeProducent, AnswerOption = aKolombia,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKaffeProducent, AnswerOption = aEtiopien,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKaffeProducent, AnswerOption = aVietnam,   IsCorrect = false },

                // Av vad tillverkas vin?
                new QuestionAnswerOptionModel { Question = qVinIngredienser, AnswerOption = aDruvor,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qVinIngredienser, AnswerOption = aApplen,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVinIngredienser, AnswerOption = aParon,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVinIngredienser, AnswerOption = aPlommon, IsCorrect = false },

                // Vad heter Norges huvudstad?
                new QuestionAnswerOptionModel { Question = qNorgesHuvudstad, AnswerOption = aOslo,       IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qNorgesHuvudstad, AnswerOption = aStockholm,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNorgesHuvudstad, AnswerOption = aKopenhagen, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNorgesHuvudstad, AnswerOption = aBerlin,     IsCorrect = false },

                // Vad heter Danmarks huvudstad?
                new QuestionAnswerOptionModel { Question = qDanmarksHuvudstad, AnswerOption = aKopenhagen, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qDanmarksHuvudstad, AnswerOption = aOslo,       IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDanmarksHuvudstad, AnswerOption = aStockholm,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDanmarksHuvudstad, AnswerOption = aHelsinki,   IsCorrect = false },

                // Vilket år undertecknades Magna Carta?
                new QuestionAnswerOptionModel { Question = qMagnaCarta, AnswerOption = a1215, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qMagnaCarta, AnswerOption = a1066, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMagnaCarta, AnswerOption = a1348, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMagnaCarta, AnswerOption = a1453, IsCorrect = false },

                // Vilket år föll Konstantinopel?
                new QuestionAnswerOptionModel { Question = qKonstantinopel, AnswerOption = a1453, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qKonstantinopel, AnswerOption = a1389, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKonstantinopel, AnswerOption = a1492, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKonstantinopel, AnswerOption = a1500, IsCorrect = false },

                // Hur många kromosompar har en frisk människa?
                new QuestionAnswerOptionModel { Question = qKromosompar, AnswerOption = a23, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qKromosompar, AnswerOption = a22, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKromosompar, AnswerOption = a24, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qKromosompar, AnswerOption = a46, IsCorrect = false },

                // Vad kallas den minsta enheten i en levande organism?
                new QuestionAnswerOptionModel { Question = qMinstaEnhet, AnswerOption = aCellen,    IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qMinstaEnhet, AnswerOption = aAtomen,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMinstaEnhet, AnswerOption = aMolekylen, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMinstaEnhet, AnswerOption = aVavnaden,  IsCorrect = false },

                // Vad kallas noll poäng i tennis?
                new QuestionAnswerOptionModel { Question = qTennisNollPoang, AnswerOption = aLove, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qTennisNollPoang, AnswerOption = aZero, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTennisNollPoang, AnswerOption = aNil,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTennisNollPoang, AnswerOption = aNoll, IsCorrect = false },

                // Vilket är det mest prestigefyllda tennisturneringen på grus?
                new QuestionAnswerOptionModel { Question = qTennisGrus, AnswerOption = aRolandGarros,   IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qTennisGrus, AnswerOption = aWimbledon,      IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTennisGrus, AnswerOption = aUSOpen,         IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTennisGrus, AnswerOption = aAustralianOpen, IsCorrect = false },

                // I vilket land uppstod jazzmusiken?
                new QuestionAnswerOptionModel { Question = qJazzUrsprung, AnswerOption = aUSA,       IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qJazzUrsprung, AnswerOption = aFrankrike, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJazzUrsprung, AnswerOption = aKina,      IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJazzUrsprung, AnswerOption = aBrasilien, IsCorrect = false },

                // Vilket instrument är Miles Davis känd för att spela?
                new QuestionAnswerOptionModel { Question = qMilesDavis, AnswerOption = aTrumpet,  IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qMilesDavis, AnswerOption = aSaxofon,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMilesDavis, AnswerOption = aPiano,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMilesDavis, AnswerOption = aKlarinet, IsCorrect = false },

                // Vilket nätverk producerade Game of Thrones?
                new QuestionAnswerOptionModel { Question = qGameOfThrones, AnswerOption = aHBO,         IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qGameOfThrones, AnswerOption = aNetflix,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGameOfThrones, AnswerOption = aAmazonPrime, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGameOfThrones, AnswerOption = aHulu,        IsCorrect = false },

                // Vilket land producerade 'Squid Game'?
                new QuestionAnswerOptionModel { Question = qSquidGame, AnswerOption = aSydkorea, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qSquidGame, AnswerOption = aJapan,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSquidGame, AnswerOption = aKina,     IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSquidGame, AnswerOption = aUSA,      IsCorrect = false },

                // Vad är x om 2x + 4 = 10?
                new QuestionAnswerOptionModel { Question = qAlgebra2x, AnswerOption = a3, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qAlgebra2x, AnswerOption = a2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAlgebra2x, AnswerOption = a4, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAlgebra2x, AnswerOption = a5, IsCorrect = false },

                // Hur många lösningar kan en andragradsekvation ha som mest?
                new QuestionAnswerOptionModel { Question = qAndragradsekvation, AnswerOption = a2, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qAndragradsekvation, AnswerOption = a1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAndragradsekvation, AnswerOption = a3, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAndragradsekvation, AnswerOption = a4, IsCorrect = false },

                // Vilket är världens största ocean?
                new QuestionAnswerOptionModel { Question = qStorstaOcean, AnswerOption = aStillahavet,     IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qStorstaOcean, AnswerOption = aAtlanten,        IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStorstaOcean, AnswerOption = aIndiskaOceanen,  IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStorstaOcean, AnswerOption = aArktiskaOceanen, IsCorrect = false },

                // Hur stor del av jordens yta täcks av vatten?
                new QuestionAnswerOptionModel { Question = qJordensVatten, AnswerOption = a71pct, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qJordensVatten, AnswerOption = a50pct, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJordensVatten, AnswerOption = a60pct, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJordensVatten, AnswerOption = a80pct, IsCorrect = false },

                // Vilket år lanserades den första iPhone?
                new QuestionAnswerOptionModel { Question = qFoerstaIphone, AnswerOption = a2007, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qFoerstaIphone, AnswerOption = a2005, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFoerstaIphone, AnswerOption = a2008, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qFoerstaIphone, AnswerOption = a2010, IsCorrect = false },

                // Vilket företag tillverkar iPhone?
                new QuestionAnswerOptionModel { Question = qIphoneTillverkare, AnswerOption = aApple,     IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qIphoneTillverkare, AnswerOption = aSamsung,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIphoneTillverkare, AnswerOption = aGoogle,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIphoneTillverkare, AnswerOption = aMicrosoft, IsCorrect = false },

                // Vilken ingrediens gör att bröddeg jäser?
                new QuestionAnswerOptionModel { Question = qBrodJaesning, AnswerOption = aJast,   IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qBrodJaesning, AnswerOption = aMjol,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBrodJaesning, AnswerOption = aSalt,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBrodJaesning, AnswerOption = aSocker, IsCorrect = false },

                // Vad är det vanligaste pulvret för att få kakor att jäsa utan jäst?
                new QuestionAnswerOptionModel { Question = qBakpulver, AnswerOption = aBakpulver, IsCorrect = true  },
                new QuestionAnswerOptionModel { Question = qBakpulver, AnswerOption = aMaizena,   IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBakpulver, AnswerOption = aVanilj,    IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBakpulver, AnswerOption = aSalt,      IsCorrect = false }
            );

            await context.SaveChangesAsync();
        }
    }
}
