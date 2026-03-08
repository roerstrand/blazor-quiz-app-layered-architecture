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

            var aRbacKorrekt = new AnswerOptionModel { Answer = "Åtkomstkontroll där behörigheter tilldelas baserat på användarens roll i organisationen" };

            var aAutnVsAutzKorrekt = new AnswerOptionModel { Answer = "Autentisering verifierar vem du är, auktorisering avgör vad du får göra" };
            var aAutnVsAutzFel1 = new AnswerOptionModel { Answer = "De är synonymer och betyder samma sak" };
            var aAutnVsAutzFel2 = new AnswerOptionModel { Answer = "Autentisering avgör vad du får göra, auktorisering verifierar vem du är" };
            var aAutnVsAutzFel3 = new AnswerOptionModel { Answer = "Autentisering gäller maskiner, auktorisering gäller människor" };

            var aPamKorrekt = new AnswerOptionModel { Answer = "Ett system för att kontrollera och övervaka åtkomst till privilegierade konton" };
            var aPamFel1 = new AnswerOptionModel { Answer = "En typ av nästa generations brandvägg" };
            var aPamFel2 = new AnswerOptionModel { Answer = "En krypteringsalgoritm för administratörslösenord" };
            var aPamFel3 = new AnswerOptionModel { Answer = "En antiviruslösning för servrar" };

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

            // Tillagda svarsalternativ för extra frågor

            // TCP/IP extra
            var aUdpKorrekt = new AnswerOptionModel { Answer = "UDP är anslutningslöst och erbjuder ingen garanterad leverans, till skillnad från TCPs sessionshantering" };
            var aUdpFel1 = new AnswerOptionModel { Answer = "UDP är säkrare än TCP men långsammare" };
            var aUdpFel2 = new AnswerOptionModel { Answer = "UDP och TCP är identiska protokoll" };
            var aUdpFel3 = new AnswerOptionModel { Answer = "UDP garanterar leveransordning men inte säkerhet" };

            var aIpv4v6Korrekt = new AnswerOptionModel { Answer = "IPv4 använder 32-bitarsadresser, IPv6 använder 128-bitarsadresser och erbjuder fler adresser" };
            var aIpv4v6Fel1 = new AnswerOptionModel { Answer = "IPv6 är äldre än IPv4 och har färre adresser" };
            var aIpv4v6Fel2 = new AnswerOptionModel { Answer = "IPv4 och IPv6 är kompatibla och fungerar identiskt" };
            var aIpv4v6Fel3 = new AnswerOptionModel { Answer = "IPv6 använder 64-bitarsadresser och ersätter MAC-adresser" };

            // DNS & DHCP extra
            var aDhcpKorrekt = new AnswerOptionModel { Answer = "Tilldelar IP-adresser automatiskt till enheter i ett nätverk" };
            var aDhcpFel1 = new AnswerOptionModel { Answer = "Översätter domännamn till IP-adresser" };
            var aDhcpFel2 = new AnswerOptionModel { Answer = "Krypterar nätverkstrafik automatiskt" };
            var aDhcpFel3 = new AnswerOptionModel { Answer = "Filtrerar oönskad nätverkstrafik" };

            var aApostKorrekt = new AnswerOptionModel { Answer = "A-post pekar på en IPv4-adress, AAAA-post pekar på en IPv6-adress" };
            var aApostFel1 = new AnswerOptionModel { Answer = "A-post och AAAA-post är synonymer för MX-poster" };
            var aApostFel2 = new AnswerOptionModel { Answer = "A-post gäller e-post, AAAA-post gäller webbservrar" };
            var aApostFel3 = new AnswerOptionModel { Answer = "AAAA-post är en äldre version av A-post" };

            // Brandväggar extra
            var aWafKorrekt = new AnswerOptionModel { Answer = "En brandvägg som analyserar HTTP-trafik och skyddar webbapplikationer mot attacker som XSS och SQLi" };
            var aWafFel1 = new AnswerOptionModel { Answer = "En brandvägg som skyddar trådlösa nätverk" };
            var aWafFel2 = new AnswerOptionModel { Answer = "En brandvägg som enbart filtrerar IP-adresser" };
            var aWafFel3 = new AnswerOptionModel { Answer = "En programvara för att övervaka e-posttrafik" };

            var aPaketfiltreringKorrekt = new AnswerOptionModel { Answer = "Nätverkslager (Layer 3)" };
            var aPaketfiltreringFel1 = new AnswerOptionModel { Answer = "Applikationslager (Layer 7)" };
            var aPaketfiltreringFel2 = new AnswerOptionModel { Answer = "Transportlager (Layer 4)" };
            var aPaketfiltreringFel3 = new AnswerOptionModel { Answer = "Datalänklager (Layer 2)" };

            // OWASP extra
            var aInjectionKorrekt = new AnswerOptionModel { Answer = "Skadlig data skickas till en tolk (t.ex. SQL, LDAP) och exekveras som kommandon" };
            var aInjectionFel1 = new AnswerOptionModel { Answer = "Angriparen injicerar kod via nätverkspacket" };
            var aInjectionFel2 = new AnswerOptionModel { Answer = "En attack som injicerar virus i operativsystemet" };
            var aInjectionFel3 = new AnswerOptionModel { Answer = "Obehörig åtkomst till databaser via svaga lösenord" };

            var aInsecureDesignKorrekt = new AnswerOptionModel { Answer = "Säkerhetsbrister som beror på dålig design och arkitektur snarare än implementationsfel" };
            var aInsecureDesignFel1 = new AnswerOptionModel { Answer = "Felaktig konfiguration av webbservern" };
            var aInsecureDesignFel2 = new AnswerOptionModel { Answer = "Användning av föråldrade krypteringsalgoritmer" };
            var aInsecureDesignFel3 = new AnswerOptionModel { Answer = "Bristande loggning och övervakning" };

            // XSS & Injektioner extra
            var aXssTyperKorrekt = new AnswerOptionModel { Answer = "Stored XSS, Reflected XSS och DOM-based XSS" };
            var aXssTyperFel1 = new AnswerOptionModel { Answer = "SQL XSS, HTTP XSS och LDAP XSS" };
            var aXssTyperFel2 = new AnswerOptionModel { Answer = "Active XSS, Passive XSS och Hybrid XSS" };
            var aXssTyperFel3 = new AnswerOptionModel { Answer = "Client XSS, Server XSS och Network XSS" };

            var aLdapKorrekt = new AnswerOptionModel { Answer = "Skadliga LDAP-frågor injiceras via inmatningsfält för att manipulera katalogtjänster" };
            var aLdapFel1 = new AnswerOptionModel { Answer = "En attack som injicerar kod i HTTPS-certifikat" };
            var aLdapFel2 = new AnswerOptionModel { Answer = "En attack mot DNS-servrar via LDAP-protokollet" };
            var aLdapFel3 = new AnswerOptionModel { Answer = "En metod för att kringgå LDAP-autentisering med brute force" };

            // Autentisering & Sessions extra
            var aJwtKorrekt = new AnswerOptionModel { Answer = "En öppen standard för att säkert överföra information som JSON-objekt signerade med en nyckel" };
            var aJwtFel1 = new AnswerOptionModel { Answer = "En krypteringsstandard för HTTP-cookies" };
            var aJwtFel2 = new AnswerOptionModel { Answer = "En protokoll för lösenordshashning" };
            var aJwtFel3 = new AnswerOptionModel { Answer = "En databas för sessionshantering" };

            var aCsrfSkyddKorrekt = new AnswerOptionModel { Answer = "CSRF-tokens (synkroniseringstokens) som valideras vid varje förfrågan" };
            var aCsrfSkyddFel1 = new AnswerOptionModel { Answer = "HTTPS-kryptering av alla förfrågningar" };
            var aCsrfSkyddFel2 = new AnswerOptionModel { Answer = "SQL prepared statements" };
            var aCsrfSkyddFel3 = new AnswerOptionModel { Answer = "Content Security Policy (CSP)" };

            // Symmetrisk kryptering extra
            var aAesNyckelKorrekt = new AnswerOptionModel { Answer = "128, 192 eller 256 bitar — varav AES-256 ger starkast skydd" };
            var aAesNyckelFel1 = new AnswerOptionModel { Answer = "64 bitar är den rekommenderade minimumnivån" };
            var aAesNyckelFel2 = new AnswerOptionModel { Answer = "512 bitar är standard för AES" };
            var aAesNyckelFel3 = new AnswerOptionModel { Answer = "AES använder inga nycklar" };

            var aDesKorrekt = new AnswerOptionModel { Answer = "Data Encryption Standard — en äldre 56-bitars algoritm som anses osäker på grund av för kort nyckellängd" };
            var aDesFel1 = new AnswerOptionModel { Answer = "Digital Encryption System — en modern ersättare till AES" };
            var aDesFel2 = new AnswerOptionModel { Answer = "En asymmetrisk krypteringsstandard med 128-bitars nycklar" };
            var aDesFel3 = new AnswerOptionModel { Answer = "En hashalgoritm för lösenord utvecklad av NSA" };

            // Asymmetrisk kryptering extra
            var aRsaKorrekt = new AnswerOptionModel { Answer = "En asymmetrisk krypteringsalgoritm baserad på faktorisering av stora primtal" };
            var aRsaFel1 = new AnswerOptionModel { Answer = "En symmetrisk krypteringsalgoritm med variabel nyckellängd" };
            var aRsaFel2 = new AnswerOptionModel { Answer = "En hashalgoritm för digitala signaturer" };
            var aRsaFel3 = new AnswerOptionModel { Answer = "En protokoll för säker nyckelutbyte utan kryptering" };

            var aCaKorrekt = new AnswerOptionModel { Answer = "En betrodd organisation som utfärdar och signerar digitala certifikat" };
            var aCaFel1 = new AnswerOptionModel { Answer = "En algoritm för att generera kryptografiska nycklar" };
            var aCaFel2 = new AnswerOptionModel { Answer = "En databas för att lagra privata nycklar" };
            var aCaFel3 = new AnswerOptionModel { Answer = "En server som hanterar TLS-handskakningar" };

            // Hashning extra
            var aSaltingKorrekt = new AnswerOptionModel { Answer = "Slumpmässig data läggs till lösenordet innan hashning för att förhindra regnbågstabeller" };
            var aSaltingFel1 = new AnswerOptionModel { Answer = "Lösenordet krypteras med en hemlig nyckel innan lagring" };
            var aSaltingFel2 = new AnswerOptionModel { Answer = "Lösenordet hashas flera gånger för att göra det längre" };
            var aSaltingFel3 = new AnswerOptionModel { Answer = "En teknik för att komprimera hashvärden" };

            var aMd5Korrekt = new AnswerOptionModel { Answer = "MD5 har kända kollisioner och är för snabb, vilket gör brute-force-attacker effektiva" };
            var aMd5Fel1 = new AnswerOptionModel { Answer = "MD5 producerar för långa hashvärden för praktisk användning" };
            var aMd5Fel2 = new AnswerOptionModel { Answer = "MD5 är patentskyddat och får inte användas fritt" };
            var aMd5Fel3 = new AnswerOptionModel { Answer = "MD5 är för långsam för moderna system" };

            // Malwaretyper extra
            var aSpywareKorrekt = new AnswerOptionModel { Answer = "Programvara som i hemlighet samlar in information om användaren och skickar den till tredje part" };
            var aSpywareFel1 = new AnswerOptionModel { Answer = "Programvara som blockerar åtkomst till filer tills en lösensumma betalas" };
            var aSpywareFel2 = new AnswerOptionModel { Answer = "Programvara som sprider sig automatiskt i nätverk" };
            var aSpywareFel3 = new AnswerOptionModel { Answer = "Programvara som visar oönskade annonser" };

            var aRootkitKorrekt = new AnswerOptionModel { Answer = "Skadlig programvara som döljer sin närvaro och ger angriparen administratörskontroll" };
            var aRootkitFel1 = new AnswerOptionModel { Answer = "Ett verktyg för att återställa root-lösenordet i Linux" };
            var aRootkitFel2 = new AnswerOptionModel { Answer = "En typ av ransomware som krypterar root-partitionen" };
            var aRootkitFel3 = new AnswerOptionModel { Answer = "En brandväggstyp för skydd mot Linux-attacker" };

            // Attackmetoder extra
            var aBotnatKorrekt = new AnswerOptionModel { Answer = "Ett nätverk av komprometterade datorer (bots) som kontrolleras av en angripare" };
            var aBotnatFel1 = new AnswerOptionModel { Answer = "En typ av krypterat nätverk för säker kommunikation" };
            var aBotnatFel2 = new AnswerOptionModel { Answer = "En nätverkstopologi för distribuerade system" };
            var aBotnatFel3 = new AnswerOptionModel { Answer = "En teknik för att balansera nätverkstrafik" };

            var aBruteForceKorrekt = new AnswerOptionModel { Answer = "En attack som systematiskt provar alla möjliga kombinationer av lösenord tills rätt hittas" };
            var aBruteForceFel1 = new AnswerOptionModel { Answer = "En attack som utnyttjar kända sårbarheter i programvara" };
            var aBruteForceFel2 = new AnswerOptionModel { Answer = "En attack som manipulerar DNS-poster" };
            var aBruteForceFel3 = new AnswerOptionModel { Answer = "En attack som avlyssnar krypterad nätverkstrafik" };

            // Social Engineering extra
            var aSmishingKorrekt = new AnswerOptionModel { Answer = "Phishing via SMS-meddelanden" };
            var aSmishingFel1 = new AnswerOptionModel { Answer = "Phishing via e-post" };
            var aSmishingFel2 = new AnswerOptionModel { Answer = "Phishing via telefon" };
            var aSmishingFel3 = new AnswerOptionModel { Answer = "Phishing via sociala medier" };

            var aPretextingKorrekt = new AnswerOptionModel { Answer = "Angriparen skapar ett falskt scenario (pretext) för att lura offret att lämna ut information" };
            var aPretextingFel1 = new AnswerOptionModel { Answer = "Angriparen lämnar ett infekterat USB-minne på en offentlig plats" };
            var aPretextingFel2 = new AnswerOptionModel { Answer = "Angriparen skickar mass-e-post med skadliga bilagor" };
            var aPretextingFel3 = new AnswerOptionModel { Answer = "Angriparen avlyssnar offentliga Wi-Fi-nätverk" };

            // Linux-säkerhet extra
            var aChownKorrekt = new AnswerOptionModel { Answer = "Ändrar ägaren eller gruppen för en fil eller katalog" };
            var aChownFel1 = new AnswerOptionModel { Answer = "Ändrar filbehörigheter (läs, skriv, kör)" };
            var aChownFel2 = new AnswerOptionModel { Answer = "Skapar en ny användare i Linux" };
            var aChownFel3 = new AnswerOptionModel { Answer = "Visar diskutrymme för filer och kataloger" };

            var aSelinuxKorrekt = new AnswerOptionModel { Answer = "Security-Enhanced Linux — ett säkerhetsramverk med obligatorisk åtkomstkontroll (MAC)" };
            var aSelinuxFel1 = new AnswerOptionModel { Answer = "En antiviruslösning för Linux-servrar" };
            var aSelinuxFel2 = new AnswerOptionModel { Answer = "En krypteringsmodul för Linux-filsystem" };
            var aSelinuxFel3 = new AnswerOptionModel { Answer = "En brandväggskonfiguration för Linux" };

            // Windows-säkerhet extra
            var aEventLogKorrekt = new AnswerOptionModel { Answer = "Windowsverktyg för att registrera system-, säkerhets- och applikationshändelser för felsökning och revision" };
            var aEventLogFel1 = new AnswerOptionModel { Answer = "En tjänst för automatisk uppdatering av Windows" };
            var aEventLogFel2 = new AnswerOptionModel { Answer = "En databas för lagring av användarlösenord" };
            var aEventLogFel3 = new AnswerOptionModel { Answer = "En inbyggd brandväggsfunktion i Windows" };

            var aApplockerKorrekt = new AnswerOptionModel { Answer = "En Windows-funktion som styr vilka program som får köras baserat på regler" };
            var aApplockerFel1 = new AnswerOptionModel { Answer = "En antiviruslösning som blockerar skadlig kod i realtid" };
            var aApplockerFel2 = new AnswerOptionModel { Answer = "En funktion för att kryptera enskilda program" };
            var aApplockerFel3 = new AnswerOptionModel { Answer = "En inbyggd lösenordshanterare i Windows" };

            // Behörighetshantering extra
            var aMfaBehKorrekt = new AnswerOptionModel { Answer = "Det kräver att angripare komprometterar flera faktorer för att få åtkomst, vilket kraftigt minskar risken" };
            var aMfaBehFel1 = new AnswerOptionModel { Answer = "Det eliminerar behovet av lösenord helt" };
            var aMfaBehFel2 = new AnswerOptionModel { Answer = "Det ökar inloggningstiden men har inga säkerhetsfördelar" };
            var aMfaBehFel3 = new AnswerOptionModel { Answer = "Det gäller bara för administrativa konton" };

            var aZeroTrustKorrekt = new AnswerOptionModel { Answer = "Ingen användare eller enhet litas på automatiskt — all åtkomst verifieras kontinuerligt oavsett position" };
            var aZeroTrustFel1 = new AnswerOptionModel { Answer = "Interna nätverksanvändare litas på automatiskt utan verifiering" };
            var aZeroTrustFel2 = new AnswerOptionModel { Answer = "En modell där alla användare ges noll behörigheter som standard" };
            var aZeroTrustFel3 = new AnswerOptionModel { Answer = "Ett system där brandväggar hanterar all autentisering" };

            // GDPR extra
            var aRaderingKorrekt = new AnswerOptionModel { Answer = "Rätten för en person att begära att deras personuppgifter raderas under vissa omständigheter" };
            var aRaderingFel1 = new AnswerOptionModel { Answer = "Skyldigheten för företag att radera data efter 5 år automatiskt" };
            var aRaderingFel2 = new AnswerOptionModel { Answer = "Rätten att radera andra personers uppgifter" };
            var aRaderingFel3 = new AnswerOptionModel { Answer = "En teknik för säker radering av krypterade filer" };

            var aPersonuppgiftsansvarigKorrekt = new AnswerOptionModel { Answer = "Den organisation eller person som bestämmer syfte och medel för behandling av personuppgifter" };
            var aPersonuppgiftsansvarigFel1 = new AnswerOptionModel { Answer = "En person utsedd av myndigheter för att övervaka GDPR-efterlevnad" };
            var aPersonuppgiftsansvarigFel2 = new AnswerOptionModel { Answer = "En tredje part som behandlar personuppgifter på uppdrag av ett företag" };
            var aPersonuppgiftsansvarigFel3 = new AnswerOptionModel { Answer = "Den person vars personuppgifter behandlas" };

            // NIS2 & ISO 27001 extra
            var aNis2OmfattasKorrekt = new AnswerOptionModel { Answer = "Medelstora och stora organisationer inom kritiska sektorer som energi, transport och hälso- och sjukvård" };
            var aNis2OmfattasFel1 = new AnswerOptionModel { Answer = "Enbart statliga myndigheter och offentliga organisationer" };
            var aNis2OmfattasFel2 = new AnswerOptionModel { Answer = "Alla företag med fler än 10 anställda inom EU" };
            var aNis2OmfattasFel3 = new AnswerOptionModel { Answer = "Bara IT-företag och teknikleverantörer" };

            var aIso27001CertKorrekt = new AnswerOptionModel { Answer = "Organisationen har implementerat och efterlever ett dokumenterat ledningssystem för informationssäkerhet" };
            var aIso27001CertFel1 = new AnswerOptionModel { Answer = "Organisationen är undantagen från GDPR-krav" };
            var aIso27001CertFel2 = new AnswerOptionModel { Answer = "Organisationens IT-system godkänts av EU-kommissionen" };
            var aIso27001CertFel3 = new AnswerOptionModel { Answer = "Organisationen garanteras fri från cyberattacker" };

            // Incident Response extra
            var aInneslutningKorrekt = new AnswerOptionModel { Answer = "Att begränsa incidentens spridning och isolera påverkade system för att förhindra ytterligare skada" };
            var aInneslutningFel1 = new AnswerOptionModel { Answer = "Att ta bort all skadlig kod från drabbade system" };
            var aInneslutningFel2 = new AnswerOptionModel { Answer = "Att dokumentera incidenten för juridiska ändamål" };
            var aInneslutningFel3 = new AnswerOptionModel { Answer = "Att återställa systemen till normaldrift" };

            var aChainOfCustodyKorrekt = new AnswerOptionModel { Answer = "Dokumentation av vem som hanterat digital bevisning, när och hur, för att säkerställa bevisningens integritet" };
            var aChainOfCustodyFel1 = new AnswerOptionModel { Answer = "En lista över alla system som påverkats av en incident" };
            var aChainOfCustodyFel2 = new AnswerOptionModel { Answer = "En metod för att kryptera digital bevisning" };
            var aChainOfCustodyFel3 = new AnswerOptionModel { Answer = "En protokoll för kommunikation under incidenthantering" };

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

            // Tillagda frågor (Q4 och Q5 per subkategori)

            // TCP/IP-grunderna extra
            var qUdpVad = new QuestionModel { Question = "Vad är UDP och hur skiljer det sig från TCP?", Category = catNatverk, SubCategory = subTCPIP };
            var qIpv4v6 = new QuestionModel { Question = "Vad är den viktigaste skillnaden mellan IPv4 och IPv6?", Category = catNatverk, SubCategory = subTCPIP };

            // DNS & DHCP extra
            var qDhcpVad = new QuestionModel { Question = "Vad är DHCP och vad används det till?", Category = catNatverk, SubCategory = subDNS };
            var qDnsApost = new QuestionModel { Question = "Vad är skillnaden mellan en A-post och en AAAA-post i DNS?", Category = catNatverk, SubCategory = subDNS };

            // Brandväggar & IDS/IPS extra
            var qWafVad = new QuestionModel { Question = "Vad är en WAF (Web Application Firewall)?", Category = catNatverk, SubCategory = subBrandvaggar };
            var qPaketfiltrering = new QuestionModel { Question = "Vilket OSI-lager arbetar en paketfiltrerande brandvägg primärt på?", Category = catNatverk, SubCategory = subBrandvaggar };

            // OWASP Top 10 extra
            var qOwaspInjection = new QuestionModel { Question = "Vad innebär 'Injection' i OWASP Top 10?", Category = catWebbsak, SubCategory = subOwasp };
            var qOwaspInsecureDesign = new QuestionModel { Question = "Vad är 'Insecure Design' enligt OWASP Top 10?", Category = catWebbsak, SubCategory = subOwasp };

            // XSS & Injektioner extra
            var qXssTyper = new QuestionModel { Question = "Vilka tre typer av XSS-attacker finns det?", Category = catWebbsak, SubCategory = subInjektioner };
            var qLdapInjektion = new QuestionModel { Question = "Vad är LDAP-injektion?", Category = catWebbsak, SubCategory = subInjektioner };

            // Autentisering & Sessions extra
            var qJwtVad = new QuestionModel { Question = "Vad är ett JWT (JSON Web Token)?", Category = catWebbsak, SubCategory = subAutentisering };
            var qCsrfSkydd = new QuestionModel { Question = "Vilken teknik är mest effektiv för att skydda mot CSRF-attacker?", Category = catWebbsak, SubCategory = subAutentisering };

            // Symmetrisk kryptering extra
            var qAesNyckel = new QuestionModel { Question = "Vilka nyckellängder stöder AES och vilken rekommenderas?", Category = catKrypto, SubCategory = subSymKrypto };
            var qDesVad = new QuestionModel { Question = "Vad är DES och varför anses det inte längre säkert?", Category = catKrypto, SubCategory = subSymKrypto };

            // Asymmetrisk kryptering & PKI extra
            var qRsaVad = new QuestionModel { Question = "Vad är RSA?", Category = catKrypto, SubCategory = subAsymKrypto };
            var qCaVad = new QuestionModel { Question = "Vad är en CA (Certificate Authority)?", Category = catKrypto, SubCategory = subAsymKrypto };

            // Hashning extra
            var qSaltingVad = new QuestionModel { Question = "Vad är 'salting' vid lagring av lösenord?", Category = catKrypto, SubCategory = subHashning };
            var qMd5Varfor = new QuestionModel { Question = "Varför rekommenderas inte MD5 för säkerhetsändamål?", Category = catKrypto, SubCategory = subHashning };

            // Malwaretyper extra
            var qSpywareVad = new QuestionModel { Question = "Vad är spyware?", Category = catMalware, SubCategory = subMalwaretyper };
            var qRootkitVad = new QuestionModel { Question = "Vad är ett rootkit?", Category = catMalware, SubCategory = subMalwaretyper };

            // Attackmetoder extra
            var qBotnatVad = new QuestionModel { Question = "Vad är ett botnät?", Category = catMalware, SubCategory = subAttackmetoder };
            var qBruteForce = new QuestionModel { Question = "Vad är en brute-force-attack?", Category = catMalware, SubCategory = subAttackmetoder };

            // Social Engineering extra
            var qSmishingVad = new QuestionModel { Question = "Vad är smishing?", Category = catMalware, SubCategory = subSocialEng };
            var qPretexting = new QuestionModel { Question = "Vad är pretexting inom social engineering?", Category = catMalware, SubCategory = subSocialEng };

            // Linux-säkerhet extra
            var qChownVad = new QuestionModel { Question = "Vad gör kommandot chown i Linux?", Category = catOS, SubCategory = subLinux };
            var qSelinuxVad = new QuestionModel { Question = "Vad är SELinux?", Category = catOS, SubCategory = subLinux };

            // Windows-säkerhet extra
            var qEventLogVad = new QuestionModel { Question = "Vad är Windows Event Log?", Category = catOS, SubCategory = subWindows };
            var qApplockerVad = new QuestionModel { Question = "Vad är AppLocker i Windows?", Category = catOS, SubCategory = subWindows };

            // Behörighetshantering extra
            var qMfaBeh = new QuestionModel { Question = "Varför är MFA viktigt för behörighetshantering?", Category = catOS, SubCategory = subBehorighet };
            var qZeroTrust = new QuestionModel { Question = "Vad innebär Zero Trust-säkerhetsmodellen?", Category = catOS, SubCategory = subBehorighet };

            // GDPR extra
            var qGdprRadering = new QuestionModel { Question = "Vad innebär rätten till radering ('rätten att bli glömd') enligt GDPR?", Category = catLagstiftning, SubCategory = subGdpr };
            var qPersonuppgiftsansvarig = new QuestionModel { Question = "Vad är en personuppgiftsansvarig (Data Controller) enligt GDPR?", Category = catLagstiftning, SubCategory = subGdpr };

            // NIS2 & ISO 27001 extra
            var qNis2Omfattas = new QuestionModel { Question = "Vilka organisationer omfattas av NIS2-direktivet?", Category = catLagstiftning, SubCategory = subNis2 };
            var qIso27001Cert = new QuestionModel { Question = "Vad innebär ISO 27001-certifiering för en organisation?", Category = catLagstiftning, SubCategory = subNis2 };

            // Incident Response extra
            var qInneslutning = new QuestionModel { Question = "Vad är inneslutning (containment) i incident response?", Category = catLagstiftning, SubCategory = subIncident };
            var qChainOfCustody = new QuestionModel { Question = "Vad är chain of custody inom digital forensik?", Category = catLagstiftning, SubCategory = subIncident };

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
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aRbacKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aLeastPrivKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aUacKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aSudoKorrekt, IsCorrect = false },

                // Autentisering vs Auktorisering
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzFel3, IsCorrect = false },

                // PAM
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamFel3, IsCorrect = false },

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
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel3, IsCorrect = false },

                // UDP
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpFel3, IsCorrect = false },

                // IPv4 vs IPv6
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Fel3, IsCorrect = false },

                // DHCP
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpFel3, IsCorrect = false },

                // A-post vs AAAA
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostFel3, IsCorrect = false },

                // WAF
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafFel3, IsCorrect = false },

                // Paketfiltrering OSI-lager
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringFel3, IsCorrect = false },

                // Injection (OWASP)
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionFel3, IsCorrect = false },

                // Insecure Design (OWASP)
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignFel3, IsCorrect = false },

                // XSS typer
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperFel3, IsCorrect = false },

                // LDAP-injektion
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapFel3, IsCorrect = false },

                // JWT
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtFel3, IsCorrect = false },

                // CSRF-skydd
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddFel3, IsCorrect = false },

                // AES nyckellängd
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelFel3, IsCorrect = false },

                // DES
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesFel3, IsCorrect = false },

                // RSA
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaFel3, IsCorrect = false },

                // CA
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaFel3, IsCorrect = false },

                // Salting
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingFel3, IsCorrect = false },

                // MD5
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Fel3, IsCorrect = false },

                // Spyware
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareFel3, IsCorrect = false },

                // Rootkit
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitFel3, IsCorrect = false },

                // Botnät
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatFel3, IsCorrect = false },

                // Brute force
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceFel3, IsCorrect = false },

                // Smishing
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingFel3, IsCorrect = false },

                // Pretexting
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingFel3, IsCorrect = false },

                // chown
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownFel3, IsCorrect = false },

                // SELinux
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxFel3, IsCorrect = false },

                // Windows Event Log
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogFel3, IsCorrect = false },

                // AppLocker
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerFel3, IsCorrect = false },

                // MFA behörighet
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehFel3, IsCorrect = false },

                // Zero Trust
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustFel3, IsCorrect = false },

                // GDPR radering
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingFel3, IsCorrect = false },

                // Personuppgiftsansvarig
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigFel3, IsCorrect = false },

                // NIS2 vilka omfattas
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasFel3, IsCorrect = false },

                // ISO 27001 certifiering
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertFel3, IsCorrect = false },

                // Inneslutning
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningFel3, IsCorrect = false },

                // Chain of custody
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyFel3, IsCorrect = false }
            );

            await context.SaveChangesAsync();
        }
    }
}
