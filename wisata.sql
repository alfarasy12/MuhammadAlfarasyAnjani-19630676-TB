-- MariaDB dump 10.19  Distrib 10.4.22-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: wisata
-- ------------------------------------------------------
-- Server version	10.4.22-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin` (
  `IDADMIN` int(10) NOT NULL,
  `NAMA` varchar(100) DEFAULT NULL,
  `STATUS` varchar(100) DEFAULT NULL,
  `PASSWORD` char(50) DEFAULT NULL,
  PRIMARY KEY (`IDADMIN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES (1001,'HASBI','ADMIN','HASBI');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pengelola`
--

DROP TABLE IF EXISTS `pengelola`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pengelola` (
  `IDPENGELOLA` int(10) NOT NULL,
  `NAMA` varchar(100) DEFAULT NULL,
  `ALAMAT` varchar(100) DEFAULT NULL,
  `NIP` char(50) DEFAULT NULL,
  `STATUS` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IDPENGELOLA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pengelola`
--

LOCK TABLES `pengelola` WRITE;
/*!40000 ALTER TABLE `pengelola` DISABLE KEYS */;
INSERT INTO `pengelola` VALUES (1001,'HASBI ARIFIN','MARABAHAN','19630930','PENGELOLA'),(1002,'ADIT','BANJARMASIN','19630931','PENGELOLA');
/*!40000 ALTER TABLE `pengelola` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiket`
--

DROP TABLE IF EXISTS `tiket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tiket` (
  `IDTIKET` char(30) NOT NULL,
  `NPELANGGAN` varchar(100) DEFAULT NULL,
  `JPELANGGAN` int(10) DEFAULT NULL,
  `NIK` char(40) DEFAULT NULL,
  `ALAMAT` varchar(100) DEFAULT NULL,
  `WISTA` varchar(100) DEFAULT NULL,
  `HTIKET` int(40) DEFAULT NULL,
  `JUMLAH` int(40) DEFAULT NULL,
  `BAYAR` int(40) DEFAULT NULL,
  `DIBAYAR` int(40) DEFAULT NULL,
  `KEMBALI` int(40) DEFAULT NULL,
  PRIMARY KEY (`IDTIKET`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiket`
--

LOCK TABLES `tiket` WRITE;
/*!40000 ALTER TABLE `tiket` DISABLE KEYS */;
INSERT INTO `tiket` VALUES ('TK001','HASBI ARIFIN',2,'6203042212000001','JL HANDEL BARU RT.015 ROHAM RAYA','AIR TERJUN BAJUIN',10000,20000,20000,50000,30000),('TK002','HUSAINI',2,'6203062212000002','BANJARMASIN SELATAN','TAHURA SULTAN ADAM',15000,30000,30000,100000,70000),('TK003','H',4,'575879','FJFJGFL','AIR TERJUN BAJUIN',10000,40000,40000,50000,10000);
/*!40000 ALTER TABLE `tiket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wisata`
--

DROP TABLE IF EXISTS `wisata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wisata` (
  `IDWISATA` int(10) NOT NULL DEFAULT 0,
  `TGLINPUT` date DEFAULT NULL,
  `NAMA` varchar(100) DEFAULT NULL,
  `KETERANGAN` char(255) DEFAULT NULL,
  `JAMBUKA` char(20) DEFAULT NULL,
  `JAMTUTUP` char(20) DEFAULT NULL,
  `HTIKET` int(40) DEFAULT NULL,
  `ASURANSI` int(40) DEFAULT NULL,
  `MAXPENGUNJUNG` int(40) DEFAULT NULL,
  PRIMARY KEY (`IDWISATA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wisata`
--

LOCK TABLES `wisata` WRITE;
/*!40000 ALTER TABLE `wisata` DISABLE KEYS */;
INSERT INTO `wisata` VALUES (1001,'2021-12-29','TAHURA SULTAN ADAM','BUKA','07:00','18:00',15000,10000000,40),(1002,'2021-12-29','AIR TERJUN BAJUIN','BUKA','07:00','18:00',10000,10000000,35);
/*!40000 ALTER TABLE `wisata` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-29 23:34:27
