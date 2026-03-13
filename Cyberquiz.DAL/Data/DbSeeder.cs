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

            // ANSWER OPTIONS

            // Networking
            var aNatverkslager = new AnswerOptionModel { Answer = "Network Layer (Layer 3)" };
            var aDatalankslager = new AnswerOptionModel { Answer = "Data Link Layer (Layer 2)" };
            var aTransportlager = new AnswerOptionModel { Answer = "Transport Layer (Layer 4)" };
            var aSessionslager = new AnswerOptionModel { Answer = "Session Layer (Layer 5)" };

            var aPort443 = new AnswerOptionModel { Answer = "443" };
            var aPort80 = new AnswerOptionModel { Answer = "80" };
            var aPort8080 = new AnswerOptionModel { Answer = "8080" };
            var aPort22 = new AnswerOptionModel { Answer = "22" };
            var aPort53 = new AnswerOptionModel { Answer = "53" };
            var aPort25 = new AnswerOptionModel { Answer = "25" };
            var aPort110 = new AnswerOptionModel { Answer = "110" };

            var aSynForklaring = new AnswerOptionModel { Answer = "The first packet in a TCP handshake" };
            var aSynFel1 = new AnswerOptionModel { Answer = "A termination packet in TCP" };
            var aSynFel2 = new AnswerOptionModel { Answer = "An acknowledgement of received data" };
            var aSynFel3 = new AnswerOptionModel { Answer = "An error message in TCP" };

            var aDnsKorrekt = new AnswerOptionModel { Answer = "Translates domain names to IP addresses" };
            var aDnsFel1 = new AnswerOptionModel { Answer = "Dynamically assigns IP addresses to devices" };
            var aDnsFel2 = new AnswerOptionModel { Answer = "Filters network traffic" };
            var aDnsFel3 = new AnswerOptionModel { Answer = "Encrypts data transmission" };

            var aDnsPoisonKorrekt = new AnswerOptionModel { Answer = "An attack that inserts fake records into the DNS cache" };
            var aDnsPoisonFel1 = new AnswerOptionModel { Answer = "A method for encrypting DNS traffic" };
            var aDnsPoisonFel2 = new AnswerOptionModel { Answer = "A technique for increasing DNS performance" };
            var aDnsPoisonFel3 = new AnswerOptionModel { Answer = "A type of DDoS attack against DNS servers" };

            var aStatefulKorrekt = new AnswerOptionModel { Answer = "Stateful firewall" };
            var aStatefulFel1 = new AnswerOptionModel { Answer = "Stateless firewall" };
            var aStatefulFel2 = new AnswerOptionModel { Answer = "Proxy firewall" };
            var aStatefulFel3 = new AnswerOptionModel { Answer = "Packet filtering firewall" };

            var aIdsIpsKorrekt = new AnswerOptionModel { Answer = "IDS detects intrusions, IPS can also block them" };
            var aIdsIpsFel1 = new AnswerOptionModel { Answer = "IDS blocks intrusions, IPS only detects" };
            var aIdsIpsFel2 = new AnswerOptionModel { Answer = "They are identical technologies" };
            var aIdsIpsFel3 = new AnswerOptionModel { Answer = "IDS is hardware, IPS is software" };

            var aDmzKorrekt = new AnswerOptionModel { Answer = "A network zone between the internet and the internal network" };
            var aDmzFel1 = new AnswerOptionModel { Answer = "An encrypted tunnel between two networks" };
            var aDmzFel2 = new AnswerOptionModel { Answer = "A type of VPN configuration" };
            var aDmzFel3 = new AnswerOptionModel { Answer = "An isolated administrative network" };

            // Web Security
            var aOwaspKorrekt = new AnswerOptionModel { Answer = "Open Worldwide Application Security Project" };
            var aOwaspFel1 = new AnswerOptionModel { Answer = "Open Web Access Security Protocol" };
            var aOwaspFel2 = new AnswerOptionModel { Answer = "Online Web Application Security Platform" };
            var aOwaspFel3 = new AnswerOptionModel { Answer = "Open Windows Application Service Provider" };

            var aBrokenAccessKorrekt = new AnswerOptionModel { Answer = "Broken Access Control" };
            var aBrokenAccessFel1 = new AnswerOptionModel { Answer = "SQL Injection" };
            var aBrokenAccessFel2 = new AnswerOptionModel { Answer = "Cryptographic Failures" };
            var aBrokenAccessFel3 = new AnswerOptionModel { Answer = "Security Misconfiguration" };

            var aSecMisconfigKorrekt = new AnswerOptionModel { Answer = "Incorrectly configured security settings in the application" };
            var aSecMisconfigFel1 = new AnswerOptionModel { Answer = "A type of XSS attack" };
            var aSecMisconfigFel2 = new AnswerOptionModel { Answer = "Weak encryption of stored data" };
            var aSecMisconfigFel3 = new AnswerOptionModel { Answer = "Insufficient authentication" };

            var aXssKorrekt = new AnswerOptionModel { Answer = "Malicious code is injected into web pages and executed in the victim's browser" };
            var aXssFel1 = new AnswerOptionModel { Answer = "An attack that manipulates databases via SQL" };
            var aXssFel2 = new AnswerOptionModel { Answer = "A network attack that intercepts traffic" };
            var aXssFel3 = new AnswerOptionModel { Answer = "An attack that forges HTTP requests" };

            var aSqlKorrekt = new AnswerOptionModel { Answer = "SQL code is injected into input fields to manipulate the database" };
            var aSqlFel1 = new AnswerOptionModel { Answer = "An encryption technique for databases" };
            var aSqlFel2 = new AnswerOptionModel { Answer = "A method for optimizing SQL queries" };
            var aSqlFel3 = new AnswerOptionModel { Answer = "An authentication method for databases" };

            var aPreparedKorrekt = new AnswerOptionModel { Answer = "Prepared statements (parameterized queries)" };
            var aPreparedFel1 = new AnswerOptionModel { Answer = "HTTPS encryption" };
            var aPreparedFel2 = new AnswerOptionModel { Answer = "Base64 encoding of input" };
            var aPreparedFel3 = new AnswerOptionModel { Answer = "Cookies with HttpOnly flag" };

            var aMfaKorrekt = new AnswerOptionModel { Answer = "Authentication using at least two independent factors" };
            var aMfaFel1 = new AnswerOptionModel { Answer = "Authentication with an extra long password" };
            var aMfaFel2 = new AnswerOptionModel { Answer = "A type of encryption for login" };
            var aMfaFel3 = new AnswerOptionModel { Answer = "Single sign-on with certificates" };

            var aSessionKorrekt = new AnswerOptionModel { Answer = "An attack where the attacker steals a session ID to take over a session" };
            var aSessionFel1 = new AnswerOptionModel { Answer = "An attack that creates millions of fake sessions" };
            var aSessionFel2 = new AnswerOptionModel { Answer = "A technique for deleting the user's cookies" };
            var aSessionFel3 = new AnswerOptionModel { Answer = "A variant of XSS attack" };

            var aCsrfKorrekt = new AnswerOptionModel { Answer = "An attack that tricks a logged-in user into performing unwanted actions" };
            var aCsrfFel1 = new AnswerOptionModel { Answer = "An attack that injects scripts into web pages" };
            var aCsrfFel2 = new AnswerOptionModel { Answer = "An attack that steals passwords via phishing" };
            var aCsrfFel3 = new AnswerOptionModel { Answer = "An attack against databases" };

            // Cryptography
            var aSymKorrekt = new AnswerOptionModel { Answer = "The same key is used for both encryption and decryption" };
            var aSymFel1 = new AnswerOptionModel { Answer = "Different keys are used for encryption and decryption" };
            var aSymFel2 = new AnswerOptionModel { Answer = "Encryption occurs without a key" };
            var aSymFel3 = new AnswerOptionModel { Answer = "Encryption with a public key" };

            var aAesKorrekt = new AnswerOptionModel { Answer = "AES (Advanced Encryption Standard)" };
            var aAesFel1 = new AnswerOptionModel { Answer = "RSA" };
            var aAesFel2 = new AnswerOptionModel { Answer = "ECC (Elliptic Curve Cryptography)" };
            var aAesFel3 = new AnswerOptionModel { Answer = "Diffie-Hellman" };

            var aAesBetydKorrekt = new AnswerOptionModel { Answer = "Advanced Encryption Standard" };
            var aAesBetydFel1 = new AnswerOptionModel { Answer = "Asymmetric Encryption System" };
            var aAesBetydFel2 = new AnswerOptionModel { Answer = "Authenticated Exchange Standard" };
            var aAesBetydFel3 = new AnswerOptionModel { Answer = "Adaptive Encryption Service" };

            var aAsymKorrekt = new AnswerOptionModel { Answer = "Encryption with a key pair — one public and one private key" };
            var aAsymFel1 = new AnswerOptionModel { Answer = "Encryption with the same key for all operations" };
            var aAsymFel2 = new AnswerOptionModel { Answer = "Keyless encryption based on an algorithm" };
            var aAsymFel3 = new AnswerOptionModel { Answer = "Encryption with a passphrase" };

            var aPrivatKorrekt = new AnswerOptionModel { Answer = "Decryption and digital signing" };
            var aPrivatFel1 = new AnswerOptionModel { Answer = "Encrypting messages to the recipient" };
            var aPrivatFel2 = new AnswerOptionModel { Answer = "Distributed openly to all parties" };
            var aPrivatFel3 = new AnswerOptionModel { Answer = "Exchange of symmetric keys" };

            var aCertKorrekt = new AnswerOptionModel { Answer = "An electronic document that binds a public key to an identity" };
            var aCertFel1 = new AnswerOptionModel { Answer = "An encrypted password file" };
            var aCertFel2 = new AnswerOptionModel { Answer = "A private key signed by the user" };
            var aCertFel3 = new AnswerOptionModel { Answer = "A hashed version of a password" };

            var aHashKorrekt = new AnswerOptionModel { Answer = "A function that converts data into a fixed hash value" };
            var aHashFel1 = new AnswerOptionModel { Answer = "A function that encrypts data with a key" };
            var aHashFel2 = new AnswerOptionModel { Answer = "A function that compresses files" };
            var aHashFel3 = new AnswerOptionModel { Answer = "A function that digitally signs documents" };

            var aEnvagKorrekt = new AnswerOptionModel { Answer = "It should be practically impossible to recover the original data (one-way function)" };
            var aEnvagFel1 = new AnswerOptionModel { Answer = "The hash should be decryptable with a key" };
            var aEnvagFel2 = new AnswerOptionModel { Answer = "The hash should always be the same length as the original data" };
            var aEnvagFel3 = new AnswerOptionModel { Answer = "The hash should be reversible for admins" };

            var aShaKorrekt = new AnswerOptionModel { Answer = "SHA-256" };
            var aShaFel1 = new AnswerOptionModel { Answer = "AES-256" };
            var aShaFel2 = new AnswerOptionModel { Answer = "RSA-2048" };
            var aShaFel3 = new AnswerOptionModel { Answer = "TLS 1.3" };

            // Malware & Attacks
            var aRansomKorrekt = new AnswerOptionModel { Answer = "Encrypts the victim's files and demands a ransom to unlock them" };
            var aRansomFel1 = new AnswerOptionModel { Answer = "Steals passwords and sends them to the attacker" };
            var aRansomFel2 = new AnswerOptionModel { Answer = "Spies on the user via the webcam" };
            var aRansomFel3 = new AnswerOptionModel { Answer = "Creates a botnet of infected computers" };

            var aTrojanKorrekt = new AnswerOptionModel { Answer = "Malicious software that disguises itself as a legitimate program" };
            var aTrojanFel1 = new AnswerOptionModel { Answer = "Software that spreads automatically through networks" };
            var aTrojanFel2 = new AnswerOptionModel { Answer = "Software that encrypts the entire hard drive" };
            var aTrojanFel3 = new AnswerOptionModel { Answer = "Software that blocks network traffic" };

            var aWormKorrekt = new AnswerOptionModel { Answer = "A worm spreads automatically without needing a host" };
            var aWormFel1 = new AnswerOptionModel { Answer = "A worm always requires manual activation by the user" };
            var aWormFel2 = new AnswerOptionModel { Answer = "A worm always encrypts the files it infects" };
            var aWormFel3 = new AnswerOptionModel { Answer = "A worm is always harmless and easily removed" };

            var aDdosKorrekt = new AnswerOptionModel { Answer = "Many computers flood a target with traffic to take down the service" };
            var aDdosFel1 = new AnswerOptionModel { Answer = "A targeted attack against a specific user's computer" };
            var aDdosFel2 = new AnswerOptionModel { Answer = "An attack that injects malicious code into databases" };
            var aDdosFel3 = new AnswerOptionModel { Answer = "An attack that occurs via malicious email attachments" };

            var aMitmKorrekt = new AnswerOptionModel { Answer = "The attacker places themselves between two parties and can intercept communications" };
            var aMitmFel1 = new AnswerOptionModel { Answer = "The attacker guesses passwords with brute force" };
            var aMitmFel2 = new AnswerOptionModel { Answer = "The attacker sends fake emails" };
            var aMitmFel3 = new AnswerOptionModel { Answer = "The attacker exploits an unknown vulnerability" };

            var aZerodayKorrekt = new AnswerOptionModel { Answer = "An attack that exploits a vulnerability unknown to the software vendor" };
            var aZerodayFel1 = new AnswerOptionModel { Answer = "An attack that occurs exactly at midnight" };
            var aZerodayFel2 = new AnswerOptionModel { Answer = "An attack against newly installed systems without updates" };
            var aZerodayFel3 = new AnswerOptionModel { Answer = "An attack executed within zero seconds" };

            var aPhishKorrekt = new AnswerOptionModel { Answer = "The attacker impersonates a trusted source to trick the victim into giving up information" };
            var aPhishFel1 = new AnswerOptionModel { Answer = "A network attack that intercepts unencrypted traffic" };
            var aPhishFel2 = new AnswerOptionModel { Answer = "A type of malware that encrypts files" };
            var aPhishFel3 = new AnswerOptionModel { Answer = "An attack that exploits vulnerabilities in browsers" };

            var aSpearKorrekt = new AnswerOptionModel { Answer = "A targeted phishing attack against a specific person or organization" };
            var aSpearFel1 = new AnswerOptionModel { Answer = "A mass-sent phishing attack to millions of recipients" };
            var aSpearFel2 = new AnswerOptionModel { Answer = "A phishing attack carried out via SMS" };
            var aSpearFel3 = new AnswerOptionModel { Answer = "A phishing attack via phone" };

            var aVishingKorrekt = new AnswerOptionModel { Answer = "Phishing via phone (voice phishing)" };
            var aVishingFel1 = new AnswerOptionModel { Answer = "Phishing via SMS" };
            var aVishingFel2 = new AnswerOptionModel { Answer = "Phishing via email" };
            var aVishingFel3 = new AnswerOptionModel { Answer = "Phishing via social media" };

            // Operating Systems
            var aChmodKorrekt = new AnswerOptionModel { Answer = "Changes file permissions (read, write, execute) in Linux" };
            var aChmodFel1 = new AnswerOptionModel { Answer = "Changes the owner of a file in Linux" };
            var aChmodFel2 = new AnswerOptionModel { Answer = "Shows active processes in Linux" };
            var aChmodFel3 = new AnswerOptionModel { Answer = "Creates a new user in Linux" };

            var aLeastPrivKorrekt = new AnswerOptionModel { Answer = "Users and processes should only have the permissions they absolutely need" };
            var aLeastPrivFel1 = new AnswerOptionModel { Answer = "All users are granted administrator privileges by default" };
            var aLeastPrivFel2 = new AnswerOptionModel { Answer = "Permissions rotate automatically every day" };
            var aLeastPrivFel3 = new AnswerOptionModel { Answer = "Permissions are assigned based solely on department" };

            var aSudoKorrekt = new AnswerOptionModel { Answer = "Allows a user to run a command with elevated privileges" };
            var aSudoFel1 = new AnswerOptionModel { Answer = "Permanently switches to the root account" };
            var aSudoFel2 = new AnswerOptionModel { Answer = "Displays system logs in real time" };
            var aSudoFel3 = new AnswerOptionModel { Answer = "Encrypts a file with root privileges" };

            var aDefenderKorrekt = new AnswerOptionModel { Answer = "Microsoft's built-in antivirus and security solution" };
            var aDefenderFel1 = new AnswerOptionModel { Answer = "A built-in firewall in Windows" };
            var aDefenderFel2 = new AnswerOptionModel { Answer = "A password manager in Windows" };
            var aDefenderFel3 = new AnswerOptionModel { Answer = "A built-in VPN service in Windows" };

            var aBitlockerKorrekt = new AnswerOptionModel { Answer = "Microsoft's built-in disk encryption tool for Windows" };
            var aBitlockerFel1 = new AnswerOptionModel { Answer = "An antivirus solution in Windows" };
            var aBitlockerFel2 = new AnswerOptionModel { Answer = "A built-in firewall in Windows" };
            var aBitlockerFel3 = new AnswerOptionModel { Answer = "A backup service in Windows" };

            var aUacKorrekt = new AnswerOptionModel { Answer = "A feature that requests confirmation before programs make administrative changes" };
            var aUacFel1 = new AnswerOptionModel { Answer = "An antivirus feature in Windows" };
            var aUacFel2 = new AnswerOptionModel { Answer = "A network firewall in Windows" };
            var aUacFel3 = new AnswerOptionModel { Answer = "A password policy in Active Directory" };

            var aRbacKorrekt = new AnswerOptionModel { Answer = "Access control where permissions are assigned based on the user's role in the organization" };

            var aAutnVsAutzKorrekt = new AnswerOptionModel { Answer = "Authentication verifies who you are, authorization determines what you are allowed to do" };
            var aAutnVsAutzFel1 = new AnswerOptionModel { Answer = "They are synonyms and mean the same thing" };
            var aAutnVsAutzFel2 = new AnswerOptionModel { Answer = "Authentication determines what you are allowed to do, authorization verifies who you are" };
            var aAutnVsAutzFel3 = new AnswerOptionModel { Answer = "Authentication applies to machines, authorization applies to people" };

            var aPamKorrekt = new AnswerOptionModel { Answer = "A system for controlling and monitoring access to privileged accounts" };
            var aPamFel1 = new AnswerOptionModel { Answer = "A type of next-generation firewall" };
            var aPamFel2 = new AnswerOptionModel { Answer = "An encryption algorithm for administrator passwords" };
            var aPamFel3 = new AnswerOptionModel { Answer = "An antivirus solution for servers" };

            // Legislation
            var aGdprKorrekt = new AnswerOptionModel { Answer = "General Data Protection Regulation" };
            var aGdprFel1 = new AnswerOptionModel { Answer = "Global Data Privacy Rights" };
            var aGdprFel2 = new AnswerOptionModel { Answer = "General Digital Privacy Rules" };
            var aGdprFel3 = new AnswerOptionModel { Answer = "Government Data Protection Registry" };

            var a72hKorrekt = new AnswerOptionModel { Answer = "72 hours" };
            var a72hFel1 = new AnswerOptionModel { Answer = "24 hours" };
            var a72hFel2 = new AnswerOptionModel { Answer = "48 hours" };
            var a72hFel3 = new AnswerOptionModel { Answer = "7 days" };

            var aPersonuppgiftKorrekt = new AnswerOptionModel { Answer = "Any information that directly or indirectly can identify a living person" };
            var aPersonuppgiftFel1 = new AnswerOptionModel { Answer = "Only name and personal identification number" };
            var aPersonuppgiftFel2 = new AnswerOptionModel { Answer = "Only digitally stored information" };
            var aPersonuppgiftFel3 = new AnswerOptionModel { Answer = "Only medical and financial information" };

            var aNis2Korrekt = new AnswerOptionModel { Answer = "Strengthen cybersecurity for critical infrastructure and essential services in the EU" };
            var aNis2Fel1 = new AnswerOptionModel { Answer = "Regulate the handling of personal data in the EU" };
            var aNis2Fel2 = new AnswerOptionModel { Answer = "Standardize software development within the EU" };
            var aNis2Fel3 = new AnswerOptionModel { Answer = "Regulate e-commerce and digital marketplaces" };

            var aIso27001Korrekt = new AnswerOptionModel { Answer = "An international standard for information security management systems (ISMS)" };
            var aIso27001Fel1 = new AnswerOptionModel { Answer = "An EU regulation on data protection" };
            var aIso27001Fel2 = new AnswerOptionModel { Answer = "A standard for programming languages" };
            var aIso27001Fel3 = new AnswerOptionModel { Answer = "A network protocol standard" };

            var aIsmsKorrekt = new AnswerOptionModel { Answer = "A framework for systematically managing and protecting an organization's information" };
            var aIsmsFel1 = new AnswerOptionModel { Answer = "A type of next-generation firewall" };
            var aIsmsFel2 = new AnswerOptionModel { Answer = "An antivirus program for enterprises" };
            var aIsmsFel3 = new AnswerOptionModel { Answer = "An encryption standard for email" };

            var aIrFaserKorrekt = new AnswerOptionModel { Answer = "Preparation, Identification, Containment & Eradication, Recovery, Lessons Learned" };
            var aIrFaserFel1 = new AnswerOptionModel { Answer = "Attack, Defense, Reporting, Closure" };
            var aIrFaserFel2 = new AnswerOptionModel { Answer = "Planning, Execution, Testing, Deployment" };
            var aIrFaserFel3 = new AnswerOptionModel { Answer = "Detection, Analysis, Patching, Logging" };

            var aForensikKorrekt = new AnswerOptionModel { Answer = "Collection and analysis of digital evidence after an incident" };
            var aForensikFel1 = new AnswerOptionModel { Answer = "Preventive security work against intrusions" };
            var aForensikFel2 = new AnswerOptionModel { Answer = "Real-time encryption of sensitive data" };
            var aForensikFel3 = new AnswerOptionModel { Answer = "Network monitoring to detect attacks" };

            var aRunbookKorrekt = new AnswerOptionModel { Answer = "Documentation with step-by-step instructions for handling specific incidents" };
            var aRunbookFel1 = new AnswerOptionModel { Answer = "A list of all system administrators" };
            var aRunbookFel2 = new AnswerOptionModel { Answer = "A firewall configuration file" };
            var aRunbookFel3 = new AnswerOptionModel { Answer = "An encryption key for incident data" };

            // TCP/IP extra
            var aUdpKorrekt = new AnswerOptionModel { Answer = "UDP is connectionless and offers no guaranteed delivery, unlike TCP's session management" };
            var aUdpFel1 = new AnswerOptionModel { Answer = "UDP is more secure than TCP but slower" };
            var aUdpFel2 = new AnswerOptionModel { Answer = "UDP and TCP are identical protocols" };
            var aUdpFel3 = new AnswerOptionModel { Answer = "UDP guarantees delivery order but not security" };

            var aIpv4v6Korrekt = new AnswerOptionModel { Answer = "IPv4 uses 32-bit addresses, IPv6 uses 128-bit addresses and offers more addresses" };
            var aIpv4v6Fel1 = new AnswerOptionModel { Answer = "IPv6 is older than IPv4 and has fewer addresses" };
            var aIpv4v6Fel2 = new AnswerOptionModel { Answer = "IPv4 and IPv6 are compatible and work identically" };
            var aIpv4v6Fel3 = new AnswerOptionModel { Answer = "IPv6 uses 64-bit addresses and replaces MAC addresses" };

            // DNS & DHCP extra
            var aDhcpKorrekt = new AnswerOptionModel { Answer = "Automatically assigns IP addresses to devices on a network" };
            var aDhcpFel1 = new AnswerOptionModel { Answer = "Translates domain names to IP addresses" };
            var aDhcpFel2 = new AnswerOptionModel { Answer = "Automatically encrypts network traffic" };
            var aDhcpFel3 = new AnswerOptionModel { Answer = "Filters unwanted network traffic" };

            var aApostKorrekt = new AnswerOptionModel { Answer = "A record points to an IPv4 address, AAAA record points to an IPv6 address" };
            var aApostFel1 = new AnswerOptionModel { Answer = "A record and AAAA record are synonyms for MX records" };
            var aApostFel2 = new AnswerOptionModel { Answer = "A record applies to email, AAAA record applies to web servers" };
            var aApostFel3 = new AnswerOptionModel { Answer = "AAAA record is an older version of A record" };

            // Firewalls extra
            var aWafKorrekt = new AnswerOptionModel { Answer = "A firewall that analyzes HTTP traffic and protects web applications against attacks like XSS and SQLi" };
            var aWafFel1 = new AnswerOptionModel { Answer = "A firewall that protects wireless networks" };
            var aWafFel2 = new AnswerOptionModel { Answer = "A firewall that only filters IP addresses" };
            var aWafFel3 = new AnswerOptionModel { Answer = "Software for monitoring email traffic" };

            var aPaketfiltreringKorrekt = new AnswerOptionModel { Answer = "Network Layer (Layer 3)" };
            var aPaketfiltreringFel1 = new AnswerOptionModel { Answer = "Application Layer (Layer 7)" };
            var aPaketfiltreringFel2 = new AnswerOptionModel { Answer = "Transport Layer (Layer 4)" };
            var aPaketfiltreringFel3 = new AnswerOptionModel { Answer = "Data Link Layer (Layer 2)" };

            // OWASP extra
            var aInjectionKorrekt = new AnswerOptionModel { Answer = "Malicious data is sent to an interpreter (e.g. SQL, LDAP) and executed as commands" };
            var aInjectionFel1 = new AnswerOptionModel { Answer = "The attacker injects code via network packets" };
            var aInjectionFel2 = new AnswerOptionModel { Answer = "An attack that injects viruses into the operating system" };
            var aInjectionFel3 = new AnswerOptionModel { Answer = "Unauthorized access to databases through weak passwords" };

            var aInsecureDesignKorrekt = new AnswerOptionModel { Answer = "Security flaws that stem from poor design and architecture rather than implementation errors" };
            var aInsecureDesignFel1 = new AnswerOptionModel { Answer = "Incorrect configuration of the web server" };
            var aInsecureDesignFel2 = new AnswerOptionModel { Answer = "Use of outdated encryption algorithms" };
            var aInsecureDesignFel3 = new AnswerOptionModel { Answer = "Insufficient logging and monitoring" };

            // XSS & Injections extra
            var aXssTyperKorrekt = new AnswerOptionModel { Answer = "Stored XSS, Reflected XSS and DOM-based XSS" };
            var aXssTyperFel1 = new AnswerOptionModel { Answer = "SQL XSS, HTTP XSS and LDAP XSS" };
            var aXssTyperFel2 = new AnswerOptionModel { Answer = "Active XSS, Passive XSS and Hybrid XSS" };
            var aXssTyperFel3 = new AnswerOptionModel { Answer = "Client XSS, Server XSS and Network XSS" };

            var aLdapKorrekt = new AnswerOptionModel { Answer = "Malicious LDAP queries are injected via input fields to manipulate directory services" };
            var aLdapFel1 = new AnswerOptionModel { Answer = "An attack that injects code into HTTPS certificates" };
            var aLdapFel2 = new AnswerOptionModel { Answer = "An attack against DNS servers via the LDAP protocol" };
            var aLdapFel3 = new AnswerOptionModel { Answer = "A method for bypassing LDAP authentication with brute force" };

            // Authentication & Sessions extra
            var aJwtKorrekt = new AnswerOptionModel { Answer = "An open standard for securely transmitting information as JSON objects signed with a key" };
            var aJwtFel1 = new AnswerOptionModel { Answer = "An encryption standard for HTTP cookies" };
            var aJwtFel2 = new AnswerOptionModel { Answer = "A protocol for password hashing" };
            var aJwtFel3 = new AnswerOptionModel { Answer = "A database for session management" };

            var aCsrfSkyddKorrekt = new AnswerOptionModel { Answer = "CSRF tokens (synchronizer tokens) that are validated with each request" };
            var aCsrfSkyddFel1 = new AnswerOptionModel { Answer = "HTTPS encryption of all requests" };
            var aCsrfSkyddFel2 = new AnswerOptionModel { Answer = "SQL prepared statements" };
            var aCsrfSkyddFel3 = new AnswerOptionModel { Answer = "Content Security Policy (CSP)" };

            // Symmetric encryption extra
            var aAesNyckelKorrekt = new AnswerOptionModel { Answer = "128, 192, or 256 bits — with AES-256 providing the strongest protection" };
            var aAesNyckelFel1 = new AnswerOptionModel { Answer = "64 bits is the recommended minimum level" };
            var aAesNyckelFel2 = new AnswerOptionModel { Answer = "512 bits is the standard for AES" };
            var aAesNyckelFel3 = new AnswerOptionModel { Answer = "AES does not use keys" };

            var aDesKorrekt = new AnswerOptionModel { Answer = "Data Encryption Standard — an older 56-bit algorithm considered insecure due to its short key length" };
            var aDesFel1 = new AnswerOptionModel { Answer = "Digital Encryption System — a modern replacement for AES" };
            var aDesFel2 = new AnswerOptionModel { Answer = "An asymmetric encryption standard with 128-bit keys" };
            var aDesFel3 = new AnswerOptionModel { Answer = "A password hashing algorithm developed by the NSA" };

            // Asymmetric encryption extra
            var aRsaKorrekt = new AnswerOptionModel { Answer = "An asymmetric encryption algorithm based on the factorization of large prime numbers" };
            var aRsaFel1 = new AnswerOptionModel { Answer = "A symmetric encryption algorithm with variable key length" };
            var aRsaFel2 = new AnswerOptionModel { Answer = "A hashing algorithm for digital signatures" };
            var aRsaFel3 = new AnswerOptionModel { Answer = "A protocol for secure key exchange without encryption" };

            var aCaKorrekt = new AnswerOptionModel { Answer = "A trusted organization that issues and signs digital certificates" };
            var aCaFel1 = new AnswerOptionModel { Answer = "An algorithm for generating cryptographic keys" };
            var aCaFel2 = new AnswerOptionModel { Answer = "A database for storing private keys" };
            var aCaFel3 = new AnswerOptionModel { Answer = "A server that handles TLS handshakes" };

            // Hashing extra
            var aSaltingKorrekt = new AnswerOptionModel { Answer = "Random data is added to the password before hashing to prevent rainbow table attacks" };
            var aSaltingFel1 = new AnswerOptionModel { Answer = "The password is encrypted with a secret key before storage" };
            var aSaltingFel2 = new AnswerOptionModel { Answer = "The password is hashed multiple times to make it longer" };
            var aSaltingFel3 = new AnswerOptionModel { Answer = "A technique for compressing hash values" };

            var aMd5Korrekt = new AnswerOptionModel { Answer = "MD5 has known collisions and is too fast, making brute-force attacks effective" };
            var aMd5Fel1 = new AnswerOptionModel { Answer = "MD5 produces hash values that are too long for practical use" };
            var aMd5Fel2 = new AnswerOptionModel { Answer = "MD5 is patented and cannot be used freely" };
            var aMd5Fel3 = new AnswerOptionModel { Answer = "MD5 is too slow for modern systems" };

            // Malware types extra
            var aSpywareKorrekt = new AnswerOptionModel { Answer = "Software that secretly collects information about the user and sends it to a third party" };
            var aSpywareFel1 = new AnswerOptionModel { Answer = "Software that blocks access to files until a ransom is paid" };
            var aSpywareFel2 = new AnswerOptionModel { Answer = "Software that spreads automatically through networks" };
            var aSpywareFel3 = new AnswerOptionModel { Answer = "Software that displays unwanted advertisements" };

            var aRootkitKorrekt = new AnswerOptionModel { Answer = "Malicious software that conceals its presence and gives the attacker administrator control" };
            var aRootkitFel1 = new AnswerOptionModel { Answer = "A tool for resetting the root password in Linux" };
            var aRootkitFel2 = new AnswerOptionModel { Answer = "A type of ransomware that encrypts the root partition" };
            var aRootkitFel3 = new AnswerOptionModel { Answer = "A type of firewall for protection against Linux attacks" };

            // Attack methods extra
            var aBotnatKorrekt = new AnswerOptionModel { Answer = "A network of compromised computers (bots) controlled by an attacker" };
            var aBotnatFel1 = new AnswerOptionModel { Answer = "A type of encrypted network for secure communication" };
            var aBotnatFel2 = new AnswerOptionModel { Answer = "A network topology for distributed systems" };
            var aBotnatFel3 = new AnswerOptionModel { Answer = "A technique for balancing network traffic" };

            var aBruteForceKorrekt = new AnswerOptionModel { Answer = "An attack that systematically tries all possible password combinations until the correct one is found" };
            var aBruteForceFel1 = new AnswerOptionModel { Answer = "An attack that exploits known vulnerabilities in software" };
            var aBruteForceFel2 = new AnswerOptionModel { Answer = "An attack that manipulates DNS records" };
            var aBruteForceFel3 = new AnswerOptionModel { Answer = "An attack that intercepts encrypted network traffic" };

            // Social Engineering extra
            var aSmishingKorrekt = new AnswerOptionModel { Answer = "Phishing via SMS messages" };
            var aSmishingFel1 = new AnswerOptionModel { Answer = "Phishing via email" };
            var aSmishingFel2 = new AnswerOptionModel { Answer = "Phishing via phone" };
            var aSmishingFel3 = new AnswerOptionModel { Answer = "Phishing via social media" };

            var aPretextingKorrekt = new AnswerOptionModel { Answer = "The attacker creates a false scenario (pretext) to trick the victim into revealing information" };
            var aPretextingFel1 = new AnswerOptionModel { Answer = "The attacker leaves an infected USB drive in a public place" };
            var aPretextingFel2 = new AnswerOptionModel { Answer = "The attacker sends mass emails with malicious attachments" };
            var aPretextingFel3 = new AnswerOptionModel { Answer = "The attacker intercepts public Wi-Fi networks" };

            // Linux security extra
            var aChownKorrekt = new AnswerOptionModel { Answer = "Changes the owner or group of a file or directory" };
            var aChownFel1 = new AnswerOptionModel { Answer = "Changes file permissions (read, write, execute)" };
            var aChownFel2 = new AnswerOptionModel { Answer = "Creates a new user in Linux" };
            var aChownFel3 = new AnswerOptionModel { Answer = "Shows disk space for files and directories" };

            var aSelinuxKorrekt = new AnswerOptionModel { Answer = "Security-Enhanced Linux — a security framework with mandatory access control (MAC)" };
            var aSelinuxFel1 = new AnswerOptionModel { Answer = "An antivirus solution for Linux servers" };
            var aSelinuxFel2 = new AnswerOptionModel { Answer = "An encryption module for Linux file systems" };
            var aSelinuxFel3 = new AnswerOptionModel { Answer = "A firewall configuration for Linux" };

            // Windows security extra
            var aEventLogKorrekt = new AnswerOptionModel { Answer = "Windows tool for recording system, security, and application events for troubleshooting and auditing" };
            var aEventLogFel1 = new AnswerOptionModel { Answer = "A service for automatic updates in Windows" };
            var aEventLogFel2 = new AnswerOptionModel { Answer = "A database for storing user passwords" };
            var aEventLogFel3 = new AnswerOptionModel { Answer = "A built-in firewall feature in Windows" };

            var aApplockerKorrekt = new AnswerOptionModel { Answer = "A Windows feature that controls which programs are allowed to run based on rules" };
            var aApplockerFel1 = new AnswerOptionModel { Answer = "An antivirus solution that blocks malicious code in real time" };
            var aApplockerFel2 = new AnswerOptionModel { Answer = "A feature for encrypting individual programs" };
            var aApplockerFel3 = new AnswerOptionModel { Answer = "A built-in password manager in Windows" };

            // Access management extra
            var aMfaBehKorrekt = new AnswerOptionModel { Answer = "It requires attackers to compromise multiple factors to gain access, greatly reducing the risk" };
            var aMfaBehFel1 = new AnswerOptionModel { Answer = "It eliminates the need for passwords entirely" };
            var aMfaBehFel2 = new AnswerOptionModel { Answer = "It increases login time but has no security benefits" };
            var aMfaBehFel3 = new AnswerOptionModel { Answer = "It only applies to administrative accounts" };

            var aZeroTrustKorrekt = new AnswerOptionModel { Answer = "No user or device is automatically trusted — all access is continuously verified regardless of location" };
            var aZeroTrustFel1 = new AnswerOptionModel { Answer = "Internal network users are automatically trusted without verification" };
            var aZeroTrustFel2 = new AnswerOptionModel { Answer = "A model where all users are given zero permissions by default" };
            var aZeroTrustFel3 = new AnswerOptionModel { Answer = "A system where firewalls handle all authentication" };

            // GDPR extra
            var aRaderingKorrekt = new AnswerOptionModel { Answer = "The right for a person to request that their personal data be deleted under certain circumstances" };
            var aRaderingFel1 = new AnswerOptionModel { Answer = "The obligation for companies to automatically delete data after 5 years" };
            var aRaderingFel2 = new AnswerOptionModel { Answer = "The right to delete other people's data" };
            var aRaderingFel3 = new AnswerOptionModel { Answer = "A technique for securely deleting encrypted files" };

            var aPersonuppgiftsansvarigKorrekt = new AnswerOptionModel { Answer = "The organization or person who determines the purpose and means of processing personal data" };
            var aPersonuppgiftsansvarigFel1 = new AnswerOptionModel { Answer = "A person appointed by authorities to supervise GDPR compliance" };
            var aPersonuppgiftsansvarigFel2 = new AnswerOptionModel { Answer = "A third party that processes personal data on behalf of a company" };
            var aPersonuppgiftsansvarigFel3 = new AnswerOptionModel { Answer = "The person whose personal data is being processed" };

            // NIS2 & ISO 27001 extra
            var aNis2OmfattasKorrekt = new AnswerOptionModel { Answer = "Medium and large organizations in critical sectors such as energy, transport and healthcare" };
            var aNis2OmfattasFel1 = new AnswerOptionModel { Answer = "Only government agencies and public organizations" };
            var aNis2OmfattasFel2 = new AnswerOptionModel { Answer = "All companies with more than 10 employees within the EU" };
            var aNis2OmfattasFel3 = new AnswerOptionModel { Answer = "Only IT companies and technology providers" };

            var aIso27001CertKorrekt = new AnswerOptionModel { Answer = "The organization has implemented and complies with a documented information security management system" };
            var aIso27001CertFel1 = new AnswerOptionModel { Answer = "The organization is exempt from GDPR requirements" };
            var aIso27001CertFel2 = new AnswerOptionModel { Answer = "The organization's IT systems have been approved by the EU Commission" };
            var aIso27001CertFel3 = new AnswerOptionModel { Answer = "The organization is guaranteed to be free from cyberattacks" };

            // Incident Response extra
            var aInneslutningKorrekt = new AnswerOptionModel { Answer = "Limiting the spread of the incident and isolating affected systems to prevent further damage" };
            var aInneslutningFel1 = new AnswerOptionModel { Answer = "Removing all malicious code from affected systems" };
            var aInneslutningFel2 = new AnswerOptionModel { Answer = "Documenting the incident for legal purposes" };
            var aInneslutningFel3 = new AnswerOptionModel { Answer = "Restoring systems to normal operation" };

            var aChainOfCustodyKorrekt = new AnswerOptionModel { Answer = "Documentation of who handled digital evidence, when and how, to ensure its integrity" };
            var aChainOfCustodyFel1 = new AnswerOptionModel { Answer = "A list of all systems affected by an incident" };
            var aChainOfCustodyFel2 = new AnswerOptionModel { Answer = "A method for encrypting digital evidence" };
            var aChainOfCustodyFel3 = new AnswerOptionModel { Answer = "A protocol for communication during incident response" };

            // ── CATEGORIES & SUBCATEGORIES ───────────────────────────────────────

            var catNatverk = new CategoryModel { Name = "Networking", Description = "Core networking concepts including TCP/IP, DNS, firewalls and intrusion detection." };
            var catWebbsak = new CategoryModel { Name = "Web Security", Description = "Security threats and defences for web applications, including OWASP Top 10." };
            var catKrypto = new CategoryModel { Name = "Cryptography", Description = "Encryption methods, certificates and hashing algorithms for secure data transmission." };
            var catMalware = new CategoryModel { Name = "Malware & Attacks", Description = "Types of malicious code, attack vectors and social engineering." };
            var catOS = new CategoryModel { Name = "Operating Systems", Description = "Security features in Linux and Windows, and privilege management." };
            var catLagstiftning = new CategoryModel { Name = "Legislation & Compliance", Description = "Regulations and standards including GDPR, NIS2, ISO 27001 and incident response." };

            var subTCPIP = new SubCategoryModel { Name = "TCP/IP Fundamentals", Description = "The OSI model, TCP/IP protocol, ports and basic network communication.", Order = 1, Category = catNatverk };
            var subDNS = new SubCategoryModel { Name = "DNS & DHCP", Description = "Name resolution, DHCP assignment and related security threats such as DNS poisoning.", Order = 2, Category = catNatverk };
            var subBrandvaggar = new SubCategoryModel { Name = "Firewalls & IDS/IPS", Description = "Firewall types, intrusion detection and prevention, and DMZ configuration.", Order = 3, Category = catNatverk };

            var subOwasp = new SubCategoryModel { Name = "OWASP Top 10", Description = "The ten most common security vulnerabilities in web applications according to OWASP.", Order = 1, Category = catWebbsak };
            var subInjektioner = new SubCategoryModel { Name = "XSS & Injections", Description = "Cross-Site Scripting, SQL injection and other injection attacks against web applications.", Order = 2, Category = catWebbsak };
            var subAutentisering = new SubCategoryModel { Name = "Authentication & Sessions", Description = "Session security, CSRF, JWT and secure authentication in web applications.", Order = 3, Category = catWebbsak };

            var subSymKrypto = new SubCategoryModel { Name = "Symmetric Encryption", Description = "AES, DES and other symmetric algorithms for data encryption.", Order = 1, Category = catKrypto };
            var subAsymKrypto = new SubCategoryModel { Name = "Asymmetric Encryption & PKI", Description = "RSA, certificates, PKI infrastructure and digital signing.", Order = 2, Category = catKrypto };
            var subHashning = new SubCategoryModel { Name = "Hashing", Description = "Hash functions such as SHA and MD5, salting and secure password storage.", Order = 3, Category = catKrypto };

            var subMalwaretyper = new SubCategoryModel { Name = "Malware Types", Description = "Viruses, trojans, ransomware, spyware and other types of malicious software.", Order = 1, Category = catMalware };
            var subAttackmetoder = new SubCategoryModel { Name = "Attack Methods", Description = "DDoS, man-in-the-middle, zero-day exploits and other attack techniques.", Order = 2, Category = catMalware };
            var subSocialEng = new SubCategoryModel { Name = "Social Engineering", Description = "Phishing, spear phishing, vishing and manipulation of people.", Order = 3, Category = catMalware };

            var subLinux = new SubCategoryModel { Name = "Linux Security", Description = "File permissions, sudo, chmod and security features in Linux.", Order = 1, Category = catOS };
            var subWindows = new SubCategoryModel { Name = "Windows Security", Description = "Windows Defender, BitLocker, UAC and built-in security features in Windows.", Order = 2, Category = catOS };
            var subBehorighet = new SubCategoryModel { Name = "Access Management", Description = "RBAC, PAM, authentication, authorization and the principle of least privilege.", Order = 3, Category = catOS };

            var subGdpr = new SubCategoryModel { Name = "GDPR", Description = "The General Data Protection Regulation, personal data and reporting requirements.", Order = 1, Category = catLagstiftning };
            var subNis2 = new SubCategoryModel { Name = "NIS2 & ISO 27001", Description = "The EU Network and Information Security Directive and the ISO standard for information security.", Order = 2, Category = catLagstiftning };
            var subIncident = new SubCategoryModel { Name = "Incident Response", Description = "Handling security incidents, digital forensics and runbooks.", Order = 3, Category = catLagstiftning };

            // ── QUESTIONS ────────────────────────────────────────────────────────

            var qOsiIpLager = new QuestionModel { Question = "Which layer of the OSI model handles IP addressing and routing?", Category = catNatverk, SubCategory = subTCPIP };
            var qHttpsPort = new QuestionModel { Question = "Which port does HTTPS use by default?", Category = catNatverk, SubCategory = subTCPIP };
            var qSynPaket = new QuestionModel { Question = "What is a SYN packet in TCP?", Category = catNatverk, SubCategory = subTCPIP };

            var qDnsVad = new QuestionModel { Question = "What is the primary task of a DNS server?", Category = catNatverk, SubCategory = subDNS };
            var qDnsPort = new QuestionModel { Question = "Which port does DNS normally use?", Category = catNatverk, SubCategory = subDNS };
            var qDnsPoison = new QuestionModel { Question = "What is DNS poisoning (DNS cache poisoning)?", Category = catNatverk, SubCategory = subDNS };

            var qIdsVsIps = new QuestionModel { Question = "What is the key difference between IDS and IPS?", Category = catNatverk, SubCategory = subBrandvaggar };
            var qStatefulFw = new QuestionModel { Question = "What is a firewall called that inspects the state of TCP sessions?", Category = catNatverk, SubCategory = subBrandvaggar };
            var qDmz = new QuestionModel { Question = "What is a DMZ (demilitarized zone) in network security?", Category = catNatverk, SubCategory = subBrandvaggar };

            var qOwaspVad = new QuestionModel { Question = "What does the abbreviation OWASP stand for?", Category = catWebbsak, SubCategory = subOwasp };
            var qOwaspAccess = new QuestionModel { Question = "Which OWASP issue means attackers can access resources they should not have access to?", Category = catWebbsak, SubCategory = subOwasp };
            var qOwaspMisconfig = new QuestionModel { Question = "What is 'Security Misconfiguration' according to OWASP?", Category = catWebbsak, SubCategory = subOwasp };

            var qXssVad = new QuestionModel { Question = "What is Cross-Site Scripting (XSS)?", Category = catWebbsak, SubCategory = subInjektioner };
            var qSqlVad = new QuestionModel { Question = "What is SQL injection?", Category = catWebbsak, SubCategory = subInjektioner };
            var qSqlSkydd = new QuestionModel { Question = "Which technique is most effective for protecting against SQL injection?", Category = catWebbsak, SubCategory = subInjektioner };

            var qMfaVad = new QuestionModel { Question = "What is multi-factor authentication (MFA)?", Category = catWebbsak, SubCategory = subAutentisering };
            var qSessionHijack = new QuestionModel { Question = "What is session hijacking?", Category = catWebbsak, SubCategory = subAutentisering };
            var qCsrf = new QuestionModel { Question = "What is a CSRF attack (Cross-Site Request Forgery)?", Category = catWebbsak, SubCategory = subAutentisering };

            var qSymVad = new QuestionModel { Question = "What characterizes symmetric encryption?", Category = catKrypto, SubCategory = subSymKrypto };
            var qSymExempel = new QuestionModel { Question = "Which is an example of a symmetric encryption algorithm?", Category = catKrypto, SubCategory = subSymKrypto };
            var qAesBetyd = new QuestionModel { Question = "What does AES stand for?", Category = catKrypto, SubCategory = subSymKrypto };

            var qAsymVad = new QuestionModel { Question = "What is asymmetric encryption?", Category = catKrypto, SubCategory = subAsymKrypto };
            var qPrivatNyckel = new QuestionModel { Question = "What is the private key used for in asymmetric encryption?", Category = catKrypto, SubCategory = subAsymKrypto };
            var qCertifikat = new QuestionModel { Question = "What is a digital certificate?", Category = catKrypto, SubCategory = subAsymKrypto };

            var qHashVad = new QuestionModel { Question = "What is a cryptographic hash function?", Category = catKrypto, SubCategory = subHashning };
            var qHashEgenskap = new QuestionModel { Question = "Which property is essential for a cryptographic hash function?", Category = catKrypto, SubCategory = subHashning };
            var qHashExempel = new QuestionModel { Question = "Which is an example of a cryptographic hash algorithm?", Category = catKrypto, SubCategory = subHashning };

            var qRansomVad = new QuestionModel { Question = "What is ransomware?", Category = catMalware, SubCategory = subMalwaretyper };
            var qTrojanVad = new QuestionModel { Question = "What is a Trojan horse (trojan)?", Category = catMalware, SubCategory = subMalwaretyper };
            var qWormVad = new QuestionModel { Question = "What distinguishes a worm from a regular virus?", Category = catMalware, SubCategory = subMalwaretyper };

            var qDdosVad = new QuestionModel { Question = "What is a DDoS attack?", Category = catMalware, SubCategory = subAttackmetoder };
            var qMitmVad = new QuestionModel { Question = "What is a man-in-the-middle attack (MitM)?", Category = catMalware, SubCategory = subAttackmetoder };
            var qZerodayVad = new QuestionModel { Question = "What is a zero-day exploit?", Category = catMalware, SubCategory = subAttackmetoder };

            var qPhishVad = new QuestionModel { Question = "What is phishing?", Category = catMalware, SubCategory = subSocialEng };
            var qSpearVad = new QuestionModel { Question = "What is spear phishing?", Category = catMalware, SubCategory = subSocialEng };
            var qVishingVad = new QuestionModel { Question = "What is vishing?", Category = catMalware, SubCategory = subSocialEng };

            var qChmodVad = new QuestionModel { Question = "What does the chmod command do in Linux?", Category = catOS, SubCategory = subLinux };
            var qLeastPriv = new QuestionModel { Question = "What does the Principle of Least Privilege mean?", Category = catOS, SubCategory = subLinux };
            var qSudoVad = new QuestionModel { Question = "What does the sudo command do in Linux?", Category = catOS, SubCategory = subLinux };

            var qDefenderVad = new QuestionModel { Question = "What is Windows Defender?", Category = catOS, SubCategory = subWindows };
            var qBitlockerVad = new QuestionModel { Question = "What is BitLocker?", Category = catOS, SubCategory = subWindows };
            var qUacVad = new QuestionModel { Question = "What is UAC (User Account Control) in Windows?", Category = catOS, SubCategory = subWindows };

            var qRbacVad = new QuestionModel { Question = "What is RBAC (Role-Based Access Control)?", Category = catOS, SubCategory = subBehorighet };
            var qAutnVsAutz = new QuestionModel { Question = "What is the difference between authentication and authorization?", Category = catOS, SubCategory = subBehorighet };
            var qPamVad = new QuestionModel { Question = "What is a PAM system (Privileged Access Management)?", Category = catOS, SubCategory = subBehorighet };

            var qGdprVad = new QuestionModel { Question = "What does GDPR stand for?", Category = catLagstiftning, SubCategory = subGdpr };
            var qGdpr72h = new QuestionModel { Question = "Within how many hours must a personal data breach be reported according to GDPR?", Category = catLagstiftning, SubCategory = subGdpr };
            var qPersonuppgift = new QuestionModel { Question = "What counts as personal data according to GDPR?", Category = catLagstiftning, SubCategory = subGdpr };

            var qNis2Syfte = new QuestionModel { Question = "What is the purpose of the NIS2 directive?", Category = catLagstiftning, SubCategory = subNis2 };
            var qIso27001Vad = new QuestionModel { Question = "What is ISO 27001?", Category = catLagstiftning, SubCategory = subNis2 };
            var qIsmsVad = new QuestionModel { Question = "What is an ISMS?", Category = catLagstiftning, SubCategory = subNis2 };

            var qIrFaser = new QuestionModel { Question = "What are the main phases of the incident response process?", Category = catLagstiftning, SubCategory = subIncident };
            var qForensik = new QuestionModel { Question = "What is digital forensics in cybersecurity?", Category = catLagstiftning, SubCategory = subIncident };
            var qRunbook = new QuestionModel { Question = "What is a runbook in incident response?", Category = catLagstiftning, SubCategory = subIncident };

            var qUdpVad = new QuestionModel { Question = "What is UDP and how does it differ from TCP?", Category = catNatverk, SubCategory = subTCPIP };
            var qIpv4v6 = new QuestionModel { Question = "What is the main difference between IPv4 and IPv6?", Category = catNatverk, SubCategory = subTCPIP };

            var qDhcpVad = new QuestionModel { Question = "What is DHCP and what is it used for?", Category = catNatverk, SubCategory = subDNS };
            var qDnsApost = new QuestionModel { Question = "What is the difference between an A record and an AAAA record in DNS?", Category = catNatverk, SubCategory = subDNS };

            var qWafVad = new QuestionModel { Question = "What is a WAF (Web Application Firewall)?", Category = catNatverk, SubCategory = subBrandvaggar };
            var qPaketfiltrering = new QuestionModel { Question = "Which OSI layer does a packet-filtering firewall primarily operate on?", Category = catNatverk, SubCategory = subBrandvaggar };

            var qOwaspInjection = new QuestionModel { Question = "What does 'Injection' mean in OWASP Top 10?", Category = catWebbsak, SubCategory = subOwasp };
            var qOwaspInsecureDesign = new QuestionModel { Question = "What is 'Insecure Design' according to OWASP Top 10?", Category = catWebbsak, SubCategory = subOwasp };

            var qXssTyper = new QuestionModel { Question = "What are the three types of XSS attacks?", Category = catWebbsak, SubCategory = subInjektioner };
            var qLdapInjektion = new QuestionModel { Question = "What is LDAP injection?", Category = catWebbsak, SubCategory = subInjektioner };

            var qJwtVad = new QuestionModel { Question = "What is a JWT (JSON Web Token)?", Category = catWebbsak, SubCategory = subAutentisering };
            var qCsrfSkydd = new QuestionModel { Question = "Which technique is most effective for protecting against CSRF attacks?", Category = catWebbsak, SubCategory = subAutentisering };

            var qAesNyckel = new QuestionModel { Question = "What key lengths does AES support and which is recommended?", Category = catKrypto, SubCategory = subSymKrypto };
            var qDesVad = new QuestionModel { Question = "What is DES and why is it no longer considered secure?", Category = catKrypto, SubCategory = subSymKrypto };

            var qRsaVad = new QuestionModel { Question = "What is RSA?", Category = catKrypto, SubCategory = subAsymKrypto };
            var qCaVad = new QuestionModel { Question = "What is a CA (Certificate Authority)?", Category = catKrypto, SubCategory = subAsymKrypto };

            var qSaltingVad = new QuestionModel { Question = "What is 'salting' when storing passwords?", Category = catKrypto, SubCategory = subHashning };
            var qMd5Varfor = new QuestionModel { Question = "Why is MD5 not recommended for security purposes?", Category = catKrypto, SubCategory = subHashning };

            var qSpywareVad = new QuestionModel { Question = "What is spyware?", Category = catMalware, SubCategory = subMalwaretyper };
            var qRootkitVad = new QuestionModel { Question = "What is a rootkit?", Category = catMalware, SubCategory = subMalwaretyper };

            var qBotnatVad = new QuestionModel { Question = "What is a botnet?", Category = catMalware, SubCategory = subAttackmetoder };
            var qBruteForce = new QuestionModel { Question = "What is a brute-force attack?", Category = catMalware, SubCategory = subAttackmetoder };

            var qSmishingVad = new QuestionModel { Question = "What is smishing?", Category = catMalware, SubCategory = subSocialEng };
            var qPretexting = new QuestionModel { Question = "What is pretexting in social engineering?", Category = catMalware, SubCategory = subSocialEng };

            var qChownVad = new QuestionModel { Question = "What does the chown command do in Linux?", Category = catOS, SubCategory = subLinux };
            var qSelinuxVad = new QuestionModel { Question = "What is SELinux?", Category = catOS, SubCategory = subLinux };

            var qEventLogVad = new QuestionModel { Question = "What is Windows Event Log?", Category = catOS, SubCategory = subWindows };
            var qApplockerVad = new QuestionModel { Question = "What is AppLocker in Windows?", Category = catOS, SubCategory = subWindows };

            var qMfaBeh = new QuestionModel { Question = "Why is MFA important for access management?", Category = catOS, SubCategory = subBehorighet };
            var qZeroTrust = new QuestionModel { Question = "What does the Zero Trust security model mean?", Category = catOS, SubCategory = subBehorighet };

            var qGdprRadering = new QuestionModel { Question = "What does the right to erasure ('right to be forgotten') mean under GDPR?", Category = catLagstiftning, SubCategory = subGdpr };
            var qPersonuppgiftsansvarig = new QuestionModel { Question = "What is a Data Controller according to GDPR?", Category = catLagstiftning, SubCategory = subGdpr };

            var qNis2Omfattas = new QuestionModel { Question = "Which organizations are covered by the NIS2 directive?", Category = catLagstiftning, SubCategory = subNis2 };
            var qIso27001Cert = new QuestionModel { Question = "What does ISO 27001 certification mean for an organization?", Category = catLagstiftning, SubCategory = subNis2 };

            var qInneslutning = new QuestionModel { Question = "What is containment in incident response?", Category = catLagstiftning, SubCategory = subIncident };
            var qChainOfCustody = new QuestionModel { Question = "What is chain of custody in digital forensics?", Category = catLagstiftning, SubCategory = subIncident };

            // ── QUESTION ↔ ANSWER OPTIONS ─────────────────────────────────────────

            context.QuestionAnswerOptions.AddRange(

                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aNatverkslager, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aDatalankslager, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aTransportlager, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOsiIpLager, AnswerOption = aSessionslager, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort443, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort80, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort8080, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHttpsPort, AnswerOption = aPort22, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynForklaring, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSynPaket, AnswerOption = aSynFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsVad, AnswerOption = aDnsFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort53, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort80, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort25, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPort, AnswerOption = aPort110, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsPoison, AnswerOption = aDnsPoisonFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIdsVsIps, AnswerOption = aIdsIpsFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qStatefulFw, AnswerOption = aStatefulFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDmz, AnswerOption = aDmzFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspVad, AnswerOption = aOwaspFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspAccess, AnswerOption = aBrokenAccessFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspMisconfig, AnswerOption = aSecMisconfigFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssVad, AnswerOption = aXssFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlVad, AnswerOption = aSqlFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSqlSkydd, AnswerOption = aPreparedFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaVad, AnswerOption = aMfaFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSessionHijack, AnswerOption = aSessionFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrf, AnswerOption = aCsrfFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymVad, AnswerOption = aSymFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSymExempel, AnswerOption = aAesFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesBetyd, AnswerOption = aAesBetydFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAsymVad, AnswerOption = aAsymFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPrivatNyckel, AnswerOption = aPrivatFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCertifikat, AnswerOption = aCertFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashVad, AnswerOption = aHashFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashEgenskap, AnswerOption = aEnvagFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qHashExempel, AnswerOption = aShaFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRansomVad, AnswerOption = aRansomFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qTrojanVad, AnswerOption = aTrojanFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWormVad, AnswerOption = aWormFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDdosVad, AnswerOption = aDdosFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMitmVad, AnswerOption = aMitmFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZerodayVad, AnswerOption = aZerodayFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPhishVad, AnswerOption = aPhishFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpearVad, AnswerOption = aSpearFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qVishingVad, AnswerOption = aVishingFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChmodVad, AnswerOption = aChmodFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLeastPriv, AnswerOption = aLeastPrivFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSudoVad, AnswerOption = aSudoFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDefenderVad, AnswerOption = aDefenderFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBitlockerVad, AnswerOption = aBitlockerFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUacVad, AnswerOption = aUacFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aRbacKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aLeastPrivKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aUacKorrekt, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRbacVad, AnswerOption = aSudoKorrekt, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAutnVsAutz, AnswerOption = aAutnVsAutzFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPamVad, AnswerOption = aPamFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprVad, AnswerOption = aGdprFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdpr72h, AnswerOption = a72hFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgift, AnswerOption = aPersonuppgiftFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Syfte, AnswerOption = aNis2Fel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Vad, AnswerOption = aIso27001Fel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIsmsVad, AnswerOption = aIsmsFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIrFaser, AnswerOption = aIrFaserFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qForensik, AnswerOption = aForensikFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRunbook, AnswerOption = aRunbookFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qUdpVad, AnswerOption = aUdpFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIpv4v6, AnswerOption = aIpv4v6Fel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDhcpVad, AnswerOption = aDhcpFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDnsApost, AnswerOption = aApostFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qWafVad, AnswerOption = aWafFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPaketfiltrering, AnswerOption = aPaketfiltreringFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInjection, AnswerOption = aInjectionFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qOwaspInsecureDesign, AnswerOption = aInsecureDesignFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qXssTyper, AnswerOption = aXssTyperFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qLdapInjektion, AnswerOption = aLdapFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qJwtVad, AnswerOption = aJwtFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCsrfSkydd, AnswerOption = aCsrfSkyddFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qAesNyckel, AnswerOption = aAesNyckelFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qDesVad, AnswerOption = aDesFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRsaVad, AnswerOption = aRsaFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qCaVad, AnswerOption = aCaFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSaltingVad, AnswerOption = aSaltingFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Korrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Fel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Fel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMd5Varfor, AnswerOption = aMd5Fel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSpywareVad, AnswerOption = aSpywareFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qRootkitVad, AnswerOption = aRootkitFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBotnatVad, AnswerOption = aBotnatFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qBruteForce, AnswerOption = aBruteForceFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSmishingVad, AnswerOption = aSmishingFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPretexting, AnswerOption = aPretextingFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChownVad, AnswerOption = aChownFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qSelinuxVad, AnswerOption = aSelinuxFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qEventLogVad, AnswerOption = aEventLogFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qApplockerVad, AnswerOption = aApplockerFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qMfaBeh, AnswerOption = aMfaBehFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qZeroTrust, AnswerOption = aZeroTrustFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qGdprRadering, AnswerOption = aRaderingFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qPersonuppgiftsansvarig, AnswerOption = aPersonuppgiftsansvarigFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qNis2Omfattas, AnswerOption = aNis2OmfattasFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qIso27001Cert, AnswerOption = aIso27001CertFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qInneslutning, AnswerOption = aInneslutningFel3, IsCorrect = false },

                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyKorrekt, IsCorrect = true },
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyFel1, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyFel2, IsCorrect = false },
                new QuestionAnswerOptionModel { Question = qChainOfCustody, AnswerOption = aChainOfCustodyFel3, IsCorrect = false }
            );

            await context.SaveChangesAsync();
        }
    }
}
