-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: baza_zamowienia
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

drop database if exists `baza_zamowienia`;
create database `baza_zamowienia`;
use `baza_zamowienia`;

drop user admin@localhost;
create user 'admin'@'localhost' identified by 'admin123';
grant all on baza_zamowienia.* to admin@localhost;
flush privileges;

drop user nie_admin@localhost;
create user 'nie_admin'@'localhost' identified by 'niejestemadminem';
grant select on baza_zamowienia.* to nie_admin@localhost;
flush privileges;

--
-- Temporary view structure for view `lista_przewoznika`
--

DROP TABLE IF EXISTS `lista_przewoznika`;
/*!50001 DROP VIEW IF EXISTS `lista_przewoznika`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `lista_przewoznika` AS SELECT 
 1 AS `firma_przewoznika`,
 1 AS `typ_przewoznika`,
 1 AS `sklep`,
 1 AS `adres`,
 1 AS `nr_tel`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `lista_sklepu`
--

DROP TABLE IF EXISTS `lista_sklepu`;
/*!50001 DROP VIEW IF EXISTS `lista_sklepu`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `lista_sklepu` AS SELECT 
 1 AS `sklep`,
 1 AS `co`,
 1 AS `nazwisko`,
 1 AS `imie`,
 1 AS `adres`,
 1 AS `nr_tel`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `osoby`
--

DROP TABLE IF EXISTS `osoby`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoby` (
  `username` varchar(15) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `imie` varchar(15) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `nazwisko` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `adres` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `nr_tel` char(12) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoby`
--

LOCK TABLES `osoby` WRITE;
/*!40000 ALTER TABLE `osoby` DISABLE KEYS */;
INSERT INTO `osoby` VALUES ('adarolada','Ada','Wiewiórka','ul.Leśna 12C, 44-100 Gliwice','+48604948413'),('ali892','Alicja','Lis','ul.Tartaków 100, 43-300 Bielsko-Biała','+48666866840'),('kinia123','Kinga','Sarna','ul.Rzeczna 66, 14-300 Morąg','+48123456789');
/*!40000 ALTER TABLE `osoby` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `przewoznik`
--

DROP TABLE IF EXISTS `przewoznik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `przewoznik` (
  `id_p` tinyint NOT NULL AUTO_INCREMENT,
  `rodzaj` enum('kurier','paczkomat','poczta','inne') CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `firma` varchar(40) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id_p`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `przewoznik`
--

LOCK TABLES `przewoznik` WRITE;
/*!40000 ALTER TABLE `przewoznik` DISABLE KEYS */;
INSERT INTO `przewoznik` VALUES (1,'kurier','DPD'),(2,'kurier','DHL'),(3,'kurier','UPS'),(4,'kurier','InPost'),(5,'paczkomat','InPost'),(6,'poczta','Poczta Polska'),(7,'inne','RUCH'),(8,'inne','Żabka'),(9,'inne','Orlen'),(10,'inne','odbiór osobisty');
/*!40000 ALTER TABLE `przewoznik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sklep`
--

DROP TABLE IF EXISTS `sklep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sklep` (
  `id_sklepu` tinyint NOT NULL AUTO_INCREMENT,
  `nazwa` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `strona_www` varchar(40) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id_sklepu`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sklep`
--

LOCK TABLES `sklep` WRITE;
/*!40000 ALTER TABLE `sklep` DISABLE KEYS */;
INSERT INTO `sklep` VALUES (1,'Sinsay','www.sinsay.com'),(2,'Carrefour','www.carrefour.pl'),(3,'CCC','www.ccc.eu'),(4,'H&M','www2.hm.com'),(5,'Empik','www.empik.com'),(6,'Komputronik','www.komputronik.pl'),(7,'Castorama','www.castorama.pl'),(8,'Ikea','www.ikea.com');
/*!40000 ALTER TABLE `sklep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `szczegolowe`
--

DROP TABLE IF EXISTS `szczegolowe`;
/*!50001 DROP VIEW IF EXISTS `szczegolowe`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `szczegolowe` AS SELECT 
 1 AS `username`,
 1 AS `co`,
 1 AS `koszt`,
 1 AS `data_zam`,
 1 AS `data_est`,
 1 AS `status`,
 1 AS `sklep`,
 1 AS `firma_przewoznika`,
 1 AS `typ_przewoznika`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `zamowienie`
--

DROP TABLE IF EXISTS `zamowienie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zamowienie` (
  `id` tinyint NOT NULL AUTO_INCREMENT,
  `co` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `koszt` float DEFAULT NULL,
  `data_zam` date DEFAULT NULL,
  `data_est` date DEFAULT NULL,
  `status` enum('w trakcie','odebrane') CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `zwrot` enum('tak','nie') CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `username` varchar(15) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `id_sklepu` tinyint NOT NULL,
  `id_p` tinyint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `username` (`username`),
  KEY `id_sklepu` (`id_sklepu`),
  KEY `id_p` (`id_p`),
  CONSTRAINT `zamowienie_ibfk_1` FOREIGN KEY (`username`) REFERENCES `osoby` (`username`),
  CONSTRAINT `zamowienie_ibfk_2` FOREIGN KEY (`id_sklepu`) REFERENCES `sklep` (`id_sklepu`),
  CONSTRAINT `zamowienie_ibfk_3` FOREIGN KEY (`id_p`) REFERENCES `przewoznik` (`id_p`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zamowienie`
--

LOCK TABLES `zamowienie` WRITE;
/*!40000 ALTER TABLE `zamowienie` DISABLE KEYS */;
INSERT INTO `zamowienie` VALUES (1,'Shorty biker',29.99,'2021-07-16','2021-07-19','odebrane','nie','adarolada',1,10),(2,'Wieszaki',23.99,'2021-07-12','2021-07-15','odebrane','nie','adarolada',8,5),(3,'Klapki',59.99,'2021-07-03','2021-07-08','odebrane','tak','ali892',3,8),(4,'Książka',31.31,'2021-07-19','2021-07-25','w trakcie','nie','kinia123',5,2);
/*!40000 ALTER TABLE `zamowienie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `zestawienie`
--

DROP TABLE IF EXISTS `zestawienie`;
/*!50001 DROP VIEW IF EXISTS `zestawienie`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `zestawienie` AS SELECT 
 1 AS `username`,
 1 AS `co`,
 1 AS `koszt`,
 1 AS `data_zam`,
 1 AS `data_est`,
 1 AS `status`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `lista_przewoznika`
--

/*!50001 DROP VIEW IF EXISTS `lista_przewoznika`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `lista_przewoznika` (`firma_przewoznika`,`typ_przewoznika`,`sklep`,`adres`,`nr_tel`) AS select `p`.`firma` AS `firma`,`p`.`rodzaj` AS `rodzaj`,`s`.`nazwa` AS `nazwa`,`o`.`adres` AS `adres`,`o`.`nr_tel` AS `nr_tel` from (((`przewoznik` `p` join `sklep` `s`) join `zamowienie` `z`) join `osoby` `o`) where ((`z`.`id_sklepu` = `s`.`id_sklepu`) and (`z`.`id_p` = `p`.`id_p`) and (`o`.`username` = `z`.`username`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `lista_sklepu`
--

/*!50001 DROP VIEW IF EXISTS `lista_sklepu`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `lista_sklepu` (`sklep`,`co`,`nazwisko`,`imie`,`adres`,`nr_tel`) AS select `s`.`nazwa` AS `nazwa`,`z`.`co` AS `co`,`o`.`nazwisko` AS `nazwisko`,`o`.`imie` AS `imie`,`o`.`adres` AS `adres`,`o`.`nr_tel` AS `nr_tel` from ((`zamowienie` `z` join `osoby` `o`) join `sklep` `s`) where ((`o`.`username` = `z`.`username`) and (`z`.`id_sklepu` = `s`.`id_sklepu`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `szczegolowe`
--

/*!50001 DROP VIEW IF EXISTS `szczegolowe`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `szczegolowe` (`username`,`co`,`koszt`,`data_zam`,`data_est`,`status`,`sklep`,`firma_przewoznika`,`typ_przewoznika`) AS select `z`.`username` AS `username`,`z`.`co` AS `co`,`z`.`koszt` AS `koszt`,`z`.`data_zam` AS `data_zam`,`z`.`data_est` AS `data_est`,`z`.`status` AS `status`,`s`.`nazwa` AS `nazwa`,`p`.`firma` AS `firma`,`p`.`rodzaj` AS `rodzaj` from ((`zamowienie` `z` join `sklep` `s`) join `przewoznik` `p`) where ((`z`.`id_sklepu` = `s`.`id_sklepu`) and (`z`.`id_p` = `p`.`id_p`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `zestawienie`
--

/*!50001 DROP VIEW IF EXISTS `zestawienie`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `zestawienie` (`username`,`co`,`koszt`,`data_zam`,`data_est`,`status`) AS select `zamowienie`.`username` AS `username`,`zamowienie`.`co` AS `co`,`zamowienie`.`koszt` AS `koszt`,`zamowienie`.`data_zam` AS `data_zam`,`zamowienie`.`data_est` AS `data_est`,`zamowienie`.`status` AS `status` from `zamowienie` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-24 16:58:51
