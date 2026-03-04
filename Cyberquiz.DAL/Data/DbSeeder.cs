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

            //SVARsALTERNATIV

            // Nätverk
            var aNatverkslager = new AnswerOptionModel { Answer = "Nätverkslager (Layer 3)" };
            var aDatalankslager = new AnswerOptionModel { Answer = "Datalänklager (Layer 2)" };
            var aTransportlager = new AnswerOptionModel { Answer = "Transportlager (Layer 4)" };
            var aSessionslager = new AnswerOptionModel { Answer = "Sessionslager (Layer 5)" };

            var aPort443 = new AnswerOptionModel { Answer = "443" };
            var aPort80 = new AnswerOptionModel { Answer = "80" };
            var aPort8080 = new AnswerOptionModel { Answer = "8080" };
            var aPort22 = new AnswerOptionModel { Answer = "22" };
            var aPort53 = new AnswerOptionModel { Answer = "53" };
            var aPort25 = new AnswerOptionModel { Answer = "25" };
            var aPort110 = new AnswerOptionModel { Answer = "110" };

            var aSynForklaring = new AnswerOptionModel { Answer = "Det första paketet i en TCP-handskakning" };
            var aSynFel1 = new AnswerOptionModel { Answer = "Ett avslutningspaket i TCP" };
            var aSynFel2 = new AnswerOptionModel { Answer = "En bekräftelse på mottagna data" };
            var aSynFel3 = new AnswerOptionModel { Answer = "Ett felmeddelande i TCP" };

            var aDnsKorrekt = new AnswerOptionModel { Answer = "Översätter domännamn till IP-adresser" };
            var aDnsFel1 = new AnswerOptionModel { Answer = "Tilldelar IP-adresser dynamiskt till enheter" };
            var aDnsFel2 = new AnswerOptionModel { Answer = "Filtrerar nätverkstrafik" };
            var aDnsFel3 = new AnswerOptionModel { Answer = "Krypterar dataöverföring" };

            var aDnsPoisonKorrekt = new AnswerOptionModel { Answer = "En attack som lägger in falska poster i DNS-cachen" };
            var aDnsPoisonFel1 = new AnswerOptionModel { Answer = "En metod för att kryptera DNS-trafik" };
            var aDnsPoisonFel2 = new AnswerOptionModel { Answer = "En teknik för att öka DNS-prestanda" };
            var aDnsPoisonFel3 = new AnswerOptionModel { Answer = "En typ av DDoS-attack mot DNS-servrar" };

            var aStatefulKorrekt = new AnswerOptionModel { Answer = "Stateful firewall" };
            var aStatefulFel1 = new AnswerOptionModel { Answer = "Stateless firewall" };
            var aStatefulFel2 = new AnswerOptionModel { Answer = "Proxy-brandvägg" };
            var aStatefulFel3 = new AnswerOptionModel { Answer = "Paketfiltrerande brandvägg" };

            var aIdsIpsKorrekt = new AnswerOptionModel { Answer = "IDS detekterar intrång, IPS kan även blockera dem" };
            var aIdsIpsFel1 = new AnswerOptionModel { Answer = "IDS blockerar intrång, IPS enbart detekterar" };
            var aIdsIpsFel2 = new AnswerOptionModel { Answer = "De är identiska teknologier" };
            var aIdsIpsFel3 = new AnswerOptionModel { Answer = "IDS är hårdvara, IPS är mjukvara" };

            var aDmzKorrekt = new AnswerOptionModel { Answer = "En nätverkszon mellan internet och det interna nätverket" };
            var aDmzFel1 = new AnswerOptionModel { Answer = "En krypterad tunnel mellan två nätverk" };
            var aDmzFel2 = new AnswerOptionModel { Answer = "En typ av VPN-konfiguration" };
            var aDmzFel3 = new AnswerOptionModel { Answer = "Ett isolerat administrativt nätverk" };

            // Webbsäkerhet
            var aOwaspKorrekt = new AnswerOptionModel { Answer = "Open Worldwide Application Security Project" };
            var aOwaspFel1 = new AnswerOptionModel { Answer = "Open Web Access Security Protocol" };
            var aOwaspFel2 = new AnswerOptionModel { Answer = "Online Web Application Security Platform" };
            var aOwaspFel3 = new AnswerOptionModel { Answer = "Open Windows Application Service Provider" };

            var aBrokenAccessKorrekt = new AnswerOptionModel { Answer = "Broken Access Control" };
            var aBrokenAccessFel1 = new AnswerOptionModel { Answer = "SQL Injection" };
            var aBrokenAccessFel2 = new AnswerOptionModel { Answer = "Cryptographic Failures" };
            var aBrokenAccessFel3 = new AnswerOptionModel { Answer = "Security Misconfiguration" };

            var aSecMisconfigKorrekt = new AnswerOptionModel { Answer = "Felaktigt konfigurerade säkerhetsinställningar i applikationen" };
            var aSecMisconfigFel1 = new AnswerOptionModel { Answer = "En typ av XSS-attack" };
            var aSecMisconfigFel2 = new AnswerOptionModel { Answer = "Svag kryptering av lagrad data" };
            var aSecMisconfigFel3 = new AnswerOptionModel { Answer = "Bristfällig autentisering" };

            var aXssKorrekt = new AnswerOptionModel { Answer = "Skadlig kod injiceras i webbsidor och körs i offrets webbläsare" };
            var aXssFel1 = new AnswerOptionModel { Answer = "En attack som manipulerar databaser via SQL" };
            var aXssFel2 = new AnswerOptionModel { Answer = "En nätverksattack som avlyssnar trafik" };
            var aXssFel3 = new AnswerOptionModel { Answer = "En attack som förfalskar HTTP-förfrågningar" };

            var aSqlKorrekt = new AnswerOptionModel { Answer = "SQL-kod injiceras i inmatningsfält för att manipulera databasen" };
            var aSqlFel1 = new AnswerOptionModel { Answer = "En krypteringsteknik för databaser" };
            var aSqlFel2 = new AnswerOptionModel { Answer = "En metod för att optimera SQL-frågor" };
            var aSqlFel3 = new AnswerOptionModel { Answer = "En autentiseringsmetod för databaser" };

            var aPreparedKorrekt = new AnswerOptionModel { Answer = "Prepared statements (parameteriserade frågor)" };
            var aPreparedFel1 = new AnswerOptionModel { Answer = "HTTPS-kryptering" };
            var aPreparedFel2 = new AnswerOptionModel { Answer = "Base64-kodning av inmatning" };
            var aPreparedFel3 = new AnswerOptionModel { Answer = "Cookies med HttpOnly-flagga" };

            var aMfaKorrekt = new AnswerOptionModel { Answer = "Autentisering med minst två oberoende faktorer" };
            var aMfaFel1 = new AnswerOptionModel { Answer = "Autentisering med ett extra långt lösenord" };
            var aMfaFel2 = new AnswerOptionModel { Answer = "En typ av kryptering för inloggning" };
            var aMfaFel3 = new AnswerOptionModel { Answer = "Single sign-on med certifikat" };

            var aSessionKorrekt = new AnswerOptionModel { Answer = "En attack där angriparen stjäl sessions-ID för att ta över en session" };
            var aSessionFel1 = new AnswerOptionModel { Answer = "En attack som skapar miljontals falska sessioner" };
            var aSessionFel2 = new AnswerOptionModel { Answer = "En teknik för att radera användarens cookies" };
            var aSessionFel3 = new AnswerOptionModel { Answer = "En variant av XSS-attack" };

            var aCsrfKorrekt = new AnswerOptionModel { Answer = "En attack som lurar en inloggad användare att utföra oönskade handlingar" };
            var aCsrfFel1 = new AnswerOptionModel { Answer = "En attack som injicerar skript i webbsidor" };
            var aCsrfFel2 = new AnswerOptionModel { Answer = "En attack som stjäl lösenord via phishing" };
            var aCsrfFel3 = new AnswerOptionModel { Answer = "En attack mot databaser" };

            // Kryptografi
            var aSymKorrekt = new AnswerOptionModel { Answer = "Samma nyckel används för kryptering och dekryptering" };
            var aSymFel1 = new AnswerOptionModel { Answer = "Olika nycklar används för kryptering och dekryptering" };
            var aSymFel2 = new AnswerOptionModel { Answer = "Kryptering sker utan nyckel" };
            var aSymFel3 = new AnswerOptionModel { Answer = "Kryptering med en publik nyckel" };

            var aAesKorrekt = new AnswerOptionModel { Answer = "AES (Advanced Encryption Standard)" };
            var aAesFel1 = new AnswerOptionModel { Answer = "RSA" };
            var aAesFel2 = new AnswerOptionModel { Answer = "ECC (Elliptic Curve Cryptography)" };
            var aAesFel3 = new AnswerOptionModel { Answer = "Diffie-Hellman" };

            var aAesBetydKorrekt = new AnswerOptionModel { Answer = "Advanced Encryption Standard" };
            var aAesBetydFel1 = new AnswerOptionModel { Answer = "Asymmetric Encryption System" };
            var aAesBetydFel2 = new AnswerOptionModel { Answer = "Authenticated Exchange Standard" };
            var aAesBetydFel3 = new AnswerOptionModel { Answer = "Adaptive Encryption Service" };

            var aAsymKorrekt = new AnswerOptionModel { Answer = "Kryptering med ett nyckelpar — en publik och en privat nyckel" };
            var aAsymFel1 = new AnswerOptionModel { Answer = "Kryptering med samma nyckel för alla operationer" };
            var aAsymFel2 = new AnswerOptionModel { Answer = "Kryptering utan nyckel baserad på algoritm" };
            var aAsymFel3 = new AnswerOptionModel { Answer = "Kryptering med lösenordsfras" };

            var aPrivatKorrekt = new AnswerOptionModel { Answer = "Dekryptering och digital signering" };
            var aPrivatFel1 = new AnswerOptionModel { Answer = "Kryptering av meddelanden till mottagaren" };
            var aPrivatFel2 = new AnswerOptionModel { Answer = "Distribueras öppet till alla parter" };
            var aPrivatFel3 = new AnswerOptionModel { Answer = "Utbyte av symmetriska nycklar" };

            var aCertKorrekt = new AnswerOptionModel { Answer = "En elektronisk handling som binder en publik nyckel till en identitet" };
            var aCertFel1 = new AnswerOptionModel { Answer = "En krypterad lösenordsfil" };
            var aCertFel2 = new AnswerOptionModel { Answer = "En privat nyckel signerad av användaren" };
            var aCertFel3 = new AnswerOptionModel { Answer = "En hashad version av ett lösenord" };

            var aHashKorrekt = new AnswerOptionModel { Answer = "En funktion som omvandlar data till ett fast hashvärde" };
            var aHashFel1 = new AnswerOptionModel { Answer = "En funktion som krypterar data med en nyckel" };
            var aHashFel2 = new AnswerOptionModel { Answer = "En funktion som komprimerar filer" };
            var aHashFel3 = new AnswerOptionModel { Answer = "En funktion som signerar dokument digitalt" };

            var aEnvagKorrekt = new AnswerOptionModel { Answer = "Det ska vara praktiskt omöjligt att återskapa originaldatan (envägsfunktion)" };
            var aEnvagFel1 = new AnswerOptionModel { Answer = "Hashen ska kunna dekrypteras med en nyckel" };
            var aEnvagFel2 = new AnswerOptionModel { Answer = "Hashen ska alltid vara lika lång som originaldatan" };
            var aEnvagFel3 = new AnswerOptionModel { Answer = "Hashen ska vara reversibel för admin" };

            var aShaKorrekt = new AnswerOptionModel { Answer = "SHA-256" };
            var aShaFel1 = new AnswerOptionModel { Answer = "AES-256" };
            var aShaFel2 = new AnswerOptionModel { Answer = "RSA-2048" };
            var aShaFel3 = new AnswerOptionModel { Answer = "TLS 1.3" };

            // Malware & Attacker
            var aRansomKorrekt = new AnswerOptionModel { Answer = "Krypterar offrets filer och kräver lösen för att låsa upp dem" };
            var aRansomFel1 = new AnswerOptionModel { Answer = "Stjäl lösenord och skickar dem till angriparen" };
            var aRansomFel2 = new AnswerOptionModel { Answer = "Spionerar på användaren via webbkameran" };
            var aRansomFel3 = new AnswerOptionModel { Answer = "Skapar ett botnät av infekterade datorer" };

            var aTrojanKorrekt = new AnswerOptionModel { Answer = "Skadlig programvara som döljer sig som ett legitimt program" };
            var aTrojanFel1 = new AnswerOptionModel { Answer = "Programvara som sprider sig automatiskt i nätverk" };
            var aTrojanFel2 = new AnswerOptionModel { Answer = "Programvara som krypterar hela hårddisken" };
            var aTrojanFel3 = new AnswerOptionModel { Answer = "Programvara som blockerar nätverkstrafik" };

            var aWormKorrekt = new AnswerOptionModel { Answer = "En mask sprider sig automatiskt utan att behöva en värd" };
            var aWormFel1 = new AnswerOptionModel { Answer = "En mask kräver alltid manuell aktivering av användaren" };
            var aWormFel2 = new AnswerOptionModel { Answer = "En mask krypterar alltid filer den infekterar" };
            var aWormFel3 = new AnswerOptionModel { Answer = "En mask är alltid ofarlig och tas enkelt bort" };

            var aDdosKorrekt = new AnswerOptionModel { Answer = "Många datorer översvämmar ett mål med trafik för att ta ner tjänsten" };
            var aDdosFel1 = new AnswerOptionModel { Answer = "En riktad attack mot en specifik användares dator" };
            var aDdosFel2 = new AnswerOptionModel { Answer = "En attack som injicerar skadlig kod i databaser" };
            var aDdosFel3 = new AnswerOptionModel { Answer = "En attack som sker via skadliga e-postbilagor" };

            var aMitmKorrekt = new AnswerOptionModel { Answer = "Angriparen placerar sig mellan två parter och kan avlyssna kommunikationen" };
            var aMitmFel1 = new AnswerOptionModel { Answer = "Angriparen gissar lösenord med brute force" };
            var aMitmFel2 = new AnswerOptionModel { Answer = "Angriparen skickar falska e-postmeddelanden" };
            var aMitmFel3 = new AnswerOptionModel { Answer = "Angriparen utnyttjar en okänd sårbarhet" };

            var aZerodayKorrekt = new AnswerOptionModel { Answer = "En attack som utnyttjar en sårbarhet okänd för mjukvaruleverantören" };
            var aZerodayFel1 = new AnswerOptionModel { Answer = "En attack som sker exakt kl 00:00" };
            var aZerodayFel2 = new AnswerOptionModel { Answer = "En attack mot nyinstallerade system utan uppdateringar" };
            var aZerodayFel3 = new AnswerOptionModel { Answer = "En attack som genomförs inom noll sekunder" };

            var aPhishKorrekt = new AnswerOptionModel { Answer = "Angriparen utger sig för att vara en pålitlig källa för att lura offret att lämna ut information" };
            var aPhishFel1 = new AnswerOptionModel { Answer = "En nätverksattack som avlyssnar okrypterad trafik" };
            var aPhishFel2 = new AnswerOptionModel { Answer = "En typ av malware som krypterar filer" };
            var aPhishFel3 = new AnswerOptionModel { Answer = "En attack som utnyttjar sårbarheter i webbläsare" };

            var aSpearKorrekt = new AnswerOptionModel { Answer = "En riktad phishingattack mot en specifik person eller organisation" };
            var aSpearFel1 = new AnswerOptionModel { Answer = "En massutskickad phishingattack till miljontals mottagare" };
            var aSpearFel2 = new AnswerOptionModel { Answer = "En phishingattack som sker via SMS" };
            var aSpearFel3 = new AnswerOptionModel { Answer = "En phishingattack via telefon" };

            var aVishingKorrekt = new AnswerOptionModel { Answer = "Phishing via telefon (voice phishing)" };
            var aVishingFel1 = new AnswerOptionModel { Answer = "Phishing via SMS" };
            var aVishingFel2 = new AnswerOptionModel { Answer = "Phishing via e-post" };
            var aVishingFel3 = new AnswerOptionModel { Answer = "Phishing via sociala medier" };

            // Operativsystem
            var aChmodKorrekt = new AnswerOptionModel { Answer = "Ändrar filbehörigheter (läs, skriv, kör) i Linux" };
            var aChmodFel1 = new AnswerOptionModel { Answer = "Ändrar ägaren av en fil i Linux" };
            var aChmodFel2 = new AnswerOptionModel { Answer = "Visar aktiva processer i Linux" };
            var aChmodFel3 = new AnswerOptionModel { Answer = "Skapar en ny användare i Linux" };

            var aLeastPrivKorrekt = new AnswerOptionModel { Answer = "Användare och processer ska bara ha de behörigheter de absolut behöver" };
            var aLeastPrivFel1 = new AnswerOptionModel { Answer = "Alla användare ges administratörsbehörighet som standard" };
            var aLeastPrivFel2 = new AnswerOptionModel { Answer = "Behörigheter roterar automatiskt varje dag" };
            var aLeastPrivFel3 = new AnswerOptionModel { Answer = "Behörigheter tilldelas enbart baserat på avdelning" };

            var aSudoKorrekt = new AnswerOptionModel { Answer = "Tillåter en användare att köra ett kommando med förhöjda rättigheter" };
            var aSudoFel1 = new AnswerOptionModel { Answer = "Byter permanent till root-kontot" };
            var aSudoFel2 = new AnswerOptionModel { Answer = "Visar systemloggar i realtid" };
            var aSudoFel3 = new AnswerOptionModel { Answer = "Krypterar en fil med root-behörighet" };

            var aDefenderKorrekt = new AnswerOptionModel { Answer = "Microsofts inbyggda antivirus- och säkerhetslösning" };
            var aDefenderFel1 = new AnswerOptionModel { Answer = "En inbyggd brandvägg i Windows" };
            var aDefenderFel2 = new AnswerOptionModel { Answer = "En lösenordshanterare i Windows" };
            var aDefenderFel3 = new AnswerOptionModel { Answer = "En inbyggd VPN-tjänst i Windows" };

            var aBitlockerKorrekt = new AnswerOptionModel { Answer = "Microsofts inbyggda diskkrypteringsverktyg för Windows" };
            var aBitlockerFel1 = new AnswerOptionModel { Answer = "En antiviruslösning i Windows" };
            var aBitlockerFel2 = new AnswerOptionModel { Answer = "En inbyggd brandvägg i Windows" };
            var aBitlockerFel3 = new AnswerOptionModel { Answer = "En säkerhetskopieringstjänst i Windows" };

            var aUacKorrekt = new AnswerOptionModel { Answer = "En funktion som ber om bekräftelse innan program utför administrativa ändringar" };
            var aUacFel1 = new AnswerOptionModel { Answer = "En antivirusfunktion i Windows" };
            var aUacFel2 = new AnswerOptionModel { Answer = "En nätverksbrandvägg i Windows" };
            var aUacFel3 = new AnswerOptionModel { Answer = "En lösenordspolicy i Active Directory" };

            // Lagstiftning
            var aGdprKorrekt = new AnswerOptionModel { Answer = "General Data Protection Regulation" };
            var aGdprFel1 = new AnswerOptionModel { Answer = "Global Data Privacy Rights" };
            var aGdprFel2 = new AnswerOptionModel { Answer = "General Digital Privacy Rules" };
            var aGdprFel3 = new AnswerOptionModel { Answer = "Government Data Protection Registry" };

            var a72hKorrekt = new AnswerOptionModel { Answer = "72 timmar" };
            var a72hFel1 = new AnswerOptionModel { Answer = "24 timmar" };
            var a72hFel2 = new AnswerOptionModel { Answer = "48 timmar" };
            var a72hFel3 = new AnswerOptionModel { Answer = "7 dagar" };

            var aPersonuppgiftKorrekt = new AnswerOptionModel { Answer = "All information som direkt eller indirekt kan identifiera en levande person" };
            var aPersonuppgiftFel1 = new AnswerOptionModel { Answer = "Enbart namn och personnummer" };
            var aPersonuppgiftFel2 = new AnswerOptionModel { Answer = "Bara digitalt lagrad information" };
            var aPersonuppgiftFel3 = new AnswerOptionModel { Answer = "Enbart medicinsk och finansiell information" };

            var aNis2Korrekt = new AnswerOptionModel { Answer = "Stärka cybersäkerheten för kritisk infrastruktur och samhällsviktiga tjänster i EU" };
            var aNis2Fel1 = new AnswerOptionModel { Answer = "Reglera hantering av personuppgifter i EU" };
            var aNis2Fel2 = new AnswerOptionModel { Answer = "Standardisera mjukvaruutveckling inom EU" };
            var aNis2Fel3 = new AnswerOptionModel { Answer = "Reglera e-handel och digitala marknadsplatser" };

            var aIso27001Korrekt = new AnswerOptionModel { Answer = "En internationell standard för informationssäkerhetsledningssystem (ISMS)" };
            var aIso27001Fel1 = new AnswerOptionModel { Answer = "En EU-förordning om dataskydd" };
            var aIso27001Fel2 = new AnswerOptionModel { Answer = "En standard för programmeringsspråk" };
            var aIso27001Fel3 = new AnswerOptionModel { Answer = "En nätverksprotokollstandard" };

            var aIsmsKorrekt = new AnswerOptionModel { Answer = "Ett ramverk för att systematiskt hantera och skydda organisationens information" };
            var aIsmsFel1 = new AnswerOptionModel { Answer = "En typ av nästa generations brandvägg" };
            var aIsmsFel2 = new AnswerOptionModel { Answer = "Ett antivirusprogram för företag" };
            var aIsmsFel3 = new AnswerOptionModel { Answer = "En krypteringsstandard för e-post" };

            var aIrFaserKorrekt = new AnswerOptionModel { Answer = "Förberedelse, Identifiering, Inneslutning & Eliminering, Återhämtning, Utvärdering" };
            var aIrFaserFel1 = new AnswerOptionModel { Answer = "Attack, Försvar, Rapportering, Avslutning" };
            var aIrFaserFel2 = new AnswerOptionModel { Answer = "Planering, Genomförande, Testning, Driftsättning" };
            var aIrFaserFel3 = new AnswerOptionModel { Answer = "Detektering, Analys, Patchning, Loggning" };

            var aForensikKorrekt = new AnswerOptionModel { Answer = "Insamling och analys av digital bevisning efter en incident" };
            var aForensikFel1 = new AnswerOptionModel { Answer = "Förebyggande säkerhetsarbete mot intrång" };
            var aForensikFel2 = new AnswerOptionModel { Answer = "Kryptering av känslig data i realtid" };
            var aForensikFel3 = new AnswerOptionModel { Answer = "Nätverksövervakning för att detektera attacker" };

            var aRunbookKorrekt = new AnswerOptionModel { Answer = "Dokumentation med steg-för-steg-instruktioner för att hantera specifika incidenter" };
            var aRunbookFel1 = new AnswerOptionModel { Answer = "En lista över alla systemadministratörer" };
            var aRunbookFel2 = new AnswerOptionModel { Answer = "En brandväggskonfigurationsfil" };
            var aRunbookFel3 = new AnswerOptionModel { Answer = "En krypteringsnyckel för incidentdata" };

            // ── KATEGORIER & SUBKATEGORIER ───────────────────────────────────────

            var catNatverk = new CategoryModel { Name = "Nätverk", Description = "Grundläggande nätverkskoncept som TCP/IP, DNS, brandväggar och intrångsdetektering." };
            var catWebbsak = new CategoryModel { Name = "Webbsäkerhet", Description = "Säkerhetshot och skyddsmekanismer för webbapplikationer, inklusive OWASP Top 10." };
            var catKrypto = new CategoryModel { Name = "Kryptografi", Description = "Krypteringsmetoder, certifikat och hashningsalgoritmer för säker dataöverföring." };
            var catMalware = new CategoryModel { Name = "Malware & Attacker", Description = "Olika typer av skadlig kod, attackvektorer och social engineering." };
            var catOS = new CategoryModel { Name = "Operativsystem", Description = "Säkerhetsfunktioner i Linux och Windows samt hantering av behörigheter." };
            var catLagstiftning = new CategoryModel { Name = "Lagstiftning & Compliance", Description = "Regelverk och standarder som GDPR, NIS2, ISO 27001 och incident response." };

            var subTCPIP = new SubCategoryModel { Name = "TCP/IP-grunderna", Description = "OSI-modellen, TCP/IP-protokollet, portar och grundläggande nätverkskommunikation.", Order = 1, Category = catNatverk };
            var subDNS = new SubCategoryModel { Name = "DNS & DHCP", Description = "Namnupplösning, DHCP-tilldelning och relaterade säkerhetshot som DNS poisoning.", Order = 2, Category = catNatverk };
            var subBrandvaggar = new SubCategoryModel { Name = "Brandväggar & IDS/IPS", Description = "Brandväggstyper, intrångsdetektering och -prevention samt DMZ-konfiguration.", Order = 3, Category = catNatverk };

            var subOwasp = new SubCategoryModel { Name = "OWASP Top 10", Description = "De tio vanligaste säkerhetssårbarheterna i webbapplikationer enligt OWASP.", Order = 1, Category = catWebbsak };
            var subInjektioner = new SubCategoryModel { Name = "XSS & Injektioner", Description = "Cross-Site Scripting, SQL-injektion och andra injektionsattacker mot webbapplikationer.", Order = 2, Category = catWebbsak };
            var subAutentisering = new SubCategoryModel { Name = "Autentisering & Sessions", Description = "Sessionssäkerhet, CSRF, JWT och säker autentisering i webbapplikationer.", Order = 3, Category = catWebbsak };

            var subSymKrypto = new SubCategoryModel { Name = "Symmetrisk kryptering", Description = "AES, DES och andra symmetriska algoritmer för kryptering av data.", Order = 1, Category = catKrypto };
            var subAsymKrypto = new SubCategoryModel { Name = "Asymmetrisk kryptering & PKI", Description = "RSA, certifikat, PKI-infrastruktur och digital signering.", Order = 2, Category = catKrypto };
            var subHashning = new SubCategoryModel { Name = "Hashning", Description = "Hashfunktioner som SHA och MD5, salting och säker lösenordslagring.", Order = 3, Category = catKrypto };

            var subMalwaretyper = new SubCategoryModel { Name = "Malwaretyper", Description = "Virus, trojaner, ransomware, spyware och andra typer av skadlig kod.", Order = 1, Category = catMalware };
            var subAttackmetoder = new SubCategoryModel { Name = "Attackmetoder", Description = "DDoS, man-in-the-middle, zero-day-exploits och andra attacktekniker.", Order = 2, Category = catMalware };
            var subSocialEng = new SubCategoryModel { Name = "Social Engineering", Description = "Phishing, spear phishing, vishing och manipulation av människor.", Order = 3, Category = catMalware };

            var subLinux = new SubCategoryModel { Name = "Linux-säkerhet", Description = "Filrättigheter, sudo, chmod och säkerhetsfunktioner i Linux.", Order = 1, Category = catOS };
            var subWindows = new SubCategoryModel { Name = "Windows-säkerhet", Description = "Windows Defender, BitLocker, UAC och inbyggda säkerhetsfunktioner i Windows.", Order = 2, Category = catOS };
            var subBehorighet = new SubCategoryModel { Name = "Behörighetshantering", Description = "RBAC, PAM, autentisering, auktorisering och principen om minsta möjliga behörighet.", Order = 3, Category = catOS };

            var subGdpr = new SubCategoryModel { Name = "GDPR", Description = "Allmänna dataskyddsförordningen, personuppgifter och rapporteringskrav.", Order = 1, Category = catLagstiftning };
            var subNis2 = new SubCategoryModel { Name = "NIS2 & ISO 27001", Description = "EU:s nätverks- och informationssäkerhetsdirektiv samt ISO-standarden för informationssäkerhet.", Order = 2, Category = catLagstiftning };
            var subIncident = new SubCategoryModel { Name = "Incident Response", Description = "Hantering av säkerhetsincidenter, digital forensik och runbooks.", Order = 3, Category = catLagstiftning };

            // ── FRÅGOR ───────────────────────────────────────────────────────────

            // Nätverk: TCP/IP
            var qOsiIpLager = new QuestionModel { Question = "Vilket lager i OSI-modellen hanterar IP-adressering och routing?", Category = catNatverk, SubCategory = subTCPIP };
            var qHttpsPort = new QuestionModel { Question = "Vilken port använder HTTPS som standard?", Category = catNatverk, SubCategory = subTCPIP };
            var qSynPaket = new QuestionModel { Question = "Vad är ett SYN-paket i TCP?", Category = catNatverk, SubCategory = subTCPIP };

            // Nätverk: DNS & DHCP
            var qDnsVad = new QuestionModel { Question = "Vad är en DNS-servers primära uppgift?", Category = catNatverk, SubCategory = subDNS };
            var qDnsPort = new QuestionModel { Question = "Vilken port använder DNS normalt?", Category = catNatverk, SubCategory = subDNS };
            var qDnsPoison = new QuestionModel { Question = "Vad är DNS-förgiftning (DNS cache poisoning)?", Category = catNatverk, SubCategory = subDNS };

            // Nätverk: Brandväggar & IDS/IPS
            var qIdsVsIps = new QuestionModel { Question = "Vad är den viktigaste skillnaden mellan IDS och IPS?", Category = catNatverk, SubCategory = subBrandvaggar };
            var qStatefulFw = new QuestionModel { Question = "Vad kallas en brandvägg som inspekterar tillståndet i TCP-sessioner?", Category = catNatverk, SubCategory = subBrandvaggar };
            var qDmz = new QuestionModel { Question = "Vad är en DMZ (demilitariserad zon) i nätverkssäkerhet?", Category = catNatverk, SubCategory = subBrandvaggar };

            // Webbsäkerhet: OWASP
            var qOwaspVad = new QuestionModel { Question = "Vad står förkortningen OWASP för?", Category = catWebbsak, SubCategory = subOwasp };
            var qOwaspAccess = new QuestionModel { Question = "Vilket OWASP-problem innebär att angripare kan komma åt resurser de inte bör ha tillgång till?", Category = catWebbsak, SubCategory = subOwasp };
            var qOwaspMisconfig = new QuestionModel { Question = "Vad är 'Security Misconfiguration' enligt OWASP?", Category = catWebbsak, SubCategory = subOwasp };

            // Webbsäkerhet: XSS & Injektioner
            var qXssVad = new QuestionModel { Question = "Vad är Cross-Site Scripting (XSS)?", Category = catWebbsak, SubCategory = subInjektioner };
            var qSqlVad = new QuestionModel { Question = "Vad är SQL-injektion?", Category = catWebbsak, SubCategory = subInjektioner };
            var qSqlSkydd = new QuestionModel { Question = "Vilken teknik är mest effektiv för att skydda mot SQL-injektion?", Category = catWebbsak, SubCategory = subInjektioner };

            // Webbsäkerhet: Autentisering & Sessions
            var qMfaVad = new QuestionModel { Question = "Vad är multi-faktorautentisering (MFA)?", Category = catWebbsak, SubCategory = subAutentisering };
            var qSessionHijack = new QuestionModel { Question = "Vad är session hijacking?", Category = catWebbsak, SubCategory = subAutentisering };
            var qCsrf = new QuestionModel { Question = "Vad är en CSRF-attack (Cross-Site Request Forgery)?", Category = catWebbsak, SubCategory = subAutentisering };

            // Kryptografi: Symmetrisk
            var qSymVad = new QuestionModel { Question = "Vad kännetecknar symmetrisk kryptering?", Category = catKrypto, SubCategory = subSymKrypto };
            var qSymExempel = new QuestionModel { Question = "Vilket är ett exempel på en symmetrisk krypteringsalgoritm?", Category = catKrypto, SubCategory = subSymKrypto };
            var qAesBetyd = new QuestionModel { Question = "Vad står AES för?", Category = catKrypto, SubCategory = subSymKrypto };

            // Kryptografi: Asymmetrisk & PKI
            var qAsymVad = new QuestionModel { Question = "Vad är asymmetrisk kryptering?", Category = catKrypto, SubCategory = subAsymKrypto };
            var qPrivatNyckel = new QuestionModel { Question = "Vad används den privata nyckeln till i asymmetrisk kryptering?", Category = catKrypto, SubCategory = subAsymKrypto };
            var qCertifikat = new QuestionModel { Question = "Vad är ett digitalt certifikat?", Category = catKrypto, SubCategory = subAsymKrypto };

            // Kryptografi: Hashning
            var qHashVad = new QuestionModel { Question = "Vad är en kryptografisk hashfunktion?", Category = catKrypto, SubCategory = subHashning };
            var qHashEgenskap = new QuestionModel { Question = "Vilken egenskap är avgörande för en kryptografisk hashfunktion?", Category = catKrypto, SubCategory = subHashning };
            var qHashExempel = new QuestionModel { Question = "Vilket är ett exempel på en kryptografisk hashalgoritm?", Category = catKrypto, SubCategory = subHashning };

            // Malware: Malwaretyper
            var qRansomVad = new QuestionModel { Question = "Vad är ransomware?", Category = catMalware, SubCategory = subMalwaretyper };
            var qTrojanVad = new QuestionModel { Question = "Vad är en trojansk häst (trojan)?", Category = catMalware, SubCategory = subMalwaretyper };
            var qWormVad = new QuestionModel { Question = "Vad skiljer en mask (worm) från ett vanligt virus?", Category = catMalware, SubCategory = subMalwaretyper };

            // Malware: Attackmetoder
            var qDdosVad = new QuestionModel { Question = "Vad är en DDoS-attack?", Category = catMalware, SubCategory = subAttackmetoder };
            var qMitmVad = new QuestionModel { Question = "Vad är en man-in-the-middle-attack (MitM)?", Category = catMalware, SubCategory = subAttackmetoder };
            var qZerodayVad = new QuestionModel { Question = "Vad är ett zero-day-exploit?", Category = catMalware, SubCategory = subAttackmetoder };

            // Malware: Social Engineering
            var qPhishVad = new QuestionModel { Question = "Vad är phishing?", Category = catMalware, SubCategory = subSocialEng };
            var qSpearVad = new QuestionModel { Question = "Vad är spear phishing?", Category = catMalware, SubCategory = subSocialEng };
            var qVishingVad = new QuestionModel { Question = "Vad är vishing?", Category = catMalware, SubCategory = subSocialEng };

            // OS: Linux
            var qChmodVad = new QuestionModel { Question = "Vad gör kommandot chmod i Linux?", Category = catOS, SubCategory = subLinux };
            var qLeastPriv = new QuestionModel { Question = "Vad innebär principen om minsta möjliga behörighet (Principle of Least Privilege)?", Category = catOS, SubCategory = subLinux };
            var qSudoVad = new QuestionModel { Question = "Vad gör kommandot sudo i Linux?", Category = catOS, SubCategory = subLinux };

            // OS: Windows
            var qDefenderVad = new QuestionModel { Question = "Vad är Windows Defender?", Category = catOS, SubCategory = subWindows };
            var qBitlockerVad = new QuestionModel { Question = "Vad är BitLocker?", Category = catOS, SubCategory = subWindows };
            var qUacVad = new QuestionModel { Question = "Vad är UAC (User Account Control) i Windows?", Category = catOS, SubCategory = subWindows };

            // OS: Behörighet
            var qRbacVad = new QuestionModel { Question = "Vad är RBAC (Role-Based Access Control)?", Category = catOS, SubCategory = subBehorighet };
            var qAutnVsAutz = new QuestionModel { Question = "Vad är skillnaden mellan autentisering och auktorisering?", Category = catOS, SubCategory = subBehorighet };
            var qPamVad = new QuestionModel { Question = "Vad är ett PAM-system (Privileged Access Management)?", Category = catOS, SubCategory = subBehorighet };

            // Lagstiftning: GDPR
            var qGdprVad = new QuestionModel { Question = "Vad står GDPR för?", Category = catLagstiftning, SubCategory = subGdpr };
            var qGdpr72h = new QuestionModel { Question = "Inom hur många timmar måste en personuppgiftsincident rapporteras enligt GDPR?", Category = catLagstiftning, SubCategory = subGdpr };
            var qPersonuppgift = new QuestionModel { Question = "Vad räknas som en personuppgift enligt GDPR?", Category = catLagstiftning, SubCategory = subGdpr };

            // Lagstiftning: NIS2 & ISO 27001
            var qNis2Syfte = new QuestionModel { Question = "Vad är syftet med NIS2-direktivet?", Category = catLagstiftning, SubCategory = subNis2 };
            var qIso27001Vad = new QuestionModel { Question = "Vad är ISO 27001?", Category = catLagstiftning, SubCategory = subNis2 };
            var qIsmsVad = new QuestionModel { Question = "Vad är ett ISMS?", Category = catLagstiftning, SubCategory = subNis2 };

            // Lagstiftning: Incident Response
            var qIrFaser = new QuestionModel { Question = "Vilka är huvudfaserna i incident response-processen?", Category = catLagstiftning, SubCategory = subIncident };
            var qForensik = new QuestionModel { Question = "Vad är digital forensik inom cybersäkerhet?", Category = catLagstiftning, SubCategory = subIncident };
            var qRunbook = new QuestionModel { Question = "Vad är en runbook inom incident response?", Category = catLagstiftning, SubCategory = subIncident };

            // ── FRÅGA ↔ SVARSALTERNATIV ──────────────────────────────────────────

            context.QuestionAnswerOptions.AddRange(

                // OSI-lager för IP
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aNatverkslager, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aDatalankslager, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aTransportlager, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aSessionslager, IsCorrect = false },

                // HTTPS-port
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort443, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort80, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort8080, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort22, IsCorrect = false },

                // SYN-paket
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynForklaring, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynFel3, IsCorrect = false },

                // DNS uppgift
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsFel3, IsCorrect = false },

                // DNS-port
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort53, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort80, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort25, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort110, IsCorrect = false },

                // DNS poisoning
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonFel3, IsCorrect = false },

                // IDS vs IPS
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsFel3, IsCorrect = false },

                // Stateful firewall
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulFel3, IsCorrect = false },

                // DMZ
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzFel3, IsCorrect = false },

                // OWASP
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspFel3, IsCorrect = false },

                // Broken Access Control
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessFel3, IsCorrect = false },

                // Security Misconfiguration
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigFel3, IsCorrect = false },

                // XSS
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssFel3, IsCorrect = false },

                // SQL-injektion
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlFel3, IsCorrect = false },

                // SQL-skydd
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedFel3, IsCorrect = false },

                // MFA
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaFel3, IsCorrect = false },

                // Session hijacking
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionFel3, IsCorrect = false },

                // CSRF
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfFel3, IsCorrect = false },

                // Symmetrisk kryptering
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymFel3, IsCorrect = false },

                // Symmetrisk exempel
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesFel3, IsCorrect = false },

                // AES betydelse
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydFel3, IsCorrect = false },

                // Asymmetrisk kryptering
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymFel3, IsCorrect = false },

                // Privat nyckel
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatFel3, IsCorrect = false },

                // Digitalt certifikat
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertFel3, IsCorrect = false },

                // Hash-funktion
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashFel3, IsCorrect = false },

                // Hash-egenskap
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagFel3, IsCorrect = false },

                // Hash-exempel
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaFel3, IsCorrect = false },

                // Ransomware
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomFel3, IsCorrect = false },

                // Trojan
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanFel3, IsCorrect = false },

                // Worm
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormFel3, IsCorrect = false },

                // DDoS
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosFel3, IsCorrect = false },

                // MitM
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmFel3, IsCorrect = false },

                // Zero-day
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayFel3, IsCorrect = false },

                // Phishing
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishFel3, IsCorrect = false },

                // Spear phishing
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearFel3, IsCorrect = false },

                // Vishing
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingFel3, IsCorrect = false },

                // chmod
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodFel3, IsCorrect = false },

                // Least privilege
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivFel3, IsCorrect = false },

                // sudo
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoFel3, IsCorrect = false },

                // Windows Defender
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderFel3, IsCorrect = false },

                // BitLocker
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerFel3, IsCorrect = false },

                // UAC
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacFel3, IsCorrect = false },

                // RBAC
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aLeastPrivKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aUacKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aSudoKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = new AnswerOptionModel { Answer = "Åtkomstkontroll där behörigheter tilldelas baserat på användarens roll i organisationen" }, IsCorrect = true },

                // Autentisering vs Auktorisering
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = new AnswerOptionModel { Answer = "Autentisering verifierar vem du är, auktorisering avgör vad du får göra" }, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = new AnswerOptionModel { Answer = "De är synonymer och betyder samma sak" }, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = new AnswerOptionModel { Answer = "Autentisering avgör vad du får göra, auktorisering verifierar vem du är" }, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = new AnswerOptionModel { Answer = "Autentisering gäller maskiner, auktorisering gäller människor" }, IsCorrect = false },

                // PAM
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = new AnswerOptionModel { Answer = "Ett system för att kontrollera och övervaka åtkomst till privilegierade konton" }, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = new AnswerOptionModel { Answer = "En typ av nästa generations brandvägg" }, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = new AnswerOptionModel { Answer = "En krypteringsalgoritm för administratörslösenord" }, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = new AnswerOptionModel { Answer = "En antiviruslösning för servrar" }, IsCorrect = false },

                // GDPR
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprFel3, IsCorrect = false },

                // GDPR 72h
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hFel3, IsCorrect = false },

                // Personuppgift
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftFel3, IsCorrect = false },

                // NIS2
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Fel3, IsCorrect = false },

                // ISO 27001
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Fel3, IsCorrect = false },

                // ISMS
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsFel3, IsCorrect = false },

                // IR-faser
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserFel3, IsCorrect = false },

                // Forensik
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikFel3, IsCorrect = false },

                // Runbook
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel3, IsCorrect = false }
            );

            await context.SaveChangesAsync();
        }
    }
}
