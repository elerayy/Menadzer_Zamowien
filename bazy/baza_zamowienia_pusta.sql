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

--
-- Table structure for table `osoby`
--

DROP TABLE IF EXISTS `osoby`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoby` (
  `username` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `imie` varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL,
  `nazwisko` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `adres` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `nr_tel` char(12) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoby`
--

LOCK TABLES `osoby` WRITE;
/*!40000 ALTER TABLE `osoby` DISABLE KEYS */;
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
  `rodzaj` enum('kurier','paczkomat','poczta','inne') COLLATE utf8_unicode_ci DEFAULT NULL,
  `firma` varchar(40) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id_p`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `przewoznik`
--

LOCK TABLES `przewoznik` WRITE;
/*!40000 ALTER TABLE `przewoznik` DISABLE KEYS */;
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
  `nazwa` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `strona_www` varchar(40) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id_sklepu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sklep`
--

LOCK TABLES `sklep` WRITE;
/*!40000 ALTER TABLE `sklep` DISABLE KEYS */;
/*!40000 ALTER TABLE `sklep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zamowienie`
--

DROP TABLE IF EXISTS `zamowienie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zamowienie` (
  `id` tinyint NOT NULL AUTO_INCREMENT,
  `co` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `koszt` float DEFAULT NULL,
  `data_zam` date DEFAULT NULL,
  `data_est` date DEFAULT NULL,
  `status` enum('w trakcie','odebrane') COLLATE utf8_unicode_ci DEFAULT NULL,
  `zwrot` enum('tak','nie') COLLATE utf8_unicode_ci DEFAULT NULL,
  `username` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `id_sklepu` tinyint NOT NULL,
  `id_p` tinyint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `username` (`username`),
  KEY `id_sklepu` (`id_sklepu`),
  KEY `id_p` (`id_p`),
  CONSTRAINT `zamowienie_ibfk_1` FOREIGN KEY (`username`) REFERENCES `osoby` (`username`),
  CONSTRAINT `zamowienie_ibfk_2` FOREIGN KEY (`id_sklepu`) REFERENCES `sklep` (`id_sklepu`),
  CONSTRAINT `zamowienie_ibfk_3` FOREIGN KEY (`id_p`) REFERENCES `przewoznik` (`id_p`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zamowienie`
--

LOCK TABLES `zamowienie` WRITE;
/*!40000 ALTER TABLE `zamowienie` DISABLE KEYS */;
/*!40000 ALTER TABLE `zamowienie` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-07 21:08:22
